using Godot;
using System;

public partial class Enemy : PathFollow2D
{

	public float Speed = 50.0f;

	public override void _Ready()
	{
	}


	public override void _Process(double delta)
	{
		Progress += Speed * (float)delta;
	}
}
