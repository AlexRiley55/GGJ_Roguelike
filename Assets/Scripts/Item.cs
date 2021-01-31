using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item {
    public string name;

    //called when the item is attached
    public abstract void Start(PlayerController pc);

    // Update is called once per frame
    public abstract void Update(PlayerController pc);

    //called when the item is detached
    public abstract void End(PlayerController pc);

    static Item[] allItems;

    public static Item getRandomItem() {
        if (allItems == null) {
            allItems = new Item[] {
                new RunningBoots(),
                new DoubleJump(),
                new AntiGravity(),
                new Glide(),
                new InfiniteKey()
            };
        }

        int randomIndex = Random.Range(0, allItems.Length);
        return allItems[randomIndex];
    }
}