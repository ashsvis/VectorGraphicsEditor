using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
 
        private bool _wasMouseMoving = false;
        private bool _isMouseDown = false;
        private Point _firstMouseDown;
        private Size _mouseOffset;
 
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
            //todo
            Figure fig;
            if (FindFigureAt(point, out fig))
            {
                var marker = fig as Marker;
                if (marker != null)
                {

                }
                else // выбрана фигура, а не маркер
                {
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
            }
            else
            {
                _selection.Clear();
                OnSelectedFigureChanged();
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
                    OnSelectedFigureChanged();
                }
            }

            _isMouseDown = false;
            //строим маркеры
            BuildMarkers();
            UpdateMarkerPositions();
        }

        /// <summary>
        /// Вызываем привязынный к событию метод
        /// </summary>
        private void OnSelectedFigureChanged()
        {
            if (SelectedFigureChanged != null)
                SelectedFigureChanged();
        }

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

        private void BuildMarkers()
        {

            Markers.Clear();
            //создаем маркеры масштаба
            if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Scale)) //если разрешено масштабирование
            {
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(0, 0), GetCursor = () => Cursors.SizeNWSE, Moved = MarkerMoved });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(1, 0), GetCursor = () => Cursors.SizeNESW, Moved = MarkerMoved });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(1, 1), GetCursor = () => Cursors.SizeNWSE, Moved = MarkerMoved });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(0, 1), GetCursor = () => Cursors.SizeNESW, Moved = MarkerMoved });
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
            var figureBuilder = new FigureBuilder();
            foreach (var marker in Markers)
                figureBuilder.BuildMarkerGeometry(marker);
        }
 
        private static void MarkerMoved(Marker marker)
        {
            Console.WriteLine(marker);
        }

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
                _mouseOffset = new Size(point.X - _firstMouseDown.X, point.Y - _firstMouseDown.Y);
                _wasMouseMoving = true;
                // показываем, как будет перемещаться список выбранных фигур
                _selection.Translate(_mouseOffset.Width, _mouseOffset.Height);
                OnSelectedFigureChanged();
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
