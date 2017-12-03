using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float maxSpeed = 6.0f;
    public bool facingRight = true;
    public float moveDirection;

    public bool doubleJump = false;
    public float jumpSpeed = 600.0f;
    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public float swordSpeed = 600.0f;
    public Transform swordSpawn;
    public Rigidbody swordPrefab;

    Rigidbody clone;

    private void Awake()
    {
        groundCheck = GameObject.Find("GroundCheck").transform;
        swordSpawn = GameObject.Find("SwordSpawn").transform;
    }

    // Use this for initialization
    void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        Rigidbody r = GetComponent<Rigidbody>();
        r.velocity = new Vector2(moveDirection * maxSpeed, r.velocity.y);

        if (grounded)
            doubleJump = false;

        if (moveDirection > 0.0f && !facingRight)
        {
            Flip();
        }

        else if(moveDirection < 0.0f && facingRight)
        {
            Flip();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if((grounded || !doubleJump) && Input.GetButtonDown("Jump"))
        {
            Rigidbody r = GetComponent<Rigidbody>();
            r.AddForce(new Vector2(0, jumpSpeed));

            if (!doubleJump && !grounded)
                doubleJump = true;
        }

        if(Input.GetButtonDown ("Fire1"))
        {
            Attack();
        }
	}

    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }

    void Attack()
    {
        clone = Instantiate(swordPrefab, swordSpawn.position, swordSpawn.rotation) as Rigidbody;
        clone.AddForce(swordSpawn.transform.right * swordSpeed);
    }
}
