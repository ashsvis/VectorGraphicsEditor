using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using EditorModel;
using EditorModel.Figures;
using EditorModel.Selections;
using SimpleEditor.Common;

namespace SimpleEditor
{
    /// <summary>
    /// Обрабатывает движения мышки, строит маркеры, управляет выделением,
    /// выполняет преобразования над фигурами
    /// </summary>
    public class SelectionController
    {
        private readonly Selection _selection;
        private readonly List<Marker> _markers;
        private readonly Layer _layer;

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

        private bool _wasMouseMoving;
        private bool _isMouseDown;
        private Point _firstMouseDown;
        private Point _mouseOffset;
        private Marker _movedMarker;
 
        /// <summary>
        /// Обработчик нажатия левой кнопки мышки
        /// </summary>
        /// <param name="point">Координаты курсора</param>
        /// <param name="modifierKeys">Какие клавиши были ещё нажаты в этот момент</param>
        public void OnMouseDown(Point point, Keys modifierKeys)
        {
            _wasMouseMoving = false;
            _isMouseDown = true;
            _firstMouseDown = point;
            //перебираем фигуры, выделяем/снимаем выделение
            FindMarkerAt(point, out _movedMarker);
            if (_movedMarker == null)   // маркера под курсором не встретилось...
            {
                Figure fig;
                if (FindFigureAt(point, out fig)) // попробуем найти фигуру...
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
                }
                else
                {
                    _selection.Clear();
                    OnSelectedFigureChanged();
                }
            }
            //строим маркеры
            BuildMarkers();
            UpdateMarkerPositions();
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
                if (_wasMouseMoving)
                {
                    // фиксация перемещения фигур
                    _selection.PushTransformToSelectedFigures();
                    OnSelectedTransformChanged();
                }
            }

            _isMouseDown = false;
            //строим маркеры
            BuildMarkers();
            UpdateMarkerPositions();
        }

        /// <summary>
        /// Вызываем привязынный к событию метод при выборе фигур
        /// </summary>
        private void OnSelectedFigureChanged()
        {
            if (SelectedFigureChanged != null)
                SelectedFigureChanged();
        }

        /// <summary>
        /// Вызываем привязынный к событию метод в процессе изменения фигур
        /// </summary>
        private void OnSelectedTransformChanging()
        {
            if (SelectedTransformChanging != null)
                SelectedTransformChanging();
        }

        /// <summary>
        /// Вызываем привязынный к событию метод в конце изменения фигур
        /// </summary>
        private void OnSelectedTransformChanged()
        {
            if (SelectedTransformChanged != null)
                SelectedTransformChanged();
        }

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
        /// Метода для более краткой записи при создании маркера
        /// </summary>
        /// <param name="normX"></param>
        /// <param name="normY"></param>
        /// <param name="cursor"></param>
        /// <param name="moved"></param>
        /// <returns></returns>
        private Marker CreateMarker(float normX, float normY, UserCursor cursor, Action<Marker, Point> moved, float anchX, float anchY)
        {
            var normPoint = new PointF(normX, normY);
            var anchPoint = new PointF(anchX, anchY);
            return new Marker
            {
                NormalizedLocalCoordinates = normPoint,
                GetCursor = () => CursorsBuilder.GetCursor(cursor),
                Moved = moved,
                AbsolutePosition = _selection.ToWorldCoordinates(normPoint),
                Anchor = new PointF(anchX, anchY),
                AnchorPosition = _selection.ToWorldCoordinates(anchPoint)
            };
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
                Markers.Add(CreateMarker(0, 0, UserCursor.SizeNWSE, ScaleMarkerMoved, 1, 1));
                Markers.Add(CreateMarker(1, 0, UserCursor.SizeNESW, ScaleMarkerMoved, 0, 1));
                Markers.Add(CreateMarker(1, 1, UserCursor.SizeNWSE, ScaleMarkerMoved, 0 ,0));
                Markers.Add(CreateMarker(0, 1, UserCursor.SizeNESW, ScaleMarkerMoved, 1, 0));
            }

            //создаем маркеры ресайза по вертикали и горизонтали
            if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Size)) //если разрешено изменение размера
            {
                Markers.Add(CreateMarker(0.5f, 0, UserCursor.SizeNS, HeightMarkerMoved, 0, 1));
                Markers.Add(CreateMarker(1, 0.5f, UserCursor.SizeWE, WidthMarkerMoved, 0, 0));
                Markers.Add(CreateMarker(0.5f, 1, UserCursor.SizeNS, HeightMarkerMoved, 0, 0));
                Markers.Add(CreateMarker(0, 0.5f, UserCursor.SizeWE, WidthMarkerMoved, 1, 0));
            }

            //создаем маркер вращения
            if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate)) //если разрешено вращение
            {
                var rotateMarker = CreateMarker(1.1f, 0, UserCursor.Rotate, RotateMarkerMoved, 0.5f, 0.5f);
                Markers.Add(rotateMarker);
            }
            // определяем геометрию маркеров по умолчанию 
            var figureBuilder = new FigureBuilder();
            foreach (var marker in Markers)
                figureBuilder.BuildMarkerGeometry(marker);
        }

        /// <summary>
        /// Метод для работы с перемещением маркеров размеров по ширине
        /// </summary>
        /// <param name="marker">Маркер, вызвавший этот метод</param>
        /// <param name="offset">Смещение</param>
        private void WidthMarkerMoved(Marker marker, Point offset)
        {
            var markerPoint = marker.AbsolutePosition;
            var anchorPoint = marker.AnchorPosition;
            var mousePoint = new PointF(markerPoint.X + offset.X, markerPoint.Y + offset.Y);
            var scale = GetScale(markerPoint, anchorPoint, mousePoint);
            _selection.Scale(scale, 1, marker.Anchor);

        }

        /// <summary>
        /// Метод для работы с перемещением маркеров размеров по высоте
        /// </summary>
        /// <param name="marker">Маркер, вызвавший этот метод</param>
        /// <param name="offset">Смещение</param>
        private void HeightMarkerMoved(Marker marker, Point offset)
        {
            var markerPoint = marker.AbsolutePosition;
            var anchorPoint = marker.AnchorPosition;
            var mousePoint = new PointF(markerPoint.X + offset.X, markerPoint.Y + offset.Y);
            var scale = GetScale(markerPoint, anchorPoint, mousePoint);
            _selection.Scale(1, scale, marker.Anchor);
        }

        private void RotateMarkerMoved(Marker marker, Point offset)
        {
            var markerPoint = marker.AbsolutePosition;
            var anchorPoint = marker.AnchorPosition;
            var mousePoint = new PointF(markerPoint.X + offset.X, markerPoint.Y + offset.Y);
            var a = markerPoint.Sub(anchorPoint);
            var m = mousePoint.Sub(anchorPoint);
            var angle = m.Angle(a);

            Console.WriteLine(angle);

            _selection.Rotate(angle, marker.Anchor);

        }

        /// <summary>
        /// Метод для работы с перемещением маркеров масштабирования
        /// </summary>
        /// <param name="marker">Маркер, вызвавший этот метод</param>
        /// <param name="offset">Смещение</param>
        private void ScaleMarkerMoved(Marker marker, Point offset)
        {
            var markerPoint = marker.AbsolutePosition;
            var anchorPoint = marker.AnchorPosition;
            var mousePoint = new PointF(markerPoint.X + offset.X, markerPoint.Y + offset.Y);
            var scale = GetScale(markerPoint, anchorPoint, mousePoint);
            _selection.Scale(scale, scale, marker.Anchor);
        }

        private const float Epsilon = 0.01f;

        /// <summary>
        /// Расчёт коэффициента масштабирования
        /// </summary>
        /// <param name="marker">Точка маркера</param>
        /// <param name="anchor">Точка якоря</param>
        /// <param name="mouse">Положение мышки</param>
        /// <returns></returns>
        private static float GetScale(PointF marker, PointF anchor, PointF mouse)
        {
            var a = marker.Sub(anchor);
            var m = mouse.Sub(anchor);
            var lengthA = a.Length();
            var b = m.DotScalar(a) / lengthA;
            var scale = b / lengthA;
            if (Math.Abs(scale) < Epsilon) scale = Epsilon;
            return scale;            
        }

        /// <summary>
        /// Вызываем этот метод, чтобы маркеры двигались синхронно с выделением
        /// </summary>
        private void UpdateMarkerPositions()
        {
            foreach (var marker in Markers)
            {
                //ставим маркер на его место в мировых координатах
                var world = Selection.ToWorldCoordinates(marker.NormalizedLocalCoordinates);
                var m = new Matrix();
                m.Translate(world.X, world.Y);
                //применяем преобразование selection
                //чтобы маркеры двигались синхронно с выделением
                m.Multiply(Selection.Transform, MatrixOrder.Append);
                //
                marker.Transform = m;
            }
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
                _mouseOffset = new Point(point.X - _firstMouseDown.X, point.Y - _firstMouseDown.Y);
                _wasMouseMoving = true;
                if (_movedMarker != null)
                {
                    // вызываем метод маркера для выполения действия
                    _movedMarker.Moved(_movedMarker, _mouseOffset);
                    OnSelectedTransformChanging();
                }
                else // выбрана фигура, а не маркер
                {
                    // показываем, как будет перемещаться список выбранных фигур
                    _selection.Translate(_mouseOffset.X, _mouseOffset.Y);
                    OnSelectedTransformChanging();
                }
            }
        }
 
        /// <summary>
        /// Форма курсора в зависимости от контекста
        /// </summary>
        /// <param name="point">Позиция курсора</param>
        /// <param name="modifierKeys">Какие клавиши были ещё нажаты в этот момент</param>
        /// <returns></returns>
        public Cursor GetCursor(Point point, Keys modifierKeys)
        {
            Marker marker;
            if (FindMarkerAt(point, out marker))
                return (Cursor)marker.GetCursor();
            Figure fig;
            if (FindFigureAt(point, out fig))
            {
                return CursorsBuilder.GetCursor(UserCursor.MoveAll);
            }
            return Cursors.Default;
        }
    }
}
