using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float moveSpeed;
    [Range(0, 1)]
    public float smoothTime;

    public Transform player;
    public float yOffset = 0.5f;
    public void Update()
    {
        if (!player)
        {
            Debug.Log("No player");
        }
        Vector3 playerTarget = new Vector3(player.position.x, player.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, playerTarget, smoothTime * Time.deltaTime);
    }
};
