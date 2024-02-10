using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionAreaLogic : MonoBehaviour
{
    public Text questionText;
    public Text instructionText;
    public GameObject textInputFieldHolder;
    public string question = "";
    private string instruction = "";

    void Start()
    {
        textInputFieldHolder = GameObject.FindGameObjectWithTag("InputField");
        questionText = GameObject.FindGameObjectWithTag("Question").GetComponent<Text>();
        instructionText = GameObject.FindGameObjectWithTag("InGameInstruction").GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        // Check if the entering collider is the player
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Player entered the question area.");

            // Check if the questionText reference is not null
            if (questionText != null)
            {
                // Set the UI Text component's text to the question
                questionText.text = question;
                textInputFieldHolder.SetActive(true);
                instruction = "Press 'E' to answer the question.";
                instructionText.text = instruction;
            }
            else
            {
                Debug.LogError("The 'questionText' reference is not assigned in the inspector.");
            }


            // if (Input.GetKeyDown(KeyCode.E))
            // {
            //     textInputFieldHolder.SetActive(true);
            // }
        }
    }

    void OnTriggerExit2D(Collider2D player)
    {
        // Check if the entering collider is the player
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Player exited the question area.");

            // Check if the questionText reference is not null
            if (questionText != null)
            {
                // Set the UI Text component's text to the question
                questionText.text = "";
                textInputFieldHolder.SetActive(false);
                instruction = "";
                instructionText.text = instruction;


            }
            else
            {
                Debug.LogError("The 'questionText' reference is not assigned in the inspector.");
            }
        }
    }
}
