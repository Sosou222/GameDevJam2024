using Godot;
using System;

public partial class DamagingComponent : Area2D
{

	[Signal]
	public delegate void HitBoxEnteredEventHandler(HitboxComponent newHitbox);

	[Export] public int Damage { private set; get; } = 5;

	public override void _Ready()
	{
		this.AreaEntered += OnArea2DEnter;

	}

	private void OnArea2DEnter(Area2D area2D)
	{
		if (area2D is HitboxComponent hc)
		{
			EmitSignal(SignalName.HitBoxEntered, hc);
		}
	}
}
