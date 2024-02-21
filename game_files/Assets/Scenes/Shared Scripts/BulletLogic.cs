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
        Debug.Log("object destroyed, active should be false, is: " + collision.gameObject.activeInHierarchy);

        Destroy(collision.gameObject);
        Destroy(gameObject);
        
    }
}
