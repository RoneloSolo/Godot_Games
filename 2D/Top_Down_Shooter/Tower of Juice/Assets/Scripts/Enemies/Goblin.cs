using Godot;
using System;

public class Goblin : Enemy{

    public override void _Ready(){
        base._Ready();
        damage = 5;
    }
    public override void _PhysicsProcess(float delta){
        MoveToPlayer(speed);
    }
}
