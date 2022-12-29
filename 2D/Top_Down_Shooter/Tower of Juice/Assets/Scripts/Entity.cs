using Godot;
using System;
using System.Collections.Generic;

public abstract class Entity: KinematicBody2D{
    public float speed{get; set;}
    public int healthPoints{get; set;}
    public int maxHealthPoints{get; set;}
	protected List<StatusEffect> statusEffects = new List<StatusEffect>();

	protected void SetUp(int speed, int healthPoints, int maxHealthPoints){
		this.speed = speed; 
		this.healthPoints = healthPoints; 
		this.maxHealthPoints = maxHealthPoints; 
	}

    public abstract void Hit(int damage);

    protected void StatusEffectHit(StatusEffect statusEffect){
		statusEffect.Start(this);
		statusEffects.Add(statusEffect);
	}

	protected void StatusEffectProcess(float delta){
		if(statusEffects.Count <= 0) return;
		foreach (var effect in statusEffects.ToArray()){
			effect.Update(delta);
			if(!effect.IsDone()) continue;
			effect.End();
			statusEffects.Remove(effect);
		}
	}
}
