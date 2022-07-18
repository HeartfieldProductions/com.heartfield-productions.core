using UnityEngine;

namespace Heartfield.UI
{
    public sealed class DisplayMonitorDropdown : DropdownOptionsBase
    {
        protected override void Initialize()
        {
            var monitors = Display.displays;

            for (int i = 0; i < monitors.Length; i++)
            {
                options.Add((i + 1).ToString("00"));

                if (Display.displays[i].active)
                    index = i;
            }

            ToggleInteractible(monitors.Length > 1);
        }
    }
}