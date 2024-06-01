using Godot;
using System;

public partial class GoldBuyLabel : Label
{
	[Export] TowerBuyButton towerBuyButton;
	public override void _Ready()
	{
		Text = $"G:{towerBuyButton.GetCost()}";
	}
}
