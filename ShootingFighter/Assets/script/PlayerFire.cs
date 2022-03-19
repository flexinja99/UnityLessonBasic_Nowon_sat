using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireTimeGap = 0.3f;
    private float fireTimer;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            fireTimer = fireTimeGap;
        }

        if (fireTimer < 0 &&
            Input.GetKeyDown(KeyCode.Space))


        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            fireTimer = fireTimeGap;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
    }
}

