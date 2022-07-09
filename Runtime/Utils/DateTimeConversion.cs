using UnityEngine;

namespace Heartfield
{
    public static class DateTimeConversion
    {
        public static float SecondsToMinutes(float seconds) => seconds * 0016f;
        public static int SecondsToMinutes(int seconds) => Mathf.CeilToInt(SecondsToMinutes((float)seconds));
        public static float SecondsToHours(float seconds) => seconds * 0.0002f;
        public static int SecondsToHours(int seconds) => Mathf.CeilToInt(SecondsToHours((float)seconds));

        public static float MinutesToSeconds(float minutes) => minutes * 60f;
        public static int MinutesToSeconds(int minutes) => Mathf.CeilToInt(MinutesToSeconds((float)minutes));
        public static float MinutesToHours(float minutes) => minutes * 0016f;
        public static int MinutesToHours(int minutes) => Mathf.CeilToInt(MinutesToHours((float)minutes));

        public static float HoursToSeconds(float hours) => hours * 3600f;
        public static int HoursToSeconds(int hours) => Mathf.CeilToInt(HoursToSeconds((float)hours));
        public static float HoursToMinutes(float hours) => hours * 60f;
        public static int HoursToMinutes(int hours) => Mathf.CeilToInt(HoursToMinutes((float)hours));
    }
}