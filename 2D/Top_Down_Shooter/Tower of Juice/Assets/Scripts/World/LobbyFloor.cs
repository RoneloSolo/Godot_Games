using Godot;
using System;

public class LobbyFloor : Floor{
	public override void SetUpFloor(Godot.Object manager, PackedScene floorToGo){
		base.SetUpFloor(manager, arenaFloor);
	}
}
