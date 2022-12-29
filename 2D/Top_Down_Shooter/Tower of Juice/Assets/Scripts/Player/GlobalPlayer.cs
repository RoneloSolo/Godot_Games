using Godot;
using System;

public class GlobalPlayer : Resource{
    public bool changeWeapon;
    public string nameWeapon;
    [Export] public int token {get; private set;}
    [Export] public int hp {get; private set;}

    public void SetHp(int hp){
        this.hp = hp;
    }    

    public void SetToken(int token){
        this.token = token;
    }

    public void ChangeWeapon(string name){
        changeWeapon = true;
        nameWeapon = name;
    }
}
