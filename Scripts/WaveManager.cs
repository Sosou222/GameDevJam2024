using Godot;
using System;

public partial class WaveManager : Node2D
{
	[Export] private PackedScene enemyPackedScene;

	private Timer timer;
	private Path2D enemyPath;
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		enemyPath = GetNode<Path2D>("EnemyPath");

		timer.Timeout += OnSpawnEnemy;
	}

	private void OnSpawnEnemy()
	{
		Enemy enemy = enemyPackedScene.Instantiate<Enemy>();
		enemyPath.AddChild(enemy);
	}
}
