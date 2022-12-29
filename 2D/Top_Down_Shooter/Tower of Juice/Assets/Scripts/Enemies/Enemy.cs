using Godot;
using System;

public class Enemy : Entity{
    private Node2D player;
    private PackedScene token = GD.Load<PackedScene>("res://Assets/Prefabs/World/Token.tscn");
    private bool isDeath;
    protected int damage;


    public override void _Ready(){
        SetUp(25,5,5);
        player = GetTree().CurrentScene.GetNode<Node2D>("World/Player");
        GetNode<Area2D>("Hit Area").Connect("body_entered", this, "Damage");
    }
    
    public override void Hit(int damage){
        healthPoints -= damage;
        if(healthPoints <= 0) Die();
    }

    private void Die(){
        for(int i = 0; i < 5; i++){
            if(isDeath) return;
            var newToken = (Node2D)token.Instance();
            newToken.GlobalPosition = GlobalPosition + new Vector2((float)GD.RandRange(-25,25), (float)GD.RandRange(-25,25));
            GetTree().CurrentScene.GetNode<YSort>("World").AddChild(newToken);
        }
    
        isDeath = true;
        QueueFree();
    }

    public void MoveToPlayer(float speed){
        MoveAndSlide((player.GlobalPosition - GlobalPosition).Normalized() * speed);
    }

    private void Damage(Node node){
        var hitNode = (Entity)node;
        if(hitNode == null) return;
        hitNode.Hit(damage);
    }
}
