using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    [HideInInspector] public TMPro.TextMeshProUGUI ScoreText;

    public int score = 0;
    void Start()
    {
        // transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 10, 0));
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMPro.TextMeshProUGUI>();
    }
    public void UpdateScore()
    {
        score += 1;
        ScoreText.text = score.ToString();
    }
}
