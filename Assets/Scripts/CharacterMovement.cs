using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 100F;
    public float jumpSpeed = 800F;
    public float maxVelocityX = 1F;
    public float maxVelocityY = 5F;
    public float minVelocityXAsRun = 0.5F;
    public float minVelocityYAsAir = 2F;

    private int hMovement;
    private Animator animator;
    private Rigidbody2D rb;
    private bool disableMovement;
    private bool jumpUp;

    // Start is called before the first frame update
    void Start()
    {
        disableMovement = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (disableMovement)
        {
            Debug.Log("Movement is disabled");
        }
        else
        {
            jumpUp = false;
            hMovement = 0;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                hMovement = -1;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                hMovement = 1;
            } 

            // Space pressed and not moving up or down
            if (Input.GetKeyDown(KeyCode.Space) && Math.Abs(rb.velocity.y) == 0)
            {
                jumpUp = true;
            }

            
        }


    }

    private void FixedUpdate()
    {
        switch (hMovement)
        {
            case 1: MoveRight(); break;
            case -1: MoveLeft(); break;
            default: break;
        }

        if (jumpUp)
        {
            JumpUp();
        }

        LimitCharVelocity();
        SetCharState();
    }
    void MoveLeft()
    {
        //rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        GetComponent<SpriteRenderer>().flipX = true;
        Debug.Log("Running Left at " + rb.velocity);
        //rb.MovePosition(rb.position + (Vector2.left*speed) * Time.deltaTime);
    }

    void MoveRight()
    {
        //rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
        rb.velocity = new Vector2(speed, rb.velocity.y);
        GetComponent<SpriteRenderer>().flipX = false;
        Debug.Log("Running Right at " + rb.velocity);
        //rb.MovePosition(rb.position + (Vector2.right * speed) * Time.deltaTime);
    }

    void JumpUp()
    {
        //rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }

    void LimitCharVelocity()
    {
        //if (Math.Abs(rb.velocity.x) > maxVelocityX)
        //{
        //    Debug.Log("Before x limmiter: " + rb.velocity);
        //    rb.velocity = new Vector2(maxVelocityX * Math.Sign(rb.velocity.x), rb.velocity.y);
        //    Debug.Log("After x limmiter: " + rb.velocity);
        //}

        //if (Math.Abs(rb.velocity.y) > maxVelocityY)
        //{
        //    Debug.Log("Before y limmiter: " + rb.velocity);
        //    rb.velocity = new Vector2(rb.velocity.x, maxVelocityY * Math.Sign(rb.velocity.y));
        //    Debug.Log("After y limmiter: " + rb.velocity);
        //}
    }
    void SetCharState()
    {
        //Debug.Log(rb.velocity.y);
        if (Math.Abs(rb.velocity.x) >= minVelocityXAsRun && !animator.GetBool("isAir"))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (rb.velocity.y > minVelocityYAsAir)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isAir", true);
        } else
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isAir", false);
        }

        if (rb.velocity.y < -minVelocityYAsAir)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isAir", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("isAir", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "FatalPlat" && collision.otherCollider.gameObject.tag == "Player")
        {
            Debug.Log("Dead");
            animator.SetTrigger("Dead");
            disableMovement = true;
        }
    }

    //public void onDyingAnimEnded()
    //{
    //    animator.SetBool("isDead", true);
    //}
}
