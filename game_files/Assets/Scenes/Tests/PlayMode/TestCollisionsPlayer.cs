using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestCollisionsPlayer
    {


    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Assets/Scenes/Levels/testLevel.unity", LoadSceneMode.Single);
    }

   
}
