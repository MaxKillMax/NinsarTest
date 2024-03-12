using System;
using UnityEngine;

namespace NST.Grids
{
    [CreateAssetMenu(fileName = nameof(GridData), menuName = nameof(GridData), order = 51)]
    public class GridData : ScriptableObject
    {
        [SerializeField] private TextAsset _textAsset;

        public string[] GetNumbers() => _textAsset.text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
    }
}
