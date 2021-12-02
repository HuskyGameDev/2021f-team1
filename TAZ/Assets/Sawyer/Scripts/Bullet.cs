using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public PlayerStats stats;

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float TimeToLive = 5f;


    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, TimeToLive);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Enemy enemy = hitInfo.GetComponent<Enemy>();
        //if (enemy != null)
        //{
            //enemy.TakeDamage(damage);
        //}

        Instantiate(impactEffect, transform.position, transform.rotation);

        hitInfo.GetComponent<EnemyStats>().takeDamage(stats.attackPower);

        Destroy(gameObject);
    }

}