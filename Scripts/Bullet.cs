using Godot;
using System;

public partial class Bullet : Area2D
{
	public int Damage { get; private set; } = 5;

	public float Speed { get; private set; } = 300.0f;

	private Vector2 direction = Vector2.Zero;

	public override void _Ready()
	{
		this.AreaEntered += (area) => GD.Print($"Hitted:{area.Owner}");
		this.AreaEntered += OnAreaEnter;
	}

	public void Init(Vector2 dir)
	{
		direction = dir;
	}

	public override void _PhysicsProcess(double delta)
	{
		GlobalPosition += direction * Speed * (float)delta;
	}

	private void OnAreaEnter(Area2D area)
	{
		if (area is HitboxComponent hitboxComponent)
		{
			QueueFree();
		}
	}
}
