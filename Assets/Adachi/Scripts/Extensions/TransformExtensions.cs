using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    #region Position Methods
    public static Transform ChangePosX(this Transform transform, float x)
    {
        var pos = transform.position;
        pos.x = x;
        transform.position = pos;
        return transform;
    }

    public static Transform ChangePosY(this Transform trandform, float y)
    {
        var pos = trandform.position;
        pos.y = y;
        trandform.position = pos;
        return trandform;
    }

    #endregion
}
