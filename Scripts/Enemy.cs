using Godot;
using System;

public partial class Enemy : PathFollow2D
{

	public float Speed = 50.0f;

	private Vector2 direction = Vector2.Right;

	public override void _Ready()
	{
	}


	public override void _Process(double delta)
	{
		Vector2 oldPos = GlobalPosition;

		Progress += Speed * (float)delta;

		direction = SnapVector(oldPos);
		GD.Print($"Direction:" + direction);
	}

	private Vector2 SnapVector(Vector2 oldPosition)
	{
		Vector2 dir = (GlobalPosition - oldPosition).Normalized();
		if (Mathf.Abs(dir.X) > Mathf.Abs(dir.Y))
		{
			return new Vector2(Mathf.Sign(dir.X), 0);
		}
		else
		{
			return new Vector2(0, Mathf.Sign(dir.Y));
		}
	}
}
