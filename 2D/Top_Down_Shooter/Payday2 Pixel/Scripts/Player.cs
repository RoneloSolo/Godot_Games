using Godot;
using System;

public class Player : KinematicBody2D{
	private Position2D hand;
	private Vector2 mousePos;
    private Sprite playerSpirte;
    
    public override void _Ready(){
		hand = GetNode<Position2D>("Hand");
		playerSpirte = GetNode<Sprite>("Sprite");
	}

    public override void _PhysicsProcess(float delta){
        var inputX = Input.GetActionStrength("right") - Input.GetActionStrength("left"); 
        var inputY = Input.GetActionStrength("down") - Input.GetActionStrength("up"); 

        MoveAndSlide(new Vector2(inputX, inputY).Normalized() * 50);
    }

    public override void _Process(float delta) {
		mousePos = GetGlobalMousePosition();
		HandHendler();
	}

    private void HandHendler() {
		if (Position.x < mousePos.x && playerSpirte.FlipH) playerSpirte.FlipH = false;
		else if (Position.x > mousePos.x && !playerSpirte.FlipH) playerSpirte.FlipH = true;
		hand.LookAt(mousePos);
		if (Mathf.Rad2Deg(hand.Rotation) > 180) hand.Rotation = Mathf.Deg2Rad(-181);
		else if (Mathf.Rad2Deg(hand.Rotation) < -180) hand.Rotation = Mathf.Deg2Rad(181);
		if (Mathf.Rad2Deg(hand.Rotation) > -90 && Mathf.Rad2Deg(hand.Rotation) < 90) hand.Scale = new Vector2(1, 1);
		else hand.Scale = new Vector2(1, -1);
	}
}
