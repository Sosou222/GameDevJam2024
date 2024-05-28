using Godot;
using System;

using System.Collections.Generic;

public partial class Tower : Node2D
{

	private int level = 1;

	private AtlasTexture towerBaseAtlasTexture;

	private Dictionary<int, AnimatedSprite2D> towerBaseSprites = new();
	private Dictionary<int, Marker2D> levelMarkers = new();

	private Area2D area2D;


	private List<Enemy> enemies = new();

	private const int pixelAtlasSeperationX = 64;

	public override void _Ready()
	{
		towerBaseAtlasTexture = GetNode<Sprite2D>("Sprites/TowerBaseSprite").Texture as AtlasTexture;
		area2D = GetNode<Area2D>("TowerDetectionRange");
		area2D.AreaEntered += OnArea2DEnter;
		area2D.AreaExited += OnArea2DExit;
	}

	public override void _Process(double delta)
	{
		enemies.RemoveAll(e => e == null || !IsInstanceValid(e));
		Enemy en = EnemiesManager.GetFirstEnemyInSightOrNull(enemies);
		if (en != null)
		{
			GD.Print($"Enemy {en.Name} progres:{en.ProgressRatio}");
		}
	}

	private void LevelUp()
	{
		Rect2 tmpReg = towerBaseAtlasTexture.Region;
		towerBaseAtlasTexture.Region = new Rect2(tmpReg.Position, new Vector2(pixelAtlasSeperationX * (level - 1), tmpReg.Size.Y));
	}

	private void OnArea2DEnter(Area2D area2D)
	{
		if (area2D is HitboxComponent hc)
		{
			if (hc.Owner is Enemy enemy)
			{
				enemies.Add(enemy);
			}
		}
	}

	private void OnArea2DExit(Area2D area2D)
	{
		if (area2D is HitboxComponent hc)
		{
			if (hc.Owner is Enemy enemy)
			{
				enemies.Remove(enemy);
			}
		}
	}

}
