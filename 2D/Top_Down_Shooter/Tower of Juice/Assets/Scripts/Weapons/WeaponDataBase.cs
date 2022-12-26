using Godot;
using System;
using System.Collections.Generic;

public class WeaponDataBase : Node{

    public IDictionary<string, PackedScene> data = new Dictionary<string, PackedScene>(){
        {"Old Revolver", GD.Load<PackedScene>("res://Assets/Prefabs/Weapons/OldRevolver.tscn")},
        {"Berreta", GD.Load<PackedScene>("res://Assets/Prefabs/Weapons/Berreta.tscn")},
        {"Glock", GD.Load<PackedScene>("res://Assets/Prefabs/Weapons/Glock.tscn")},
        {"Mp5", GD.Load<PackedScene>("res://Assets/Prefabs/Weapons/Mp5.tscn")},
        {"Famas", GD.Load<PackedScene>("res://Assets/Prefabs/Weapons/Famas.tscn")},
        {"Aug", GD.Load<PackedScene>("res://Assets/Prefabs/Weapons/Aug.tscn")},
        {"M4", GD.Load<PackedScene>("res://Assets/Prefabs/Weapons/M4.tscn")},
        {"Ak", GD.Load<PackedScene>("res://Assets/Prefabs/Weapons/Ak.tscn")},
        {"Chauchat", GD.Load<PackedScene>("res://Assets/Prefabs/Weapons/Chauchat.tscn")}
    };
}
