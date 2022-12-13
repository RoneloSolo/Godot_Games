using Godot;
using System;

public class House : Stracture{
    public override void DoStuff(){
        base.DoStuff();
        gameManager.AddRescource(GameManager.RescourceType.Gold, 1);
    }

    public override void SetUp(GameManager manager){
        base.SetUp(manager);
        gameManager.AddRescource(GameManager.RescourceType.Human, 5);
    }
}
 