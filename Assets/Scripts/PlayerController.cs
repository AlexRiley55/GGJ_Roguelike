using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpStartingSpeed = 20f;
    public float accelJumpMaxSpeed = 35f;
    public float basicJumpAccel = 20f;
    public float basicJumpMaxSpeed = 10f;
    public float jumpAccel = 50f;

    public bool isJumping = false;
    public bool basicJumping = false;
    public bool accelJump = false;

    public float runSpeed = 15f;
    public float modifiedRunSpeed;

    public float gravity = 30f;
    public float modifiedGravity;

    public float currentJumpSpeed = 0f;
    public float currentBasicJumpSpeed = 0f;
    public float currentAccelJumpSpeed = 0f;
    public float currentGravity = 0f;

    Vector3 FacingDir = new Vector3(1, 0, 0);
    public float shootSpeed = 10f;

    static PlayerController playerController;

    public static PlayerController getPlayer() {
        return playerController;
    }

    void Awake() {
        playerController = gameObject.GetComponent(typeof(PlayerController)) as PlayerController;
    }

    // Start is called before the first frame update
    void Start() {
        modifiedRunSpeed = runSpeed;
        modifiedGravity = gravity;
    }

    // Update is called once per frame
    void Update() {
        move();
    }

    public void move() {
        CharacterController cc = gameObject.GetComponent(typeof(CharacterController)) as CharacterController;

        if (!cc.isGrounded) {
            currentGravity += modifiedGravity * Time.deltaTime;
        } else {
            currentGravity = 0;
        }

        if (Input.GetAxis("Horizontal") > 0.1) {
            FacingDir.x = 1;
        }

        if (Input.GetAxis("Horizontal") < -0.1) {
            FacingDir.x = -1;
        }

        if (Input.GetAxis("Vertical") > 0.1 && cc.isGrounded) {
            Debug.Log("Jump");
            isJumping = true;
            currentGravity = 0;
            currentJumpSpeed = jumpStartingSpeed;
            currentAccelJumpSpeed = jumpStartingSpeed;
            accelJump = true;
            basicJumping = true;
        } else if (Input.GetAxis("Vertical") < 0.1 && accelJump) {
            accelJump = false;
            currentJumpSpeed -= currentAccelJumpSpeed;
            currentAccelJumpSpeed = 0;
        }

        if (basicJumping) {
            currentJumpSpeed += basicJumpAccel * Time.deltaTime;
            currentBasicJumpSpeed += basicJumpAccel * Time.deltaTime;
            if (currentBasicJumpSpeed >= basicJumpMaxSpeed) {
                basicJumping = false;
                currentJumpSpeed -= currentBasicJumpSpeed;
                currentBasicJumpSpeed = 0;
            }
        }

        if (accelJump) {
            currentJumpSpeed += jumpAccel * Time.deltaTime;
            currentAccelJumpSpeed += jumpAccel * Time.deltaTime;
            if (currentAccelJumpSpeed >= accelJumpMaxSpeed) {
                accelJump = false;
                currentJumpSpeed -= currentAccelJumpSpeed;
                currentAccelJumpSpeed = 0;
            }
        }

        if (isJumping) {
            cc.Move(transform.up * currentJumpSpeed * Time.deltaTime);
        }

        if ((!basicJumping && !accelJump) || !isJumping) { //others can cancel a jump by setting isJumping to false
            currentJumpSpeed = 0;
            currentBasicJumpSpeed = 0;
            isJumping = false;
        }

        Vector3 move = transform.right * Input.GetAxis("Horizontal") * modifiedRunSpeed + transform.up * -1 * currentGravity;
        cc.Move(move * Time.deltaTime);
    }

    public void resetVars() {
        jumpStartingSpeed = 20f;
        accelJumpMaxSpeed = 35f;
        basicJumpAccel = 20f;
        basicJumpMaxSpeed = 10f;
        jumpAccel = 50f;

        isJumping = false;
        basicJumping = false;
        accelJump = false;

        runSpeed = 15f;

        gravity = 30f;

        currentJumpSpeed = 0f;
        currentBasicJumpSpeed = 0f;
        currentAccelJumpSpeed = 0f;
        currentGravity = 0f;

        FacingDir = new Vector3(1, 0, 0);
        shootSpeed = 10f;
    }

    
}
