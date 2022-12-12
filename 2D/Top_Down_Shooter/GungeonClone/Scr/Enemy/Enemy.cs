using Godot;
using System;

public class Enemy : KinematicBody2D{

	public int health = 4;
	public int speed = 25;
	private Vector2 velocity;
	Vector2 extraVelocity;
	public Node2D player;
	float deacceleration = 2;
	float acceleration = 7;

	private Vector2[] direction = new Vector2[8]{Vector2.Right , new Vector2(1,-1), Vector2.Up, new Vector2(-1,-1), Vector2.Left, new Vector2(-1,1), Vector2.Down, -new Vector2(1,1)};
	private RayCast2D[] directionRay = new RayCast2D[8];
	private float[] directionValue = new float[8];

	private PackedScene essencePrefab = GD.Load<PackedScene>("res://Prefab/Essence.tscn");

	public override void _Ready(){
		for(int i = 0; i < 8; i++){
			directionRay[i] = GetNode<RayCast2D>("" + i);
		}
		player = GetTree().CurrentScene.GetNode<Node2D>("YSort/Player");
	}

	private Vector2 DirectionToMove(Vector2 target, int strengthToAvoidOthers){
		for(int i = 0; i < 8 ;i++){
			if(!directionRay[i].IsColliding()) continue;
			directionValue[i] = -5;
			if(i == 7) directionValue[0] = -strengthToAvoidOthers;
			else directionValue[i + 1] = -strengthToAvoidOthers;
			if(i == 0) directionValue[7] = -strengthToAvoidOthers;
			else directionValue[i - 1] = -strengthToAvoidOthers;
		}		
		var dirToPlayer = GlobalPosition.DirectionTo(target);
		float value = -999;
		float newValue;
		int index = 0;
		for(int i = 0; i < 8 ;i++){
			newValue = dirToPlayer.Dot(direction[i]);
			if(newValue > value){
				index = i;
				value = newValue;
			}
		}
		return direction[index];
	}

	public override void _PhysicsProcess(float delta){
		if(player == null) return;
		velocity = Movement(delta).Normalized() * speed;
	    MoveAndSlide(velocity + extraVelocity);
		extraVelocity*=.8f;
	}
	
	private Vector2 Movement(float delta){
		var maxSpeed = DirectionToMove(player.GlobalPosition, 5) * speed;
		var vel = new Vector2();

		if(maxSpeed.x != 0) vel.x = Mathf.Lerp(velocity.x, maxSpeed.x, acceleration * delta);
		else vel.x = Mathf.Lerp(velocity.x, 0, deacceleration * delta);

		if(maxSpeed.y != 0) vel.y = Mathf.Lerp(velocity.y, maxSpeed.y, acceleration * delta);
		else vel.y = Mathf.Lerp(velocity.y, 0, deacceleration * delta);


		return vel;
	}

	public void Hit(int i, Vector2 vel){
		health -=i;
		if(health<=0){
			Die();
			return;
		}
		extraVelocity += vel * 5;
	}

	private void Die(){
		var amonutToDrop = (int)GD.RandRange(1,5);
		for (int i = 0; i < amonutToDrop; i++){
			var essance = (Node2D)essencePrefab.Instance();
			essance.GlobalPosition = GlobalPosition + new Vector2((float)GD.RandRange(-10,10),(float)GD.RandRange(-10,10));
			GetTree().CurrentScene.AddChild(essance);
		}
		QueueFree();
	}
}
