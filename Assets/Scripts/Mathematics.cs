using UnityEngine;

public class Mathematics : MonoBehaviour
{
    static public float Square(float grade)
    {
        return grade * grade;
    }

    static public float Distance(Coordinates coord1, Coordinates coord2)
    {
        float diffSquared = Square(coord1.x - coord2.x) +
            Square(coord1.y - coord2.y) +
            Square(coord1.z - coord2.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;
    }

    static public float VectorLength(Coordinates vector)
    {
        float length = Distance(new Coordinates(0, 0, 0), vector);
        return length;
    }

    static public Coordinates Normalize(Coordinates vector)
    {
        float length = VectorLength(vector);
        vector.x /= length;
        vector.y /= length;
        vector.z /= length;

        return vector;
    }

    static public float Dot(Coordinates vector1, Coordinates vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
    }

    static public Coordinates Projection(Coordinates vector1, Coordinates vector2)
    {
        float numeratorPart = Dot(vector1, vector2);
        float vector2Length = VectorLength(vector2);
        float denominatorPart = Square(vector2Length);
        Coordinates resultCoordinate = new Coordinates(vector2.x * (numeratorPart / denominatorPart), vector2.y * (numeratorPart / denominatorPart), vector2.z * (numeratorPart / denominatorPart));

        return resultCoordinate;
    }

    static public Coordinates Cross(Coordinates vector1, Coordinates vector2)
    {
        float i = vector1.y * vector2.z - vector1.z * vector2.y;
        float j = vector1.z * vector2.x - vector1.x * vector2.z;
        float k = vector1.x * vector2.y - vector1.y * vector2.x;

        Coordinates resultCoordinates = new Coordinates(i, j, k);
        return resultCoordinates;
    }

    static public bool IsIntersectRay_Triangle(Line ray, Triangle triangle)
    {
        float u,v,t;

        Coordinates e1 = triangle.v1 - triangle.v0;
        Coordinates e2 = triangle.v2 - triangle.v0;
        Coordinates p = Cross(ray.v, e2);
        float denominator = Dot(e1, p);

        if (denominator == 0)
            return false;

        float f = 1.0f / denominator;

        Coordinates s = ray.A - triangle.v0;
        u = f * Dot(s, p);
        if (u < 0f || u > 1f) 
            return false;

        Coordinates q = Cross(s, e1);
        v = f * Dot(ray.v, q);
        if (v < 0f || u + v > 1f)
            return false;

        t = f * Dot(e2, q);
        return t >= 0f;
    }
}
