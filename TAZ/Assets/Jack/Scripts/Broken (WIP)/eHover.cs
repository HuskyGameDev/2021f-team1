using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHover : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float agroRange = 5;

    [SerializeField] float moveSpeed = 5;

    Rigidbody2D fEnemy;
    float x;
    float y;
    bool chase = false;

    void Start()
    {
        fEnemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        y = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.y + 10f;
        x = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x;
        Vector2 target = new Vector2(x, y);
        float pDist = Vector2.Distance(transform.position, player.position);

        if (pDist < agroRange)
        {
            chase = true;
        }
        else
        {
            chase = false;
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, Time.deltaTime);
        }

        if(chase == true)
        {
            Chase(target);
        }
        
    }

    void Chase(Vector2 target)
    {
        transform.Translate(target* Time.deltaTime);
        //transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
    }

}
