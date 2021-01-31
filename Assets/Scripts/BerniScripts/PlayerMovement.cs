using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMaster playerMaster;

    [Header("Stats")]
    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    public bool jumpActivated = false; 
    public bool jumping = false; //currently jumping

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;                

        if (Input.GetButtonDown("Jump") && jumping == false)
        {
            jumpActivated = true;
            Debug.Log("jump");
        }        
    }

    private void FixedUpdate()
    {
        playerMaster.Move(horizontalMove * Time.fixedDeltaTime, false, jumpActivated);
        jumpActivated = false;
    }

}
