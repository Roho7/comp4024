using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [Header("Enemy Settings")]
    [HideInInspector] public Rigidbody2D enemy;
    [Range(0.01f, 1.0f)] public float speed = 0.1f;
    [Range(0, 10)] public float jumpforce = 5;
    [Range(0f, 10f)] public float moveInterval = 5f;
    [HideInInspector] public ScoreLogic scoreLogic;
    float moveTimer = 0;

    AudioScript audio;

    AudioScript audio;

    int direction = -1;

    void Start()
    {
        scoreLogic = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreLogic>();
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioScript>();

    }
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
            audio.PlaySFX(audio.scoreSound);
            Destroy(gameObject);
            scoreLogic.UpdateScore();
            Destroy(gameObject);
        }
    }
}
