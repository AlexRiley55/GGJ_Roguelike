using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public Vector3 openRelativePosition;
    Vector3 openPosition;

    public float openSpeed = 10f;
    public bool opening = false;

    void Start() {
        openPosition = transform.position + openRelativePosition;
    }

    // Update is called once per frame
    void Update() {
        if (opening && Vector3.Distance(transform.position, openPosition) > 0.1f) {
            transform.Translate(openRelativePosition * Time.deltaTime * openSpeed);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player") {
            PlayerController pc = PlayerController.getPlayer();
            if (pc.keys > 0) {
                pc.keys--;
                opening = true;
            }
        }
    }
}
