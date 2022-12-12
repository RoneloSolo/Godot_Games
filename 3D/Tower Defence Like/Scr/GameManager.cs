using Godot;
using System.Collections.Generic;
using System;

public class GameManager : Spatial{
    private enum RescourceType{
        Gold,
        Food,
        Human
    };

    private enum StractureType{
        Tower,
        Farmland,
        House
    };

    private struct Rescourece{
        public RescourceType type;
        public int amount;

        public Rescourece(RescourceType t, int a){
            type = t;
            amount = a;
        }
        
    }

     private IDictionary<RescourceType, int> rescourceStorage = new Dictionary<RescourceType, int>(){
        {RescourceType.Food, 0},
        {RescourceType.Human, 10},
        {RescourceType.Gold, 0},

    };

    private IDictionary<StractureType, Rescourece[]> stracturesCost = new Dictionary<StractureType, Rescourece[]>(){
        {StractureType.Tower, new Rescourece[1]{
            new Rescourece(RescourceType.Human, 1)}
            },

        {StractureType.House, new Rescourece[1]{
            new Rescourece(RescourceType.Gold, 0)}
            },

        {StractureType.Farmland, new Rescourece[1]{
            new Rescourece(RescourceType.Gold, 0)}
            }
    };

    private IDictionary<StractureType, PackedScene> stracturePrefab = new Dictionary<StractureType, PackedScene>(){
        {StractureType.Tower, GD.Load<PackedScene>("res://Prefab/Tower.tscn")},
        {StractureType.House, GD.Load<PackedScene>("res://Prefab/House.tscn")},
        {StractureType.Farmland, GD.Load<PackedScene>("res://Prefab/Farmland.tscn")}
    };

    private IDictionary<Vector2, bool> worldGrid = new Dictionary<Vector2, bool>();

    private Vector2 gridSize = new Vector2(5,5);
    private Vector2 mousePos;
    private Camera camera;
    private PhysicsDirectSpaceState spaceState;
    private SpatialMaterial blueprintMaterial = GD.Load<SpatialMaterial>("res://Material/blueprint.tres");
    private SpatialMaterial stractureMaterial = GD.Load<SpatialMaterial>("res://Material/stracture.tres");

    private Spatial currentStractureBlueprint;
    private StractureType currentStracture;

    public override void _Ready(){
        camera = GetTree().CurrentScene.GetNode<Camera>("Camera");
        spaceState = GetWorld().DirectSpaceState;

        currentStractureBlueprint = GetNode<Spatial>("Tower");
        currentStracture = StractureType.Tower;
    }

    public override void _Process(float delta){
        Building();
	}

    private void Building(){
        if(currentStractureBlueprint == null) return;

        mousePos = GetViewport().GetMousePosition();
        var rawPosition = World.ScreenPointToRay(mousePos, camera, spaceState);
        var gridPositon = World.PositionToGridPosition(rawPosition, gridSize);
        currentStractureBlueprint.Translation = gridPositon;
        var positionOnGrid = World.PointToGrid(currentStractureBlueprint.Translation.x, currentStractureBlueprint.Translation.z, gridSize);

        if(worldGrid.ContainsKey(positionOnGrid) || !IsEnughRescources()){  
            blueprintMaterial.AlbedoColor = Colors.Red;
            return;
        }

        blueprintMaterial.AlbedoColor = Colors.Green;

        if(!Input.IsActionJustPressed("mouseLeft")) return;

        BuildStracture(positionOnGrid, gridPositon);
    }

    private void BuildStracture(Vector2 positionOnGrid, Vector3 gridPositon){
        foreach (var item in stracturesCost[currentStracture]){
            rescourceStorage[item.type] -= item.amount;
        }
        worldGrid.Add(positionOnGrid, true);
        var stracture = (Stracture)stracturePrefab[currentStracture].Instance();
        stracture.SetUp();
        float s = 1;
        
        // Todo: calculate furmola that the square can move in sqare and roate without go out from the square

        stracture.Translation = gridPositon + new Vector3((float)GD.RandRange(-(gridSize.x/2) + s,(gridSize.x/2) - s), 0, (float)GD.RandRange(-(gridSize.y/2) + s,(gridSize.y/2) - s));
        stracture.RotationDegrees = new Vector3(0, (float)GD.RandRange(-180,180), 0);
        GetTree().CurrentScene.AddChild(stracture);
        stracture.Material = stractureMaterial;
    }

    private bool IsEnughRescources(){
        foreach (var item in stracturesCost[currentStracture]){
            if(item.amount > rescourceStorage[item.type]) return false;
        }
        return true;
    }

}

public class World{
    public static Vector3 ScreenPointToRay(Vector2 mousePosition, Camera camera, PhysicsDirectSpaceState spaceState){
        var rayOrigin = camera.ProjectRayOrigin(mousePosition);
        var rayEnd = rayOrigin + camera.ProjectRayNormal(mousePosition) * 2000;
        var rayArray = spaceState.IntersectRay(rayOrigin, rayEnd);
        if(rayArray.Contains("position")){
            return (Vector3)rayArray["position"];  
        }
        return new Vector3(0,10,0);
    }

    public static Vector2 PointToGrid(float x, float y, Vector2 gridSize){
        return new Vector2( x / gridSize.x, y / gridSize.y);
    }

    public static Vector3 PositionToGridPosition(Vector3 position, Vector2 gridSize){
        return new Vector3(Mathf.Stepify(position.x,gridSize.x), 0, Mathf.Stepify(position.z,gridSize.y));
    }
}
