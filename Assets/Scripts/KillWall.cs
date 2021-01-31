using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWall : MonoBehaviour {

    public float killHeight = -10;
    PlayerData pd;

    public bool active = true;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (pd == null) { //needs to initialize late after Player is spawned
            pd = PlayerData.getPlayerData();
        }

        GameObject player = pd.gameObject;
        if (active && player.transform.position.y <= killHeight) {
            pd.killPlayer();
        }
    }
}
