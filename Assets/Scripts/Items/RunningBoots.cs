using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningBoots : Item {

    float damageRate = 1f;

    public RunningBoots() {
        name = "Running Boots";
    }

    public override void Start(PlayerData pd) {
        //pc.modifiedRunSpeed *= 5.0f;
    }

    public override void Update(PlayerData pd) {
        //pd.currentHealth -= damageRate * Time.deltaTime;
    }

    public override void End(PlayerData pd) {
        //pc.modifiedRunSpeed /= 5.0f;
    }
}
