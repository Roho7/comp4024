using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    [HideInInspector] public TMPro.TextMeshProUGUI ScoreText;

    public int score = 0;
    void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMPro.TextMeshProUGUI>();
    }
    public void UpdateScore()
    {
        score += 1;
        ScoreText.text = score.ToString();
    }
    public void UpdateScoreBy(int i)
    {
        if (i < 0 || score == int.MaxValue)
        {
            return;
        }

        score += i;
        ScoreText.text = score.ToString();
    }

}
