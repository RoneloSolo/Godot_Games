using Godot;
using System;

public class Interactable : Node2D{
    [Export] public InteractableTag interactableTag;
    [Export] public float timeToHold;
    public Node2D node;
    public PackedScene largeDrill;
    public PackedScene  smallDrill = GD.Load<PackedScene>("res://Prefab/SmallDrill.tscn");
    public float time;
    bool isBorken;

    public override void _Ready(){
        node = (Node2D)GetParent();
    }

    public override void _Process(float delta){
        if(isBorken) return;
        switch(interactableTag){
            case InteractableTag.SmallDrill:
                time+=delta;
                if(time >= timeToHold) GetParent().QueueFree();
                break;
            case InteractableTag.LargeDrill:
                break;
        }
    }

    public enum InteractableTag{
        Ecm,
        SmallDrill,
        LargeDrill,
        SmallDrillPut,  
        LargeDrillPut,
        LargeDrillBag,
        KeycardScaner,
        Keycard,
        Lockpick,
        None
    };

    public InteractableTag GetTag(){
        return interactableTag;
    }
}
