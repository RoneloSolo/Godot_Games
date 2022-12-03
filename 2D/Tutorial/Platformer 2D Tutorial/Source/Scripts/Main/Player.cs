using Godot;
using System;

public class Player : KinematicBody2D{
	//Movement
	private readonly float DEACCELERATION = 2;
	private readonly float ACCELERATION = 7f;
	private readonly int SPEED = 50;
	//Jump
	private readonly float L_CAYOTE = .2f;
	private readonly float L_BUFFER = .2f;
	private readonly float L_DELAY = .1f;
	private readonly int JUMP_THRUST = 100;
	private float t_cayote;
	private float t_buffer;
	private float t_delay;
	private bool isOnFloor;
	private readonly float GRAVITY = 9.81f;
	private Vector2 velocity;

	public override void _Process(float delta){
		ProccesJump(delta);
	}

	public override void _PhysicsProcess(float delta){
		ProccesMovement(delta);
	}

	private void CheckFloorColl(Godot.Object node, bool b){
		t_cayote = L_CAYOTE;
		isOnFloor = b;
	}

	private void ProccesJump(float delta){
		if(t_buffer > 0) t_buffer -= delta;
		if(!isOnFloor) t_cayote -= delta;
		if(t_delay > 0) t_delay -= delta;
		if(!Input.IsActionJustPressed("jump") || t_delay > 0) return;
		t_buffer = L_BUFFER;
	}

	private void ProccesMovement(float delta){
		var input = (Input.GetActionStrength("right") - Input.GetActionStrength("left")) * SPEED;

		if(input != 0) velocity.x = Mathf.Lerp(velocity.x, input, ACCELERATION * delta);
		else velocity.x = Mathf.Lerp(velocity.x, input, DEACCELERATION * delta);

		if(t_cayote > 0 && t_buffer > 0){
			t_buffer = 0;
			t_delay = L_DELAY;
			velocity.y -= JUMP_THRUST;
		}

		velocity.y += GRAVITY * delta;

		MoveAndSlide(velocity);
	}
}
