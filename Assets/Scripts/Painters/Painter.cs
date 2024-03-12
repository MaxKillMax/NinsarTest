using System.Collections.Generic;
using NST.Initializes;
using UnityEngine;
using Grid = NST.Grids.Grid;

namespace NST.Painters
{
    public class Painter : MonoInitializable
    {
        private const int SQUARE_WIDTH = 3;

        [SerializeField] private PainterData _data;
        [SerializeField] private MeshRenderer[] _renderers;
        [SerializeField] private Grid _grid;

        private Material[] _materials;

        protected override void OnInitialize()
        {
            _materials = new Material[_renderers.Length];

            for (int i = 0; i < _materials.Length; i++)
            {
                _materials[i] = new Material(_data.Sample);
                _renderers[i].material = _materials[i];
            }
        }

        private void OnDestroy()
        {
            if (_materials == null)
                return;

            for (int i = 0; i < _materials.Length; i++)
                Destroy(_materials[i]);
        }

        private void OnEnable()
        {
            _grid.OnPointUpdated += Repaint;

            Repaint(_grid.Point);
        }

        private void OnDisable()
        {
            _grid.OnPointUpdated -= Repaint;
        }

        private void Repaint(Vector2Int point)
        {
            List<PaintColorType> numbers = GetColorsInSquare(point);

            for (int i = 0; i < numbers.Count; i++)
                Paint((PaintPositionType)i, numbers[i]);
        }

        private PaintColorType GetColor(Vector2Int point) => (PaintColorType)_grid.GetNumber(point);

        private List<PaintColorType> GetColorsInSquare(Vector2Int origin)
        {
            List<PaintColorType> colors = new(SQUARE_WIDTH * SQUARE_WIDTH);

            for (int y = 0; y < SQUARE_WIDTH; y++)
            {
                for (int x = 0; x < SQUARE_WIDTH; x++)
                {
                    colors.Add(GetColor(_grid.GetPoint(origin.x + x, origin.y + y)));
                    Debug.Log($"{origin.x + x}/{origin.y + y} is {colors[^1]}");
                }
            }

            return colors;
        }

        public void Paint(PaintPositionType positionType, PaintColorType colorType)
            => _materials[(int)positionType].color = _data.Colors[(int)colorType];
    }
}
