using Godot;
using System;

public class Enemy : KinematicBody2D{
    protected int health {get; set;}
    protected int damage {get; set;}
    protected int speed {get; set;}
    private Node2D player;
    private PackedScene token = GD.Load<PackedScene>("res://Assets/Prefabs/World/Token.tscn");
    private bool isDeath;

    public override void _Ready(){
        player = GetTree().CurrentScene.GetNode<Node2D>("World/Player");
    }
    
    public void Hit(int damage){
        health -= damage;
        if(health > 0) return; 
        for(int i = 0; i < 5; i++){
            if(isDeath) return;
            var newToken = (Node2D)token.Instance();
            newToken.GlobalPosition = GlobalPosition + new Vector2((float)GD.RandRange(-25,25), (float)GD.RandRange(-25,25));
            GetTree().CurrentScene.GetNode<YSort>("World").AddChild(newToken);
        }
    
        isDeath = true;
        QueueFree();
    }

    public void MoveToPlayer(int speed){
        MoveAndSlide((player.GlobalPosition - GlobalPosition) * speed);
    }
}
