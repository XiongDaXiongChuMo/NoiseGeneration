namespace NoiseGeneration
{
    internal static class Interpolation
    {
        public static float LinearLerp(float t, float a, float b)
        {
            if (t <= 0) return a;
            if (t >= 1) return b;

            return a * (1 - t) + b * t;
        }

        public static float SmoothStep(float t, float a, float b) => LinearLerp(t * t * (3 - 2 * t), a, b);

        public static float SmootherStep(float t, float a, float b) => LinearLerp(t * t * t * (t * (t * 6 - 15) + 10), a, b);
    }
}
