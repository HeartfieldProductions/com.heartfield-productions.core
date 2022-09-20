using UnityEngine;
using Heartfield.SceneManagement;

namespace Heartfield
{
    //[CreateAssetMenu(fileName = "New Game Manager Asset", menuName = "Heartfield Productions/Game Manager Asset")]
    public sealed class GameManagerAsset : ScriptableObject
    {
        static GameManagerAsset _instance;
        public static GameManagerAsset Instance => _instance;

        bool displayPauseMenu;

        public void QuitApplication()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void LoadScene(int sceneInBuildIndex)
        {
            LoadingManager.Load(sceneInBuildIndex);
        }

        public void TogglePause(bool value)
        {
            displayPauseMenu = value;
            LoadingManager.ToggleUiScene(GameManager.Instance.PauseMenuSceneIndex, displayPauseMenu);
        }

        public void TogglePause()
        {
            TogglePause(!displayPauseMenu);
        }

        public static void ToggleCursor(bool value)
        {
            Cursor.visible = value;

            Cursor.lockState = value ?
#if UNITY_EDITOR
                CursorLockMode.None :
#else
                CursorLockMode.Confined :
#endif
                CursorLockMode.Locked;
        }
    }
}