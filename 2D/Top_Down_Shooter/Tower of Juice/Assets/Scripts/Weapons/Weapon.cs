using Godot;
using System;

public class Weapon : Node2D{
    protected string name {get; set;}
    [Export] protected PackedScene projectile;
    protected Position2D point;

    public override void _Ready(){
        point = GetNode<Position2D>("Point");
    }

    public void SpawnProjactile(PackedScene projactile){
        var newProjectile = (Projectile)projectile.Instance();
        newProjectile.SetUp(point.GlobalPosition, point.GlobalRotation);
        GetTree().CurrentScene.GetNode<YSort>("World").AddChild(newProjectile);
    }
}
