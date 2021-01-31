using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteKey : Item {

    bool gaveKey = false;

    public InfiniteKey() {
        name = "Infinite Key";
    }

    public override void Start(PlayerController pc) {

    }

    public override void Update(PlayerController pc) {
        if (pc.keys == 0) {
            gaveKey = true;
            pc.keys += 1;
        }
    }

    public override void End(PlayerController pc) {
        if (gaveKey) {
            pc.keys -= 1;
        }
    }
}
