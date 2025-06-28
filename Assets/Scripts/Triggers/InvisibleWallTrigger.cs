using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class InvisibleWallTrigger : MonoBehaviour
{
    protected CircleCollider2D _collider;
    protected float distanceToDisplacePlayerAwayOfColliderRadius = 0.1f;
    protected float dotProductTreshold = 0.8f;

    protected Vector3 enterPosition;
    protected Vector3 enterDirection;

    protected bool activated;


    protected void OnTriggerEnter2D(Collider2D other)
    {
        enterPosition = other.transform.position;
        enterDirection = transform.position - enterPosition;
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        Vector3 exitDirection = transform.position - other.transform.position;

        activated = Vector3.Dot(enterDirection, exitDirection) < 0;
    }

    protected void OnTriggerStay2D(Collider2D other)
    {Debug.Log(11111);
        Vector3 currentPos = other.transform.position;
        if (currentPos.x != enterPosition.x)
        {
            Vector3 currentDirection = transform.position - currentPos;
            if(Vector3.Dot(currentDirection, enterDirection) > dotProductTreshold)
                other.transform.position = enterPosition;
            Debug.Log(Vector3.Dot(currentDirection, enterDirection));
        }
    }

}
