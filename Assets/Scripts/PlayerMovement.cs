using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Declare Variables
    public CharacterController2D controller;
    public Rigidbody2D rb;
    public SpriteRenderer sR;

    public Sprite standing;
    public Sprite crouching;

    public BoxCollider2D collide;

    public Vector2 standingSize;
    public Vector2 crouchingSize;



    private float runSpeed = 20f;
    private float jumpRate = 0.5f;
    private float nextJump = 0.5f;

    public bool jump = false;
    public bool crouch = false;
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

        if (Input.GetButtonDown("Jump") && Time.time > nextJump)
        {
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            nextJump = Time.time + jumpRate;
            jump = true;

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sR.sprite = crouching;
            sR.flipX = false;
            collide.size = crouchingSize;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sR.sprite = standing;
            sR.flipX = true;
            collide.size = standingSize;
        }
 
    }

    void FixedUpdate()
    {
        controller.Move(horizontalInput * Time.fixedDeltaTime, false, false);
        jump = false;
    }

 

}
