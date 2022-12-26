using Godot;
using System;

public class ShopWeaponItem : ShopItem{

    public ShopWeaponItem(string name, string description, Texture icon, int cost) : base(name, description, icon, cost){}

    public override void Buy(){
        GD.Print("Bought Weapon");
    }
}
