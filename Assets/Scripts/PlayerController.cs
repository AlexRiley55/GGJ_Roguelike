using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpStartingSpeed = 0.03f;
    public float jumpMaxSpeed = 0.1f;
    public float jumpAccel = 0.45f;

    public bool isJumping = false;
    public bool accelJump = false;

    public float runSpeed = 20f;
    public float modifiedRunSpeed;

    public float maxHealth = 100f;
    public float modifiedmaxHealth;
    public float currentHealth = 100f;
    public float gravity = 3f;

    public float currentJumpSpeed = 0f;
    public float currentGravity = 0f;

    Vector3 FacingDir = new Vector3(1, 0, 0);
    public float shootSpeed = 10f;

    public List<Item> items = new List<Item>();

    static GameObject player;

    public static GameObject getPlayer() {
        return player;
    }

    // Start is called before the first frame update
    void Start() {
        player = gameObject;
        modifiedRunSpeed = runSpeed;
        modifiedmaxHealth = maxHealth;

        //attachItem(new DoubleJump());
        attachItem(new RunningBoots());
        //detachItem(new RunningBoots());
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

        foreach (Item item in items) {
            item.Update(this);
        }
    }

    public void move() {
        CharacterController cc = gameObject.GetComponent(typeof(CharacterController)) as CharacterController;

        if (!cc.isGrounded) {
            currentGravity += gravity * Time.deltaTime;
        } else {
            currentGravity = 0;
            isJumping = false;
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
            isJumping = true;
            currentGravity = 0;
            currentJumpSpeed = jumpStartingSpeed;
            accelJump = true;
        } else if (Input.GetAxis("Vertical") < 0.1 && accelJump) {
            currentJumpSpeed = 0;
            accelJump = false;
        }

        cc.Move(transform.up * currentJumpSpeed);

        Vector3 move = transform.right * Input.GetAxis("Horizontal") * modifiedRunSpeed + transform.up * -1 * currentGravity;
        cc.Move(move * Time.deltaTime);
    }

    public void attack() {
        GameObject projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectile"); //TODO: this is slow so do it earlier
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRB = projectile.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        projectileRB.velocity = FacingDir * shootSpeed;
    }

    public void attachItem(Item item) {
        Debug.Log("Attaching " + item.name);
        item.Start(this);
        items.Add(item);
    }

    public void detachItem(Item item) {
        Debug.Log("Detaching " + item.name);
        item.End(this);
        items.Remove(item);
    }
}
