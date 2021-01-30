using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpStartingSpeed;
    public float jumpMaxSpeed;
    public float jumpAccel;

    bool accelJump = false;

    public float runSpeed;
    public float health;
    public float gravity;

    float currentJumpSpeed = 0f;
    float currentGravity = 0f;

    Vector3 FacingDir = new Vector3(1, 0, 0);
    public float shootSpeed = 5f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        CharacterController cc = gameObject.GetComponent(typeof(CharacterController)) as CharacterController;

        if (accelJump) {
            currentJumpSpeed += jumpAccel * Time.deltaTime;

            if (currentJumpSpeed >= jumpMaxSpeed) {
                currentJumpSpeed = 0;
                accelJump = false;
            }
        }

        move();

        if (Input.GetKeyUp("space")) { //TODO: make this use axis for compatability later?
            Debug.Log("Fire");
            attack();
        }
    }

    public void move() {
        CharacterController cc = gameObject.GetComponent(typeof(CharacterController)) as CharacterController;

        if (!cc.isGrounded) {
            currentGravity += gravity * Time.deltaTime;
        } else {
            currentGravity = 0;
        }

        if (Input.GetAxis("Horizontal") > 0.1) {
            Debug.Log("Right");
            FacingDir.x = 1;
        }

        if (Input.GetAxis("Horizontal") < -0.1) {
            Debug.Log("Left");
            FacingDir.x = -1;
        }

        if (Input.GetAxis("Vertical") > 0.1 && cc.isGrounded) {
            Debug.Log("Jump");
            currentGravity = 0;
            currentJumpSpeed = jumpStartingSpeed;
            accelJump = true;
        } else if (Input.GetAxis("Vertical") < 0.1 && accelJump) {
            currentJumpSpeed = 0;
            accelJump = false;
        }

        cc.Move(transform.up * currentJumpSpeed);

        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.up * -1 * currentGravity;
        cc.Move(runSpeed * Time.deltaTime * move);
    }

    public void attack() {
        GameObject projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectile");
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRB = projectile.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        projectileRB.velocity = FacingDir * shootSpeed;
    }
}
