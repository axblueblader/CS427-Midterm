﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 100F;
    public float jumpSpeed = 800F;
    public float maxVelocityX = 1F;
    public float maxVelocityY = 5F;
    public float minVelocityXAsRun = 0.5F;
    public float minVelocityYAsAir = 0.2F;
    public Transform target;
    public AudioSource jumpSound;
    public AudioSource walkSound;
    public AudioSource dieSound;

    private float hMovement;
    private Animator animator;
    private Rigidbody2D rb;
    private Text messTextBox;
    private bool jumpUp;
    private Vector2 posBefore;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (messTextBox == null)
        {
            messTextBox = GameObject.Find("MessTextBox").GetComponent<Text>();
        }
        InvokeRepeating("PlayWalkSound", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (animator.GetBool("isDead"))
        {
            Debug.Log("Movement is disabled");
        }
        else
        {
            jumpUp = false;
            hMovement = Input.GetAxisRaw("Horizontal");

            //if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    hMovement = -1;
            //}

            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    hMovement = 1;
            //} 

            // Space pressed and not moving up or down
            if (Input.GetKeyDown(KeyCode.Space) && Math.Abs(rb.velocity.y) <= minVelocityYAsAir)
            {
                jumpUp = true;
            }
        }


        
    }

    private void FixedUpdate()
    {
        posBefore = target.position;
        //switch (hMovement)
        //{
        //    case 1: MoveRight(); break;
        //    case -1: MoveLeft(); break;
        //    default: break;
        //}
        MoveHorizontal();
        
        if (jumpUp)
        {
            JumpUp();
        }

        SetCharState();
    }
    

    void MoveHorizontal()
    {
        rb.velocity = new Vector2(speed*hMovement, rb.velocity.y);
        if ( hMovement != 0)
        {
            GetComponent<SpriteRenderer>().flipX = hMovement > 0 ? false : true;
        }
        
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
        jumpSound.PlayOneShot(jumpSound.clip);
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
        if (collision.gameObject.tag == "FatalPlat")
        {
            Debug.Log("Dead");
            animator.SetBool("isDead",true);
            messTextBox.text = MessageConstants.WorldMessage.deadPlayer;
            dieSound.PlayOneShot(dieSound.clip);
        }
    }

    void PlayWalkSound()
    {
        if (hMovement != 0 && animator.GetBool("isAir") == false 
            && animator.GetBool("isRunning") == true
            && animator.GetBool("isDead") == false)
        {
            walkSound.PlayOneShot(walkSound.clip);
        }
        else
        {
            walkSound.Stop();
        }
    }
}