using Godot;
using System;

using System.Collections.Generic;

public enum WeaponBehavior
{
	Rotate,
	StayInPlace
}

public partial class Tower : Node2D
{

	[Export] private PackedScene bulletScene;
	[Export] private WeaponBehavior weaponBehavior = WeaponBehavior.Rotate;

	private Node2D weaponHolder;
	private Marker2D shootMarker;
	private EnemyDetectionComponent enemyDetectionComponent;
	private Timer timer;

	private List<Enemy> enemies => enemyDetectionComponent.enemies;

	private const int pixelAtlasSeperationX = 64;

	public override void _Ready()
	{
		weaponHolder = GetNode<Node2D>("WeaponHolder");
		timer = GetNode<Timer>("Timer");
		shootMarker = weaponHolder.GetNode<Marker2D>("Marker2D");
		enemyDetectionComponent = GetNode<EnemyDetectionComponent>("EnemyDetectionComponent");

		timer.Timeout += Shoot;
	}

	private void Shoot()
	{
		enemies.RemoveAll(e => e == null || !IsInstanceValid(e));
		Enemy en = EnemiesManager.GetFirstEnemyInSightOrNull(enemies);
		if (en != null)
		{
			if (weaponBehavior == WeaponBehavior.Rotate)
			{
				weaponHolder.LookAt(en.GlobalPosition);
			}

			Bullet bullet = bulletScene.Instantiate<Bullet>();
			bullet.GlobalPosition = shootMarker.GlobalPosition;
			bullet.LookAt(en.GlobalPosition);
			bullet.Init(en.GlobalPosition);

			GetTree().Root.AddChild(bullet);
		}
	}

}
