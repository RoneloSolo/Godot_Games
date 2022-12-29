using Godot;
using System;

public class SceneTransition : Control{
    private AnimationPlayer anim;
    public string scenePath = "";

    public override void _Ready(){
        anim = GetNode<AnimationPlayer>("SceneTransition/AnimationPlayer");
        anim.Play("Start");  
    }

    private void AnimationFinished(string name){
        if(scenePath == ""){
            QueueFree();
        }
        else GetTree().ChangeScene(scenePath);
    }
}
