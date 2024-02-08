using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed = 0.01f;
    public float jumpforce = 5;
    private bool hasJumped = false;



    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {

        hasJumped = false;

    }
    void Update()
    {

        {
            if (Input.GetKey(KeyCode.W) && !hasJumped)
            {
                player.velocity = Vector3.up * jumpforce;
                hasJumped = true;
            }
            // if (Input.GetKey(KeyCode.S))
            // {
            //     player.transform.position += new Vector3(0, -speed, 0);
            // }
            if (Input.GetKey(KeyCode.A))
            {
                player.transform.position += new Vector3(-speed, 0, 0);
                player.transform.localScale = new Vector3(1, 1, 1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                player.transform.position += new Vector3(speed, 0, 0);
                player.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}