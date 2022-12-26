using Godot;
using System;

public class PlayerInteraction : Area2D{
    private bool isEnterInteraction;
    private RichTextLabel interactionGui;
    InteractableTag interactableTag;
    float timeHold;
    float timeToHold;
    Node2D interactable;
    bool isKeycardAvalibale = false;
    Interactable inter;

    public override void _Ready(){
        interactionGui = GetTree().CurrentScene.GetNode<RichTextLabel>("CanvasLayer/Gui/Interaction");
        interactableTag = InteractableTag.None;
    }

    private void OnAreaEnter(Interactable area){
        isEnterInteraction = true;    
        interactionGui.Visible = true;
        interactableTag = (InteractableTag)area.GetTag();
        inter = area;
        timeToHold = area.timeToHold;
        interactable = area.node;

        switch (interactableTag){
            case InteractableTag.Ecm:
                interactionGui.Text = "Hold F to put ecm";
                break;
            
            case InteractableTag.SmallDrill:
                interactionGui.Text = "Hold F to repair drill";
                break;
            
            case InteractableTag.LargeDrill:
                interactionGui.Text = "Hold F to repair drill";
                break;
            
            case InteractableTag.SmallDrillPut:
                interactionGui.Text = "Hold F to put drill";
                break;
            
            case InteractableTag.LargeDrillPut:
                interactionGui.Text = "Hold F to put drill";
                break;

            case InteractableTag.LargeDrillBag:
                interactionGui.Text = "Hold F to take large drill";
                break;

            case InteractableTag.Keycard:
                interactionGui.Text = "Press F to take keycard";
                break;

            case InteractableTag.KeycardScaner:
                if(isKeycardAvalibale) interactionGui.Text = "Press F to open with keycard";
                else interactionGui.Text = "Need keycard to open";
                break;

            case InteractableTag.Lockpick:
                interactionGui.Text = "Hold F to lockpick";
                break;
        }
    }

    public override void _Process(float delta){
        switch (interactableTag){
            
            case InteractableTag.Ecm:
                if(Input.IsActionPressed("interaction")) {
                    timeHold += delta;
                    if(timeHold >= timeToHold) interactable.QueueFree();
                }
                else if(Input.IsActionJustReleased("interaction")) timeHold = 0;
                break;

            case InteractableTag.Lockpick:
                if(Input.IsActionPressed("interaction")) {
                    timeHold += delta;
                    if(timeHold >= timeToHold) interactable.QueueFree();
                }
                else if(Input.IsActionJustReleased("interaction")) timeHold = 0;
                break;

            case InteractableTag.KeycardScaner:
                if(Input.IsActionPressed("interaction") && isKeycardAvalibale) {
                    interactable.QueueFree();
                    isKeycardAvalibale = false;
                }
                break;

            case InteractableTag.Keycard:
                if(Input.IsActionPressed("interaction") && !isKeycardAvalibale) {
                    interactable.QueueFree();
                    isKeycardAvalibale = true;
                }
                break;

            case InteractableTag.SmallDrill:
                
                break;
            
            case InteractableTag.LargeDrill:
                
                break;
            
            case InteractableTag.SmallDrillPut:
                if(Input.IsActionPressed("interaction")) {
                    timeHold += delta;
                    if(timeHold >= timeToHold) {
                        var drill = (Node2D)inter.smallDrill.Instance();
                        interactable.AddChild(drill);
                        drill.GlobalPosition = inter.GlobalPosition;
                        inter.QueueFree();
                    }
                }
                else if(Input.IsActionJustReleased("interaction")) timeHold = 0;
                break;

            case InteractableTag.LargeDrillPut:
                interactionGui.Text = "Hold F to put drill";
                break;

            case InteractableTag.LargeDrillBag:
                interactionGui.Text = "Hold F to take large drill";
                break;
        }
        if(timeHold >= timeToHold) timeHold = 0;
    }

    private void OnAreaExit(Area2D area){
        isEnterInteraction = false;
        interactionGui.Visible = false;
        interactableTag = InteractableTag.None;
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
}
