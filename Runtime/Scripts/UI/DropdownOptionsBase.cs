using UnityEngine;
#if USE_UNITY_TMP
using TMPro;
#else
using UnityEngine.UI;
#endif
using System.Collections.Generic;

namespace Heartfield.UI
{
#if USE_UNITY_TMP
    [RequireComponent(typeof(TMP_Dropdown))]
#else
    [RequireComponent(typeof(Dropdown))]
#endif
    [DisallowMultipleComponent]
    public abstract class DropdownOptionsBase : MonoBehaviour
    {
#if USE_UNITY_TMP
        protected TMP_Dropdown dropdown;
        [SerializeField] protected TMP_Text title;
#else
        protected Dropdown dropdown;
        [SerializeField] protected Text title;
#endif

        Color titleColor;
        Color disabledTitleColor;

        protected bool initialize = true;
        protected List<string> options = new List<string>();
        protected int index = 0;

        protected abstract void Initialize();

        protected virtual void Awake()
        {
#if USE_UNITY_TMP
            dropdown = GetComponent<TMP_Dropdown>();
#else
            dropdown = GetComponent<Dropdown>();
#endif

            if (title != null)
            {
                titleColor = title.color;
                disabledTitleColor = titleColor * .75f;
                disabledTitleColor.a = 1;
            }

            if (!initialize)
                return;

            dropdown.ClearOptions();

            Initialize();

            dropdown.AddOptions(options);
            dropdown.value = index;
            dropdown.RefreshShownValue();
        }

        protected void ToggleInteractible(bool value)
        {
            dropdown.interactable = value;

            if (title != null)
                title.color = value ? titleColor : disabledTitleColor;
        }
    }
}