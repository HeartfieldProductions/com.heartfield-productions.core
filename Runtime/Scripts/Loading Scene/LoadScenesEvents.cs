using UnityEngine;
using UnityEngine.Events;

namespace Heartfield.SceneManagement
{
    public class LoadScenesEvents : MonoBehaviour
    {
        [SerializeField] UnityEvent<int> OnLoadScenesCompleted;

        void Awake()
        {
            if (OnLoadScenesCompleted.GetPersistentEventCount() > 0)
                LoadingManager.OnLoadScenesCompleted += OnLoadScenesCompleted.Invoke;
        }
    }
}