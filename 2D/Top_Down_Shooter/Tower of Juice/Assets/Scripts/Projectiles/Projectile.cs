using Godot;
using System;

public class Projectile : RigidBody2D{
    [Export] int speed;
    [Export] int damage;
    float time;

    public void SetUp(Vector2 pos, float rot){
        GlobalPosition = pos;
        GlobalRotation = rot;
        ApplyCentralImpulse(Vector2.Right.Rotated(Rotation) * speed);
    }

    public override void _PhysicsProcess(float delta){
        if(GetCollidingBodies().Count > 0) Hit();
        time += delta;
        if(time >= 2) QueueFree();
    }

    private void Hit(){
        var hitated = GetCollidingBodies();
        if((Enemy)hitated[0] != null){
            var enemy = (Enemy)hitated[0];
            enemy.Hit(damage);
        }
        QueueFree();
    }
}
