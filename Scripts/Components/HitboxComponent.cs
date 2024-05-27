using Godot;
using System;

public partial class HitboxComponent : Area2D
{

	[Export] private HealthComponent healthComponent;

	private void OnAreaEnter(Area2D area)
	{
		healthComponent.TakeDamage(0);
	}
}
