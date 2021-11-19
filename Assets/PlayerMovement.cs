using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool grounded;
    public float movementSpeed = 5f;
    private float yVelocity = 0f;

    [SerializeField] private float jumpForce = 6f;

    public bool canMove = true;

    public bool stunned = false;

    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private CapsuleCollider2D capsuleCollider, capsuleColliderTrigger;
    private BoxCollider2D boxCollider;

    private float inputX;

    private AudioSource hitSound;

    [SerializeField] CameraShake cameraShake;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        hitSound = GetComponent<AudioSource>();
    }


    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        
        

        if (Input.GetKeyDown(KeyCode.Space) && grounded && canMove)
        {
            grounded = false;
            yVelocity = jumpForce;
        }
        
        
        
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Switch();
        }
    }

    private void FixedUpdate()
    {
        var hit = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - 1f), new Vector2(1f,0.05f),
            0f, Vector2.down, 0.05f, groundLayer);
        if (hit.collider != null && yVelocity <= 0f)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (canMove)
        {
            rb.velocity = new Vector2(inputX * movementSpeed, yVelocity);
        }

            /* Rb add force when not grounded. tried it, feels janky as fuck
            if (canMove) 
            {
                if (grounded)
                    rb.velocity = new Vector3(inputX * movementSpeed, yVelocity, 0);
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, yVelocity);
                    rb.AddForce(new Vector2(inputX * 500 * Time.deltaTime, 9));
                }
            */

            if (grounded) yVelocity = 0f;
        else yVelocity -= 9.81f * Time.deltaTime;
    }



    private void Switch()
    {
        if (!stunned)
        {
            stunned = true;
            rb.constraints = RigidbodyConstraints2D.None;
            canMove = false;
            capsuleCollider.enabled = true;
            capsuleColliderTrigger.enabled = true;
            boxCollider.enabled = false;
        }
        else
        {
            stunned = false;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            canMove = true;
            transform.DOMoveY(transform.position.y + 0.5f, 0.25f);
            transform.DORotate(new Vector3(0, 0, 0), 0.25f);
            capsuleCollider.enabled = false;
            capsuleColliderTrigger.enabled = false;
            boxCollider.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (stunned)
        {
            if (other.CompareTag("Environment") && rb.velocity.magnitude >= 1f)
            {
                hitSound.Play();
                cameraShake.Shake(rb.velocity.magnitude, 10f, 0.1f);
            }
        }
        
    }
}
