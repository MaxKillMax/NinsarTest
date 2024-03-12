using UnityEngine;

namespace NST.Painters
{
    [CreateAssetMenu(fileName = nameof(PainterData), menuName = nameof(PainterData), order = 51)]
    public class PainterData : ScriptableObject
    {
        [SerializeField] private Material _sample;
        [SerializeField] private Color[] _colors;

        public Material Sample => _sample;
        public Color[] Colors => _colors;
    }
}
