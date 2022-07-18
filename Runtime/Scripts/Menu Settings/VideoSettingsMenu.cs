using UnityEngine;

namespace Heartfield.SettingsMenu
{
    [CreateAssetMenu(fileName = "New Video Settings Asset", menuName = "Heartfield Productions/Settings/Video Settings Asset")]
    public sealed class VideoSettingsMenu : ScriptableObject
    {
        public static readonly int[] frameRatesTable = { -1, 30, 40, 50, 60, 120, 144, 240 };

#if UNITY_STANDALONE_OSX
        static readonly int[] windowModesTable = { 0, 1, 2 };
#else
        static readonly int[] windowModesTable = { 0, 1, 3 };
#endif

        public static void SetScreenResolution(int index)
        {
            var resolution = Screen.resolutions[index];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public static void SetFrameRate(int index)
        {
            Application.targetFrameRate = frameRatesTable[index];
        }

        public static void SetWindowMode(int index)
        {
            Screen.fullScreenMode = (FullScreenMode)windowModesTable[index];
            Screen.fullScreen = index < 2;
        }

        public static void SetMonitor(int index)
        {
             
        }
    }
}