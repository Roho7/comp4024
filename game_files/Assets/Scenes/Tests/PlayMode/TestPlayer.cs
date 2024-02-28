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
        SceneManager.LoadScene("Assets/Scenes/Levels/Level Leo Test.unity", LoadSceneMode.Single);
    }

    [UnityTest]
    public IEnumerator TestPlayerJump()
    {
        
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();

        playerLogic.HandleJump();
        yield return null;

        Assert.AreEqual(Vector3.up * playerLogic.jumpForce, player.velocity);
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
        yield return null;

        Assert.AreEqual(player.transform.localScale, new Vector3(1, 1, 1));

    }
}
