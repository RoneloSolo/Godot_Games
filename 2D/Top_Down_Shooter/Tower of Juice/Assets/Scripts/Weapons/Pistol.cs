using Godot;
using System;

public class Pistol : Weapon{

    public override void _Input(InputEvent @event){
        if(Input.IsActionJustPressed("left mouse")) Shoot();
    }

    private void Shoot(){
        SpawnProjactile(projectile);
    }
}
