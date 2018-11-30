using EditorModel.Figures;
using EditorModel.Geometry;
using EditorModel.Selections;
using SimpleEditor.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SimpleEditor.Controllers
{
    public enum EditorMode
    {
        Select,
        FrameSelect,
        ChangeGeometry,
        Drag,
        CreateFigure,
        Skew,
        Verticies
    }

    /// <summary>
    /// Обрабатывает движения мышки, строит маркеры, управляет выделением,
    /// выполняет преобразования над фигурами
    /// </summary>
    public class SelectionController
    {
        private readonly Selection _selection;
        private readonly List<Marker> _markers;
        private readonly Layer _layer;

        public Func<Figure> CreateFigureRequest;

        public SelectionController(Layer layer)
        {
            _selection = new Selection();
            _markers = new List<Marker>();
            _layer = layer;
        }

        /// <summary>
        /// Текущий слой
        /// </summary>
        public Layer CurrentLayer { get; set; }

        /// <summary>
        /// Выделенные фигуры
        /// </summary>
        public Selection Selection { get { return _selection; } }

        /// <summary>
        /// Маркеры
        /// </summary>
        public List<Marker> Markers { get { return _markers; } }

        /// <summary>
        /// Изменилась выделенная фигура/фигуры
        /// </summary>
        public event Action SelectedFigureChanged = delegate { };

        /// <summary>
        /// Выделенная фигура/фигуры начинают/продолжают трансформироваться
        /// </summary>
        public event Action SelectedTransformChanging = delegate { };

        /// <summary>
        /// Трансформировалась выделенная фигура/фигуры 
        /// </summary>
        public event Action SelectedTransformChanged = delegate { };

        /// <summary>
        /// Изменилась рамка выделения
        /// </summary>
        public event Action<Rectangle> SelectedRangeChanging = delegate { };

        /// <summary>
        /// Изменился режим работы редактора
        /// </summary>
        public event Action<EditorMode> EditorModeChanged = delegate { };

        /// <summary>
        /// Слой будет изменён 
        /// </summary>
        public event Action LayerStartChanging = delegate { };

        /// <summary>
        /// Слой был изменён 
        /// </summary>
        public event Action LayerChanged = delegate { };

        private bool _wasMouseMoving;
        private bool _wasVertexMoving;
        private bool _isMouseDown;
        private Point _firstMouseDown;
        private Marker _movedMarker;

        private EditorMode _editorMode = EditorMode.Select;
        private EditorMode _lastMode = EditorMode.Select;

        /// <summary>
        /// Режим работы редактора фигур
        /// </summary>
        public EditorMode EditorMode
        {
            get { return _editorMode; }
            set
            {
                // прошлый режим запоминаем, если был любой базовый режим
                if (_editorMode == EditorMode.Select ||
                    _editorMode == EditorMode.Skew ||
                    _editorMode == EditorMode.Verticies)
                {
                    _lastMode = _editorMode;
                }
                _editorMode = value;
                // запрещаем рисовать рамку вокруг фигур, когда изменяем вершины
                _selection.IsFrameVisible = _editorMode != EditorMode.Verticies && (_editorMode != EditorMode.ChangeGeometry || _lastMode != EditorMode.Verticies);
                // если переключились в любой базовый режим
                if (_editorMode == EditorMode.Select ||
                    _editorMode == EditorMode.Skew ||
                    _editorMode == EditorMode.Verticies)
                {
                    // то строим маркеры
                    BuildMarkers();
                    UpdateMarkerPositions();                    
                }
                OnEditorModeChanged(EditorMode);
            }
        }

        /// <summary>
        /// Действия по двойному клику на фигурах
        /// Обычно, это действие по умолчанию
        /// </summary>
        /// <param name="location"></param>
        /// <param name="modifierKeys"></param>
        public void OnDblClick(Point location, Keys modifierKeys)
        {
            Figure fig;
            if ((EditorMode != EditorMode.Select && 
                 EditorMode != EditorMode.Skew && 
                 EditorMode != EditorMode.Verticies) ||
                !_selection.FindFigureAt(_layer, location, out fig)) return;
            // фигура найдена.
            var textGeometry = fig.Geometry as TextGeometry;
            if (textGeometry != null)
            {
                    
            }
        }

        /// <summary>
        /// Обработчик нажатия левой кнопки мышки
        /// </summary>
        /// <param name="point">Координаты курсора</param>
        /// <param name="modifierKeys">Какие клавиши были ещё нажаты в этот момент</param>
        public void OnMouseDown(Point point, Keys modifierKeys)
        {
            _wasMouseMoving = false;
            _wasVertexMoving = false;
            _isMouseDown = true;
            // запоминаем точку нажатия мышкой
            _firstMouseDown = point;

            if (EditorMode != EditorMode.Select &&
                EditorMode != EditorMode.Skew &&
                EditorMode != EditorMode.Verticies)
                Clear();   // очищаем список выбранных

            //перебираем фигуры, выделяем/снимаем выделение
            FindMarkerAt(point, out _movedMarker);
            if (_movedMarker == null)   // маркера под курсором не встретилось...
            {
                Figure fig;
                if ((EditorMode == EditorMode.Select ||
                     EditorMode == EditorMode.Skew || 
                     EditorMode == EditorMode.Verticies) &&
                    _selection.FindFigureAt(_layer, point, out fig)) // попробуем найти фигуру...
                {
                    // фигура найдена.
                    // если этой фигуры не было в списке
                    if (!_selection.Contains(fig))
                    {
                        // если не нажата управляющая клавиша Ctrl
                        // в режиме изменения вершим может быть выбрана только одна фигура
                        if (!modifierKeys.HasFlag(Keys.Control))
                            _selection.Clear(); // очистим список выбранных
                                                // то добавим её в список
                        _selection.Add(fig);
                        OnSelectedFigureChanged();
                    }
                    else 
                    {
                        if (EditorMode == EditorMode.Verticies)
                        {
                            OnLayerStartChanging();
                            // вставка новой вершины при нажатом Ctrl
                            _selection.InsertVertex(fig, point);
                            OnLayerChanged();
                        }
                        // при нажатой клавише Ctrl удаляем эту фигуру из списка
                        // если она не последняя
                        else 
                        if (_selection.Count > 1 && modifierKeys.HasFlag(Keys.Control))
                        {
                            _selection.Remove(fig);
                            OnSelectedFigureChanged();
                        }
                    }
                    //строим маркеры
                    BuildMarkers();
                    UpdateMarkerPositions();
                    // что-то выбрано, тогда "тянем"
                    if (_selection.Count > 0)
                        EditorMode = EditorMode.Drag;
                }
                else
                {
                    // в точке мышки ничего нет
                    Clear(); // очищаем список выбранных
                    OnSelectedFigureChanged();

                    if (CreateFigureRequest != null)
                    {
                        //создаем новую фигуру
                        EditorMode = EditorMode.CreateFigure;
                        OnLayerStartChanging();
                        CreateFigure(point);
                    }
                    else
                    {
                        // создаём "резиновую" рамку
                        new FigureBuilder().BuildFrameGeometry(_selection, point);
                        EditorMode = EditorMode.FrameSelect;
                    }
                }
            }
            else
            {
                if (EditorMode == EditorMode.Verticies)
                {
                    if (modifierKeys.HasFlag(Keys.Control))
                    {
                        OnLayerStartChanging();
                        _selection.RemoveVertex(((VertexMarker) _movedMarker).Owner, ((VertexMarker) _movedMarker).Index);
                        OnLayerChanged();
                    }
                }
                else
                    EditorMode = EditorMode.ChangeGeometry;
            }
        }

        /// <summary>
        /// Создаём новую фигуру
        /// </summary>
        /// <param name="point">Позиция мышки</param>
        private void CreateFigure(Point point)
        {
            //создаем новую фигуру
            var newFig = CreateFigureRequest();
            if (newFig != null)
            {
                // сразу смещаем на половину размера, чтобы левый верхний угол был в точке мышки
                newFig.Transform.Matrix.Translate(point.X + 0.5f, point.Y + 0.5f);
                _layer.Figures.Add(newFig);
                _selection.Add(newFig);
                CreateFigureRequest = null;
                OnSelectedFigureChanged();
            }
        }

        /// <summary>
        /// Обработчик перемещения мышки при нажатой левой кнопке мышки 
        /// </summary>
        /// <param name="point">Координаты курсора</param>
        /// <param name="modifierKeys">Какие клавиши были ещё нажаты в этот момент</param>
        public void OnMouseMove(Point point, Keys modifierKeys)
        {
            if (!_isMouseDown) return;
            _wasMouseMoving = true;

            // если выбран маркер
            if (_movedMarker != null)
            {
                // вызываем метод маркера для выполения действия
                OnMarkerMoved(_movedMarker, point);
                OnSelectedTransformChanging();
            }
            // выбран не маркер
            else
            {
                switch (EditorMode)
                {
                    case EditorMode.FrameSelect:
                        var frameGeometry = _selection.Geometry as FrameGeometry;
                        if (frameGeometry != null)
                            frameGeometry.EndPoint = point;
                        break;

                    case EditorMode.CreateFigure:
                        var startPoint = _firstMouseDown;
                        var scale = new PointF(point.X - startPoint.X, point.Y - startPoint.Y);
                        if (Math.Abs(scale.X) < Helper.EPSILON) scale.X = Helper.EPSILON;
                        if (Math.Abs(scale.Y) < Helper.EPSILON) scale.Y = Helper.EPSILON;
                        _selection.Scale(scale.X, scale.Y, startPoint);
                        OnSelectedTransformChanging();
                        break;

                    default:
                        // показываем, как будет перемещаться список выбранных фигур
                        var mouseOffset = new Point(point.X - _firstMouseDown.X, point.Y - _firstMouseDown.Y);
                        _selection.Translate(mouseOffset.X, mouseOffset.Y);
                        OnSelectedTransformChanging();
                        break;
                }
            }
            OnSelectedRangeChanging(Rectangle.Ceiling(_selection.GetTransformedPath().Path.GetBounds()));
        }

        /// <summary>
        /// Обработчик отпускания левой кнопки мышки
        /// </summary>
        /// <param name="point">Координаты курсора</param>
        /// <param name="modifierKeys">Какие клавиши были ещё нажаты в этот момент</param>
        public void OnMouseUp(Point point, Keys modifierKeys)
        {
            if (_isMouseDown)
            {
                switch (EditorMode)
                {
                    // выбор рамкой
                    case EditorMode.FrameSelect:
                        // добавляем все фигуры, которые оказались охваченными прямоугольником выбора
                        // в список выбранных фигур
                        var rect = _selection.GetTransformedPath().Path.GetBounds();
                        foreach (var fig in _layer.Figures.Where(fig => 
                            rect.Contains(Rectangle.Ceiling(fig.GetTransformedPath().Path.GetBounds()))))
                            _selection.Add(fig);
                        // если ничего не выбралось, то вызываем метод PushTransformToSelectedFigures(),
                        // чтобы убрать остающуюся рамку выбора
                        if (_selection.Count == 0)
                            _selection.PushTransformToSelectedFigures();
                        //
                        OnSelectedFigureChanged();
                        break;
                    // создание предопределённых фигур
                    case EditorMode.CreateFigure:
                        _selection.PushTransformToSelectedFigures();
                        OnLayerChanged();
                        break;
                    case EditorMode.Verticies:
                        if (_wasVertexMoving)
                        {
                            OnLayerChanged();
                            _wasVertexMoving = false;
                        }
                        _isMouseDown = false;
                        return;
                        break;
                    default:
                        // фиксация перемещения фигур
                        if (!_selection.Transform.Matrix.IsIdentity)
                        {
                            OnLayerStartChanging();
                            _selection.PushTransformToSelectedFigures();
                            OnLayerChanged();
                        }
                        break;
                }

                if (_wasMouseMoving)
                {
                    _wasMouseMoving = false;
                    OnSelectedTransformChanged();
                }
            }

            //строим маркеры
            BuildMarkers();
            UpdateMarkerPositions();

            // возврат в текущий режим
            EditorMode = _lastMode;

            _isMouseDown = false;
        }

        /// <summary>
        /// Отражение выбранных фигур по горизонтали
        /// </summary>
        public void FlipX()
        {
            OnLayerStartChanging();
            _selection.FlipX();
            _selection.PushTransformToSelectedFigures();
            OnLayerChanged();

            //строим маркеры
            BuildMarkers();
            UpdateMarkerPositions();
        }

        /// <summary>
        /// Отражение выбранных фигур по вертикали
        /// </summary>
        public void FlipY()
        {
            OnLayerStartChanging();
            _selection.FlipY();
            _selection.PushTransformToSelectedFigures();
            OnLayerChanged();

            //строим маркеры
            BuildMarkers();
            UpdateMarkerPositions();
        }

        /// <summary>
        /// Поворот на четверть по часовой стрелке
        /// </summary>
        public void Rotate90Cw()
        {
            OnLayerStartChanging();
            _selection.Rotate90Cw();
            _selection.PushTransformToSelectedFigures();
            OnLayerChanged();

            //строим маркеры
            BuildMarkers();
            UpdateMarkerPositions();
        }

        /// <summary>
        /// Поворот на четверть против часовой стрелки
        /// </summary>
        public void Rotate90Ccw()
        {
            OnLayerStartChanging();
            _selection.Rotate90Ccw();
            _selection.PushTransformToSelectedFigures();
            OnLayerChanged();

            //строим маркеры
            BuildMarkers();
            UpdateMarkerPositions();
        }

        /// <summary>
        /// Поворот на 180 градусов
        /// </summary>
        public void Rotate180()
        {
            OnLayerStartChanging();
            _selection.Rotate180();
            _selection.PushTransformToSelectedFigures();
            OnLayerChanged();

            //строим маркеры
            BuildMarkers();
            UpdateMarkerPositions();
        }

        /// <summary>
        /// Очистить список выбранных фигур
        /// </summary>
        public void Clear()
        {
            _markers.Clear();
            _selection.Clear();
            OnSelectedFigureChanged();
        }

        #region Извещатели событий

        /// <summary>
        /// Вызываем привязанный к событию метод при выборе фигур
        /// </summary>
        private void OnSelectedFigureChanged()
        {
            SelectedFigureChanged();
        }

        /// <summary>
        /// Вызываем привязанный к событию метод в процессе изменения фигур
        /// </summary>
        private void OnSelectedTransformChanging()
        {
            SelectedTransformChanging();
        }

        /// <summary>
        /// Вызываем привязанный к событию метод в конце изменения фигур
        /// </summary>
        private void OnSelectedTransformChanged()
        {
            SelectedTransformChanged();
        }

        /// <summary>
        /// Вызываем привязанный к событию метод при изменении рамки выбора
        /// </summary>
        /// <param name="rect"></param>
        private void OnSelectedRangeChanging(Rectangle rect)
        {
            SelectedRangeChanging(rect);
        }

        /// <summary>
        /// Вызываем привязанный к событию метод при изменении режима редактора
        /// </summary>
        /// <param name="mode"></param>
        private void OnEditorModeChanged(EditorMode mode)
        {
            EditorModeChanged(mode);
        }

        /// <summary>
        /// Вызываем привязанный к событию метод перед изменением слоя
        /// </summary>
        private void OnLayerStartChanging()
        {
            LayerStartChanging();
        }

        /// <summary>
        /// Вызываем привязанный к событию метод после изменения слоя
        /// </summary>
        private void OnLayerChanged()
        {
            LayerChanged();
        }

        #endregion Извещатели событий

        #region Все методы для работы с маркерами

        /// <summary>
        /// Ищем маркер в данной точке
        /// </summary>
        /// <param name="point">Положение курсора</param>
        /// <param name="marker">Найденный маркер или null</param>
        /// <returns></returns>
        private bool FindMarkerAt(Point point, out Marker marker)
        {
            marker = null;
            var found = false;
            // просматриваем маркеры с конца списка
            for (var i = Markers.Count - 1; i >= 0; i--)
            {
                var fig = Markers[i];
                var path = fig.GetTransformedPath();
                if (!path.Path.IsVisible(point)) continue;
                marker = fig;
                found = true;
                break;
            }
            return found;
        }

        /// <summary>
        /// Создание маркера
        /// </summary>
        /// <param name="type">Тип маркера</param>
        /// <param name="posX">Нормированная координата маркера по горизонтали</param>
        /// <param name="posY">Нормированная координата маркера по вертикали</param>
        /// <param name="cursor">Курсор на маркере</param>
        /// <param name="anchorX">Нормированная координата якоря по горизонтали</param>
        /// <param name="anchorY">Нормированная координата якоря по вертикали</param>
        /// <param name="offsetX">Смещение координаты якоря по горизонтали </param>
        /// <param name="offsetY">Смещение координаты якоря по вертикали</param>
        /// <returns></returns>
        private Marker CreateMarker(MarkerType type, float posX, float posY, UserCursor cursor,
                                    float anchorX, float anchorY, float offsetX = 0, float offsetY = 0)
        {
            var normPoint = new PointF(posX, posY);
            var anchPoint = new PointF(anchorX, anchorY);
            return new Marker
            {
                MarkerType = type,
                Cursor = CursorFactory.GetCursor(cursor),
                Position = _selection.ToWorldCoordinates(normPoint).Add(new PointF(offsetX, offsetY)),
                AnchorPosition = _selection.ToWorldCoordinates(anchPoint)
            };
        }

        //private VertexMarker CreateVertexMarker(float posX, float posY)
        //{
        //    return new VertexMarker
        //    {
        //        MarkerType = MarkerType.Vertex,
        //        Cursor = CursorFactory.GetCursor(UserCursor.MoveAll),
        //        Position = _selection.ToWorldCoordinates(new PointF(posX, posY))
        //    };
        //}
/*
                            foreach (var vertexMarker in from pt in path.Path.PathPoints 
                                        let normX = (pt.X - bounds.X) / bounds.Width 
                                        let normY = (pt.Y - bounds.Y) / bounds.Height 
                                        select CreateMarker(MarkerType.Vertex, normX, normY, UserCursor.MoveAll, 0, 0))
                            {
                                vertexMarker.Index = n++;
                                vertexMarker.Owner = fig;
 */

        /// <summary>
        /// Метод (действие) при перемещении любого маркера
        /// </summary>
        /// <param name="marker">Маркер, который перемещаем</param>
        /// <param name="mousePos">Позиция мышки на новом месте</param>
        private void OnMarkerMoved(Marker marker, Point mousePos)
        {
            // получаем коэффициент масштабирования, используя позицию маркера в мировых "координатах",
            // позицию якоря в мировых "координатах" и позицию курсора мышки
            var scale = Helper.GetScale(marker.Position, marker.AnchorPosition, mousePos);
            // в зависимости от типа маркера вызываем метод Scale с различными параметрами 
            switch (marker.MarkerType)
            {
                case MarkerType.SizeX:
                    _selection.Scale(scale, 1, marker.AnchorPosition);
                    break;
                case MarkerType.SizeY:
                    _selection.Scale(1, scale, marker.AnchorPosition);
                    break;
                case MarkerType.SkewX:
                    var dx = (marker.Position.X - mousePos.X)/(marker.AnchorPosition.Y - marker.Position.Y);
                    _selection.Skew(dx, 0, marker.AnchorPosition);
                    break;
                case MarkerType.SkewY:
                    var dy = (marker.Position.Y - mousePos.Y)/(marker.AnchorPosition.X - marker.Position.X);
                    _selection.Skew(0, dy, marker.AnchorPosition);
                    break;
                case MarkerType.Scale:
                    _selection.Scale(scale, scale, marker.AnchorPosition);
                    break;
                case MarkerType.Rotate:
                    // получаем угол вращения (в градусах), используя позицию маркера в мировых "координатах",
                    // позицию якоря в мировых "координатах" и позицию курсора мышки
                    var angle = Helper.GetAngle(marker.Position, marker.AnchorPosition, mousePos);
                    // поворачиваем выделенные фигуры относительно "якоря" (по умолчанию - по центру фигуры выделения)
                    _selection.Rotate(angle, marker.AnchorPosition);
                    break;
                case MarkerType.Vertex:
                    if (!_wasVertexMoving)
                        OnLayerStartChanging();
                    
                    // двигаем вершину
                    var vm = (VertexMarker) marker;
                    _selection.MoveVertex(vm.Owner, vm.Index, mousePos);

                    //обновляем позицию маркера
                    vm.Position = mousePos;
                    UpdateMarkerPositions();

                    _wasVertexMoving = true;
                    break;
            }
        }

        /// <summary>
        /// Метод строит маркеры у объекта Selection
        /// </summary>
        private void BuildMarkers()
        {
            // стираем предыдущие маркеры
            Markers.Clear();
            // если ничего не выбрано, выходим
            if (Selection.Count == 0) return;
            switch (_editorMode)
            {
                case EditorMode.Skew:
                    //создаём маркеры скоса по горизонтали и по вертикали
                    if (_selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Skew)) //если разрешён скос
                    {
                        Markers.Add(CreateMarker(MarkerType.SkewX, 0.5f, 0, UserCursor.SkewHorizontal, 1, 1));
                        Markers.Add(CreateMarker(MarkerType.SkewY, 0, 0.5f, UserCursor.SkewVertical, 1, 1));
                        Markers.Add(CreateMarker(MarkerType.SkewY, 1, 0.5f, UserCursor.SkewVertical, 0, 0));
                        Markers.Add(CreateMarker(MarkerType.SkewX, 0.5f, 1, UserCursor.SkewHorizontal, 0, 0));
                    }
                    break;
                case EditorMode.Verticies:
                    // создаём маркеры на вершинах фигур
                    if (_selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Vertex)) //если разрешено редактирование вершин
                    {
                        foreach (var fig in _selection.Where(figure => figure.Geometry is PolygoneGeometry))
                        {
                            var polygone = fig.Geometry as PolygoneGeometry;
                            //get transformed points
                            var points = polygone.GetTransformedPoints(fig);
                            for (int i = 0; i < points.Length; i++)
                                Markers.Add(CreateVertexMarker(points[i], i, fig));
                        }
                    }
                    break;
                case EditorMode.Select:
                    // создаём маркеры масштаба
                    if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Scale)) //если разрешено масштабирование
                    {
                        Markers.Add(CreateMarker(MarkerType.Scale, 0, 0, UserCursor.SizeNWSE, 1, 1));
                        Markers.Add(CreateMarker(MarkerType.Scale, 1, 0, UserCursor.SizeNESW, 0, 1));
                        Markers.Add(CreateMarker(MarkerType.Scale, 1, 1, UserCursor.SizeNWSE, 0, 0));
                        Markers.Add(CreateMarker(MarkerType.Scale, 0, 1, UserCursor.SizeNESW, 1, 0));
                    }

                    // создаём маркеры ресайза по вертикали и горизонтали
                    if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Size)) //если разрешено изменение размера
                    {
                        Markers.Add(CreateMarker(MarkerType.SizeY, 0.5f, 0, UserCursor.SizeNS, 0.5f, 1));
                        Markers.Add(CreateMarker(MarkerType.SizeX, 1, 0.5f, UserCursor.SizeWE, 0, 0.5f));
                        Markers.Add(CreateMarker(MarkerType.SizeY, 0.5f, 1, UserCursor.SizeNS, 0.5f, 0));
                        Markers.Add(CreateMarker(MarkerType.SizeX, 0, 0.5f, UserCursor.SizeWE, 1, 0.5f));
                    }

                    // создаём маркер вращения
                    if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate)) //если разрешено вращение
                    {
                        var rotateMarker = CreateMarker(MarkerType.Rotate, 1, 0, UserCursor.Rotate, 0.5f, 0.5f, 15, -15);
                        Markers.Add(rotateMarker);
                    }
                    break;
            }
            // задаём геометрию маркеров по умолчанию 
            var figureBuilder = new FigureBuilder();
            foreach (var marker in Markers)
                figureBuilder.BuildMarkerGeometry(marker);
        }

        private VertexMarker CreateVertexMarker(PointF point, int index, Figure fig)
        {
            var marker = new VertexMarker
            {
                MarkerType = MarkerType.Vertex,
                Cursor = CursorFactory.GetCursor(UserCursor.MoveAll),
                Position = point,
                Index = index,
                Owner = fig
            };
            return marker;
        }

        /// <summary>
        /// Вызываем этот метод, чтобы маркеры двигались синхронно с выделением
        /// </summary>
        private void UpdateMarkerPositions()
        {
            foreach (var marker in Markers)
                marker.PushPositionToTransform();
        }

        #endregion Всё для работы с маркерами

        /// <summary>
        /// Форма курсора в зависимости от контекста
        /// </summary>
        /// <param name="point">Позиция курсора</param>
        /// <param name="modifierKeys">Какие клавиши были ещё нажаты в этот момент</param>
        /// <param name="button">Нажатая кнопка мышки</param>
        /// <returns>Настроенный курсор</returns>
        public Cursor GetCursor(Point point, Keys modifierKeys, MouseButtons button)
        {
            switch (EditorMode)
            {
                // для базовых режимов настраиваем вид курсора на маркерах
                case EditorMode.Select:
                case EditorMode.Skew:
                case EditorMode.Verticies:
                    Marker marker;
                    if (FindMarkerAt(point, out marker))
                    {
                        return modifierKeys.HasFlag(Keys.Control) 
                            ? CursorFactory.GetCursor(UserCursor.RemoveVertex) 
                            : marker.Cursor;
                    }
                    Figure fig;
                    if (_selection.FindFigureAt(_layer, point, out fig))
                    {
                        if (EditorMode == EditorMode.Verticies &&
                            _selection.Contains(fig) && _selection.IsHit(_layer, point))
                            return CursorFactory.GetCursor(UserCursor.AddVertex);
                        return CursorFactory.GetCursor(UserCursor.MoveAll);
                    }
                    if (!modifierKeys.HasFlag(Keys.Left))
                        return Cursors.Default;
                    break;
                // когда тащим фигуры
                case EditorMode.Drag:
                    return _selection.Count > 0
                               ? CursorFactory.GetCursor(UserCursor.SizeAll)
                               : CursorFactory.GetCursor(UserCursor.SelectByRibbonRect);
                // когда изменяем масштабируем, меняем ширину/высоту, вращаем или искажаем
                case EditorMode.ChangeGeometry:
                    if (button == MouseButtons.Left && _lastMode == EditorMode.Verticies)
                        return CursorFactory.GetCursor(UserCursor.MoveVertex);
                    return _movedMarker.Cursor;
            }

            return Cursors.Default;
        }

        /// <summary>
        /// Переместить выбранные фигуры наверх по оси z
        /// </summary>
        public void BringToFront()
        {
            LayerStartChanging();
            foreach (var fig in _selection)
            {
                _layer.Figures.Remove(fig);
                _layer.Figures.Add(fig);
            }
            LayerChanged();
            OnSelectedFigureChanged();
        }

        /// <summary>
        /// Переместить выбранные фигуры вниз по оси z
        /// </summary>
        public void SendToBack()
        {
            LayerStartChanging();
            foreach (var fig in _selection)
            {
                _layer.Figures.Remove(fig);
                _layer.Figures.Insert(0, fig);
            }
            LayerChanged();
            OnSelectedFigureChanged();
        }

        /// <summary>
        /// Группировка фигур в одну фигуру
        /// </summary>
        public void Group()
        {
            if (_selection.Count < 2) return;
            var group = _selection.Group();
            LayerStartChanging();
            foreach (var fig in _selection)
                _layer.Figures.Remove(fig);
            _layer.Figures.Add(group);
            LayerChanged();
            _selection.Clear();
            _selection.Add(group);
            OnSelectedFigureChanged();
        }

        /// <summary>
        /// Разгруппировка фигуры на несколько вложенных
        /// </summary>
        public void Ungroup()
        {
            if (_selection.Count == 0) return;
            LayerStartChanging();
            foreach (var fig in _selection.OfType<FigureGroup>())
                _layer.Figures.Remove(fig);
            var list = _selection.Ungroup();
            _layer.Figures.AddRange(list);
            LayerChanged();
            _selection.Clear();
            foreach (var fig in list)
                _selection.Add(fig);
            BuildMarkers();
            UpdateMarkerPositions();
            OnSelectedFigureChanged();
        }
    }
}
