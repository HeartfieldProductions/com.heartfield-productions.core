namespace Heartfield.Utils
{
    public partial struct UnitsConversion
    {
        const float PI = 3.14159274f;

        /// <summary>
        /// divide the length value by 10
        /// </summary>
        public static float MmToCm(float value) => value * .1f;

        /// <summary>
        /// divide the length value by 1000
        /// </summary>
        public static float MmToMeter(float value) => value * .001f;

        /// <summary>
        /// divide the length value by 25.4
        /// </summary>
        public static float MmToInch(float value) => value * 0.039f;

        /// <summary>
        /// multiply the length value by 10
        /// </summary>
        public static float CmToMm(float value) => value * 10f;

        /// <summary>
        /// divide the length value by 100
        /// </summary>
        public static float CmToMeter(float value) => value * .01f;

        /// <summary>
        /// divide the length value by 2.54
        /// </summary>
        public static float CmToInch(float value) => value * 0.393f;

        /// <summary>
        /// multiply the length value by 1000
        /// </summary>
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
        public static float MeterToInch(float value) => value * 39.37f;

        /// <summary>
        /// multiply the length value by 25.4
        /// </summary>
        public static float InchToMm(float value) => value * 25.4f;

        /// <summary>
        /// multiply the length value by 2.45
        /// </summary>
        public static float InchToCm(float value) => value * 2.54f;

        /// <summary>
        /// divide the length value by 39.37
        /// </summary>
        public static float InchToMeter(float value) => value * 0.025f;

        /// <summary>
        /// multiply the length value by 3.281
        /// </summary>
        public static float MeterToFoot(float value) => value * 3.281f;

        /// <summary>
        /// multiply the speed value by 3.6
        /// </summary>
        public static float MsToKmh(float value) => value * 3.6f;

        /// <summary>
        /// multiply the speed value by 2.237
        /// </summary>
        public static float MsToMph(float value) => value * 2.237f;

        /// <summary>
        /// for an approximate result, divide the speed value by 1.609
        /// </summary>
        public static float KmhToMph(float value) => value * 0.621f;

        /// <summary>
        /// divide the speed value by 3.6
        /// </summary>
        public static float KmhToMs(float value) => value * 0.277f;

        /// <summary>
        /// for an approximate result, multiply the speed value by 1.609
        /// </summary>
        public static float MphToKmh(float value) => value * 1.609f;

        /// <summary>
        /// (value * 1.8) + 32
        /// </summary>
        public static float CelsiusToFahrenheit(float value) => (value * 1.8f) + 32f;

        /// <summary>
        /// value + 237.3
        /// </summary>
        public static float CelsiusToKelvin(float value) => value + 237.3f;

        /// <summary>
        /// (value - 32) * 1.8
        /// </summary>
        public static float FahrenheitToCelsius(float value) => (value - 32) * 1.8f;

        /// <summary>
        /// value / 1.341
        /// </summary>
        public static float HpToKw(float value) => value * .745f;

        /// <summary>
        /// value * 1.341
        /// </summary>
        public static float KwToHp(float value) => value * 1.341f;

        /// <summary>
        /// value * 1.356
        /// </summary>
        public static float FtlbToNm(float value) => value * 1.3558f;

        /// <summary>
        /// value / 1.356
        /// </summary>
        public static float NmToFtlb(float value) => value * .7375f;

        /// <summary>
        /// value * 0.0018
        /// </summary>
        public static float FtlbToHp(float value) => value * .0018f;

        /// <summary>
        /// value * 8.851
        /// </summary>
        public static float LbInToNm(float value) => value * 8.851f;

        /// <summary>
        /// value * 0.070307
        /// </summary>
        public static float PsiToKg(float value) => value * .070307f;

        /// <summary>
        /// value * 14.223
        /// </summary>
        public static float KgToPsi(float value) => value * 14.223f;

        /// <summary>
        /// value * 100000
        /// </summary>
        public static float BarToPascal(float value) => value * 100000f;

        /// <summary>
        /// rpm * (PI / 30)
        /// </summary>
        public static float RpmToRad(float rpm) => rpm * PI * .0333f;

        /// <summary>
        /// rad * (30 / PI)
        /// </summary>
        public static float RadToRpm(float rad) => rad * 9.549f;

        /// <summary>
        /// rpm / 60
        /// </summary>
        public static float RpmToHz(float value) => value * .0166f;

        /// <summary>
        /// Hz * 60
        /// </summary>
        public static float HzToRpm(float value) => value * 60f;

        /// <summary>
        /// rpm / 60
        /// </summary>
        public static float RpmToRps(float value) => value * .0166f;

        /// <summary>
        /// 1.36 * PI * rpm * torque / (30 * 1000);
        /// </summary>
        /// <param name="torque">Nm</param>
        /// <param name="rpm"></param>
        /// <returns></returns>
        public static float TorqueNmToPowerHp(float torque, float rpm) => 1.36f * PI * rpm * torque * .333e-4f;

        /// <summary>
        /// PI * rpm * torque / (30 * 1000);
        /// </summary>
        /// <param name="torque">Nm</param>
        /// <param name="rpm"></param>
        /// <returns></returns>
        public static float TorqueNmToPowerKw(float torque, float rpm) => PI * rpm * torque * .333e-4f;
    }
}