using Constants;
using Godot;
using System;

public partial class Enemy : PathFollow2D
{

	public float Speed = 100.0f;

	private Vector2 direction = Vector2.Right;

	private AnimationPlayer animationPlayer;
	private AnimatedSprite2D animatedSprite2D;

	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

		animatedSprite2D.SpriteFrames = AnimationsManager.GetSpritesFrames(EnemyType.FireBug);

		animationPlayer.AddAnimationLibrary("", AnimationsManager.GetAnimationLibrary(EnemyType.FireBug));

		animationPlayer.Play("DyingUp");

	}


	public override void _Process(double delta)
	{
		Vector2 oldPos = GlobalPosition;

		Progress += Speed * (float)delta;

		direction = SnapVector(oldPos);

		ChangeAnimation();
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

	private void ChangeAnimation()
	{
		string animationName = "Walk";
		if (direction == Vector2.Down)
		{
			animationName += "Down";
		}
		else if (direction == Vector2.Up)
		{
			animationName += "Up";
		}
		else if (direction == Vector2.Left)
		{
			animationName += "Left";
		}
		else
		{
			animationName += "Right";
		}

		animationPlayer.Play(animationName);
	}
}
