﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : Item {

    public AntiGravity() {
        name = "Anti Gravity";
    }

    public override void Start(PlayerData pd) {
        //pc.modifiedGravity /= 2.0f;
        Rigidbody2D rb = pd.gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rb.gravityScale /= 6;
        pd.pMaster.m_JumpForce /= 3f;
    }

    public override void Update(PlayerData pd) {

    }

    public override void End(PlayerData pd) {
        //pc.modifiedGravity *= 2.0f;
        Rigidbody2D rb = pd.gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rb.gravityScale *= 6;
        pd.pMaster.m_JumpForce *= 3f;
    }
}
