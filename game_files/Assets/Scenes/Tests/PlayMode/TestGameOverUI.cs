using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TestGameOverUI
{


    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Assets/Scenes/Levels/testLevel.unity", LoadSceneMode.Single);
    }

   
    [UnityTest]
    public IEnumerator TestGameOverWhenPlayerDies()
    {
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();
        playerLogic.HandlePlayerDeath();
        var gameOverUI = GameObject.Find("GameOverUI");



        yield return null;

        Assert.IsTrue(gameOverUI.activeInHierarchy);
    }

    [UnityTest]
    public IEnumerator TestTimeScalePause()
    {
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();
        playerLogic.HandlePlayerDeath();
        var gameOverUI = GameObject.Find("GameOverUI");



        yield return null;

        Assert.AreEqual(Time.timeScale, 0f);
    }


    [UnityTest]
    public IEnumerator TestExitFunction()
    {
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();
        playerLogic.HandlePlayerDeath();

        GameOverUI gameOverUI = GameObject.FindAnyObjectByType<GameOverUI>(); 
        gameOverUI.exit();
        
        yield return null;

        Assert.AreEqual("MenuScreen", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator testRestartFunction()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();
        playerLogic.HandlePlayerDeath();

        GameOverUI gameOverUI = GameObject.FindAnyObjectByType<GameOverUI>();
        gameOverUI.restartLevel();

        yield return null;

        Assert.AreEqual(currentLevel, SceneManager.GetActiveScene().name);
    }



    [UnityTest]
    public IEnumerator TestNoBtn()
    {
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();
        playerLogic.HandlePlayerDeath();
        var gameOverUI = GameObject.Find("GameOverUI");
        Button button = GameObject.Find("NoBtn").GetComponent<Button>();
        button.onClick.Invoke();




        yield return null;

        Assert.AreEqual("MenuScreen", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator TestYesBtn()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();
        playerLogic.HandlePlayerDeath();
        var gameOverUI = GameObject.Find("GameOverUI");
        Button button = GameObject.Find("YesBtn").GetComponent<Button>();
        button.onClick.Invoke();




        yield return null;

        Assert.AreEqual(currentLevel, SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator TestTimeFrameRestAfterYes()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();
        playerLogic.HandlePlayerDeath();
        var gameOverUI = GameObject.Find("GameOverUI");
        Button button = GameObject.Find("YesBtn").GetComponent<Button>();
        button.onClick.Invoke();


        yield return null;

        Assert.AreEqual(1f, Time.timeScale);
    }

    [UnityTest]
    public IEnumerator TestTimeFrameRestAfterNo()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();
        playerLogic.HandlePlayerDeath();
        var gameOverUI = GameObject.Find("GameOverUI");
        Button button = GameObject.Find("NoBtn").GetComponent<Button>();
        button.onClick.Invoke();


        yield return null;

        Assert.AreEqual(1f, Time.timeScale);
    }


}
