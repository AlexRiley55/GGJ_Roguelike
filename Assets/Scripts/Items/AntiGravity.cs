using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : Item {

    public AntiGravity() {
        name = "Anti Gravity";
    }

    public override void Start(PlayerController pc) {
        pc.modifiedGravity /= 2.0f;
    }

    public override void Update(PlayerController pc) {

    }

    public override void End(PlayerController pc) {
        pc.modifiedGravity *= 2.0f;
    }
}
