using Godot;
using System;
using System.Linq;


public enum MovementType
{
	Stationary,
	InDirection,
	TowardTarget
}

public partial class Bullet : Node2D
{
	private Vector2 direction = Vector2.Zero;

	private DamagingComponent damagingComponent;

	private IMovementComponent movementComponent;

	public override void _Ready()
	{
		damagingComponent = GetNode<DamagingComponent>("DamagingComponent");
		damagingComponent.HitBoxEntered += (hc) => QueueFree();
	}

	public void Init(Vector2 targetPos)
	{
		movementComponent = GetChildren().OfType<IMovementComponent>().FirstOrDefault();
		if (movementComponent != null)
			movementComponent.Init(targetPos);
	}
}
