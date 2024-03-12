using NST.Times;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace NST.Interfaces
{
    public class MessagePopup : MonoBehaviour
    {
        private const float DEFAULT_SHOW_TIME = 2;

        private static MessagePopup Instance;
        private static DelayedCall Call;

        [SerializeField] private TMP_Text _text;

        private void Awake()
        {
            Assert.IsNull(Instance);

            Instance = this;
            gameObject.SetActive(false);
        }

        public static void Show(string message, float time = DEFAULT_SHOW_TIME)
        {
            Instance.gameObject.SetActive(true);
            Instance._text.text = message;

            DelayedCall.Stop(Call);
            Call = DelayedCall.Start(OnShowTimeEnd, time);
        }

        private static void OnShowTimeEnd()
        {
            Instance.gameObject.SetActive(false);
        }
    }
}
