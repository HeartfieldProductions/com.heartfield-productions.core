using UnityEngine;
using UnityEngine.UI;

namespace Heartfield.SceneManagement
{
    [RequireComponent(typeof(Slider))]
    public sealed class LoadingProgressDisplay : MonoBehaviour
    {
        Slider slider;

        void Awake()
        {
            slider = GetComponent<Slider>();
            slider.minValue = 0;
            slider.maxValue = 1;
            
            LoadingManager.OnLoadingProgress += OnDisplayLoadingProgress;
        }

        void OnDisplayLoadingProgress(float progress)
        {
            slider.SetValueWithoutNotify(progress);
        }
    }
}