using Godot;
using System;

public class Goblin : Enemy{

    private int health {get; set;} = 25;
    private int damage {get; set;} = 25;
    private int speed {get; set;} = 1;

    public override void _PhysicsProcess(float delta){
        MoveToPlayer(speed);
    }
}
