using Godot;
using System;

public partial class Enemy : PathFollow2D
{

	public float Speed = 50.0f;

	private Vector2 direction = Vector2.Right;

	private AnimationPlayer animationPlayer;
	private AnimatedSprite2D animatedSprite2D;

	public override void _Ready()
	{

		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

		animatedSprite2D.SpriteFrames = GD.Load<SpriteFrames>("res://Resources/AnimatedSprites/FirebugSpriteFrames.tres");

		AnimationLibrary animationLibrary = GD.Load<AnimationLibrary>("res://Resources/Animations/Firebug.res");
		animationPlayer.AddAnimationLibrary("", animationLibrary);

		GD.Print($"Animation library count:{animationLibrary.GetAnimationList().Count}");
		foreach (var animation in animationPlayer.GetAnimationList())
		{
			GD.Print($"Animation Name:{animation}");
		}

		animationPlayer.Play("DyingUp");

	}


	public override void _Process(double delta)
	{
		Vector2 oldPos = GlobalPosition;

		Progress += Speed * (float)delta;

		direction = SnapVector(oldPos);
		//GD.Print($"Direction:" + direction);
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
