namespace Heartfield.Utils
{
    public static class UnitsConversion
    {
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
        public static float MmToInch(float value) => value * 0.039f;

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
        public static float CmToInch(float value) => value * 0.393f;

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
        public static float InchToMeter(float value) => value * 0.025f;

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
        public static float KmhToMph(float value) => value * 0.621f;
        /// <summary>
        /// divide the speed value by 3.6
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float KmhToMs(float value) => value * 0.277f;
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
        /// (value - 32) * 1.8
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float FahrenheitToCelsius(float value) => (value - 32) * 1.8f;

        /// <summary>
        /// value / 1.341
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float HpToKw(float value) => value * .745f;
        /// <summary>
        /// value * 1.341
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float KwToHp(float value) => value * 1.341f;

        /// <summary>
        /// value * 1.356
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float FtlbToNm(float value) => value * 1.356f;

        /// <summary>
        /// value * 0.070307
        /// </summary>
        /// <param name="value"></param>
        /// <returns>PSI converted to Kg</returns>
        public static float PsiToKg(float value) => value * .070307f;

        /// <summary>
        /// value * 14.223
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float KgToPsi(float value) => value * 14.223f;
    }
}