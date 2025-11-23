using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

using Unity.VisualScripting;

public class moveController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int jumpCount;
   // [SerializeField] private float speedMultiplier;

    private float xInput;
    private Animator anim;

    public bool isMoving;

    [Header("Collision check")]
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool isGrounded;
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        AnimationController ();
        xInput = Input.GetAxisRaw("Horizontal");
        Movement();
        CollisionsCheck();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space was pressed");
            Jump();
        }
       /* if (moveSpeed<maxSpeed)
        {
            moveSpeed += speedMultiplier;
        }*/
    }

  
    private void AnimationController()
    {
        anim.SetBool("isMoving", isMoving);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    public void CollisionsCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (isGrounded) { jumpCount = 1; }
    }
    private void Jump()
    {
        if (isGrounded || jumpCount>=1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle") { 
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }
    }

    

    private void Movement()
    {
        rb.velocity = new Vector2(1 * moveSpeed, rb.velocity.y);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    
}
