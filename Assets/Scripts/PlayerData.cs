using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    //public PlayerController pc; //TODO

    public PlayerMaster pMaster;
    public PlayerMovement pMovement;

    public float maxHealth = 100f;
    public float modifiedMaxHealth;
    public float currentHealth = 100f;

    public List<Item> items = new List<Item>();
    public int keys;

    static PlayerData playerData;

    public static PlayerData getPlayerData() {
        return playerData;
    }

    void Awake() {
        playerData = gameObject.GetComponent(typeof(PlayerData)) as PlayerData;
        pMaster = gameObject.GetComponent(typeof(PlayerMaster)) as PlayerMaster;
        pMovement = gameObject.GetComponent(typeof(PlayerMovement)) as PlayerMovement;
    }

    // Start is called before the first frame update
    void Start() {
        modifiedMaxHealth = maxHealth;
        attachItem(new BouncyShoes());
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("left shift")) { //TODO: make this use axis for compatability later?
            Debug.Log("Fire");
            attack();
        }

        foreach (Item item in items) {
            item.Update(this);
        }

        checkHealth();
    }

    public void attack() {
        GameObject projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectile"); //TODO: this is slow so do it earlier
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRB = projectile.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        //projectileRB.velocity = shootSpeed; //* FacingDir;
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

    public void checkHealth() {
        if (currentHealth > modifiedMaxHealth) {
            currentHealth = modifiedMaxHealth;
        } else if (currentHealth <= 0) {
            killPlayer();
        }
    }

    public void killPlayer() {
        Debug.Log("Player has died");
        GameManager gm = GameManager.getGame();
        gm.restart();
    }

    public void reset() {
        //pc.resetVars();
        maxHealth = 100f;
        currentHealth = 100f;

        items = new List<Item>();

        Awake();
        Start();
    }
}
