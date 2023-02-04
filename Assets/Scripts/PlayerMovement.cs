using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Declare Variables
    public CharacterController2D controller;
    public Rigidbody2D rb;
    public SpriteRenderer sR;

    public float runSpeed = 20f;

    public bool jump = false;
    public bool crouch = false;
    float horizontalInput = 0f;


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
           // crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
 
    }

    void FixedUpdate()
    {
        controller.Move(horizontalInput * Time.fixedDeltaTime, false, false);
        jump = false;
    }
    
}
