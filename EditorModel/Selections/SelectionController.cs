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
    class SelectionController
    {
        private readonly Selection _selection = new Selection();
        private readonly List<Marker> _markers = new List<Marker>();

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
 
        public void OnMouseDown(Point p, Keys modifierKeys)
        {
            _wasMouseMoving = false;
            _isMouseDown = true;
        }
 
        public void OnMouseUp(Point p, Keys modifierKeys)
        {
            _isMouseDown = false;
 
            //перебираем фигуры, выделяем/снимаем выделение
            //todo
 
            //строим маркеры
            BuildMarkers();
            UpdateMarkerPositions();
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
            if (Selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate))//если разрешено вращение
            {
                var rotateMarker = new Marker {NormalizedLocalCoordinates = new PointF(1.1f, 0)};
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
 
        public void OnMouseMove(Point p, Keys modifierKeys)
        {
            if (_isMouseDown)
            {
                _wasMouseMoving = true;
                //todo
                UpdateMarkerPositions();
            }
        }
 
        public Cursor GetCursor(Point p, Keys modifierKeys)
        {
            throw new NotImplementedException();
        }
    }
}
