using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Declare Variables
    [SerializeField]
    private float speed = 20f;
    private float jumpForce = 10f;
    private bool jumped = false;
    private bool isGrounded = false;

    private float horizontalInput;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        // Moves player left and right
        horizontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMovement = horizontalInput * speed * Time.deltaTime;
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);

        if (jumped && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
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
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            jumped = true;
        }
       
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
