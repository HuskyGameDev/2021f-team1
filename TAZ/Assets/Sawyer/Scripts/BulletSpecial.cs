using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpecial : MonoBehaviour
{
    public PlayerStats stats;

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float TimeToLive = 5.0f;


    // Use this for initialization
    void Start()
    {
        rb.velocity = Vector3.forward * speed;
        Destroy(gameObject, TimeToLive);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Enemy enemy = hitInfo.GetComponent<Enemy>();
        //if (enemy != null)
        //{
        //enemy.TakeDamage(damage);
        //}

        if (hitInfo.gameObject.layer == 7)
        {
            Debug.Log("Hit Enemy");
            hitInfo.GetComponent<EnemyStats>().takeDamage(stats.attackPower);
            Destroy(gameObject);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);



        //Destroy(gameObject);
    }
}
