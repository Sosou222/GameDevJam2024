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
		if (area is DamagingComponent dc)
		{
			GD.Print($"Taking {dc.Damage} from current {healthComponent.Health}");
			healthComponent.TakeDamage(dc.Damage);
		}
	}
}
