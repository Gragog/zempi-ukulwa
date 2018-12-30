using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Ext { 
    public static Vector2 ToVector2(this Vector3 v3)
    {
        return new Vector2(v3.x, v3.y);
    }
}
