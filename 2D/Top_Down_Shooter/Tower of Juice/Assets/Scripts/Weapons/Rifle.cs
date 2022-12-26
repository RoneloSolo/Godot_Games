using Godot;
using System;

public class Rifle : Weapon{
	[Export] public float delayShoot;
	private float time;
	private float lastTimeShoot;

	public override void _Process(float delta){
		time += delta;
		if(Input.IsActionPressed("left mouse")) Shoot();
	}

	private void Shoot(){
		if(time < lastTimeShoot + delayShoot) return;
		lastTimeShoot = time;
		SpawnProjactile(projectile);
	} 
}
