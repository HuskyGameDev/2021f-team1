using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eRand : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float agroRange = 5;

    [SerializeField] float moveSpeed = 5;
    Rigidbody2D fEnemy;
    bool chase = false;
    private float timeLeft;
    void Start()
    {
        fEnemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float pDist = Vector2.Distance(transform.position, player.position);
        float rv = 0f;
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            rv = Random.Range(0f, 1f);
        }
        Chase(rv);
   
    }

    void Chase(float randomValue)
    {
        float ranval = randomValue;
        if (ranval == 0f)
        {
            fEnemy.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            fEnemy.velocity = new Vector2(-moveSpeed, 0);
        }

    }

    void StopChase()
    {
        fEnemy.velocity = new Vector2(0, 0);
    }
}
