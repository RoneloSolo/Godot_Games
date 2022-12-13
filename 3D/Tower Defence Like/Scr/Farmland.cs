using Godot;
using System;

public class Farmland : Stracture{
    public override void DoStuff(){
        base.DoStuff();
        gameManager.AddRescource(GameManager.RescourceType.Food, 1);
    }
}
