using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestGunLogic
{


    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Assets/Scenes/Levels/testLevel.unity", LoadSceneMode.Single);
    }

    [UnityTest]
    public IEnumerator BulletNotFiredBeforeCooldownExpires()
    {

        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();

        // Find the existing Gun object in the scene
        var gunGO = GameObject.FindFirstObjectByType<GunLogic>();

        yield return new WaitForSeconds(gunGO.fireCooldown);


        
        gunGO.HandleShooting();
        gunGO.HandleShooting();


        yield return null;



        // Assert that the enemy is destroyed after a collision with a bullet
        Assert.AreEqual(1, GameObject.FindObjectsOfType<BulletLogic>().Length);
    }

}
