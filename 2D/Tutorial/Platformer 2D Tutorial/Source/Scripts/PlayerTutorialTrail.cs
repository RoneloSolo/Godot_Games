// using Godot;
// using System;

// public class PlayerTutorialTrail : KinematicBody2D{

// // ====================================================================
// //  Fast movement

// 	// private readonly int SPEED = 50;

// 	// public override void _PhysicsProcess(float delta){
//     //     var input = Input.GetActionStrength("right") - Input.GetActionStrength("left");
//     //     var velocity = input * SPEED * Vector2.Right;
//     //     MoveAndSlide(velocity, Vector2.Up);
//     // }

// // =========================================================================
// //  Rearange

// 	// private readonly int SPEED = 50;
// 	// private Vector2 velocity;

// 	// public override void _PhysicsProcess(float delta){
// 	// 	velocity.x = Movement();
//     // 	MoveAndSlide(velocity, Vector2.Up);
// 	// }

// 	// private float Movement(){
// 	// 	var input = Input.GetActionStrength("right") - Input.GetActionStrength("left");
// 	// 	return input * SPEED;
// 	// }


// // ================================================================
// 	// Smooth movement

// 	// private readonly int SPEED = 50;
// 	// private Vector2 velocity;
// 	// private readonly float DEACCELERATION = 2;
// 	// private readonly float ACCELERATION = 7f;

// 	// public override void _PhysicsProcess(float delta){
// 	//     velocity.x = Movement(delta);
// 	//     MoveAndSlide(velocity, Vector2.Up);
// 	// }

// 	// private float Movement(float delta){
// 	//     var input = Input.GetActionStrength("right") - Input.GetActionStrength("left");
// 	//     var maxSpeed = input * SPEED;
// 	// 	if(input != 0) return Mathf.Lerp(velocity.x, maxSpeed, ACCELERATION * delta);
// 	// 	else return Mathf.Lerp(velocity.x, 0, DEACCELERATION * delta);
// 	// }

// // ================================================================
// 	// Gravity

// 	// private readonly int SPEED = 50;
// 	// private Vector2 velocity;
// 	// private readonly float DEACCELERATION = 2;
// 	// private readonly float ACCELERATION = 7f;
// 	// private readonly float GRAVITY = 98.1f;

// 	// public override void _PhysicsProcess(float delta){
// 	//     velocity.x = Movement(delta);
// 	// 	if(!IsOnFloor()) velocity.y += GRAVITY * delta;
// 	//     MoveAndSlide(velocity, Vector2.Up);
// 	// }

// 	// private float Movement(float delta){
// 	//     var input = Input.GetActionStrength("right") - Input.GetActionStrength("left");
// 	//     var maxSpeed = input * SPEED;
// 	// 	if(input != 0) return Mathf.Lerp(velocity.x, maxSpeed, ACCELERATION * delta);
// 	// 	else return Mathf.Lerp(velocity.x, 0, DEACCELERATION * delta);
// 	// }

// // ================================================================
// 	// Jump

	// private readonly int SPEED = 50;
	// private Vector2 velocity;
	// private readonly float DEACCELERATION = 2;
	// private readonly float ACCELERATION = 7f;
	// private readonly float GRAVITY = 98.1f;
	// private readonly int JUMP_THRUST = 150;

	// public override void _Process(float delta) => ProccesJump(delta);

	// private void ProccesJump(float delta){
	// 	if(Input.IsActionJustPressed("jump") && IsInFloor()){
	// 		velocity.y =- JUMP_THRUST;
	// 	}
	// }

	// public override void _PhysicsProcess(float delta){
	//     velocity.x = Movement(delta);
	// 	if(!IsOnFloor()) velocity.y += GRAVITY * delta;
	//     MoveAndSlide(velocity, Vector2.Up);
	// }

	// private float Movement(float delta){
	//     var input = Input.GetActionStrength("right") - Input.GetActionStrength("left");
	//     var maxSpeed = input * SPEED;
	// 	if(input != 0) return Mathf.Lerp(velocity.x, maxSpeed, ACCELERATION * delta);
	// 	else return Mathf.Lerp(velocity.x, 0, DEACCELERATION * delta);
	// }

// 	// ================================================================

// 	// Jump GRound check

// 	// private readonly int SPEED = 50;
// 	// private Vector2 velocity;
// 	// private readonly float DEACCELERATION = 2;
// 	// private readonly float ACCELERATION = 7f;
// 	// private readonly float GRAVITY = 98.1f;
// 	// private readonly int JUMP_THRUST = 150;
// 	// private readonly float L_BUFFER = .2f;
// 	// private float t_buffer;
// 	// private bool isOnFloor;

// 	// public override void _Process(float delta) => ProccesJump(delta);

// 	// private void ProccesJump(float delta){
// 	// 	if(t_buffer > 0) t_buffer -= delta;/document/d/1wbzlfE418R9E91WSpD9Z_koJtS0P0DR0f9DTH6r9gu8/edit

// 	// 	if(Input.IsActionJustPressed("jump")){
// 	// 		t_buffer = L_BUFFER;
// 	// 	}
// 	// }

// 	// public override void _PhysicsProcess(float delta){
// 	// 	isOnFloor = IsOnFloor();
// 	//     velocity.x = Movement(delta);
// 	// 	if(!isOnFloor) velocity.y += GRAVITY * delta;
// 	// 	if(t_buffer > 0 && isOnFloor){
// 	// 		velocity.y = 0;
// 	// 		t_buffer = 0;
// 	// 		velocity.y -= JUMP_THRUST;
// 	// 	}
// 	//     MoveAndSlide(velocity, Vector2.Up);
// 	// }

// 	// private float Movement(float delta){
// 	//     var input = Input.GetActionStrength("right") - Input.GetActionStrength("left");
// 	//     var maxSpeed = input * SPEED;
// 	// 	if(input != 0) return Mathf.Lerp(velocity.x, maxSpeed, ACCELERATION * delta);
// 	// 	else return Mathf.Lerp(velocity.x, 0, DEACCELERATION * delta);
// 	// }

// // ================================================================
// 	// Jump Cayote buffer  and delay

// 	// private readonly int SPEED = 50;
// 	// private Vector2 velocity;
// 	// private readonly float DEACCELERATION = 2;
// 	// private readonly float ACCELERATION = 7f;
// 	// private readonly float GRAVITY = 98.1f;
// 	// private readonly int JUMP_THRUST = 150;
// 	// private readonly float L_BUFFER = .2f;
// 	// private float t_buffer;
// 	// private bool isOnFloor;
// 	// private readonly float L_CAYOTE = .3f; 
// 	// private float t_cayote;
// 	// private float t_delay;
// 	// private readonly float L_DELAY = .1f; 

// 	// public override void _Process(float delta) => ProccesJump(delta);

// 	// private void ProccesJump(float delta){
// 	// 	if(t_buffer > 0) t_buffer -= delta;
// 	// 	if(!isOnFloor) t_cayote -= delta;
// 	// 	if(t_delay > 0) t_delay -= delta;

// 	// 	if(Input.IsActionJustPressed("jump") && t_delay <= 0){
// 	// 		t_buffer = L_BUFFER;
// 	// 	}
// 	// }

// 	// public override void _PhysicsProcess(float delta){
// 	// 	isOnFloor = IsOnFloor();
// 	// 	if(isOnFloor) t_cayote = L_CAYOTE;
// 	// 	else velocity.y += GRAVITY * delta;
// 	//     velocity.x = Movement(delta);
// 	// 	if(t_cayote > 0 && t_buffer > 0){
// 	// 		t_delay = L_DELAY;
// 	// 		velocity.y = 0;
// 	// 		t_buffer = 0;
// 	// 		t_cayote = 0
// 	// 		velocity.y -= JUMP_THRUST;
// 	// 	}

// 	//     MoveAndSlide(velocity, Vector2.Up);
// 	// }

// 	// private float Movement(float delta){
// 	//     var input = Input.GetActionStrength("right") - Input.GetActionStrength("left");
// 	//     var maxSpeed = input * SPEED;
// 	// 	if(input != 0) return Mathf.Lerp(velocity.x, maxSpeed, ACCELERATION * delta);
// 	// 	else return Mathf.Lerp(velocity.x, 0, DEACCELERATION * delta);
// 	// }
	
// 	// ================================================================
// 	// Jump hold and double jump final touch

// 	private readonly float DEACCELERATION = 2;
// 	private readonly float ACCELERATION = 7f;
// 	private readonly int JUMP_THRUST = 150;
// 	private readonly float GRAVITY = 98.1f;
// 	private readonly float L_CAYOTE = .2f; 
// 	private readonly float L_BUFFER = .2f;
// 	private readonly float L_DELAY = .1f; 
// 	private readonly float L_HOLD = 1;
// 	private readonly int L_JUMP = 2;
// 	private readonly int SPEED = 50;
// 	private Vector2 velocity;
// 	private float t_cayote;
// 	private float t_buffer;
// 	private float t_delay;
// 	private float t_hold;
// 	private int c_jump;
// 	private bool isOnFloor;

// 	private void ProccesJump(float delta){
// 		if(t_buffer > 0) t_buffer -= delta;
// 		if(!isOnFloor) t_cayote -= delta;
// 		if(t_delay > 0) t_delay -= delta;
		
// 		if(Input.IsActionJustPressed("jump") && t_delay <= 0){
// 			t_buffer = L_BUFFER;
// 		}
// 		else if(Input.IsActionJustReleased("jump")) t_hold = 0;
// 	}

// 	private void Jump(float delta){
// 		if((t_cayote > 0 && t_buffer > 0) || (t_buffer > 0 && c_jump > 0)){
// 			t_hold = L_HOLD;
// 			c_jump--;
// 			t_buffer = 0;
// 			velocity.y = 0;
// 			velocity.y -= JUMP_THRUST;
// 			t_delay = L_DELAY;
// 		}
// 		else if(t_hold > 0){
// 			t_hold -= delta;
// 			velocity.y = 0;
// 			velocity.y -= JUMP_THRUST;
// 			t_delay = L_DELAY;
// 		}
// 	}

// 	private float Movement(float delta){
// 	    var input = Input.GetActionStrength("right") - Input.GetActionStrength("left");
// 	    var maxSpeed = input * SPEED;
// 		if(input != 0) return Mathf.Lerp(velocity.x, maxSpeed, ACCELERATION * delta);
// 		else return Mathf.Lerp(velocity.x, 0, DEACCELERATION * delta);
// 	}

// 	public override void _Process(float delta) => ProccesJump(delta);

// 	public override void _PhysicsProcess(float delta){
// 		isOnFloor = IsOnFloor();
// 		if(isOnFloor) {
// 			t_cayote = L_CAYOTE;
// 			c_jump = L_JUMP;
// 		}
// 		else velocity.y += GRAVITY * delta;
// 		if(IsOnCelling() && velocity.y < 0f) {
// 			velocity.y = 0;
// 			t_hold = 0;
// 		}
// 		Jump(delta);
// 	    MoveAndSlide(velocity);
// 	}
// }
