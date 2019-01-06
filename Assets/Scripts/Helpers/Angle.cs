using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle {
    static public float AngleBetweenVector2(Vector2 a, Vector2 b)
    {
        Vector2 diference = b - a;
        float sign = (b.y < a.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
}
