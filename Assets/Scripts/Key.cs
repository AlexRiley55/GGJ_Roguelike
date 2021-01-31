using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player") {
            PlayerData pd = PlayerData.getPlayerData();
            pd.keys++;
            Destroy(gameObject);
        }
    }
}
