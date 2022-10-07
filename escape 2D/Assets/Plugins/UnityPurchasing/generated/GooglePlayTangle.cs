#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("/ls8u5pqHaK2LAoC1XPQo3seUBwoBXpyFq9tTDjKK6SqYVl2F3/kMQb+gwnNNIoUtKxey8nhaaQIrihjPL+xvo48v7S8PL+/viHMZaaCLktnmV5aT5mDgO3Fg26NXqtZvR+kEX/z5YORJkwbCNmLPjFrwpUL0SR/wpdZpAcHt00fFocmzPmRmk2Oc8P2hw7+iJnGXLZ8NT7gGUOW6v8SnVJtklUXFO6OH4ty2dJRJOfBEZ8Cjjy/nI6zuLeUOPY4SbO/v7+7vr2dotB+BN0NLuR7+v5SjWzWqAFaBr+XN23nMr8mcp2liMxqWlhq1rMf4NWphvOwpHaYNvwSRj+Tk24xgeSh3XG6nsi28sRttzV7Jo6cHPvCtLd60hha+fltd7y9v76/");
        private static int[] order = new int[] { 2,7,3,7,10,13,11,9,13,9,13,12,12,13,14 };
        private static int key = 190;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
