using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapingBoots : Item {
    public LeapingBoots() {
        name = "Leaping Boots";
    }

    public override void Start(PlayerData pd) {
        pd.pMovement.runSpeed *= 1.5f;
    }

    public override void Update(PlayerData pd) {
        if (pd.pMovement.jumping == true) {
            pd.pMaster.playerRigidbody2D.AddForce(new Vector2( 15f, 2f));
        }
    }

    public override void End(PlayerData pd) {
        pd.pMovement.runSpeed /= 1.5f;
    }
}
