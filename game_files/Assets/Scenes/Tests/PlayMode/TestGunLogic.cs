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

    [UnityTest]
    public IEnumerator BulletDirectionMatchesPlayerScale()
    {
        // Find the existing Player object in the scene
        var playerLogic = GameObject.FindFirstObjectByType<PlayerLogic>();
        var player = playerLogic.GetComponent<Rigidbody2D>();

        // Find the existing Gun object in the scene
        var gunGO = GameObject.FindFirstObjectByType<GunLogic>();

        // Set the player scale to a specific value
        player.transform.localScale = new Vector3(-1, 1, 1);

        // Simulate the space key press
        gunGO.HandleShooting();
        // Wait for the frame to pass
        yield return new WaitForSeconds(1f);

        // Get the instantiated bullet
        var bullet = GameObject.FindObjectOfType<BulletLogic>();

        // Assert that the bullet's velocity matches the player's scale
        Assert.AreEqual(-gunGO.bulletSpeed, bullet.GetComponent<Rigidbody2D>().velocity.x);
    }

}
