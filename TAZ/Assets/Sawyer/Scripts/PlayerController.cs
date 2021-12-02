using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public PlayerStats stats;
    private Rigidbody2D rb;
    public Camera mainCamera;
    public Gun gun;

    [Header("Layer Masks")]
    [SerializeField]
    private LayerMask groundLayer;

    [Header("Movement Variables")]
    [SerializeField]
    private float movementAccel = 50;
    [SerializeField]
    private float maxMoveSpeed;
    [SerializeField]
    private float linearDrag = 10;
    private float horizontalDirection;
    private bool changingDirection => (rb.velocity.x > 0f && horizontalDirection < 0f || rb.velocity.x < 0f && horizontalDirection > 0f);

    [Header("Jump Variables")]
    [SerializeField]
    private float jumpForce = 12f;
    [SerializeField]
    private bool canJump;
    [SerializeField]
    private float airLinearDrag = 2.5f;
    [SerializeField]
    private float fallMultiplier = 8f;
    [SerializeField]
    private float lowJumpFallMultiplier = 5f;
    private int extraJumpsRemaining;


    [Header("Ground Collision Variables")]
    [SerializeField]
    private float groundRaycastLength = 0.75f;
    [SerializeField]
    private Vector3 groundRaycastOffset;
    [SerializeField]
    private bool onGround;

    [Header("Wall Collision Variables")]
    [SerializeField]
    private float wallRaycastLength = 0.35f;
    [SerializeField]
    private Vector3 wallRaycastOffset;
    [SerializeField]
    private bool onRightWall;
    [SerializeField]
    private bool onLeftWall;

    [Header("Mouse Variables")]
    [SerializeField]
    private Vector3 mouseWorldPos;

    //These are the stats for the attack object
    public Transform attack;
    public float range = .5f;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxMoveSpeed = stats.maxSpeed;
    }

    //PLAYER_CONTROLLER_2.0
    private void Update()
    {

        //movement and controls
        horizontalDirection = GetInput().x;
        if (Input.GetButtonDown("Jump") && canJump && onRightWall)
            WallJump(1);
        else if (Input.GetButtonDown("Jump") && canJump && onLeftWall)
            WallJump(2);
        else if (Input.GetButtonDown("Jump") && canJump && (onGround || extraJumpsRemaining > 0))
            Jump();
        else if (Input.GetMouseButtonDown(0))
            basicAttack();
        else if (Input.GetKey(KeyCode.E) && stats.specialReady)
        {
            specialAbility();
            stats.resetSpecial();
        }
        else if (Input.GetKey(KeyCode.Q) && stats.ultReady)
        {
            ultimateAbility();
            stats.resetUlt();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            basicAttack();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            specialAbility();
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            ultimateAbility();
        }

        //mouse position
        GetMouse();
    }

    private void FixedUpdate()
    {
        CheckCollisions();
        MoveCharacter();

        if (canJump && onGround)
        {
            extraJumpsRemaining = stats.extraJumps;
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
        if (collision.gameObject.layer == 6)
            canJump = true;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attack.position, range);
    }

    // Ability functions
    private void specialAbility()
    {
        Collider2D[] hits;

        switch (stats.type)
        {
            case "Zoologist":
                //stats.attackpower;
                //Basic attack case for melee and AOE attacks, with AOE attacks range being higher
                hits = Physics2D.OverlapCircleAll(attack.position, 1f, enemyLayers);

                foreach (Collider2D enemy in hits)
                {
                    //use enemy.GetComponent<Enemy>.function()
                    //Call a function that hurts the enemy -- in the enemy's page the function should include:
                    //curHealth -= stats.attackpower
                    //if (curHealth <= 0) {destroy(self);}
                    //stats.attackpower; for damage done
                }

                break;
            case "Phoenix":
                gun.Shoot();
                break;
            case "Dire wolf":
                gun.Shoot();
                break;
            case "Drake":

                //Basic attack case for melee and AOE attacks, with AOE attacks range being higher
                hits = Physics2D.OverlapCircleAll(attack.position, 1f, enemyLayers);

                foreach (Collider2D enemy in hits)
                {
                    //use enemy.GetComponent<Enemy>.function()
                    //Call a function that hurts the enemy -- in the enemy's page the function should include:
                        //curHealth -= stats.attackpower
                        //if (curHealth <= 0) {destroy(self);}
                    //stats.attackpower; for damage done
                }

                break;
            case "Basilisk":
                gun.Shoot();
                break;
            default:
                print("Test");
                // code block
                break;
        }
        Debug.Log("Special Ability Cast");
    }

    private void ultimateAbility()
    {
        Collider2D[] hits;
        switch (stats.type)
        {
            case "Zoologist":
                //stats.attackpower;
                //Basic attack case for melee and AOE attacks, with AOE attacks range being higher
                hits = Physics2D.OverlapCircleAll(attack.position, 1.2f, enemyLayers);

                foreach (Collider2D enemy in hits)
                {
                    //use enemy.GetComponent<Enemy>.function()
                    //Call a function that hurts the enemy -- in the enemy's page the function should include:
                    //curHealth -= stats.attackpower
                    //if (curHealth <= 0) {destroy(self);}
                    //stats.attackpower; for damage done
                }
                break;
            case "Phoenix":
                //Basic attack case for melee and AOE attacks, with AOE attacks range being higher
                hits = Physics2D.OverlapCircleAll(attack.position, 1f, enemyLayers);

                foreach (Collider2D enemy in hits)
                {
                    //use enemy.GetComponent<Enemy>.function()
                    //Call a function that hurts the enemy -- in the enemy's page the function should include:
                    //curHealth -= stats.attackpower
                    //if (curHealth <= 0) {destroy(self);}
                    //stats.attackpower; for damage done
                }
                break;
            case "Dire wolf":

                //Basic attack case for melee and AOE attacks, with AOE attacks range being higher
                hits = Physics2D.OverlapCircleAll(attack.position, 1.2f, enemyLayers);

                foreach (Collider2D enemy in hits)
                {
                    //use enemy.GetComponent<Enemy>.function()
                    //Call a function that hurts the enemy -- in the enemy's page the function should include:
                    //curHealth -= stats.attackpower
                    //if (curHealth <= 0) {destroy(self);}
                    //stats.attackpower; for damage done
                }

                break;
            case "Drake":
                gun.Shoot();
                break;
            case "Basilisk":
                gun.Shoot();
                break;
            default:
                // code block
                break;
        }
        Debug.Log("Ultimate Ability Cast");
    }

    private void basicAttack()
    {
        Collider2D[] hits;
        switch (stats.type)
        {
            case "Zoologist":

                //Basic attack case for melee and AOE attacks, with AOE attacks range being higher
                hits = Physics2D.OverlapCircleAll(attack.position, .4f, enemyLayers);
			
			foreach (Collider2D enemy in hits)
                {
                    //use enemy.GetComponent<Enemy>.function()
                    //Call a function that hurts the enemy -- in the enemy's page the function should include:
                    //curHealth -= stats.attackpower
                    //if (curHealth <= 0) {destroy(self);}
                    //stats.attackpower; for damage done
                }

                break;
            case "Phoenix":
                gun.Shoot();
                break;
            case "Dire wolf":

                //Basic attack case for melee and AOE attacks, with AOE attacks range being higher
                hits = Physics2D.OverlapCircleAll(attack.position, .5f, enemyLayers);

                foreach (Collider2D enemy in hits)
                {
                    //use enemy.GetComponent<Enemy>.function()
                    //Call a function that hurts the enemy -- in the enemy's page the function should include:
                    //curHealth -= stats.attackpower
                    //if (curHealth <= 0) {destroy(self);}
                    //stats.attackpower; for damage done
                }

                break;
            case "Drake":

                //Basic attack case for melee and AOE attacks, with AOE attacks range being higher
                hits = Physics2D.OverlapCircleAll(attack.position, .5f, enemyLayers);

                foreach (Collider2D enemy in hits)
                {
                    //use enemy.GetComponent<Enemy>.function()
                    //Call a function that hurts the enemy -- in the enemy's page the function should include:
                    //curHealth -= stats.attackpower
                    //if (curHealth <= 0) {destroy(self);}
                    //stats.attackpower; for damage done
                }

                break;
            case "Basilisk":

                //Basic attack case for melee and AOE attacks, with AOE attacks range being higher
                hits = Physics2D.OverlapCircleAll(attack.position, .4f, enemyLayers);

                foreach (Collider2D enemy in hits)
                {
                    //use enemy.GetComponent<Enemy>.function()
                    //Call a function that hurts the enemy -- in the enemy's page the function should include:
                    //curHealth -= stats.attackpower
                    //if (curHealth <= 0) {destroy(self);}
                    //stats.attackpower; for damage done
                }

                break;
            default:
                // code block
                break;
        }
        Debug.Log("Basic Attack");
    }
    // End of ability functions

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void GetMouse()
    {
        mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
    }

    private void MoveCharacter()
    {
        rb.AddForce(new Vector2(horizontalDirection, 0f) * movementAccel);
        if (Mathf.Abs(rb.velocity.x) > maxMoveSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxMoveSpeed, rb.velocity.y);
    }

    private void ApplyLinearDrag()
    {
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
        if (extraJumpsRemaining > 0)
            extraJumpsRemaining--;
        else
            canJump = false;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void WallJump(int dir)
    {
        if (extraJumpsRemaining < 0)
            canJump = false;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        Vector2 wallJumpDirection = new Vector2();
        if (dir == 1)
            wallJumpDirection = new Vector2(-.75f, 1f);
        else if (dir == 2)
            wallJumpDirection = new Vector2(.75f, 1f);
        rb.AddForce(wallJumpDirection * jumpForce, ForceMode2D.Impulse);
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

    private void CheckCollisions()
    {
        onGround = Physics2D.Raycast(transform.position + groundRaycastOffset, Vector2.down, groundRaycastLength, groundLayer);

        onRightWall = Physics2D.Raycast(transform.position + wallRaycastOffset, Vector2.right, wallRaycastLength, groundLayer);
        onLeftWall = Physics2D.Raycast(transform.position + wallRaycastOffset, Vector2.left, wallRaycastLength, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position + groundRaycastOffset, transform.position + Vector3.down * groundRaycastLength);
        Gizmos.DrawLine(transform.position + wallRaycastOffset, transform.position + Vector3.right * wallRaycastLength);
        Gizmos.DrawLine(transform.position + wallRaycastOffset, transform.position + Vector3.left * wallRaycastLength);
        Gizmos.DrawLine(transform.position, mouseWorldPos);
    }

}
