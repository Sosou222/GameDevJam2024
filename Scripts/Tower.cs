using Godot;
using System;

using System.Collections.Generic;

public partial class Tower : Node2D
{

	[Export] private PackedScene bulletScene;

	private Dictionary<int, Node2D> weaponsHolders = new();
	private Node2D currentWeaponHolder;
	private Marker2D currentMarker;
	private AnimatedSprite2D currentSprites;


	private int currentLevel = 1;

	private AtlasTexture towerBaseAtlasTexture;


	private EnemyDetectionComponent enemyDetectionComponent;

	private List<Enemy> enemies => enemyDetectionComponent.enemies;


	private Timer timer;

	private const int pixelAtlasSeperationX = 64;

	public override void _Ready()
	{
		towerBaseAtlasTexture = GetNode<Sprite2D>("TowerBaseSprite").Texture as AtlasTexture;
		enemyDetectionComponent = GetNode<EnemyDetectionComponent>("EnemyDetectionComponent");
		timer = GetNode<Timer>("Timer");

		timer.Timeout += Shoot;

		weaponsHolders.Add(1, GetNode<Node2D>("Weapons/LV1"));
		weaponsHolders.Add(2, GetNode<Node2D>("Weapons/LV2"));
		weaponsHolders.Add(3, GetNode<Node2D>("Weapons/LV3"));

		SetLevel(2);
	}

	public override void _Process(double delta)
	{

	}

	private void Shoot()
	{
		enemies.RemoveAll(e => e == null || !IsInstanceValid(e));
		Enemy en = EnemiesManager.GetFirstEnemyInSightOrNull(enemies);
		if (en != null)
		{
			//GD.Print($"Enemy {en.Name} progres:{en.ProgressRatio}");
			currentWeaponHolder.LookAt(en.GlobalPosition);
			Vector2 dirToEnemy = (en.GlobalPosition - currentMarker.GlobalPosition).Normalized();

			Bullet bullet = bulletScene.Instantiate<Bullet>();
			bullet.Init(dirToEnemy);
			bullet.GlobalPosition = currentMarker.GlobalPosition;
			bullet.LookAt(en.GlobalPosition);

			GetTree().Root.AddChild(bullet);
		}
	}

	private void SetLevel(int level)
	{
		currentLevel = level;

		Rect2 tmpReg = towerBaseAtlasTexture.Region;
		towerBaseAtlasTexture.Region = new Rect2(new Vector2(tmpReg.Size.X * (currentLevel - 1), tmpReg.Position.Y), tmpReg.Size);
		SetCurrentGolders(currentLevel);
	}

	private void SetCurrentGolders(int level)
	{
		foreach (var weapon in weaponsHolders)
		{
			weapon.Value.Visible = false;
		}
		currentWeaponHolder = weaponsHolders[level];
		currentMarker = currentWeaponHolder.GetNode<Marker2D>("Marker2D");
		currentSprites = currentWeaponHolder.GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		currentWeaponHolder.Visible = true;
	}

}
