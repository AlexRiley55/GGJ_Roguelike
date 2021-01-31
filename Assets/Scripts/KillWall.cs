using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWall : MonoBehaviour {

    public float killHeight = -10;
    PlayerController pc;

    public bool active = true;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (pc == null) { //needs to initialize late after Player is spawned
            pc = PlayerController.getPlayer();
        }

        PlayerController t = pc;
        GameObject player = pc.gameObject;
        if (active && player.transform.position.y <= killHeight) {
            pc.killPlayer();
        }
    }
}
