using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public GameObject playerObject;
    public BoxCollider2D boxCollide;

    private float horizontal;
    private bool isFacingRight = true;
    private float runSpeed = 10f;
    private float jumpPower = 12f;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();


    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        Flip();

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            boxCollide.enabled = false;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            boxCollide.enabled = true;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        /*
                horizontal = Input.GetAxisRaw("Horizontal");

                rb.velocity = new Vector2(dirX, rb.velocity.y) * runSpeed;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GetComponent<Rigidbody2D>().AddForce(jumpSpeed, ForceMode2D.Impulse);
                }
         */

        rb.velocity = new Vector2(horizontal * runSpeed, rb.velocity.y);

    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}