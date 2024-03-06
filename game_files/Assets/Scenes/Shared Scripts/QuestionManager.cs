using UnityEngine;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour
{
    public TextAsset questionsJson;
    private List<Question> allQuestions;

    void Start()
    {
        LoadQuestions();
    }

    public void LoadQuestions()
    {
        QuestionsContainer questionsContainer = JsonUtility.FromJson<QuestionsContainer>(questionsJson.text);
        allQuestions = questionsContainer.questions;
    }

    // Class structure for JSON data
    [System.Serializable]
    public class Question
    {
        public int id;
        public string question;
        public string correctAnswer;
        public string hint;
        public int difficulty;
    }

    [System.Serializable]
    private class QuestionsContainer
    {
        public List<Question> questions;
    }

    // Random question based on difficulty
    public Question GetRandomQuestion(int difficulty)
    {
        List<Question> filteredQuestions = allQuestions.FindAll(q => q.difficulty == difficulty);
        if (filteredQuestions.Count > 0)
        {
            return filteredQuestions[Random.Range(0, filteredQuestions.Count)];
        }
        return null;
    }
}