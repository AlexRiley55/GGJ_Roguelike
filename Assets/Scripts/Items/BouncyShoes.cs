using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyShoes : Item {
    public BouncyShoes() {
        name = "Bouncy Shoes";
    }

    public override void Start(PlayerData pd) {
        Rigidbody2D rb = pd.gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rb.gravityScale *= 6;
        pd.pMaster.m_JumpForce *= 4f;
    }

    public override void Update(PlayerData pd) {
        if (!pd.pMovement.jumping && !pd.pMovement.jumpActivated) {
            pd.pMovement.jumpActivated = true;
        }
    }

    public override void End(PlayerData pd) {
        Rigidbody2D rb = pd.gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rb.gravityScale /= 6;
        pd.pMaster.m_JumpForce /= 4f;
    }
}
