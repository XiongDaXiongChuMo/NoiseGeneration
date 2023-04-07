namespace NoiseGeneration
{
    internal abstract class NoiseGenerator
    {
        public int Seed { get; internal set; }

        public NoiseGenerator(int seed)
        {
            Seed = seed;
            Randomize();
        }

        internal abstract void Randomize();

        public abstract double Evaluate();
    }
}