using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glide : Item {
    float prior_jumpStartingSpeed;
    float prior_accelJumpMaxSpeed;
    float prior_basicJumpAccel;
    float prior_basicJumpMaxSpeed;
    float prior_jumpAccel;
    public float prior_modifiedRunSpeed;
    public float prior_modifiedGravity;

    public Glide() {
        name = "Glide";
    }

    public override void Start(PlayerData pd) {
        /*
        prior_jumpStartingSpeed = pc.jumpStartingSpeed;
        pc.jumpStartingSpeed = 20;

        prior_accelJumpMaxSpeed = pc.accelJumpMaxSpeed;
        pc.accelJumpMaxSpeed = 25;

        prior_basicJumpAccel = pc.basicJumpAccel;
        pc.basicJumpAccel = 0;

        prior_basicJumpMaxSpeed = pc.basicJumpMaxSpeed;
        pc.basicJumpMaxSpeed = 0;

        prior_jumpAccel = pc.jumpAccel;
        pc.jumpAccel = 45;

        prior_modifiedRunSpeed = pc.modifiedRunSpeed;
        pc.modifiedRunSpeed = 20;

        prior_modifiedGravity = pc.modifiedGravity;
        pc.modifiedGravity = 10;
        */

        pd.pMaster.m_MovementSmoothing *= 3;
    }

    public override void Update(PlayerData pd) {
        if (pd.pMovement.jumping == true) {
            pd.pMaster.playerRigidbody2D.AddForce(new Vector2(0f, 2));
        }
    }

    public override void End(PlayerData pd) {
        /*
        pc.jumpStartingSpeed = prior_jumpStartingSpeed;

        pc.accelJumpMaxSpeed = prior_accelJumpMaxSpeed;

        pc.basicJumpAccel = prior_basicJumpAccel;

        pc.basicJumpMaxSpeed = prior_basicJumpMaxSpeed;

        pc.jumpAccel = prior_jumpAccel;

        pc.modifiedRunSpeed = prior_modifiedRunSpeed;

        pc.modifiedGravity = prior_modifiedGravity;
        */

        pd.pMaster.m_MovementSmoothing /= 3;
    }
}
