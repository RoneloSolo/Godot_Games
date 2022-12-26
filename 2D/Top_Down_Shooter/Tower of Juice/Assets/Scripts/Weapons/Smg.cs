using Godot;
using System;

public class Smg : Weapon{
    [Export] private float delayShoot;
    [Export] private int amountBurst;
    private int amountLeft;
    private float time;
    private float lastTimeShoot;
    private bool isShoot;


    public override void _Process(float delta){
        time += delta;
        if(Input.IsActionJustPressed("left mouse") && !isShoot) isShoot = true;
        Shoot();
    }

    private void Shoot(){
        if(!isShoot) return;
        if(amountLeft <= 0){
            amountLeft = amountBurst;
            isShoot = false;
            return;
        }
        if(time < lastTimeShoot + delayShoot) return;
        amountLeft--;
        lastTimeShoot = time;
        SpawnProjactile(projectile);
    } 
}
