using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Declare Variables
   // public CharacterController2D controller;
    public Rigidbody2D rb;

    public Animator animator;

    public SpriteRenderer sR;
    public Sprite standing;
    public Sprite crouching;

    public BoxCollider2D collide;
    public CircleCollider2D circleCollide;

    public Vector2 standingSize;
    public Vector2 crouchingSize;



    public float runSpeed;
    public float jump;

    public bool isJumping;
    //private float nextJump = 0.5f;

   // public bool jump = false;
  //  public bool crouch = false;
    float horizontalInput = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();
        collide.size = standingSize;

        sR = GetComponent<SpriteRenderer>();
        sR.sprite = standing;

        standingSize = collide.size;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal") * runSpeed;
        rb.velocity = new Vector2(runSpeed * horizontalInput, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sR.sprite = crouching;
            collide.size = crouchingSize;
            animator.SetBool("IsCrouching", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sR.sprite = standing;
            collide.size = standingSize;
            animator.SetBool("IsCrouching", false);
        }
 
    }

    void OnCollisionEnter2D(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

}
