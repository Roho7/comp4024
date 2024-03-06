using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestScore { 

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Assets/Scenes/Levels/testLevel.unity", LoadSceneMode.Single);
    }

    [UnityTest]
    public IEnumerator TestUpdateScore()
    {
        // Get the ScoreLogic object
        ScoreLogic scoreObject = GameObject.FindObjectOfType<ScoreLogic>();

        // Get the current score
        int score = scoreObject.score;

        // Update the score
        scoreObject.UpdateScore();

        yield return null;

        // Expected result: The score should increase by the default value (e.g., 1)
        Assert.AreEqual(score + 1, scoreObject.score);
    }

    [UnityTest]
    public IEnumerator TestUpdateScoreByPositiveNumber()
    {
        // Get the ScoreLogic object
        ScoreLogic scoreObject = GameObject.FindObjectOfType<ScoreLogic>();

        // Get the current score
        int score = scoreObject.score;

        // Update the score by a positive number (e.g., 5)
        int increaseAmount = 5;
        scoreObject.UpdateScoreBy(increaseAmount);

        yield return null;

        // Expected result: The score should increase by the specified amount
        Assert.AreEqual(score + increaseAmount, scoreObject.score);
    }

    [UnityTest]
    public IEnumerator TestUpdateScoreByNegativeNumber()
    {
        // Get the ScoreLogic object
        ScoreLogic scoreObject = GameObject.FindObjectOfType<ScoreLogic>();

        // Get the current score
        int score = scoreObject.score;

        // Update the score by a negative number (e.g., -3)
        int decreaseAmount = -3;
        scoreObject.UpdateScoreBy(decreaseAmount);

        yield return null;

        // Expected result: The score should not change (negative increases are not allowed)
        Assert.AreEqual(score, scoreObject.score);
    }

    [UnityTest]
    public IEnumerator TestUpdateScoreByMaxIntValue()
    {
        // Get the ScoreLogic object
        ScoreLogic scoreObject = GameObject.FindObjectOfType<ScoreLogic>();

        // Get the current score
        int score = scoreObject.score;

        // Update the score by the maximum int value
        int maxIntValue = int.MaxValue;
        scoreObject.UpdateScoreBy(maxIntValue);
        scoreObject.UpdateScoreBy(1);


        yield return null;

        // Expected result: The score should be capped
        Assert.AreEqual(maxIntValue, scoreObject.score);
    }

    [UnityTest]
    public IEnumerator TestInitialScoreIsZero()
    {
        // Create a new ScoreLogic object
        ScoreLogic scoreObject = GameObject.FindObjectOfType<ScoreLogic>();


        // Expected result: The initial score should be 0
        Assert.AreEqual(0, scoreObject.score);


        yield return null;
    }
}
