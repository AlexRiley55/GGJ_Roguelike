using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningBoots : Item {

    public RunningBoots() {
        name = "Running Boots";
    }

    public override void Start(PlayerData pd) {
        pd.pMovement.runSpeed *= 3.0f;
        pd.pMaster.m_MovementSmoothing *= 1.2f;
    }

    public override void Update(PlayerData pd) {
    }

    public override void End(PlayerData pd) {
        pd.pMovement.runSpeed /= 3.0f;
        pd.pMaster.m_MovementSmoothing /= 1.2f;
    }
}
