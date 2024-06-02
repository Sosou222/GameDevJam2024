using Constants;
using Godot;
using System;

using System.Collections.Generic;
using System.Linq;

public partial class EnemiesManager : Node
{
    private Dictionary<EnemyType, PackedScene> enemiesScenes = new();

    private static EnemiesManager instance;

    private List<Enemy> enemies = new();

    public override void _Ready()
    {
        if (instance != null)
        {
            QueueFree();
            return;
        }
        instance = this;

        enemiesScenes.Add(EnemyType.Leafbug, GD.Load<PackedScene>("res://Nodes/Prefabs/Enemies/EnemyLeafbug.tscn"));
        enemiesScenes.Add(EnemyType.FireBug, GD.Load<PackedScene>("res://Nodes/Prefabs/Enemies/EnemyFirebug.tscn"));
    }

    public override void _Process(double delta)
    {
        var groupArray = GetTree().GetNodesInGroup("Enemy");

        foreach (var group in groupArray)
        {
            if (group is Enemy enemy)
            {
                enemies.Add(enemy);
            }
        }
    }

    public static PackedScene GetEnemyScene(EnemyType enemyType)
    {
        return instance.enemiesScenes[enemyType];
    }

    public static Enemy GetFirstEnemyInSightOrNull(List<Enemy> enemiesInSight)
    {
        var tmp = instance.enemies.Where(e => enemiesInSight.Contains(e)).ToList();
        if (tmp.Count == 0)
        {
            return null;
        }
        tmp = tmp.OrderBy(e => e.ProgressRatio).ToList();

        if (tmp.Count >= 2)
        {
            //GD.Print($"First ratio:{tmp[0].ProgressRatio} Last Ratio:{tmp.Last().ProgressRatio}");
        }
        return tmp.Last();
    }
}
