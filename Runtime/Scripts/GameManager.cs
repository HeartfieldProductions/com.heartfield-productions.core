using UnityEngine;

namespace Heartfield
{
    [DefaultExecutionOrder(-1000)]
    public sealed class GameManager : MonoBehaviour
    {
        static GameManager _instance;
        public static GameManager Instance => _instance;

        [SerializeField] int pauseMenuSceneIndex;
        [SerializeField] int loadingScreenSceneIndex;

        internal int PauseMenuSceneIndex => pauseMenuSceneIndex;
        internal int LoadingScreenSceneIndex => loadingScreenSceneIndex;

        GameManager()
        {
            if (_instance != null && _instance != this)
                Destroy(this);

            _instance = this;
        }
    }
}