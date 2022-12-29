using Godot;
using System;

public class TowerFloorManager : Node2D{
    private PackedScene arenaFloor = GD.Load<PackedScene>("res://Assets/Prefabs/World/ArenaFloor.tscn");
    private PackedScene lobbyFloor = GD.Load<PackedScene>("res://Assets/Prefabs/World/LobbyFloor.tscn");
    private Node2D currentFloor;
    private PackedScene transition = GD.Load<PackedScene>("res://Assets/Prefabs/Effects/SceneTransition.tscn");


    public void EnterTeleporter(object body, PackedScene floor){
        EnterFloor(floor);
    }

    public override void _Ready(){
        EnterFloor(lobbyFloor);
    }

    private void EnterFloor(PackedScene floor){
        var newFloor = (Floor)floor.Instance();
        CallDeferred("add_child", newFloor);
        newFloor.SetUpFloor(this);
        if(currentFloor != null) currentFloor.QueueFree();
        currentFloor = newFloor;
    }
}
