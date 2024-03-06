using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestPlayer
{


    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Assets/Scenes/Levels/testLevel.unity", LoadSceneMode.Single);
    }

    [UnityTest]
    public IEnumerator TestPlayerJump()
    {

        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();

        playerLogic.HandleJump();
        yield return null;

        Assert.IsTrue(player.velocity.y > 0);
    }

    [UnityTest]
    public IEnumerator TestDoubleJump()
    {

        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();

        playerLogic.HandleJump();
        playerLogic.HandleJump();
        yield return null;

        Assert.IsTrue(player.velocity.y < (Vector3.up.y * playerLogic.jumpForce)) ;
    }

    [UnityTest]
    public IEnumerator TestPlayerLeft()
    {
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();

        playerLogic.HandleHorizontalMovement(-1);
        yield return null;

        Assert.AreEqual(player.transform.localScale, new Vector3(-1, 1, 1));

    }

    [UnityTest]
    public IEnumerator TestPlayerRight()
    {
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();

        playerLogic.HandleHorizontalMovement(1);
        playerLogic.HandleHorizontalMovement(1);
        playerLogic.HandleHorizontalMovement(1);
        playerLogic.HandleHorizontalMovement(1);
        playerLogic.HandleHorizontalMovement(1);
        new WaitForSeconds(10);

        yield return null;

        Assert.IsTrue(Time.timeScale==1f);

    }

    [UnityTest]
    public IEnumerator TestDeath()
    {
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();

        
        yield return null;

        Assert.AreEqual(player.transform.localScale, new Vector3(1, 1, 1));

    }

    [UnityTest]
    public IEnumerator testDeathCausesGameOver()
    {
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();
        playerLogic.HandlePlayerDeath();
        var gameOverUI = GameObject.Find("GameOverUI");



        yield return null;

        Assert.IsTrue(gameOverUI.activeInHierarchy);

    }
}
