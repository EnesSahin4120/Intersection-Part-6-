using UnityEngine;

public class Ray_Triangle_Test : MonoBehaviour
{
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private Transform rayDirection;

    [SerializeField] private Transform triangle_v0;
    [SerializeField] private Transform triangle_v1;
    [SerializeField] private Transform triangle_v2; 

    private bool isIntersect;

    private void Update()
    {
        Coordinates rayOriginCoord = new Coordinates(rayOrigin.position.x, rayOrigin.position.y, rayOrigin.position.z);
        Coordinates rayDirCoord = new Coordinates(rayDirection.position.x, rayDirection.position.y, rayDirection.position.z);
        Line _ray = new Line(rayOriginCoord, rayDirCoord, Line.LINETYPE.RAY);

        Coordinates triangle_v0_Coord = new Coordinates(triangle_v0.position.x, triangle_v0.position.y, triangle_v0.position.z);
        Coordinates triangle_v1_Coord = new Coordinates(triangle_v1.position.x, triangle_v1.position.y, triangle_v1.position.z);
        Coordinates triangle_v2_Coord = new Coordinates(triangle_v2.position.x, triangle_v2.position.y, triangle_v2.position.z);
        Triangle _triangle = new Triangle(triangle_v0_Coord, triangle_v1_Coord, triangle_v2_Coord);

        isIntersect = Mathematics.IsIntersectRay_Triangle(_ray, _triangle);

        Debug.DrawLine(triangle_v0_Coord.ToVector(), triangle_v1_Coord.ToVector(), Color.red);
        Debug.DrawLine(triangle_v0_Coord.ToVector(), triangle_v2_Coord.ToVector(), Color.red);
        Debug.DrawLine(triangle_v1_Coord.ToVector(), triangle_v2_Coord.ToVector(), Color.red);

        if (isIntersect)
            Debug.DrawLine(rayOriginCoord.ToVector(), rayDirCoord.ToVector(), Color.red);
        else
            Debug.DrawLine(rayOriginCoord.ToVector(), rayDirCoord.ToVector(), Color.green);
    }
}
