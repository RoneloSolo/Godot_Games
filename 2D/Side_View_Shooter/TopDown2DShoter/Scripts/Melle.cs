using Godot;
using System;

public class Melle : PlayerState{
	public override void On(){
		GD.Print("Melle On");
	}
	
	public override void Off(){
		GD.Print("Melle Off");
	}

	public override void Update(){
	}
	
	public override void input(InputEvent inputEvent){
	}
}
