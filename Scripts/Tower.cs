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
	[Export] public float ShootInterval = 1.0f;
	[Export] public int UpgradeCost = 20;
	[Export] private string SFXShootSound = "";
	[Export] public string TowerShowName = "";
	[Export] public string DamageTextShow = "";

	[Export] public PackedScene upgradedTower { private set; get; } = null;

	public Area2D TowerPlacementComponent { private set; get; }
	public ShowAreaComponent showAreaComponent { private set; get; }

	private Node2D weaponHolder;
	private Marker2D shootMarker;
	private AnimatedSprite2D animatedSprite2D;
	private EnemyDetectionComponent enemyDetectionComponent;
	private Timer timer;

	private Tween shootTween;
	private bool canShoot = true;

	private List<Enemy> enemies => enemyDetectionComponent.enemies;

	public override void _Ready()
	{
		weaponHolder = GetNode<Node2D>("WeaponHolder");
		timer = GetNode<Timer>("Timer");
		shootMarker = weaponHolder.GetNode<Marker2D>("Marker2D");
		animatedSprite2D = weaponHolder.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		enemyDetectionComponent = GetNode<EnemyDetectionComponent>("EnemyDetectionComponent");
		TowerPlacementComponent = GetNode<Area2D>("TowerPlacementComponent");
		showAreaComponent = GetNode<ShowAreaComponent>("ShowAreaComponent");

		//timer.Timeout += Shoot;
	}

	public override void _Process(double delta)
	{
		Shoot();
	}

	private void CreateShootTween()
	{
		canShoot = false;
		animatedSprite2D.Play("Fire");
		animatedSprite2D.Stop();
		shootTween = CreateTween();
		shootTween.TweenProperty(animatedSprite2D, "frame", animatedSprite2D.SpriteFrames.GetFrameCount("Fire"), ShootInterval).From(0);
		shootTween.TweenCallback(Callable.From(() => animatedSprite2D.Play("Idle")));
		shootTween.TweenCallback(Callable.From(() => canShoot = true));
	}

	private void Shoot()
	{
		if (!canShoot)
		{
			return;
		}

		enemies.RemoveAll(e => e == null || !IsInstanceValid(e) || e.IsDying == true);
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

			GameManager.Instance.BulletHolder.AddChild(bullet);
			if (SFXShootSound != "")
			{
				AudioManager.PlaySound(SFXShootSound);
			}
			CreateShootTween();
		}
	}

}
