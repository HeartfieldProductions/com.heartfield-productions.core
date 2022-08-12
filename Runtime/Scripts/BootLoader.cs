using UnityEngine;
using Heartfield.SceneManagement;
using System.Collections;

namespace Heartfield
{
    [DefaultExecutionOrder(-999)]
    [DisallowMultipleComponent]
    public sealed class BootLoader : MonoBehaviour
    {        
        void Start()
        {
            GameManagerAsset.ToggleCursor(true);
            LoadingManager.RegisterPersistentScene(0);
            LoadingManager.Load(1);
        }
    }
}