using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject basicBulletPrefab;
    public GameObject specialBulletPrefab;
    public GameObject ultimateBulletPrefab;
    

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ShootBasic()
    {
        GameObject bullet = Instantiate(basicBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    public void ShootSpecial()
    {
        Debug.Log("Pew pew");
        GameObject bullet = Instantiate(specialBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public void ShootUltimate() {
        GameObject bullet = Instantiate(ultimateBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
