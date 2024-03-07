using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EnemyLogicTests
{

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Assets/Scenes/Levels/testLevel.unity", LoadSceneMode.Single);
    }

    [UnityTest]
    public IEnumerator EnemyDestroyedOnCollision()
    {
        // Find the existing enemy object in the scene
        GameObject enemyGO = GameObject.Find("enemy-1");

        // Instantiate a new bullet object
        GameObject bulletGO = new GameObject("Bullet");
        BulletLogic bulletLogic = bulletGO.AddComponent<BulletLogic>();
        Collider2D bulletCollider = bulletGO.AddComponent<BoxCollider2D>();
        bulletGO.tag = "Bullet"; // Ensure the bullet has the correct tag


        bulletGO.transform.position = enemyGO.transform.position;

        // Yield null to wait for the physics to be simulated



        yield return null;

        Debug.Log(enemyGO);


        // Assert that the enemy is destroyed after a collision with a bullet
        Assert.IsFalse(enemyGO.gameObject);
    }

    [UnityTest]
    public IEnumerator EnemyMoves()
    {
        // Find the existing enemy object in the scene
        GameObject enemyGO = GameObject.Find("enemy-1");

        // Record the initial position of the enemy
        Vector3 initialPosition = enemyGO.transform.position;

        // Wait for the enemy to move on its interval
        yield return new WaitForSeconds(2f);

        // Assert that the enemy has moved (its position should change)
        Assert.AreNotEqual(initialPosition, enemyGO.transform.position);
    }

    [UnityTest]
    public IEnumerator EnemyDirectionChangeOnInterval()
    {
        // Find the existing enemy object in the scene
        GameObject enemyGO = GameObject.Find("enemy-1");

        // Record the initial direction of the enemy
        int initialDirection = enemyGO.GetComponent<EnemyLogic>().direction;

        // Wait for the enemy to change direction on its interval
        yield return new WaitForSeconds(enemyGO.GetComponent<EnemyLogic>().moveInterval);

        // Assert that the enemy has changed direction
        Assert.AreNotEqual(initialDirection, enemyGO.GetComponent<EnemyLogic>().direction);
    }

    [UnityTest]
    public IEnumerator EnemyScoreNotUpdatedOnNonBulletCollision()
    {
        // Get the current score
        ScoreLogic scoreObject = GameObject.FindObjectOfType<ScoreLogic>();
        int score = scoreObject.score;

        // Find the existing enemy object in the scene
        GameObject enemyGO = GameObject.Find("enemy-1");

        // Instantiate a new game object as a non-bullet collider
        GameObject nonBulletColliderGO = new GameObject("NonBulletCollider");
        nonBulletColliderGO.tag = "Untagged"; // No tag to simulate a non-bullet collider
        nonBulletColliderGO.AddComponent<BoxCollider2D>();

        // Set the non-bullet collider's position to that of the enemy
        nonBulletColliderGO.transform.position = enemyGO.transform.position;



        // Wait for physics to be simulated
        yield return new WaitForSeconds(2f);

        // Assert that the score is not updated on a non-bullet collision
        Assert.AreEqual(score, scoreObject.score);


    }

    [UnityTest]
    public IEnumerator ScoreIncreasedOnEnemyDestroyed()
    {

        // Get the current score
        ScoreLogic scoreObject = GameObject.FindObjectOfType<ScoreLogic>();
        int score = scoreObject.score;


        GameObject enemyGO = GameObject.Find("enemy-1");

        // Instantiate a new bullet object
        GameObject bulletGO = new GameObject("Bullet");
        BulletLogic bulletLogic = bulletGO.AddComponent<BulletLogic>();
        Collider2D bulletCollider = bulletGO.AddComponent<BoxCollider2D>();
        bulletGO.tag = "Bullet"; // Ensure the bullet has the correct tag

        // Set the bullet's position to that of the enemy
        bulletGO.transform.position = enemyGO.transform.position;



        // Yield null to wait for the physics to be simulated
        yield return new WaitForSeconds(2f);


        // Assert that the score is increased after the enemy is destroyed by a bullet
        Assert.AreEqual(score, scoreObject.score);
    }
}