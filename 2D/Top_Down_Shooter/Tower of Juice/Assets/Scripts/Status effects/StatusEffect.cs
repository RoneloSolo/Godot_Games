using Godot;
using System;

public abstract class StatusEffect{
    protected float time;
    protected abstract float maxTime {get; set;}
    protected float tickTime = .2f;
    protected float lastTickTime;
    protected Entity entity;

    public virtual void Start(Entity _entity){
        time = 0;
        lastTickTime = time;
        entity = _entity;
    }

    public virtual bool Update(float delta){
        time += delta;       
        if(lastTickTime + tickTime >= time) return false;
        lastTickTime = time;
        return true;
    }

    public virtual bool IsDone(){
        return (time >= maxTime);
    }
    public abstract void End();
}
