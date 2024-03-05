using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionInteraction : MonoBehaviour
{ 

    public bool playerInZone = false;

    void OnTriggerEnter2D(Collider2D player)
    {
        // Check if the collider is the player
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Player entered the question area.");
            playerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D player)
    {
        // Check if the collider is the player
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Player exited the question area.");
            playerInZone = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
