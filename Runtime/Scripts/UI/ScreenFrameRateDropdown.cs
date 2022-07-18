using UnityEngine;
using Heartfield.SettingsMenu;

namespace Heartfield.UI
{
    public sealed class ScreenFrameRateDropdown : DropdownOptionsBase
    {
        protected override void Initialize()
        {
            var refreshRate = Screen.currentResolution.refreshRate;
            var ratesTable = VideoSettingsMenu.frameRatesTable;

            options.Add("Ilimitado");

            for (int i = 1; i < ratesTable.Length; i++)
            {
                int frameRate = ratesTable[i];

                if (frameRate > refreshRate)
                    break;

                string displayName = $"{frameRate} FPS";
                options.Add(displayName);

                if (frameRate == refreshRate)
                {
                    index = i;
                    VideoSettingsMenu.SetFrameRate(i);
                }
            }
        }
    }
}