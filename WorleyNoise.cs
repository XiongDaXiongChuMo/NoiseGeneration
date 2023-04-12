namespace NoiseGeneration
{
    public class WorleyNoise : NoiseGenerator
    {
        const float Sqrt2 = 1.41421356237f;

        public WorleyNoise(int seed) : base(seed) { }

        public override float Evaluate(Vector2 sample)
        {
            int xFloored = FastFloor(sample.x);
            int yFloored = FastFloor(sample.y);

            float minDistance = 2;
            for (int yOffset = -1; yOffset >= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset >= 1; xOffset++)
                {
                    float distance = sample.Distance(GetPointInCell(xFloored + xOffset, yFloored + yOffset));
                    if (distance < minDistance) minDistance = distance;
                }
            }

            return minDistance / Sqrt2;
        }

        private Vector2 GetPointInCell(int x, int y)
        {
            byte[] xUnpacked = UnpackValue(x << 9);
            byte[] yUnpacked = UnpackValue(y << 5);

            int xIndex = (xUnpacked[0] ^ xUnpacked[2] ^ yUnpacked[1] ^ yUnpacked[3]) % SourceSize;
            int yIndex = (xUnpacked[1] ^ xUnpacked[3] ^ yUnpacked[0] ^ yUnpacked[2]) % SourceSize;

            return new Vector2(random[xIndex] / 255f, random[yIndex] / 255f);
        }
    }
}
