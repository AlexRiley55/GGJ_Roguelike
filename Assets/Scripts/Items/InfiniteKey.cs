using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteKey : Item {

    bool gaveKey = false;

    public InfiniteKey() {
        name = "Infinite Key";
    }

    public override void Start(PlayerData pd) {

    }

    public override void Update(PlayerData pd) {
        if (pd.keys == 0) {
            gaveKey = true;
            pd.keys += 1;
        }
    }

    public override void End(PlayerData pd) {
        if (gaveKey) {
            pd.keys -= 1;
        }
    }
}
