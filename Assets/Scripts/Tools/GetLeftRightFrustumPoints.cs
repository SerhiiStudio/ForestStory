using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GetLeftRightFrustumPoints
{
    public static Vector2 GetLeftRightWorldBounds(Camera cam)
    {
        float height = cam.orthographicSize * 2;
        float width = height * cam.aspect;

        Vector2 camPos = cam.transform.position;

        float left = camPos.x - width / 2f;
        float right = camPos.x + width / 2f;

        return new Vector2(left, right);
    }

}
