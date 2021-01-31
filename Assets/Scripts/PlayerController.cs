using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpStartingSpeed = 20f;
    public float accelJumpMaxSpeed = 35f;
    public float basicJumpAccel = 20f;
    public float basicJumpMaxSpeed = 10f;
    public float jumpAccel = 50f;

    public bool isJumping = false;
    public bool basicJumping = false;
    public bool accelJump = false;

    public float runSpeed = 15f;
    public float modifiedRunSpeed;

    public float maxHealth = 100f;
    public float modifiedmaxHealth;
    public float currentHealth = 100f;
    public float gravity = 30f;

    public float currentJumpSpeed = 0f;
    public float currentBasicJumpSpeed = 0f;
    public float currentAccelJumpSpeed = 0f;
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

        attachItem(new DoubleJump());
        //attachItem(new RunningBoots());
        //detachItem(new RunningBoots());
    }

    // Update is called once per frame
    void Update() {
        CharacterController cc = gameObject.GetComponent(typeof(CharacterController)) as CharacterController;

        move();

        if (Input.GetKeyDown("left shift")) { //TODO: make this use axis for compatability later?
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
            currentAccelJumpSpeed = jumpStartingSpeed;
            accelJump = true;
            basicJumping = true;
        } else if (Input.GetAxis("Vertical") < 0.1 && accelJump) {
            accelJump = false;
            currentJumpSpeed -= currentAccelJumpSpeed;
            currentAccelJumpSpeed = 0;
        }

        if (basicJumping) {
            currentJumpSpeed += basicJumpAccel * Time.deltaTime;
            currentBasicJumpSpeed += basicJumpAccel * Time.deltaTime;
            if (currentBasicJumpSpeed >= basicJumpMaxSpeed) {
                basicJumping = false;
                currentJumpSpeed -= currentBasicJumpSpeed;
                currentBasicJumpSpeed = 0;
            }
        }

        if (accelJump) {
            currentJumpSpeed += jumpAccel * Time.deltaTime;
            currentAccelJumpSpeed += jumpAccel * Time.deltaTime;
            if (currentAccelJumpSpeed >= accelJumpMaxSpeed) {
                accelJump = false;
                currentJumpSpeed -= currentAccelJumpSpeed;
                currentAccelJumpSpeed = 0;
            }
        }

        if (isJumping) {
            cc.Move(transform.up * currentJumpSpeed * Time.deltaTime);
        }

        if ((!basicJumping && !accelJump) || !isJumping) { //others can cancel a jump by setting isJumping to false
            currentJumpSpeed = 0;
            currentBasicJumpSpeed = 0;
            isJumping = false;
        }

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
