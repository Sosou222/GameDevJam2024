using Constants;
using Godot;
using System;

using Godot.Collections;

public partial class WaveManager : Node2D
{
	[Signal]
	public delegate void WaveEndEventHandler(int waveNumber);


	[Export] private PackedScene enemyPackedScene;

	private Timer timer;
	private Path2D enemyPath;

	private Array<string> waveData = new();
	private int waveIndex = 0;
	private int wavePositionCurrent = 0;
	private int enemyCount = 0;
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		enemyPath = GetNode<Path2D>("EnemyPath");

		timer.Timeout += OnSpawnEnemy;
		this.WaveEnd += (waveN) => GD.Print($"Wave {waveN} ended");
		//StartWave(0);
	}

	public void StartWave(int waveNumber)
	{
		waveIndex = waveNumber;
		waveData.Clear();

		foreach (WaveInfo info in WaveData.Info[waveIndex])
		{
			for (int i = 0; i < info.Amount; i++)
				waveData.Add(info.EnemyType);
		}

		enemyCount = waveData.Count;

		wavePositionCurrent = 0;
		timer.Start();
	}

	private void OnSpawnEnemy()
	{
		if (wavePositionCurrent >= waveData.Count)
		{
			timer.Stop();
			return;
		}

		string enemyType = waveData[wavePositionCurrent];

		Enemy enemy = enemyPackedScene.Instantiate<Enemy>();
		enemyPath.AddChild(enemy);
		enemy.Init(enemyType, EnemyData.Info[enemyType]);

		//enemy.ReachedEnd += OnEnemyEndOrDie;
		//enemy.healthComponent.Die += OnEnemyEndOrDie;

		enemy.TreeExited += OnEnemyEndOrDie;

		wavePositionCurrent++;
	}

	private void OnEnemyEndOrDie()
	{
		enemyCount--;
		if (enemyCount == 0)
		{
			EmitSignal(SignalName.WaveEnd, waveIndex);
		}
	}
}
