using Godot;
using System;

public class Player : RigidBody2D{
	private readonly float ACCELERATION = 5;
	private readonly float DEACCELERATION = .5f;
	private readonly int SPEED = 200;
	
	private void ProcessMovement(Physics2DDirectBodyState bodyState){
		var inputVelocityHorizontal = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		inputVelocityHorizontal *= SPEED;
		inputVelocityHorizontal -= LinearVelocity.x;
		inputVelocityHorizontal = (inputVelocityHorizontal == 0) ? inputVelocityHorizontal * DEACCELERATION : inputVelocityHorizontal * ACCELERATION;
		AppliedForce = new Vector2(inputVelocityHorizontal, 0);
		bodyState.LinearVelocity += bodyState.Step * bodyState.TotalGravity;
	}

	public override void _IntegrateForces(Physics2DDirectBodyState bodyState){
		ProcessMovement(bodyState);
	}
}
