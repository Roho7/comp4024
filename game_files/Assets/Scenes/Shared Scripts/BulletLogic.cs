using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public float life = 3;
    void Awake()
    {
        Destroy(gameObject, life);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null)
        {
            Debug.Log("No collision");
        }
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
