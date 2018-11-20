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
 
        public void OnMouseDown(Point point, Keys modifierKeys)
        {
            _wasMouseMoving = false;
            _isMouseDown = true;
        }

        public void OnMouseUp(Point point, Keys modifierKeys)
        {
            _isMouseDown = false;

            //перебираем фигуры, выделяем/снимаем выделение
            //todo
            Figure fig;
            if (FindFigureAt(point, out fig))
            {
                var marker = fig as Marker;
                if (marker != null)
                {

                }
                else
                {
                    if (!_selection.Contains(fig))
                    {
                        _selection.Add(fig);
                        OnSelectedFigureChanged();
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
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(0, 0) });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(1, 0) });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(1, 1) });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(0, 1) });
            }

            //создаем маркеры ресайза по верт и гориз
            if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Scale)) //если разрешено изменение размера
            {
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(0.5f, 0) });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(1, 0.5f) });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(0.5f, 1) });
                Markers.Add(new Marker { NormalizedLocalCoordinates = new PointF(0, 0.5f) });
            }

            //создаем маркер вращения
            if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate)) //если разрешено вращение
            {
                var rotateMarker = new Marker { NormalizedLocalCoordinates = new PointF(1.1f, 0) };
                Markers.Add(rotateMarker);
            }
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
 
        public void OnMouseMove(Point point, Keys modifierKeys)
        {
            if (_isMouseDown)
            {
                _wasMouseMoving = true;
                //todo
                UpdateMarkerPositions();
            }
        }
 
        /// <summary>
        /// Форма курсора в зависимости от контекста
        /// </summary>
        /// <param name="point">Позиция курсора</param>
        /// <param name="modifierKeys">Управляющие клавиши</param>
        /// <returns></returns>
        public Cursor GetCursor(Point point, Keys modifierKeys)
        {
            Marker marker;
            if (FindMarkerAt(point, out marker))
            {
                return Cursors.Hand;                
            }
            Figure fig;
            if (FindFigureAt(point, out fig))
            {
                return Cursors.SizeAll;
            }
            return Cursors.Default;
        }
    }
}
