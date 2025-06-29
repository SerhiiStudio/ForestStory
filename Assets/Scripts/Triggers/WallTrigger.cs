using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class WallTrigger : MonoBehaviour
{
    [Header("Wall Behavior Settings")]
    [SerializeField] protected float distanceAddToDisplacement = 0.0f;
    [SerializeField] protected float dotProductThreshold = 0.8f;

    protected CircleCollider2D _collider;
    protected Vector3 enterPosition;
    protected Vector3 enterDirection;

    protected virtual void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsPlayer(other)) return;

        enterPosition = other.transform.position;
        enterDirection = transform.position - enterPosition;
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (!IsPlayer(other)) return;
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (!IsPlayer(other)) return;

        Vector3 currentPos = other.transform.position;

        if (currentPos.x != enterPosition.x)
        {
            Vector3 currentDirection = transform.position - currentPos;

            float additionalDistance = distanceAddToDisplacement;
            if (currentDirection.x > 0) additionalDistance *= -1;

            if (Vector3.Dot(currentDirection, enterDirection) > dotProductThreshold)
            {
                Vector3 displacementTarget = new Vector3(enterPosition.x + additionalDistance, enterPosition.y);
                
                SetPlayerBlocked(true);
                OnBlocked(other, displacementTarget);
            }
            else
            {
                SetPlayerBlocked(false);
            }
        }
    }


    protected virtual void OnBlocked(Collider2D player, Vector3 displacementTarget)
    {
        if(player.gameObject.TryGetComponent<PlayerTransformReference>(out PlayerTransformReference playerTransform))
            playerTransform.TransformReference.position = displacementTarget;
    }

    protected virtual bool IsPlayer(Collider2D collider)
    {
        return collider.CompareTag("Player");
    }

    protected virtual void SetPlayerBlocked(bool isBlocked)
    {
        PlayerMain.Instance.SetIfRestrictedByBoundary(isBlocked);
    }
}
