using UnityEngine;

namespace Heartfield.SceneManagement
{
    sealed class ToggleLoadingAudioListener : MonoBehaviour
    {
        [SerializeField] AudioListener listener;

        void Awake()
        {
            listener.enabled = false;
            LoadingManager.OnLoadingScreenOpened += EnableAudioListener;
            LoadingManager.OnLoadingScreenClosed += DisableAudioListener;
        }

        void OnDisable()
        {
            LoadingManager.OnLoadingScreenOpened -= EnableAudioListener;
            LoadingManager.OnLoadingScreenClosed -= DisableAudioListener;
        }

        void EnableAudioListener()
        {
            listener.enabled = true;
        }

        void DisableAudioListener()
        {
            listener.enabled = false;
        }
    }
}