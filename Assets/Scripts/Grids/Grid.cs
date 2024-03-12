using System;
using NST.Initializes;
using UnityEngine;

namespace NST.Grids
{
    public class Grid : MonoInitializable
    {
        [SerializeField] private GridData _data;

        private string[] _numbers;

        public int Height => _numbers.Length;
        public int Width => _numbers[0].Length;
        public Vector2Int Point { get; private set; }

        public event Action<Vector2Int> OnPointUpdated;

        protected override void OnInitialize()
        {
            _numbers = _data.GetNumbers();

            if (Width < 1 || Height < 1)
                throw new Exception("Empty colors array exception");

            SetRandomPoint();
        }

        private void SetRandomPoint()
        {
            Point = new(Random(Width), Random(Height));

            static int Random(int limit) => UnityEngine.Random.Range(0, limit);
        }

        public Vector2Int GetPoint(int x, int y)
        {
            while (x < 0)
                x += Width;

            while (y < 0)
                y += Height;

            return new(x % Width, y % Height);
        }

        public int GetNumber(Vector2Int point) => _numbers[point.y][point.x] - '0';

        public void AddOffsetToCurrentPoint(int x, int y)
        {
            Point = GetPoint(Point.x + x, Point.y - y);
            OnPointUpdated?.Invoke(Point);
        }

        public void AddOffsetToCurrentPoint(Vector2Int offset) => AddOffsetToCurrentPoint(offset.x, offset.y);
    }
}
