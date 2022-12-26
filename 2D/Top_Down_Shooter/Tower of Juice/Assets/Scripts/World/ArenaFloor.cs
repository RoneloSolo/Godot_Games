using Godot;
using System;

public class ArenaFloor : Floor{
    [Export] private PackedScene[] enemies;
    private int enemiesLeft;
    float timeLeft = 1;
    bool isSpawned;
    private PlayerData playerData = GD.Load<PlayerData>("res://Assets/Resources/PlayerData.tres");

    public override void SetUpFloor(Godot.Object manager, PackedScene floorToGo){
        base.SetUpFloor(manager, lobbyFloor);
        teleporter.Visible = false;
    }

    private void EnemyDeath(){
        enemiesLeft--;
        if(enemiesLeft <= 0) ArenaClear();
    }

    private void ArenaClear(){
        teleporter.Visible = true;
        playerData.SetToken(playerData.token + 25);
    }

    private void SpawnWave(){
        enemiesLeft = 25;
        for (int i = 0; i < 25; i++){
            var _enemy = (Node2D)enemies[0].Instance();
            GetTree().CurrentScene.GetNode<YSort>("World").AddChild(_enemy);
            _enemy.GlobalPosition = new Vector2((float)GD.RandRange(-500,500), (float)GD.RandRange(-500,500));
            _enemy.Connect("tree_exiting", this, "EnemyDeath");
        }
    }

    public override void _PhysicsProcess(float delta){
        if(isSpawned) return;
        if(timeLeft > 0) timeLeft -= delta;
        else {
            SpawnWave();
            isSpawned = true;
        }
    }
}
