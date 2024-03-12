using NST.Scenes;
using UnityEngine;
using Input = NST.Inputs.Input;
using Time = NST.Times.Time;

namespace NST
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private SceneType _loadingScene;

        private readonly Time _time = new();
        private readonly Input _input = new();

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SceneLauncher.Open(_loadingScene);
        }

        private void Update()
        {
            _time.Update();
            _input.Update();
        }
    }
}
