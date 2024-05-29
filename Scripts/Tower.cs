using Godot;
using System;

using System.Collections.Generic;

public partial class Tower : Node2D
{

	[Export] private PackedScene bulletScene;

	private Node2D weaponHolder;
	private Marker2D shootMarker;
	private EnemyDetectionComponent enemyDetectionComponent;

	private List<Enemy> enemies => enemyDetectionComponent.enemies;

	private Tween shootTween;

	private const int pixelAtlasSeperationX = 64;

	public override void _Ready()
	{
		weaponHolder = GetNode<Node2D>("WeaponHolder");
		shootMarker = weaponHolder.GetNode<Marker2D>("Marker2D");
		enemyDetectionComponent = GetNode<EnemyDetectionComponent>("EnemyDetectionComponent");
	}

	public override void _Process(double delta)
	{
		if (shootTween == null)
		{

		}
	}

	private void TryShooting()
	{
		enemies.RemoveAll(e => e == null || !IsInstanceValid(e));
		Enemy en = EnemiesManager.GetFirstEnemyInSightOrNull(enemies);
		if (en != null)
		{

		}
	}

	private void Shoot()
	{
		enemies.RemoveAll(e => e == null || !IsInstanceValid(e));
		Enemy en = EnemiesManager.GetFirstEnemyInSightOrNull(enemies);
		if (en != null)
		{
			//GD.Print($"Enemy {en.Name} progres:{en.ProgressRatio}");
			weaponHolder.LookAt(en.GlobalPosition);
			Vector2 dirToEnemy = (en.GlobalPosition - shootMarker.GlobalPosition).Normalized();

			Bullet bullet = bulletScene.Instantiate<Bullet>();
			bullet.Init(dirToEnemy);
			bullet.GlobalPosition = shootMarker.GlobalPosition;
			bullet.LookAt(en.GlobalPosition);

			GetTree().Root.AddChild(bullet);
		}
	}

}
