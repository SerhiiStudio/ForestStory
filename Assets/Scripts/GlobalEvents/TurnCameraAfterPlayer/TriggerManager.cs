using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform leftTrigger;
    [SerializeField] Transform rightTrigger;

    private void Update()
    {
        if (cam != null)
        {
            Vector2 coords = GetLeftRightFrustumPoints.GetLeftRightWorldBounds(cam);

            if (leftTrigger != null)
            {
                var leftPos = new Vector3(coords.x, cam.transform.position.y);
                leftTrigger.transform.position = leftPos;
            }

            if (rightTrigger != null)
            {
                var rightPos = new Vector3(coords.y, cam.transform.position.y);
                rightTrigger.transform.position = rightPos;
            }
        }
    }
}
