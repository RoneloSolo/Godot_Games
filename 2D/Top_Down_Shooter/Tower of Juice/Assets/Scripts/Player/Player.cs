using Godot;
using System;

public class Player : RigidBody2D{
	private float deltaTime;
	private float time;
	private float speed = 120;
	private Position2D hand;
	private Vector2 mousePos;
	private Sprite playerSpirte;
	private float frictionScale = 8; 
	private float gettingSpeedScale = 1f; 
	private Vector2 topVelocity;
	private PlayerData data = GD.Load<PlayerData>("res://Assets/Resources/PlayerData.tres");
	private UIManager UI;

	public override void _Ready(){
		hand = GetNode<Position2D>("Hand");
		playerSpirte = GetNode<Sprite>("Sprite");
		UI = GetTree().CurrentScene.GetNode<UIManager>("CanvasLayer");
	}

	public override void _Process(float delta) {
		deltaTime = delta;
		time += deltaTime;
		mousePos = GetGlobalMousePosition();
		HandHendler();
	}

	public override void _PhysicsProcess(float delta) {
		Movement();
	}

	private void Movement() {
		topVelocity.x = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		topVelocity.y = Input.GetActionStrength("down") - Input.GetActionStrength("up");
		topVelocity = topVelocity.Normalized() * speed;
		var desVelocity = topVelocity - LinearVelocity;
		desVelocity = (topVelocity.Length() <= 0) ? desVelocity * frictionScale : desVelocity * gettingSpeedScale;
		AppliedForce = desVelocity;
	}

	public override void _IntegrateForces(Physics2DDirectBodyState state){
		Movement();
	}

	private void HandHendler() {
		if (Position.x < mousePos.x && playerSpirte.FlipH) playerSpirte.FlipH = false;
		else if (Position.x > mousePos.x && !playerSpirte.FlipH) playerSpirte.FlipH = true;
	}

	public void Hit(int damage){
		data.SetHp(data.hp - damage);
		UI.UpdateHpUI();
	}
}