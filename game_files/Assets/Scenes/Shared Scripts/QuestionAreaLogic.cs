using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public class QuestionAreaLogic : MonoBehaviour
{

    public bool isInZone = false;

    void OnTriggerEnter2D(Collider2D player)
    {
        // Check if the collider is the player
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Player entered the question area.");
            isInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D player)
    {
        // Check if the collider is the player
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Player exited the question area.");
            isInZone = false;
        }
    }
}
