using Constants;
using Godot;
using System;

public partial class Enemy : PathFollow2D
{

	[Signal]
	public delegate void ReachedEndEventHandler();

	public HealthComponent healthComponent { get; private set; }

	public bool IsDying { get; private set; } = false;


	private float Speed = 100.0f;
	private int Gold = 1;

	private Vector2 direction = Vector2.Right;

	private AnimationPlayer animationPlayer;
	private AnimatedSprite2D animatedSprite2D;



	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		healthComponent = GetNode<HealthComponent>("HealthComponent");

		this.ReachedEnd += () => GD.Print($"{Name} reached end");
		this.ReachedEnd += QueueFree;

		healthComponent.Die += OnDie;
	}


	public override void _Process(double delta)
	{
		if (IsDying)
		{
			return;
		}

		Vector2 oldPos = GlobalPosition;

		Progress += Speed * (float)delta;

		direction = SnapVector(oldPos);

		ChangeAnimation();

		if (ProgressRatio == 1.0f)
		{
			EmitSignal(SignalName.ReachedEnd);
		}
	}

	public void Init(EnemyType EnemyType, EnemyInfo enemyInfo)
	{
		animationPlayer.Play("WalkRight");

		Speed = enemyInfo.Speed;
		Gold = enemyInfo.Gold;
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

	private string GetAnimationDir()
	{
		if (direction == Vector2.Down)
		{
			return "Down";
		}
		else if (direction == Vector2.Up)
		{
			return "Up";
		}
		else if (direction == Vector2.Left)
		{
			return "Left";
		}
		else
		{
			return "Right";
		}
	}

	private void ChangeAnimation()
	{
		string animationName = "Walk";
		animationName += GetAnimationDir();

		animationPlayer.Play(animationName);
	}

	private void OnDie()
	{
		if (IsDying)
		{
			return;
		}
		GameManager.AddGold(Gold);
		IsDying = true;
		string animationName = "Dying";
		animationName += GetAnimationDir();

		animationPlayer.Play(animationName);
		animationPlayer.AnimationFinished += (name) =>
		{
			QueueFree();
		};
	}
}
