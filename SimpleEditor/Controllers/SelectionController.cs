using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Figures;
using EditorModel.Selections;
using SimpleEditor.Commands;
using SimpleEditor.Common;

namespace SimpleEditor.Controllers
{
    public enum EditorMode
    {
        Select,
        Drag,
        Scale,
        SizeX,
        SizeY,
        Rotate,
        SkewX,
        SkewY,
        AddLine,
        AddPolygon,
        AddRectangle,
        AddSquare,
        AddEllipse,
        AddCircle
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
        readonly UndoRedoManager _undoRedoManager;

        public SelectionController(Layer layer)
        {
            _selection = new Selection();
            _markers = new List<Marker>();
            _layer = layer;
            _layer.FiguresCountChanged += () => OnLayerChanged();
            _undoRedoManager = new UndoRedoManager();
            _undoRedoManager.StateChanged += (sender, e) => OnUndoRedoChanged(sender, e);
        }

        public void Undo()
        {
            _undoRedoManager.Undo();
        }

        public void Redo()
        {
            _undoRedoManager.Redo();
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

        public event Action<UndoRedoManager, UndoRedoEventArgs> UndoRedoChanged = delegate { };

        public event Action<int> LayerChanged = delegate { };

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

        private Figure _ribbon;

        /// <summary>
        /// Создание специальной фигуры для выделения рамкой
        /// </summary>
        /// <param name="point"></param>
        private void CreateRibbonFrame(Point point)
        {
            _ribbon = new Figure();
            var builder = new FigureBuilder();
            switch (_editorMode)
            {
                case EditorMode.Select:
                    builder.BuildRectangleGeometry(_ribbon);
                    break;
                case EditorMode.AddLine:
                    builder.BuildRectangleGeometry(_ribbon);   //todo Нужно придумать геометрию для линии
                    break;
                case EditorMode.AddPolygon:
                    builder.BuildPolygoneGeometry(_ribbon);
                    break;
                case EditorMode.AddRectangle:
                    builder.BuildRectangleGeometry(_ribbon);
                    break;
                case EditorMode.AddSquare:
                    builder.BuildSquareGeometry(_ribbon);
                    break;
                case EditorMode.AddEllipse:
                    builder.BuildEllipseGeometry(_ribbon);
                    break;
                case EditorMode.AddCircle:
                    builder.BuildCircleGeometry(_ribbon);
                    break;
            }
            _ribbon.Transform.Translate(point.X, point.Y);
            _ribbon.Transform.Scale(1, 1);
            _selection.Add(_ribbon);
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
                        {
                            _selection.Clear(); // очистим список выбранных
                        }

                        _selection.Add(fig);    // то добавим её в список
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
                    // создаём "резиновую" рамку
                    CreateRibbonFrame(point);
                    // создаём спец. маркер для выделения рамкой
                    CreateSelectMarker();

                    OnSelectedFigureChanged();
                }
            }
            else
            {
                // како-то маркер был под мышкой
                // естанавливаем соответствующий режим
                switch (_movedMarker.MarkerType)
                {
                    case MarkerType.Scale:
                        EditorMode = EditorMode.Scale;
                        break;
                    case MarkerType.SizeX:
                        EditorMode = EditorMode.SizeX;
                        break;
                    case MarkerType.SizeY:
                        EditorMode = EditorMode.SizeY;
                        break;
                    case MarkerType.Rotate:
                        EditorMode = EditorMode.Rotate;
                        break;
                    case MarkerType.SkewX:
                        EditorMode = EditorMode.SkewX;
                        break;
                    case MarkerType.SkewY:
                        EditorMode = EditorMode.SkewY;
                        break;
                }
            }
        }

        /// <summary>
        /// Создание специальнго маркера для выбора рамкой
        /// </summary>
        private void CreateSelectMarker()
        {
            _movedMarker = new SelectMarker
            {
                MarkerType = MarkerType.Select,
                Cursor = CursorFactory.GetCursor(UserCursor.SelectByRibbonRect),
                Position = _selection.ToWorldCoordinates(new PointF(0f, 0f)),
                AnchorPosition = _selection.ToWorldCoordinates(new PointF(1f, 1f)),
                AnchorX = _selection.ToWorldCoordinates(new PointF(1f, 0f)),
                AnchorY = _selection.ToWorldCoordinates(new PointF(0f, 1f))
            };

            //ставим маркер на его место в мировых координатах
            var world = _movedMarker.Position;
            var m = new Matrix();
            m.Translate(world.X, world.Y);
            //применяем преобразование selection
            //чтобы маркер двигался синхронно с выделением
            m.Multiply(Selection.Transform, MatrixOrder.Append);
            //
            _movedMarker.Transform = m;
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
                if (_movedMarker != null)
                {
                    // вызываем метод маркера для выполения действия
                    OnMarkerMoved(_movedMarker, point);
                    OnSelectedTransformChanging();
                }
                else // выбрана фигура, а не маркер
                {
                    // показываем, как будет перемещаться список выбранных фигур
                    var mouseOffset = new Point(point.X - _firstMouseDown.X, point.Y - _firstMouseDown.Y);
                    _selection.Translate(mouseOffset.X, mouseOffset.Y);
                    OnSelectedTransformChanging();
                }
                OnSelectedRangeChanging(Rectangle.Ceiling(_selection.GetTransformedPath().GetBounds()));
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
                if (_ribbon != null)
                {
                    if (EditorMode == EditorMode.Select)
                    {
                        // добавляем все фигуры, которые оказались охваченными прямоугольником выбора
                        // в список выбранных фигур
                        _selection.PushTransformToSelectedFigures();
                        var rect = _ribbon.GetTransformedPath().GetBounds();
                        foreach (var fig in _layer.Figures.Where(fig =>
                            rect.Contains(Rectangle.Ceiling(fig.GetTransformedPath().GetBounds()))))
                            _selection.Add(fig);
                    }
                    else
                    {
                        // добавляем фигуру здесь
                        _selection.PushTransformToSelectedFigures();
                        _layer.Figures.Add(_ribbon);

                    }
                    _selection.Remove(_ribbon);
                    _ribbon = null;
                    OnSelectedRangeChanging(Rectangle.Empty);
                }

                if (_wasMouseMoving)
                {
                    _wasMouseMoving = false;
                    // фиксация перемещения фигур
                    //_undoRedoManager.Execute(new PushTransformToSelectedFiguresCommand(_selection, OnSelectedTransformChanged));
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
        /// Вызываем привязанный к событию метод при изменении счётчиков отмены/возврата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUndoRedoChanged(UndoRedoManager sender, UndoRedoEventArgs e)
        {
            UndoRedoChanged(sender, e);
        }

        private void OnLayerChanged()
        {
            LayerChanged(_layer.Figures.Count);
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
        private Marker CreateMarker(MarkerType type, float posX, float posY, UserCursor cursor, float anchorX, float anchorY)
        {
            var normPoint = new PointF(posX, posY);
            var anchPoint = new PointF(anchorX, anchorY);
            return new Marker
            {
                MarkerType = type,
                Cursor = CursorFactory.GetCursor(cursor),
                Position = _selection.ToWorldCoordinates(normPoint),
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
                case MarkerType.Select:
                    var selmark = (SelectMarker)marker;
                    var mouse = new PointF(mousePos.X, mousePos.Y);
                    var x = marker.Position.Sub(selmark.AnchorX); // строим вектор AnchorX-Marker
                    var y = marker.Position.Sub(selmark.AnchorY); // строим вектор AnchorY-Marker
                    var mX = mouse.Sub(selmark.AnchorX);  // строим вектор AnchorX-Mouse(position)
                    var scaleX = mX.DotScalar(x) / x.LengthSqr();
                    var mY = mouse.Sub(selmark.AnchorY);  // строим вектор AnchorY-Mouse(position)
                    var scaleY = mY.DotScalar(y) / y.LengthSqr();
                    // защита результата от "крайних" случаев расчёта
                    if (Math.Abs(scaleX) < 0.001f) scaleX = 0.001f;
                    if (Math.Abs(scaleY) < 0.001f) scaleY = 0.001f;

                    _selection.Scale(scaleX, scaleY, marker.AnchorPosition);
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
                var rotateMarker = CreateMarker(MarkerType.Rotate, 1.1f, 0, UserCursor.Rotate, 0.5f, 0.5f);
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

        private Cursor _cursor = Cursors.Default;

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
                    {
                        _cursor = marker.Cursor;
                        break;
                    }
                    Figure fig;
                    if (FindFigureAt(point, out fig))
                    {
                        _cursor = CursorFactory.GetCursor(UserCursor.MoveAll);
                        break;
                    }
                    if (!modifierKeys.HasFlag(Keys.Left))
                        _cursor = Cursors.Default;
                    break;
                case EditorMode.Drag:
                    _cursor = _selection.Count > 0 
                        ? Cursors.SizeAll 
                        : CursorFactory.GetCursor(UserCursor.SelectByRibbonRect);
                    break;
                case EditorMode.AddLine:
                    _cursor = Cursors.Default; //todo Создать курсор для линии
                    break;
                case EditorMode.AddPolygon:
                case EditorMode.AddRectangle:
                case EditorMode.AddSquare:
                    _cursor = CursorFactory.GetCursor(UserCursor.CreateRect);
                    break;
                case EditorMode.AddEllipse:
                case EditorMode.AddCircle:
                    _cursor = CursorFactory.GetCursor(UserCursor.CreateEllipse);
                    break;
                default:
                    if (_movedMarker != null)
                        _cursor = _movedMarker.Cursor;
                    break;
            }
            return _cursor;
        }
    }
}
