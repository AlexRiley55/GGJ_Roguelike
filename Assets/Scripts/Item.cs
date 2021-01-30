using System.Collections;
using System.Collections.Generic;

public abstract class Item {
    public string name;

    //called when the item is attached
    public abstract void Start(PlayerController pc);

    // Update is called once per frame
    public abstract void Update(PlayerController pc);

    //called when the item is detached
    public abstract void End(PlayerController pc);
}