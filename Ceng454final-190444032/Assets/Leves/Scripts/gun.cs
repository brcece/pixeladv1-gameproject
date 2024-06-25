using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var bullet = Instantiate(bulletPrefab , bulletSpawnPoint.position,bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity= bulletSpawnPoint.right *bulletSpeed;
        }
    }
}
