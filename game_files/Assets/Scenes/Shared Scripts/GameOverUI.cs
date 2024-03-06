using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
   public void setup()
    {
        gameObject.SetActive(true);
    }

    public void restartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void exit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuScreen");
    }
   
}
