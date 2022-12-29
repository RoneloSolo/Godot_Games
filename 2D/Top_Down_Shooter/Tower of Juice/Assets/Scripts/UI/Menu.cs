using Godot;
using System;

public class Menu : Control{
    private PackedScene transition = GD.Load<PackedScene>("res://Assets/Prefabs/Effects/SceneTransition.tscn");
    
    public void ClickPlay(){
        var tra = (SceneTransition)transition.Instance();
        tra.scenePath = "res://Assets/Scenes/Main.tscn";
        GetTree().CurrentScene.AddChild(tra);
    }
}
