using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAura : Item {
    float healingRate = 2f;

    public HealingAura() {
        name = "Healing Aura";
    }

    public override void Start(PlayerController pc) {

    }

    public override void Update(PlayerController pc) {
        pc.currentHealth += healingRate * Time.deltaTime;
    }

    public override void End(PlayerController pc) {

    }
}
