using NST.Interfaces;
using UnityEngine;
using Grid = NST.Grids.Grid;

namespace NST.Players
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Grid _grid;

        private void Start()
        {
            PrintPoint(_grid.Point);
        }

        private void OnEnable()
        {
            Inputs.Input.SetKeyCodeDownListenState(true, KeyCode.A, MoveLeft);
            Inputs.Input.SetKeyCodeDownListenState(true, KeyCode.D, MoveRight);
            Inputs.Input.SetKeyCodeDownListenState(true, KeyCode.W, MoveUp);
            Inputs.Input.SetKeyCodeDownListenState(true, KeyCode.S, MoveDown);

            _grid.OnPointUpdated += PrintPoint;
        }

        private void OnDisable()
        {
            Inputs.Input.SetKeyCodeDownListenState(false, KeyCode.A, MoveLeft);
            Inputs.Input.SetKeyCodeDownListenState(false, KeyCode.D, MoveRight);
            Inputs.Input.SetKeyCodeDownListenState(false, KeyCode.W, MoveUp);
            Inputs.Input.SetKeyCodeDownListenState(false, KeyCode.S, MoveDown);

            _grid.OnPointUpdated -= PrintPoint;
        }

        private void PrintPoint(Vector2Int point)
        {
            string message = $"X: {point.x}  Y: {_grid.Height - point.y - 1}";

            Debug.Log(message);
            MessagePopup.Show(message);
        }

        private void MoveLeft() => _grid.AddOffsetToCurrentPoint(-1, 0);

        private void MoveRight() => _grid.AddOffsetToCurrentPoint(1, 0);

        private void MoveUp() => _grid.AddOffsetToCurrentPoint(0, 1);

        private void MoveDown() => _grid.AddOffsetToCurrentPoint(0, -1);
    }
}
