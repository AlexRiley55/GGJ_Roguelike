using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAura : Item {
    float healingRate = 2f;

    public HealingAura() {
        name = "Healing Aura";
    }

    public override void Start(PlayerData pd) {

    }

    public override void Update(PlayerData pd) {
        pd.currentHealth += healingRate * Time.deltaTime;
    }

    public override void End(PlayerData pd) {

    }
}
