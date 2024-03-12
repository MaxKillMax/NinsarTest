using UnityEngine.SceneManagement;

namespace NST.Scenes
{
    public static class SceneLauncher
    {
        public static void Open(SceneType type, LoadSceneMode mode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene((int)type, mode);
        }
    }
}
