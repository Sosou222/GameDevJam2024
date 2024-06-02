using Godot;
using System;

public partial class HealthBarComponent : ProgressBar
{

	[Export] private HealthComponent healthComponent;
	private ProgressBar damageBar;
	private Timer timer;

	public override void _Ready()
	{
		damageBar = GetNode<ProgressBar>("DamageBar");
		timer = GetNode<Timer>("Timer");

		this.MaxValue = healthComponent.MaxHealth;
		this.MinValue = 0.0f;
		this.Value = healthComponent.Health;

		damageBar.MaxValue = this.MaxValue;
		damageBar.MinValue = this.MinValue;

		healthComponent.TakenDamage += OnTakenDamage;
		timer.Timeout += OnTimeout;
	}

	private void OnTakenDamage(int newHealth)
	{
		this.Value = newHealth;
		timer.Start();
	}

	private void OnTimeout()
	{
		damageBar.Value = this.Value;
	}
}
