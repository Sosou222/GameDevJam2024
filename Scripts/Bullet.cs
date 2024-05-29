using Godot;
using System;

public partial class Bullet : Node2D
{

	public float Speed { get; private set; } = 300.0f;

	private Vector2 direction = Vector2.Zero;

	private DamagingComponent damagingComponent;

	public override void _Ready()
	{
		damagingComponent = GetNode<DamagingComponent>("DamagingComponent");
		damagingComponent.HitBoxEntered += (hc) => QueueFree();
	}

	public void Init(Vector2 dir)
	{
		direction = dir;
	}

	public override void _PhysicsProcess(double delta)
	{
		GlobalPosition += direction * Speed * (float)delta;
	}
}
