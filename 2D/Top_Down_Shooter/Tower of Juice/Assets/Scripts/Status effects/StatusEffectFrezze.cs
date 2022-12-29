using Godot;
using System;

public class StatusEffectFrezze : StatusEffect{
    protected override float maxTime {get; set;} = 2;
    
    public override void Start(Entity _entity){
        base.Start(_entity);
        entity.speed *= .5f;
    }

    public override void End(){
        entity.speed *= 2;
    }
}