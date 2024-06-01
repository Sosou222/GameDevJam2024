using Godot;
using System;

public partial class GoldLabel : Label
{
	public override void _Ready()
	{
		GameManager.Instance.GoldChange += ChangeGoldLabel;
		ChangeGoldLabel(GameManager.Instance.Gold);
	}

	private void ChangeGoldLabel(int gold)
	{
		Text = $"Gold:{gold}";
	}
}
