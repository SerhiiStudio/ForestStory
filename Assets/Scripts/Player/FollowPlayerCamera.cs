using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        if(player != null)
        {
            Vector3 targetPos = new Vector3(player.position.x, transform.position.y, transform.position.z);
            Vector3 pos = Vector3.Lerp(transform.position, targetPos, 1f * Time.deltaTime);
            transform.position = pos;
        }
    }
}
