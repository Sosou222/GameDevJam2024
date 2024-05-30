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
	[Export] private PackedScene afterEffect;
	private Vector2 direction = Vector2.Zero;

	private DamagingComponent damagingComponent;

	private IMovementComponent movementComponent;

	public override void _Ready()
	{
		damagingComponent = GetNode<DamagingComponent>("DamagingComponent");
		damagingComponent.HitBoxEntered += (hc) => QueueFree();

		this.TreeExiting += CreateAfterEffect;
	}

	public void Init(Vector2 targetPos)
	{
		movementComponent = GetChildren().OfType<IMovementComponent>().FirstOrDefault();
		if (movementComponent != null)
			movementComponent.Init(targetPos);
	}

	private void CreateAfterEffect()
	{
		Node2D ae = afterEffect.Instantiate<Node2D>();
		ae.GlobalPosition = this.GlobalPosition;

		GetTree().Root.CallDeferred("add_child", ae);
	}
}
