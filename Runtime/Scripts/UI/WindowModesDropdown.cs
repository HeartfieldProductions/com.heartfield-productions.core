using UnityEngine;

namespace Heartfield.UI
{
    public sealed class WindowModesDropdown : DropdownOptionsBase
    {
        protected override void Awake()
        {
            initialize = false;

            base.Awake();

            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            dropdown.value = (int)Screen.fullScreenMode;
            dropdown.RefreshShownValue();
        }

        protected override void Initialize() { }

        public void ToggleResolutionsOptions()
        {
            ToggleInteractible(dropdown.value != 0);
        }
    }
}