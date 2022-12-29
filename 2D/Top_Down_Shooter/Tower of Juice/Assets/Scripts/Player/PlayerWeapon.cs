using Godot;
using System;
using System.Collections.Generic;

public class PlayerWeapon: Position2D {
    private Node2D weapon;
    private WeaponDataBase weaponDataBase;
    private Node currentWeapon;
    private GlobalPlayer globalPlayer = GD.Load<GlobalPlayer>("res://Assets/Resources/PlayerData.tres");
    private Vector2 mousePos;
    private Position2D gunPos;

    public override void _Ready() {
        weaponDataBase = new WeaponDataBase();
        gunPos = GetNode<Position2D>("GunPosition");
        ChangeWeapon("Ak");
    }

    public void ChangeWeapon(string name) {
        if(globalPlayer.changeWeapon) globalPlayer.changeWeapon = false;
        if (currentWeapon != null) {
            weapon = (Node2D) weaponDataBase.data[name].Instance();
            gunPos.AddChild(weapon);
            weapon.GlobalPosition = gunPos.GlobalPosition;
            currentWeapon.QueueFree();
            currentWeapon = weapon;
            return;
          }
        weapon = (Node2D) weaponDataBase.data[name].Instance();
        gunPos.AddChild(weapon);
        weapon.GlobalPosition = gunPos.GlobalPosition;
        currentWeapon = weapon;
    }

    public override void _Process(float delta) {
        if(globalPlayer.changeWeapon) ChangeWeapon(globalPlayer.nameWeapon);
        LookAt(mousePos);
        if (Mathf.Rad2Deg(Rotation) > 180) Rotation = Mathf.Deg2Rad(-181);
        else if (Mathf.Rad2Deg(Rotation) < -180) Rotation = Mathf.Deg2Rad(181);
        if (Mathf.Rad2Deg(Rotation) > -90 && Mathf.Rad2Deg(Rotation) < 90) Scale = new Vector2(1, 1);
        else Scale = new Vector2(1, -1);
    }

    public override void _Input(InputEvent @event){
        mousePos = GetGlobalMousePosition();
    }
}