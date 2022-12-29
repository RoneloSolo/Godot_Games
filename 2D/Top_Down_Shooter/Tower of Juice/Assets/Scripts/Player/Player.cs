using Godot;
using System;

public class Player : Entity{
	private Position2D hand;
	private Vector2 mousePos;
	private GlobalPlayer data = GD.Load<GlobalPlayer>("res://Assets/Resources/PlayerData.tres");
	private UIManager UI;
	private Vector2 velocity;
	
	private Sprite head;
	private Sprite body;

	private Texture frontHead = GD.Load<Texture>("res://Assets/Sprites/Player/Front Face.png");
	private Texture sideHead = GD.Load<Texture>("res://Assets/Sprites/Player/Side face.png");
	private Texture backHead = GD.Load<Texture>("res://Assets/Sprites/Player/Back Face.png");

	private Texture frontbackBody = GD.Load<Texture>("res://Assets/Sprites/Player/FrontBack Body.png");
	private Texture sideBody = GD.Load<Texture>("res://Assets/Sprites/Player/Side Body.png");

	private void ReferenceObjects(){
		hand = GetNode<Position2D>("Hand");
		head = GetNode<Sprite>("Head");
		body = GetNode<Sprite>("Body");
		UI = GetTree().CurrentScene.GetNode<UIManager>("CanvasLayer");
	}

	public override void _Ready(){
		SetUp(50,5,5);
		ReferenceObjects();
		data.SetHp(healthPoints);
	}

	public override void _Process(float delta) {
		SpriteProcess();
		StatusEffectProcess(delta);
	}

	public override void _PhysicsProcess(float delta) {
		Movement();
	}

	private void Movement() {
		velocity = velocity.Normalized() * speed;
		MoveAndSlide(velocity);
	}

	private void SpriteProcess() {
		if(mousePos.y < Position.y && (mousePos.x < Position.x + 25 && mousePos.x > Position.x - 25)){
			head.Texture = backHead;
			body.Texture = frontbackBody;
		}
		else if(mousePos.y > Position.y && (mousePos.x < Position.x + 25 && mousePos.x > Position.x - 25)){
			head.Texture = frontHead;
			body.Texture = frontbackBody;
		}
		else if (Position.x < mousePos.x) {
			head.Texture = sideHead;
			head.FlipH = false;
			body.Texture = sideBody;
			body.FlipH = false;
		}
		else if (Position.x > mousePos.x) {
			head.Texture = sideHead;
			head.FlipH = true;
			body.Texture = sideBody;
			body.FlipH = true;
		}
	}

	public override void Hit(int damage){
		healthPoints -= damage;
		data.SetHp(healthPoints);
		UI.UpdateHpUI();
		if(healthPoints <= 0) Die();
	}

	private void Die(){
		GetTree().ChangeScene("res://Assets/Scenes/Menu.tscn");
	}

	public override void _Input(InputEvent @event){
		mousePos = GetGlobalMousePosition();
		velocity.x = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		velocity.y = Input.GetActionStrength("down") - Input.GetActionStrength("up");
		@event.Dispose();
	}
}
