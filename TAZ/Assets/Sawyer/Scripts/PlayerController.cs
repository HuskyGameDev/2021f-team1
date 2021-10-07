using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public PlayerStats stats;
    private Rigidbody2D rb;

    [Header("Layer Masks")]
    [SerializeField] private LayerMask groundLayer;

    [Header("Movement Variables")]
    [SerializeField] private float movementAccel = 50;
    [SerializeField] private float maxMoveSpeed = 12;
    [SerializeField] private float linearDrag = 10;
    private float horizontalDirection;
    private bool changingDirection => (rb.velocity.x > 0f && horizontalDirection < 0f || rb.velocity.x < 0f && horizontalDirection > 0f);

    [Header("Jump Variables")]
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private bool canJump;
    [SerializeField] private float airLinearDrag = 2.5f;
    [SerializeField] private float fallMultiplier = 8f;
    [SerializeField] private float lowJumpFallMultiplier = 5f;

    /*
    [Header("Ground Collision Variables")]
    [SerializeField] private float groundRaycastLength;
    [SerializeField] private bool onGround;
    */

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //PLAYER_CONTROLLER_2.0
    private void Update()
    {
        horizontalDirection = GetInput().x;
        if (Input.GetButtonDown("Jump") && canJump)
            Jump();
    }

    private void FixedUpdate()
    {
        //CheckCollisions();
        MoveCharacter();
        
        if (canJump)
        {
            ApplyLinearDrag();
        }
        else
        {
            ApplyAirLinearDrag();
        }
        FallMultiplier();
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
            canJump = true;
        
    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MoveCharacter()
    {
        rb.AddForce(new Vector2(horizontalDirection, 0f) * movementAccel);
        if (Mathf.Abs(rb.velocity.x) > maxMoveSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxMoveSpeed, rb.velocity.y);
    }

    private void ApplyLinearDrag() {
        if (Mathf.Abs(horizontalDirection) < 0.4f || changingDirection) 
            rb.drag = linearDrag;
        else
            rb.drag = 0f;
    }

    private void ApplyAirLinearDrag()
    {
            rb.drag = airLinearDrag;
    }

    private void Jump()
    {
        canJump = false;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FallMultiplier()
    {
        if (rb.velocity.y < 0)
            rb.gravityScale = fallMultiplier;
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.gravityScale = lowJumpFallMultiplier;
        else
            rb.gravityScale = 1f;
    }

    /*
    private void CheckCollisions()
    {
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundRaycastLength, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRaycastLength);
    }
    */

    /*
    //PLAYER_CONTROLLER_1.0
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
    */
}
