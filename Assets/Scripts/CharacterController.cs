using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Declare Variables
    [SerializeField]
    private float speed = 20f;
    //private float jumpForce = 10f;
    private bool jumped = false;
    private bool isGrounded = false;

    int jumpCount = 0;
    int maxJumps = 1;

    private float horizontalInput;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumps;
    }

    private void FixedUpdate()
    {
        // Moves player left and right
        horizontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMovement = horizontalInput * speed * Time.deltaTime;
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);

        if (jumped && isGrounded)
        {
            jumped = false;
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Player jump

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount > 0)
            {
                Jump();
            }
            //rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            //jumped = true;
        }
       
    }

    public void Jump()
    {
        rb.velocity = transform.up * 10;
        jumpCount -= 1;
    }


}
