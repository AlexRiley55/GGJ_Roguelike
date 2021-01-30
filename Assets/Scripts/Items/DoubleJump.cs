using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : Item { //TODO: this will break if more than 1 are applied
    float doubleJumpSpeed = 500f;

    bool hasZeroedVert = false;
    bool canDoubleJump = true;
    bool justDoubleJumped = false;

    public DoubleJump() {
        name = "Double Jump";
    }

    public override void Start(PlayerController pc) {

    }

    public override void Update(PlayerController pc) {
        GameObject player = pc.gameObject;
        CharacterController cc = player.GetComponent(typeof(CharacterController)) as CharacterController;

        if (justDoubleJumped) {
            pc.currentJumpSpeed = 0;
            justDoubleJumped = false;
        }

        if (Input.GetAxis("Vertical") > 0.1 && !cc.isGrounded && !pc.accelJump && canDoubleJump && hasZeroedVert) {
            Debug.Log("Double Jump");
            pc.currentGravity = 0;
            cc.Move(pc.transform.up * doubleJumpSpeed * Time.deltaTime);
            canDoubleJump = false;
            justDoubleJumped = true;
            hasZeroedVert = false;
        }
        
        if (cc.isGrounded) {
            canDoubleJump = true;
            hasZeroedVert = false;
        }

        if (Input.GetAxis("Vertical") < 0.1 && pc.isJumping) {
            hasZeroedVert = true;
        }
    }

    public override void End(PlayerController pc) {

    }
}
