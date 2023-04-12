namespace NoiseGeneration
{
    public struct Vector2
    {
        public float x;
        public float y;

        public float magnitude { get => MathF.Sqrt(x * x + y * y); }
        public Vector2 Normalized { get => this / magnitude; }


        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2 (float _x, float _y)
        {
            x = _x;
            y = _y;
        }

        public float Dot(Vector2 other) => x * other.x + y * other.y;
        public float Distance(Vector2 other)
        {
            float xDiff = x - other.x;
            float yDiff = y - other.y;

            return MathF.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        public static Vector2 operator +(Vector2 vector, Vector2 other) => new(vector.x + other.x, vector.y + other.y);
        public static Vector2 operator -(Vector2 vector, Vector2 other) => new(vector.x - other.x, vector.y - other.y);
        public static Vector2 operator *(Vector2 vector, float scalar) => new(vector.x * scalar, vector.y * scalar);
        public static Vector2 operator /(Vector2 vector, float quotient) => new(vector.x / quotient, vector.y / quotient);
    }
}
