using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningBoots : Item {

    public RunningBoots() {
        name = "Running Boots";
    }

    public override void Start(PlayerController pc) {
        pc.modifiedRunSpeed *= 1.20f;
    }

    public override void Update(PlayerController pc) {

    }

    public override void End(PlayerController pc) {
        pc.modifiedRunSpeed /= 1.20f;
    }
}
