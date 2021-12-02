using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Shoot()
    {
        Debug.Log("Pew pew");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
