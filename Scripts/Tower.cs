using Godot;
using System;

using Godot.Collections;

public partial class Tower : Node2D
{

	private int level = 1;

	private AtlasTexture towerBaseAtlasTexture;

	private Dictionary<int, AnimatedSprite2D> towerBaseSprites = new();
	private Dictionary<int, Marker2D> levelMarkers = new();

	private Area2D area2D;


	private const int pixelAtlasSeperationX = 64;

	public override void _Ready()
	{
		towerBaseAtlasTexture = GetNode<Sprite2D>("Sprites/TowerBaseSprite").Texture as AtlasTexture;
		area2D = GetNode<Area2D>("TowerDetectionRange");
		area2D.AreaEntered += OnArea2DEnter;
		area2D.AreaExited += OnArea2DExit;
	}

	private void LevelUp()
	{
		Rect2 tmpReg = towerBaseAtlasTexture.Region;
		towerBaseAtlasTexture.Region = new Rect2(tmpReg.Position, new Vector2(pixelAtlasSeperationX * (level - 1), tmpReg.Size.Y));
	}

	private void OnArea2DEnter(Area2D area2D)
	{
		//GD.Print($"Enter Name:{area2D.Name}");
		if (area2D is HitboxComponent hc)
		{
			//GD.Print("Is a hitbox");
		}
	}

	private void OnArea2DExit(Area2D area2D)
	{
		//GD.Print($"Exit Name:{area2D.Name}");
	}

}
