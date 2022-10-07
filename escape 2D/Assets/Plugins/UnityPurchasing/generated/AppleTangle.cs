#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class AppleTangle
    {
        private static byte[] data = System.Convert.FromBase64String("MJw6FMWjla1AiJoxyhvZ5E/MB5D36+Kn1ejo86fExreZkIq3sbeztevip87p5Km2obejgYTSg4yUmsb3B5OsV+7AE/GOeXPsCqnHIXDAyvgyvSpziImHFYw2ppGp81K7ilzlkfXm5PPu5OKn9PPm8+Lq4unz9Km3LCT2FcDU0kYoqMY0f3xk90phJMunxMa3BYalt4qBjq0BzwFwioaGhtXi6+7m6eTip+jpp/Pv7vSn5OL1tLHdt+W2jLeOgYTSg4GUhdLUtpSht6OBhNKDjJSaxvf36+KnxOL18wyeDll+zOtygCylt4Vvn7l/145UgbeIgYTSmpSGhniDgreEhoZ4t5rl6+Kn9PPm6ePm9eOn8+L16vSn5uAIjzOncEwrq6fo9zG4hrcLMMRIgGv6vgQM1KdUv0M2OB3Ijex4rHv9twWG8beJgYTSmoiGhniDg4SFhpgWXJnA12yCatn+A6pssSXQy9Jr7uHu5Obz7ujpp8by8+/o9e7z/raKgY6tAc8BcIqGhoKCh4QFhoaH26nHIXDAyviP2beYgYTSmqSDn7eRiBq6dKzOr51PeUkyPole2ZtRTLovW/mlsk2iUl6IUexTJaOklnAmK/Pv6PXu8/62kbeTgYTSg4SUisb3wvmYy+zXEcYOQ/PljJcExgC0DQb4xi8fflZN4Ruj7JZXJDxjnK1EmP6n5vT08uri9Kfm5OTi9/Pm6eTij6yBhoKCgIWGkZnv8/P39L2oqPCRt5OBhNKDhJSKxvf36+Kn1ejo8xIZ/YsjwAzcU5GwtExDiMpJk+5WrQHPAXCKhoaCgoe35baMt46BhNKjZWxWMPdYiMJmoE126v9qYDKQkPfr4qfE4vXz7uHu5Obz7ujpp8by3iCCjvuQx9GWmfNUMAykvMAkUujp46fk6Onj7vPu6On0p+jhp/L04qi3BkSBj6yBhoKCgIWFtwYxnQY0j9m3BYaWgYTSmqeDBYaPtwWGg7e3loGE0oONlI3G9/fr4qfO6eSpts5f8Ri0k+Im8BNOqoWEhoeGJAWGtwWDPLcFhCQnhIWGhYWGhbeKgY5esfhGANJeIB4+tcV8X1L2Gfkm1YOBlIXS1LaUt5aBhNKDjZSNxvf3srW2s7e0sd2QirSyt7W3vrW2s7dOnvVy2olS+NgcdaKEPdIIytqKdpgCBAKcHrrAsHUuHMcJq1M2F5Vf8PCp5vf36+Kp5OjqqOb39+vi5OY2t99r3YO1C+80CJpZ4vR44NniO7qh4KcNtO1wigVIWWwkqH7U7dzjsR7Lqv8wagscW3TwHHXxVfC3yEaBhNKaiYORg5OsV+7AE/GOeXPsCqfm6eOn5OL18+7h7uTm8+7o6af3OXP0HGlV44hM/sizXyW5fv947E+n6OGn8+/ip/Pv4umn5vf36+7k5gj0BudBnNyOqBU1f8PPd+e/GZJy47KkksyS3po0E3BxGxlI1z1G39fz7uHu5Obz4qfl/qfm6f6n9+b18wWGh4GOrQHPAXDk44KGtwZ1t62Bq6fk4vXz7uHu5Obz4qf36Ovu5P5H5LTwcL2Aq9FsXYimiV099J7IMoKHhAWGiIe3BYaNhQWGhodjFi6O1y0NUl1je1eOgLA38vKm");
        private static int[] order = new int[] { 59,6,3,32,23,46,24,13,38,38,10,16,29,42,21,51,28,51,28,47,31,22,54,46,25,51,40,35,29,29,51,53,46,52,43,37,52,38,38,59,58,46,42,47,49,52,58,56,48,51,52,52,58,55,55,59,56,58,58,59,60 };
        private static int key = 135;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
