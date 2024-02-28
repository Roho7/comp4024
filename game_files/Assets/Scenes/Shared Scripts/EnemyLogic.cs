using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [Header("Enemy Settings")]
    [HideInInspector] public Rigidbody2D enemy;
    [Range(0.01f, 0.1f)] public float speed = 0.1f;
    [Range(0, 10)] public float jumpforce = 5;
    [Range(0f, 10f)] public float moveInterval = 5f;
    float moveTimer = 0;

    int direction = -1;


    void Update()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer > moveInterval)
        {
            speed *= -1;
            moveTimer = 0f;
            direction *= -1;
        }

        enemy.velocity = new Vector2(speed, 0);
        enemy.transform.localScale = new Vector3(direction, 1, 1);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Collision with bullet");
            Destroy(gameObject);
        }
    }
}
