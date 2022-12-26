using Godot;
using System.Collections.Generic;
using System;

public class Stracture : CSGCombiner{
    public bool isBuilded;
    [Export] public int maxHealth = 100;
    [Export] public Vector2 size;
    protected int health;
    Timer timer;
    public GameManager gameManager;

    public virtual void SetUp(GameManager manager){
        gameManager = manager;
        isBuilded = true;
        timer = GetNode<Timer>("Timer");
        if(timer != null) timer.Autostart = true;
    }

    public virtual void DoStuff(){
        if(health < maxHealth) health += 10;    // Regenerate health of stracture
    }

    public virtual void Hit(int damage){
        health -= damage;
        if(health <= 0) QueueFree();
    }
}
