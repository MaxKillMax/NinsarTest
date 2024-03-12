using UnityEngine;

namespace NST.Initializes
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private MonoInitializable[] _initializables;

        private void Awake()
        {
            for (int i = 0; i < _initializables.Length; i++)
                _initializables[i].Initialize();
        }
    }
}
