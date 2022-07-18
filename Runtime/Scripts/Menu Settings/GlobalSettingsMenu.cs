using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heartfield
{
    [CreateAssetMenu(fileName = "New Global Settings Asset", menuName = "Heartfield Productions/Settings/Global Settings Asset")]
    public sealed class GlobalSettingsMenu : ScriptableObject
    {
        public static void QuitApplication()
        {
            Application.Quit();
        }
    }
}