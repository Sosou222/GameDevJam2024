using Godot;
using System;
using System.Collections.Generic;

public partial class EnemyDetectionComponent : Area2D
{
	public List<Enemy> enemies { private set; get; } = new();

	public override void _Ready()
	{
		this.AreaEntered += OnArea2DEnter;
		this.AreaExited += OnArea2DExit;
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
