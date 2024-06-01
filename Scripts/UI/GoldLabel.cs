using Godot;
using System;

public partial class GoldLabel : Label
{
	public override void _Ready()
	{
		GameManager.Instance.GoldChange += OnChangeGold;
		OnChangeGold(GameManager.Instance.Gold);
	}

	private void OnChangeGold(int gold)
	{
		Text = $"Gold:{gold}";
	}
}
