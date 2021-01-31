using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item {
    public string name;

    //called when the item is attached
    public abstract void Start(PlayerData pd);

    // Update is called once per frame
    public abstract void Update(PlayerData pd);

    //called when the item is detached
    public abstract void End(PlayerData pd);

    static Item[] allItems;

    public static Item getRandomItem() {
        if (allItems == null) {
            allItems = new Item[] {
                new RunningBoots(),
                //new DoubleJump(),
                new AntiGravity(),
                new Glide(),
                new InfiniteKey(),
                new LeapingBoots(),
                new BouncyShoes()
                //new HealingAura()
            };
        }

        int randomIndex = Random.Range(0, allItems.Length);
        return allItems[randomIndex];
    }
}