using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ===============================
// Provide the answer to the question and the
// obstacle to be removed
// ===============================

public class SubmitAnswerLogic : MonoBehaviour
{
    private string input;
    public string correctAnswer;
    public GameObject obstacle;
    public void SubmitAnswer(string input)
    {
        if (input == correctAnswer)
        {
            Debug.Log("Correct answer!");
            obstacle.SetActive(false);
        }
        else
        {
            Debug.Log("Incorrect answer!");
        }
    }
}
