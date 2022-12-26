using Godot;
using System;

public abstract class ShopItem : Resource{
    public string name {get; private set;}
    public string description {get; private set;}
    public Texture icon {get; private set;}
    public int cost {get; private set;}

    // public Texture GetIcon() {return icon;}
    // public string _GetName() {return name;}
    // public string GetDescription() {return description;}

    public ShopItem(string name, string description, Texture icon, int cost){
        this.name = name;
        this.description = description;
        this.icon = icon;
        this.cost = cost;
    }

    public abstract void Buy();

    public bool IsAbleToBuy(int amount){ return (amount >= cost);}
}
