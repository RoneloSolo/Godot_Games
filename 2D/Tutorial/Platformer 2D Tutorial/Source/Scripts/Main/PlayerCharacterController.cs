using Godot;
using System;

public class PlayerCharacterController : KinematicBody2D{
	private readonly float DEACCELERATION = 2;
	private readonly float ACCELERATION = 7f;
	private readonly int JUMP_THRUST = 150;
	private readonly float GRAVITY = 98.1f;
	private readonly float L_CAYOTE = .2f; 
	private readonly float L_BUFFER = .2f;
	private readonly float L_DELAY = .1f; 
	private readonly float L_HOLD = 1;
	private readonly int L_JUMP = 2;
	private readonly int SPEED = 50;
	private Vector2 velocity;
	private float t_cayote;
	private float t_buffer;
	private float t_delay;
	private float t_hold;
	private int c_jump;
	private bool isOnFloor;
	private RayCast2D cellingRay;

	public override void _Ready(){
		cellingRay = GetNode<RayCast2D>("CellingRay");
	}

	public override void _Process(float delta) => ProccesJump(delta);

	public override void _PhysicsProcess(float delta) => ProccesMovement(delta);

	private void CheckFloorColl(Godot.Object node, bool condition){
		t_cayote = L_CAYOTE;
		isOnFloor = condition;
		if(condition) c_jump = L_JUMP;
	}

	private void ProccesJump(float delta){
		if(t_buffer > 0) t_buffer -= delta;
		if(!isOnFloor) t_cayote -= delta;
		if(t_delay > 0) t_delay -= delta;
		
		if(Input.IsActionJustPressed("jump") && t_delay <= 0){
			t_buffer = L_BUFFER;
		}
		else if(Input.IsActionJustReleased("jump")) t_hold = 0;
	}

	private void ProccesMovement(float delta){
		var input = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		var maxSpeed = input * SPEED;

		if(input != 0) velocity.x = Mathf.Lerp(velocity.x, maxSpeed, ACCELERATION * delta);
		else velocity.x = Mathf.Lerp(velocity.x, 0, DEACCELERATION * delta);

		if((t_cayote > 0 && t_buffer > 0) || (t_buffer > 0 && c_jump > 0) || t_hold > 0){
			if(t_hold <= 0) t_hold = L_HOLD;
			t_hold -= delta;
			c_jump--;
			t_delay = L_DELAY;
			t_buffer = 0;
			velocity.y = 0;
			velocity.y -= JUMP_THRUST;
		}
		if(cellingRay.IsColliding() && velocity.y < 0f) velocity.y = 0;
		if(!isOnFloor) velocity.y += GRAVITY * delta;
		MoveAndSlide(velocity);
	}
}
