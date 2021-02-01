using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public Sprite usedSprite;
    bool collidingWithPlayer = false;
    bool used = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("e") && collidingWithPlayer && !used) {
            Debug.Log("enter");
            GameManager gm = GameManager.getGame();
            gm.enableDiologue(this);
            used = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            collidingWithPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            collidingWithPlayer = false;
        }
    }

    public void setUsed() {
        SpriteRenderer sr = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        sr.sprite = usedSprite;
        used = true;
        PlayerData pd = PlayerData.getPlayerData();
        tradeItem(pd);
    }

    void tradeItem(PlayerData pd) {
        int randIndex = Random.Range(0, pd.items.Count);
        Item item = pd.items[randIndex];

        pd.detachItem(item);
        pd.attachItem(Item.getRandomItem());

        GameManager gm = GameManager.getGame();
        gm.addScore();
    }
}
