using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;

public class TestGunLogic
{
    [SetUp]
    public void Setup()
    {
        // Load the test scene
        SceneManager.LoadScene("Assets/Scenes/Levels/testLevel.unity", LoadSceneMode.Single);
    }

    [UnityTest]
    public IEnumerator ShouldNotFireBulletBeforeCooldownExpires()
    {
        // Find the existing Gun object in the scene

        var playerLogic = GameObject.FindObjectOfType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();
        var gunGO = GameObject.FindObjectOfType<GunLogic>();

        // Wait for the cooldown to elapse
        yield return new WaitForSeconds(gunGO.fireCooldown);

        // Attempt to shoot twice within a short time
        gunGO.HandleShooting();
        gunGO.HandleShooting();

        yield return null;

        Assert.AreEqual(1, GameObject.FindObjectsOfType<BulletLogic>().Length);
    }

}
