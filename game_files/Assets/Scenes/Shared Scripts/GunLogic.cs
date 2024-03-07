using System.Collections;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public Transform player;
    AudioScript audio;

    public float fireCooldown = 1f;
    public float lastFireTime = 0f;

    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioScript>();

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)){
            HandleShooting();
        }
       
    }

    public void HandleShooting()
    {
        
        if (Time.time - lastFireTime >= fireCooldown)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }

    void Fire()
    {
        audio.PlaySFX(audio.gunSound);
        float rotationZ = (player.localScale.x < 0) ? 270f : 90f;
        Quaternion bulletRotation = Quaternion.Euler(0, 0, rotationZ);

        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletRotation);
        Vector2 bulletVelocity = (player.localScale.x < 0) ? -bulletSpawnPoint.right : bulletSpawnPoint.right;
        bullet.GetComponent<Rigidbody2D>().velocity = bulletVelocity * bulletSpeed;
    }
}
