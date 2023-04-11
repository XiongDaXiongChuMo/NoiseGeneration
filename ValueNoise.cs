namespace NoiseGeneration
{
    public class ValueNoise : NoiseGenerator
    {
        public bool useSmotherStep = false;

        public ValueNoise(int seed) : base(seed) { }

        public override float Evaluate(Vector2 sample)
        {
            int xFloored = FastFloor(sample.x);
            int yFloored = FastFloor(sample.y);

            float[] gridValues =
            {
                GetValueAtCoord(xFloored, yFloored),
                GetValueAtCoord(xFloored + 1, yFloored),
                GetValueAtCoord(xFloored, yFloored + 1),
                GetValueAtCoord(xFloored + 1, yFloored + 1),
            };

            float tx = sample.x - xFloored;
            float ty = sample.y - yFloored;

            System.Func<float, float, float, float> interpolation = Interpolation.SmoothStep;
            if (useSmotherStep) interpolation = Interpolation.SmootherStep;

            return interpolation(ty,
                    interpolation(tx, gridValues[0], gridValues[1]),
                    interpolation(tx, gridValues[2], gridValues[3])
                );
        }

        private float GetValueAtCoord(int x, int y)
        {
            byte[] xUnpacked = UnpackValue(x << 3);
            byte[] yUnpacked = UnpackValue(y << 7);
            
            int index = (
                xUnpacked[0] ^ xUnpacked[1] ^ xUnpacked[2] ^ xUnpacked[2] ^ 
                yUnpacked[0] ^ yUnpacked[1] ^ yUnpacked[2] ^ yUnpacked[2]) % SourceSize;

            return random[index] / 255f * 2f - 1;
        }
    }
}
