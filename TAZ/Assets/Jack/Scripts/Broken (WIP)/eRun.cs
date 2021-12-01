using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eRun : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float agroRange = 5;

    [SerializeField] float moveSpeed = 5;

    Rigidbody2D fEnemy;


    void Start()
    {
        fEnemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float pDist = Vector2.Distance(transform.position, player.position);

        if (pDist < agroRange)
        {
            Run();
        }
        else
        {
            StopRun();
        }
    }

    void Run()
    {
        if (transform.position.x < player.position.x)
        {
            fEnemy.velocity = new Vector2(-moveSpeed, 0);
        }
        else
        {
            fEnemy.velocity = new Vector2(moveSpeed, 0);
        }


    }

    void StopRun()
    {
        fEnemy.velocity = new Vector2(0, 0);
    }
}
