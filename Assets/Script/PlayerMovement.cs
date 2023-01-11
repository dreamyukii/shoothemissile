using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform cellingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maximumJumpCount;
    
    private Rigidbody2D rb;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        jumpCount = maximumJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
    
    private void FixedUpdate()
    {
        //check if ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded)
        {
            jumpCount = maximumJumpCount;
        }
        
        //move
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f,jumpForce));
            jumpCount--;
        }
        isJumping = false;
    }
    
    private void ProcessInput()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
        }
    }
    
    
}
