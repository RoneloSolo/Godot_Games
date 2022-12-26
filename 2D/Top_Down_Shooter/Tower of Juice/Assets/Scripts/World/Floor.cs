using Godot;
using System;

public class Floor : Node2D{
    protected PackedScene arenaFloor = GD.Load<PackedScene>("res://Assets/Prefabs/World/ArenaFloor.tscn");
    protected PackedScene lobbyFloor = GD.Load<PackedScene>("res://Assets/Prefabs/World/LobbyFloor.tscn");
    protected Area2D teleporter;

    public virtual void SetUpFloor(Godot.Object manager, PackedScene floorToGo = null){
        teleporter =  GetNode<Area2D>("Teleporter");
        teleporter.Connect("body_entered", manager, "EnterTeleporter", new Godot.Collections.Array(){floorToGo});
    }
}
