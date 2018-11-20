using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using EditorModel.Figures;

namespace EditorModel.Selections
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

        private bool _wasMouseMoving = false;
        private bool _isMouseDown = false;
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
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(0, 0), GetCursor = () => Cursors.SizeNWSE, Moved = ScaleMarkerMoved });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(1, 0), GetCursor = () => Cursors.SizeNESW, Moved = ScaleMarkerMoved });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(1, 1), GetCursor = () => Cursors.SizeNWSE, Moved = ScaleMarkerMoved });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(0, 1), GetCursor = () => Cursors.SizeNESW, Moved = ScaleMarkerMoved });
            }

            //создаем маркеры ресайза по вертикали и горизонтали
            if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Size)) //если разрешено изменение размера
            {
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(0.5f, 0), GetCursor = () => Cursors.SizeNS, Moved = MarkerMoved });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(1, 0.5f), GetCursor = () => Cursors.SizeWE, Moved = MarkerMoved });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(0.5f, 1), GetCursor = () => Cursors.SizeNS, Moved = MarkerMoved });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(0, 0.5f), GetCursor = () => Cursors.SizeWE, Moved = MarkerMoved });
            }

            //создаем маркер вращения
            if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate)) //если разрешено вращение
            {
                var rotateMarker = new Marker
                    {
                        NormalizedLocalCoordinates = new PointF(1.1f, 0),
                        GetCursor = () => Cursors.UpArrow,
                        Moved = MarkerMoved
                    };
                Markers.Add(rotateMarker);
            }
            // определяем геометрию маркеров по умолчанию 
            var figureBuilder = new FigureBuilder();
            foreach (var marker in Markers)
                figureBuilder.BuildMarkerGeometry(marker);
        }
 
        private void MarkerMoved(Marker marker, Point offset)
        {
            
        }

        /// <summary>
        /// Метод для работы с перемещением маркеров масштабирования
        /// </summary>
        /// <param name="marker">Маркер, вызвавший этот метод</param>
        /// <param name="offset">Смещение</param>
        private void ScaleMarkerMoved(Marker marker, Point offset)
        {
            var p = marker.NormalizedLocalCoordinates;
            var bounds = _selection.Geometry.Path.GetBounds();
            var scaleX = (bounds.Width + offset.X * ChangeSign(p.X)) / bounds.Width;
            var scaleY = (bounds.Height + offset.Y * ChangeSign(p.Y)) / bounds.Height;
            _selection.Scale(scaleX, scaleY, new PointF(Reverse(p.X), Reverse(p.Y)));
        }

        /// <summary>
        /// Для 1 возвращает +1, для 0 возвращает -1
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private static int ChangeSign(float coordinate)
        {
            return Math.Abs(coordinate - 1) < float.Epsilon ? 1 : -1;
        }

        /// <summary>
        /// Меняет 0 на 1 и наоборот
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private static int Reverse(float coordinate)
        {
            return Math.Abs(coordinate - 1) < float.Epsilon ? 0 : 1;
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
                return Cursors.SizeAll;
            }
            return Cursors.Default;
        }
    }
}
