using Godot;
using System;
using System.Collections.Generic;

public class WeaponsManager : Position2D{
    private Node2D weapon;
    private WeaponDataBase weaponDataBase;

    public override void _Ready(){
        weaponDataBase = new WeaponDataBase();
        weapon = (Node2D)weaponDataBase.data["Old Revolver"].Instance();
        AddChild(weapon);
    }

    public override void _Process(float delta){
      var mousePos = GetGlobalMousePosition();
      LookAt(mousePos);
      if (Mathf.Rad2Deg(Rotation) > 180) Rotation = Mathf.Deg2Rad(-181);
      else if (Mathf.Rad2Deg(Rotation) < -180) Rotation = Mathf.Deg2Rad(181);
      if (Mathf.Rad2Deg(Rotation) > -90 && Mathf.Rad2Deg(Rotation) < 90) Scale = new Vector2(1, 1);
      else Scale = new Vector2(1, -1);
    }
}
