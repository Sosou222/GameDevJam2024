using Godot;
using System;

public partial class Bullet : Area2D
{
	public int Damage { get; private set; } = 5;

	public override void _Ready()
	{
		this.AreaEntered += (area) => GD.Print($"Hitted:{area.Owner}");
		this.AreaEntered += OnAreaEnter;
	}

	public override void _PhysicsProcess(double delta)
	{

	}

	private void OnAreaEnter(Area2D area)
	{
		if (area is HitboxComponent hitboxComponent)
		{
			//QueueFree();
		}
	}
}
