using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public PlayerStats stats;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector2.left * stats.speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * stats.speed * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * stats.jumpForce, ForceMode2D.Impulse);
        }
    }
}
