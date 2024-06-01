using Godot;
using System;

public partial class HealthLabel : Label
{
	public override void _Ready()
	{
		GameManager.Instance.HpComponent.TakenDamage += OnChangeHealth;
		OnChangeHealth(GameManager.Instance.HpComponent.Health);
	}

	private void OnChangeHealth(int hp)
	{
		Text = $"Hp:{hp}";
	}
}
