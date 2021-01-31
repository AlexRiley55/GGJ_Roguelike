﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningBoots : Item {

    float damageRate = 1f;

    public RunningBoots() {
        name = "Running Boots";
    }

    public override void Start(PlayerController pc) {
        pc.modifiedRunSpeed *= 5.0f;
    }

    public override void Update(PlayerController pc) {
        pc.currentHealth -= damageRate * Time.deltaTime;
    }

    public override void End(PlayerController pc) {
        pc.modifiedRunSpeed /= 5.0f;
    }
}
