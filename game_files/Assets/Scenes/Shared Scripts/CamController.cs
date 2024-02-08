using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float moveSpeed;
    [Range(0, 1)]
    public float smoothTime;

    public Transform player;
    public void FixedUpdate()
    {
        Vector3 playerPos = GetComponent<Transform>().position;

        playerPos.x = player.position.x;
        playerPos.y = player.position.y;

        GetComponent<Transform>().position = playerPos;
    }
}
