using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eFollow : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float agroRange = 5;

    [SerializeField] float moveSpeed = 5;

    Rigidbody2D fEnemy;


    void Start()
    {
        fEnemy = GetComponent<Rigidbody2D>();
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float pDist = Vector2.Distance(transform.position, player.position);

        if (pDist < agroRange)
        {
            Chase();
        }
        else
        {
            StopChase();
        }
    }

    void Chase()
    {
        Vector2 playerX = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, playerX, moveSpeed * Time.deltaTime);
    }

    void StopChase()
    {
        fEnemy.velocity = new Vector2(0, 0);
    }
}
