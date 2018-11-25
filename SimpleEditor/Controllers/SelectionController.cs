using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Figures;
using EditorModel.Selections;
using SimpleEditor.Common;

namespace SimpleEditor.Controllers
{
    public enum EditorMode
    {
        Select,
        FrameSelect,
        ChangeGeometry,
        Drag,
        CreateFigure
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

        private bool _wasMouseMoving;
        private bool _isMouseDown;
        private Point _firstMouseDown;
        private Marker _movedMarker;

        private EditorMode _editorMode = EditorMode.Select;

        public EditorMode EditorMode
        {
            get { return _editorMode; }
            set
            {
                _editorMode = value;
                OnEditorModeChanged(EditorMode);
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
            _isMouseDown = true;
            // запоминаем точку нажатия мышкой
            _firstMouseDown = point;

            if (EditorMode != EditorMode.Select)
                Clear();   // очищаем список выбранных

            //перебираем фигуры, выделяем/снимаем выделение
            FindMarkerAt(point, out _movedMarker);
            if (_movedMarker == null)   // маркера под курсором не встретилось...
            {
                Figure fig;
                if (EditorMode == EditorMode.Select && 
                    FindFigureAt(point, out fig)) // попробуем найти фигуру...
                {
                    // фигура найдена.
                    // если этой фигуры не было в списке
                    if (!_selection.Contains(fig))
                    {
                        // если не нажата управляющая клавиша Ctrl
                        if (!modifierKeys.HasFlag(Keys.Control))
                            _selection.Clear(); // очистим список выбранных
                                                // то добавим её в список
                        _selection.Add(fig);
                        OnSelectedFigureChanged();
                    }
                    else if (modifierKeys.HasFlag(Keys.Control))
                    {
                        // при нажатой клавише Ctrl удаляем эту фигуру из списка
                        // если она не последняя
                        if (_selection.Count > 1)
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
                    // в точке мышки нечего нет, очищаем список выделенных
                    Clear();
                    OnSelectedFigureChanged();

                    if (CreateFigureRequest != null)
                    {
                        //создаем новую фигуру
                        CreateFigure(point);
                        EditorMode = EditorMode.CreateFigure;
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
                EditorMode = EditorMode.ChangeGeometry;
            }
        }

        private void CreateFigure(Point point)
        {
            //создаем новую фигуру
            var newFig = CreateFigureRequest();
            newFig.Transform.Translate(point.X + 0.5f, point.Y + 0.5f);
            _layer.Figures.Add(newFig);
            _selection.Add(newFig);
            CreateFigureRequest = null;
            OnSelectedFigureChanged();
        }

        /// <summary>
        /// Обработчик перемещения мышки при нажатой левой кнопки мышки 
        /// </summary>
        /// <param name="point">Координаты курсора</param>
        /// <param name="modifierKeys">Какие клавиши были ещё нажаты в этот момент</param>
        public void OnMouseMove(Point point, Keys modifierKeys)
        {
            if (_isMouseDown)
            {
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
                            (_selection.Geometry as FrameGeometry).EndPoint = point;
                            OnSelectedRangeChanging(Rectangle.Ceiling(_selection.GetTransformedPath().GetBounds()));
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
            }
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
                if (EditorMode == EditorMode.FrameSelect)
                {
                    // добавляем все фигуры, которые оказались охваченными прямоугольником выбора
                    // в список выбранных фигур
                    var rect = _selection.GetTransformedPath().GetBounds();
                    foreach (var fig in _layer.Figures.Where(fig =>
                        rect.Contains(Rectangle.Ceiling(fig.GetTransformedPath().GetBounds()))))
                        _selection.Add(fig);
                }

                if (_wasMouseMoving)
                {
                    _wasMouseMoving = false;
                    // фиксация перемещения фигур
                    _selection.PushTransformToSelectedFigures();
                    OnSelectedTransformChanged();
                }

            }

            //строим маркеры
            BuildMarkers();
            UpdateMarkerPositions();

            // обнуление рамки выбора
            EditorMode = EditorMode.Select;

            _isMouseDown = false;
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
        /// Вызываем привязынный к событию метод при выборе фигур
        /// </summary>
        private void OnSelectedFigureChanged()
        {
            SelectedFigureChanged();
        }

        /// <summary>
        /// Вызываем привязынный к событию метод в процессе изменения фигур
        /// </summary>
        private void OnSelectedTransformChanging()
        {
            SelectedTransformChanging();
        }

        /// <summary>
        /// Вызываем привязынный к событию метод в конце изменения фигур
        /// </summary>
        private void OnSelectedTransformChanged()
        {
            SelectedTransformChanged();
        }

        /// <summary>
        /// Вызываем привязынный к событию метод при изменении рамки выбора
        /// </summary>
        /// <param name="rect"></param>
        private void OnSelectedRangeChanging(Rectangle rect)
        {
            SelectedRangeChanging(rect);
        }

        /// <summary>
        /// Вызываем привязынный к событию метод при изменении режима редактора
        /// </summary>
        /// <param name="mode"></param>
        private void OnEditorModeChanged(EditorMode mode)
        {
            EditorModeChanged(mode);
        }

        #endregion Извещатели событий

        /// <summary>
        /// Ищем фигуру в данной точке
        /// </summary>
        /// <param name="point">Положение курсора</param>
        /// <param name="figure">Найденная фигура или null</param>
        /// <returns></returns>
        private bool FindFigureAt(Point point, out Figure figure)
        {
            figure = null;
            var found = false;
            for (var i = _layer.Figures.Count - 1; i >= 0; i--)
            {
                var fig = _layer.Figures[i];
                var path = fig.GetTransformedPath();
                if (!path.IsVisible(point)) continue;
                figure = fig;
                found = true;
                break;
            }
            return found;
        }

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
            for (var i = Markers.Count - 1; i >= 0; i--)
            {
                var fig = Markers[i];
                var path = fig.GetTransformedPath();
                if (!path.IsVisible(point)) continue;
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
        /// <returns></returns>
        private Marker CreateMarker(MarkerType type, float posX, float posY, UserCursor cursor, float anchorX, float anchorY, float offsetX = 0, float offsetY = 0)
        {
            var normPoint = new PointF(posX, posY);
            var anchPoint = new PointF(anchorX, anchorY);
            return new Marker
            {
                MarkerType = type,
                Cursor = CursorFactory.GetCursor(cursor),
                Position = _selection.ToWorldCoordinates(normPoint).Add( new PointF(offsetX, offsetY)),
                AnchorPosition = _selection.ToWorldCoordinates(anchPoint)
            };
        }

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
                case MarkerType.SizeX: _selection.Scale(scale, 1, marker.AnchorPosition); break;
                case MarkerType.SizeY: _selection.Scale(1, scale, marker.AnchorPosition); break;
                case MarkerType.Scale: _selection.Scale(scale, scale, marker.AnchorPosition); break;
                case MarkerType.Rotate:
                    {
                        // получаем угол вращения (в градусах), используя позицию маркера в мировых "координатах",
                        // позицию якоря в мировых "координатах" и позицию курсора мышки
                        var angle = Helper.GetAngle(marker.Position, marker.AnchorPosition, mousePos);
                        // поворачиваем выделенные фигуры относительно "якоря" (по умолчанию - по центру фигуры выделения)
                        _selection.Rotate(angle, marker.AnchorPosition);
                        break;
                    }
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
            //создаем маркеры масштаба
            if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Scale)) //если разрешено масштабирование
            {
                Markers.Add(CreateMarker(MarkerType.Scale, 0, 0, UserCursor.SizeNWSE, 1, 1));
                Markers.Add(CreateMarker(MarkerType.Scale, 1, 0, UserCursor.SizeNESW, 0, 1));
                Markers.Add(CreateMarker(MarkerType.Scale, 1, 1, UserCursor.SizeNWSE, 0, 0));
                Markers.Add(CreateMarker(MarkerType.Scale, 0, 1, UserCursor.SizeNESW, 1, 0));
            }

            //создаем маркеры ресайза по вертикали и горизонтали
            if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Size)) //если разрешено изменение размера
            {
                Markers.Add(CreateMarker(MarkerType.SizeY, 0.5f, 0, UserCursor.SizeNS, 0.5f, 1));
                Markers.Add(CreateMarker(MarkerType.SizeX, 1, 0.5f, UserCursor.SizeWE, 0, 0.5f));
                Markers.Add(CreateMarker(MarkerType.SizeY, 0.5f, 1, UserCursor.SizeNS, 0.5f, 0));
                Markers.Add(CreateMarker(MarkerType.SizeX, 0, 0.5f, UserCursor.SizeWE, 1, 0.5f));
            }

            //создаем маркер вращения
            if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate)) //если разрешено вращение
            {
                var rotateMarker = CreateMarker(MarkerType.Rotate, 1, 0, UserCursor.Rotate, 0.5f, 0.5f, 15, -15);
                Markers.Add(rotateMarker);
            }

            //задаем геометрию маркеров по умолчанию 
            var figureBuilder = new FigureBuilder();
            foreach (var marker in Markers)
                figureBuilder.BuildMarkerGeometry(marker);
        }

        /// <summary>
        /// Вызываем этот метод, чтобы маркеры двигались синхронно с выделением
        /// </summary>
        private void UpdateMarkerPositions()
        {
            foreach (var marker in Markers)
            {
                //ставим маркер на его место в мировых координатах
                var world = marker.Position;
                var m = new Matrix();
                m.Translate(world.X, world.Y);
                //применяем преобразование selection
                //чтобы маркеры двигались синхронно с выделением
                m.Multiply(Selection.Transform, MatrixOrder.Append);
                //
                marker.Transform = m;
            }
        }

        #endregion Всё для работы с маркерами

        /// <summary>
        /// Форма курсора в зависимости от контекста
        /// </summary>
        /// <param name="point">Позиция курсора</param>
        /// <param name="modifierKeys">Какие клавиши были ещё нажаты в этот момент</param>
        /// <returns></returns>
        public Cursor GetCursor(Point point, Keys modifierKeys)
        {
            switch (EditorMode)
            {
                case EditorMode.Select:
                    Marker marker;
                    if (FindMarkerAt(point, out marker))
                        return marker.Cursor;
                    Figure fig;
                    if (FindFigureAt(point, out fig))
                    {
                        return CursorFactory.GetCursor(UserCursor.MoveAll);
                    }
                    if (!modifierKeys.HasFlag(Keys.Left))
                        return Cursors.Default;
                    break;
                case EditorMode.Drag:
                    return _selection.Count > 0 
                        ? Cursors.SizeAll 
                        : CursorFactory.GetCursor(UserCursor.SelectByRibbonRect);
                case EditorMode.ChangeGeometry:
                    return _movedMarker.Cursor;
            }

            return Cursors.Default;
        }
    }
}
