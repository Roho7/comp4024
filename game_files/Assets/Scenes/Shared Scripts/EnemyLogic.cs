using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public Rigidbody2D enemy;
    public float speed = 0.1f;
    public float jumpforce = 5;
    public float moveInterval = 5f;
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
            Destroy(gameObject);
        }
    }
}
