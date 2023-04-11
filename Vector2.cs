namespace NoiseGeneration
{
    public struct Vector2
    {
        public float x;
        public float y;

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

        public static Vector2 operator +(Vector2 vector, Vector2 other) => new(vector.x + other.x, vector.y + other.y);
        public static Vector2 operator -(Vector2 vector, Vector2 other) => new(vector.x - other.x, vector.y - other.y);
        public static Vector2 operator *(Vector2 vector, float scalar) => new(vector.x * scalar, vector.y * scalar);
        public static Vector2 operator /(Vector2 vector, float quotient) => new(vector.x / quotient, vector.y / quotient);
    }
}
