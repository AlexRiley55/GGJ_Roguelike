using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : Item { //TODO: this will break if more than 1 are applied
    float initialDJSpeed = 20f;
    float maxDJSpeed = 35f;
    float DJbasicAccel = 10f;
    float DJAccel = 50f;

    float currentDJSpeed = 0;

    bool DJumping = false;
    bool accelDJ = false;

    bool hasZeroedVert = false;
    bool canDoubleJump = true;

    public DoubleJump() {
        name = "Double Jump";
    }

    public override void Start(PlayerData pd) {

    }

    public override void Update(PlayerData pd) {
        /*

        GameObject player = pc.gameObject;
        CharacterController cc = player.GetComponent(typeof(CharacterController)) as CharacterController;

        if (Input.GetAxis("Vertical") > 0.1 && !cc.isGrounded && canDoubleJump && hasZeroedVert) {
            Debug.Log("Double Jump");
            pc.currentGravity = 0;
            currentDJSpeed = initialDJSpeed;
            canDoubleJump = false;
            hasZeroedVert = false;
            accelDJ = true;
            DJumping = true;
        } else if (Input.GetAxis("Vertical") < 0.1 && accelDJ) {
            //currentDJSpeed = 0;
            accelDJ = false;
        }

        if (DJumping) {
            currentDJSpeed += DJbasicAccel * Time.deltaTime;
        }

        if (accelDJ) {
            currentDJSpeed += DJAccel * Time.deltaTime;
            
        }

        if (DJumping) {
            cc.Move(pc.transform.up * currentDJSpeed * Time.deltaTime);
        }

        if (currentDJSpeed >= maxDJSpeed) {
            currentDJSpeed = 0;
            accelDJ = false;
            DJumping = false;
        }

        if (cc.isGrounded) {
            canDoubleJump = true;
            hasZeroedVert = false;
        }

        if (Input.GetAxis("Vertical") < 0.1 && pc.isJumping) {
            hasZeroedVert = true;
        }

        */
    }

    public override void End(PlayerData pd) {

    }
}
