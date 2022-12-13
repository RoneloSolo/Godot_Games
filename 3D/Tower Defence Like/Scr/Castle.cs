using Godot;
using System;

public class Castle : Stracture{

	public override void DoStuff(){
		base.DoStuff();
		gameManager.AddRescource(GameManager.RescourceType.Gold, 1);
	}

	public override void Hit(int damage){
		health -= damage;
		if(health > 0) return;
		GD.Print("Lost Game");
		QueueFree();
	}
}
