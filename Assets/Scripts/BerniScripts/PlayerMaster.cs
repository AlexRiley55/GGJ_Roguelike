using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMaster : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Animator animator;
    [Space]

    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.

    public bool grounded;            // Whether or not the player is grounded.
    private Rigidbody2D playerRigidbody2D;
    private bool facingRight = true;  // For determining which way the player is currently facing.
    private Vector3 velocity = Vector3.zero;

    

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();       
    }

    private void FixedUpdate()
    {
        //grounded = true;
    }

    public void Move(float move, bool crouch, bool jump)
    {     
        //only control the player if grounded or airControl is turned on
        if (grounded || m_AirControl)
        {           
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, playerRigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            playerRigidbody2D.velocity = Vector3.SmoothDamp(playerRigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !facingRight)
            {
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && facingRight)
            {
                Flip();
            }
            animator.SetFloat("running", Mathf.Abs(move));
        }
        // If the player should jump...
        if (jump && !playerMovement.jumping)
        {
            animator.SetBool("Jumping", jump);
            Debug.Log("Worked");
            // Add a vertical force to the player.
            playerMovement.jumping = true;
            grounded = false;
            playerRigidbody2D.AddForce(new Vector2(0f, m_JumpForce));            
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            playerMovement.jumping = false;
            animator.SetBool("Jumping", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            grounded = true;            
        }        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            grounded = false;
        }
    }

}
