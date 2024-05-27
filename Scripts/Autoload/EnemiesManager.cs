using Godot;
using System;

using System.Collections.Generic;
using System.Linq;

public partial class EnemiesManager : Node
{
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

    public static Enemy GetFirstEnemyInSightOrNull(Godot.Collections.Array<Enemy> enemiesInSight)
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
