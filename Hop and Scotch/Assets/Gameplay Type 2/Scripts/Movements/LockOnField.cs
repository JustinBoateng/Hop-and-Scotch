using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LockOnField
{
    
    public static void DrawRectangle(GameObject GB, Vector2 top_right_corner, Vector2 bottom_left_corner)
    {
        Vector2 center_offset = (top_right_corner + bottom_left_corner) * 0.5f; //midpoint of these two points

        Vector2 Displacement_Vector = top_right_corner - bottom_left_corner;

        float x_projection = Vector2.Dot(Displacement_Vector, Vector2.right);
        float y_projection = Vector2.Dot(Displacement_Vector, Vector2.up);

        Vector2 top_left_corner = new Vector2(-x_projection * 0.5f, y_projection * 0.5f) + center_offset;
        Vector2 bottom_right_corner = new Vector2(x_projection * 0.5f, -y_projection * 0.5f) + center_offset;

        Gizmos.DrawLine(top_right_corner, top_left_corner);
        Gizmos.DrawLine(top_left_corner, bottom_left_corner);
        Gizmos.DrawLine(bottom_left_corner, bottom_right_corner);
        Gizmos.DrawLine(bottom_right_corner, top_right_corner);

    }

}
