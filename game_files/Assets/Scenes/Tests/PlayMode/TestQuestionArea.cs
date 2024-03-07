using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestQuestionArea
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Assets/Scenes/Levels/testLevel.unity", LoadSceneMode.Single);
    }

    [UnityTest]
    public IEnumerator QuestionManagerLoadsIn()
    {
        var qGO = GameObject.Find("QuestionArea");

        QuestionAreaLogic questionArea = qGO.GetComponent<QuestionAreaLogic>();

        yield return null;

        Assert.NotNull(questionArea, "QuestionAreaLogic component not found in the scene");
    }

    [UnityTest]
    public IEnumerator PlayerEntersAndExitsQuestionArea()
    {
        // Find the existing QuestionArea object in the scene
        var qGO = GameObject.Find("QuestionArea");

        QuestionAreaLogic questionArea = qGO.GetComponent<QuestionAreaLogic>();

        // Find the existing Player object in the scene
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();

        // Move the player into the question area
        player.transform.position = questionArea.transform.position;

        // Move the player out of the question area
        player.transform.position = new Vector2(questionArea.transform.position.x + 10f, questionArea.transform.position.y);

        // Wait for the frame to pass
        yield return null;

        // Assert that the player is now out of the question area
        Assert.IsFalse(questionArea.isInZone, "Player should be out of the question area");
    }

    [UnityTest]
    public IEnumerator IsInZoneDefaultValue()
    {
        // Find the existing QuestionArea object in the scene
        var qGO = GameObject.Find("QuestionArea");

        QuestionAreaLogic questionArea = qGO.GetComponent<QuestionAreaLogic>();

        // Find the existing Player object in the scene
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();

        yield return null;

        // Ensure the initial state is as expected
        Assert.IsFalse(questionArea.isInZone, "QuestionArea should not be in the zone initially");
    }

    [UnityTest]
    public IEnumerator playerEnters()
    {
        // Find the existing QuestionArea object in the scene
        var qGO = GameObject.Find("QuestionArea");

        QuestionAreaLogic questionArea = qGO.GetComponent<QuestionAreaLogic>();

        // Find the existing Player object in the scene
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();

        // Move the player into the question area
        player.transform.position = questionArea.transform.position;

        // Wait for the frame to pass
        yield return null;

        // Assert that the player is now in the question area
        Assert.IsTrue(questionArea.isInZone, "Player should be in the question area");
    }

    [UnityTest]
    public IEnumerator DifferentObjectDoesNotAffectQuestionArea()
    {
        // Find the existing QuestionArea object in the scene
        var questionArea = GameObject.FindFirstObjectByType<QuestionAreaLogic>();
        Assert.NotNull(questionArea, "QuestionAreaLogic component not found in the scene");

        // Find the existing Player object in the scene
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();

        // Instantiate a different object
        GameObject otherObject = new GameObject("OtherObject");
        otherObject.AddComponent<Collider2D>();

        // Ensure the initial state is as expected
        Assert.IsFalse(questionArea.isInZone, "QuestionArea should not be in the zone initially");

        // Move the player into the question area
        player.transform.position = questionArea.transform.position;

        // Wait for the frame to pass
        yield return null;

        // Assert that the player is now in the question area
        Assert.IsTrue(questionArea.isInZone, "Player should be in the question area");

        // Move the different object into the question area
        otherObject.transform.position = questionArea.transform.position;

        // Wait for the frame to pass
        yield return null;

        // Assert that the state of the question area remains unchanged
        Assert.IsTrue(questionArea.isInZone, "Player should still be in the question area");

        // Cleanup: Destroy the temporary GameObject
        GameObject.Destroy(otherObject);
    }
}
