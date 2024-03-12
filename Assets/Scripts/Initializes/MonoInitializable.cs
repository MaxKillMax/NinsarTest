using UnityEngine;
using UnityEngine.Assertions;

namespace NST.Initializes
{
    public abstract class MonoInitializable : MonoBehaviour
    {
        private bool _isInitialized = false;

        public void Initialize()
        {
            Assert.IsFalse(_isInitialized);

            _isInitialized = true;
            OnInitialize();
        }

        protected abstract void OnInitialize();
    }
}
