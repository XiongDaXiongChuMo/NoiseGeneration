namespace NoiseGeneration
{
    public class PerlinNoise : NoiseGenerator
    {
        public bool useSmotherStep = false;

        public PerlinNoise(int seed) : base(seed) { }

        public override float Evaluate(Vector2 sample)
        {
            int xFloored = FastFloor(sample.x);
            int yFloored = FastFloor(sample.y);

            float[] perlinValues = 
            {
                GetVectorAtPoint(xFloored    , yFloored    ).Dot(new Vector2(xFloored    , yFloored    )),
                GetVectorAtPoint(xFloored + 1, yFloored    ).Dot(new Vector2(xFloored + 1, yFloored    )),
                GetVectorAtPoint(xFloored    , yFloored + 1).Dot(new Vector2(xFloored    , yFloored + 1)),
                GetVectorAtPoint(xFloored + 1, yFloored + 1).Dot(new Vector2(xFloored + 1, yFloored + 1)),
            };

            float tx = sample.x - xFloored;
            float ty = sample.y - yFloored;

            System.Func<float, float, float, float> interpolation = Interpolation.SmoothStep;
            if (useSmotherStep) interpolation = Interpolation.SmootherStep;

            return interpolation(ty,
                    interpolation(tx, perlinValues[0], perlinValues[1]),
                    interpolation(tx, perlinValues[2], perlinValues[3])
                );
        }

        private Vector2 GetVectorAtPoint(int x, int y)
        {
            byte[] xUnpacked = UnpackValue(x << 3);
            byte[] yUnpacked = UnpackValue(y << 7);

            int index = (
                xUnpacked[0] ^ xUnpacked[1] ^ xUnpacked[2] ^ xUnpacked[3] ^
                yUnpacked[0] ^ yUnpacked[1] ^ yUnpacked[2] ^ yUnpacked[3]) % SourceSize;

            float radians = MathF.PI * (random[index] / 255f * 2f - 1);

            return new Vector2(MathF.Cos(radians), MathF.Sin(radians));
        }
    }
}
