namespace Heartfield.Utils
{
    public static class UnitsConversion
    {
        const float mmToInchFraction = 1f / 25.4f;
        const float cmToInchFraction = 1f / 2.54f;
        const float inchToMeterFraction = 1f / 39.37f;
        const float kmhToMphFraction = 1f / 1.609f;
        const float kmhToMsFraction = 1f / 3.6f;
        const float fToCfraction = 9f / 5f;
        const float HpToKwFraction = 1f / 1.341f;

        /// <summary>
        /// divide the length value by 10
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float MmToCm(float value) => value * .1f;
        /// <summary>
        /// divide the length value by 1000
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float MmToMeter(float value) => value * .001f;
        /// <summary>
        /// divide the length value by 25.4
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float MmToInch(float value) => value * mmToInchFraction;

        /// <summary>
        /// multiply the length value by 10
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float CmToMM(float value) => value * 10f;
        /// <summary>
        /// divide the length value by 100
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float CmToMeter(float value) => value * .01f;
        /// <summary>
        /// divide the length value by 2.54
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float CmToInch(float value) => value * cmToInchFraction;

        /// <summary>
        /// multiply the length value by 1000
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float MeterToMm(float value) => value * 1000f;
        /// <summary>
        /// multiply the length value by 100
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float MeterToCm(float value) => value * 100f;
        /// <summary>
        /// multiply the length value by 39.37
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float MeterToInch(float value) => value * 39.37f;

        /// <summary>
        /// multiply the length value by 25.4
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float InchToMm(float value) => value * 25.4f;
        /// <summary>
        /// multiply the length value by 2.45
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float InchToCm(float value) => value * 2.54f;
        /// <summary>
        /// divide the length value by 39.37
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float InchToMeter(float value) => value * inchToMeterFraction;

        /// <summary>
        /// multiply the speed value by 3.6
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float MsToKmh(float value) => value * 3.6f;
        /// <summary>
        /// multiply the speed value by 2.237
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float MsToMph(float value) => value * 2.237f;
        /// <summary>
        /// for an approximate result, divide the speed value by 1.609
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float KmhToMph(float value) => value * kmhToMphFraction;
        /// <summary>
        /// divide the speed value by 3.6
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float KmhToMs(float value) => value * kmhToMsFraction;
        /// <summary>
        /// for an approximate result, multiply the speed value by 1.609
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float MphToKmh(float value) => value * 1.609f;

        /// <summary>
        /// (value * 1.8) + 32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float CelsiusToFahrenheit(float value) => (value * 1.8f) + 32f;
        /// <summary>
        /// (value - 32) * (5/9)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float FahrenheitToCelsius(float value) => (value - 32) * fToCfraction;

        public static float HpToKw(float value) => value * HpToKwFraction;
        public static float KwToHp(float value) => value * 1.341f;

        public static float FtlbToNm(float value) => value * 1.356f;
    }
}