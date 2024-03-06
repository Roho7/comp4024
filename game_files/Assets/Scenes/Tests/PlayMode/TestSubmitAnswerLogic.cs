using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestSubmitAnswerLogic
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Assets/Scenes/Levels/testLevel.unity", LoadSceneMode.Single);
    }

    [UnityTest]
    public IEnumerator TestEmptyInput()
    {

        var logic = GameObject.FindFirstObjectByType<SubmitAnswerLogic>();
        logic.correctAnswer = "test";
        logic.SubmitAnswer("");

        yield return null;

        Assert.IsTrue(logic.obstacle.activeInHierarchy);
    }

    [UnityTest]
    public IEnumerator TestIncorretInput()
    {

        var logic = GameObject.FindFirstObjectByType<SubmitAnswerLogic>();
        logic.correctAnswer = "test";
        logic.SubmitAnswer("Incorrect");

        yield return null;

        Assert.IsTrue(logic.obstacle.activeInHierarchy);
    }

    [UnityTest]
    public IEnumerator TestCorrectInput()
    {

        var logic = GameObject.FindFirstObjectByType<SubmitAnswerLogic>();
        logic.correctAnswer = "test";
        logic.SubmitAnswer("test");

        yield return null;

        Assert.IsFalse(logic.obstacle.activeInHierarchy);
    }
}
