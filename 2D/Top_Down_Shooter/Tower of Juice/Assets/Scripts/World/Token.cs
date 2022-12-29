using Godot;
using System;

public class Token : Node2D{
    private GlobalPlayer playerData = GD.Load<GlobalPlayer>("res://Assets/Resources/PlayerData.tres");
    private UIManager UI;

	public override void _Ready(){
		UI = GetTree().CurrentScene.GetNode<UIManager>("CanvasLayer");
	}

    public void OnBodyEnter(Node2D body){
        playerData.SetToken(playerData.token + 1);
        UI.UpdateTokenUI();
        QueueFree();
    }
}
