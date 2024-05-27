using Godot;
using System;

public partial class HitboxComponent : Area2D
{

	[Export] private HealthComponent healthComponent;

	public override void _Ready()
	{
		this.AreaEntered += OnAreaEnter;
	}

	private void OnAreaEnter(Area2D area)
	{
		if (area is Bullet bullet)
		{
			GD.Print($"Taking {bullet.Damage} from current {healthComponent.Health}");
			healthComponent.TakeDamage(bullet.Damage);
		}
	}
}
