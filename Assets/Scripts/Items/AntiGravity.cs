using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : Item {

    public AntiGravity() {
        name = "Anti Gravity";
    }

    public override void Start(PlayerData pd) {
        //pc.modifiedGravity /= 2.0f;
    }

    public override void Update(PlayerData pd) {

    }

    public override void End(PlayerData pd) {
        //pc.modifiedGravity *= 2.0f;
    }
}
