using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public Transform player;
    private float fireCooldown = 1f;
    private float lastFireTime;


    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && Time.time - lastFireTime >= fireCooldown)
        {
            lastFireTime = Time.time;
            Fire();
        }

    }
    void Fire()
    {

        var playerDirection = player.localScale.x;
        if (playerDirection < 0)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, 0, 270));
            bullet.GetComponent<Rigidbody2D>().velocity = -bulletSpawnPoint.right * bulletSpeed;
        }
        else
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, 0, 90));
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
        }

    }
}
