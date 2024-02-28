using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using static UnityEngine.UI.CanvasScaler;


public class TestMainMenu
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Assets/Scenes/Menu Screen/MenuScreen.unity", LoadSceneMode.Single);
    }


    [UnityTest]
    public IEnumerator VerifyScene()
    {
        var gameObject = GameObject.FindGameObjectWithTag("Background").GetComponent<RectTransform>();

        yield return null;

        Assert.That(gameObject, Is.Not.Null);
    }

    [UnityTest]
    public IEnumerator levelSelectorIsDisabled()
    {
        Button showLevelsBtn = GameObject.Find("ShowLevelsBtn").GetComponent<Button>();
        yield return null;

        Assert.AreEqual(GameObject.Find("LevelSelector"), null);
    }

    [UnityTest]
    public IEnumerator levelSelectorIsActive()
    {
        Button showLevelsBtn = GameObject.Find("ShowLevelsBtn").GetComponent<Button>();
        showLevelsBtn.onClick.Invoke();
        yield return null;

        Assert.IsTrue(GameObject.Find("LevelSelector").activeInHierarchy);
        GameObject.Find("LevelSelector").SetActive(false);
    }

    [UnityTest]
    public IEnumerator scencesAreLoadedAsButtons()
    {
        Button showLevelsBtn = GameObject.Find("ShowLevelsBtn").GetComponent<Button>();
        showLevelsBtn.onClick.Invoke();

        LevelSelector lvlContainer = GameObject.Find("LevelSelector").GetComponent<LevelSelector>();
        yield return null;

        Assert.AreEqual((UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - 2 ), lvlContainer.getNumberOfButtons());
    }

    [UnityTest]
    public IEnumerator verifySceneChange()
    {
        Button showLevelsBtn = GameObject.Find("ShowLevelsBtn").GetComponent<Button>();
        showLevelsBtn.onClick.Invoke();

        LevelSelector lvlContainer = GameObject.Find("LevelSelector").GetComponent<LevelSelector>();
        Button button = GameObject.FindGameObjectWithTag("lvlButton").GetComponent<Button>();
        button.onClick.Invoke();
        yield return null;

        Assert.AreEqual("level 1", SceneManager.GetActiveScene().name);
    }




}
