using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public Sprite usedSprite;
    bool collidingWithPlayer = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("e") && collidingWithPlayer) {
            setUsed();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player") {
            collidingWithPlayer = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Player") {
            collidingWithPlayer = false;
        }
    }

    void setUsed() {
        SpriteRenderer sr = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        sr.sprite = usedSprite;
    }
}
