using UnityEngine;

namespace Heartfield.UI
{
    public sealed class ScreenResolutionsDropdown : DropdownOptionsBase
    {
        protected override void Initialize()
        {
            var resolutions = Screen.resolutions;

            for (int i = 0; i < resolutions.Length; i++)
            {
                var resolution = resolutions[i];

                string displayName = $"{resolution.width} x {resolution.height} {resolution.refreshRate} hz";
                options.Add(displayName);

                if (resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height)
                    index = i;
            }
        }
    }
}