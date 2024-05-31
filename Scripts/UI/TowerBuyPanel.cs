using Godot;
using System;

public partial class TowerBuyPanel : Panel
{
	[Export] PackedScene towerScene;


	public override void _Ready()
	{
		this.GuiInput += OnGuiInput;
	}

	private void OnGuiInput(InputEvent inputEvent)
	{
		string action = "UILeftClick";
		GD.Print("OnGuiInput");
		if (inputEvent is InputEventMouseButton button)
		{
			if (button.IsActionPressed(action))
			{
				GD.Print("Action Pressed");
			}
			else if (button.IsActionReleased(action))
			{
				GD.Print("Action Released");
			}
		}
		else if (inputEvent is InputEventMouseMotion motion)
		{
			if (motion.IsActionPressed(action))
			{
				GD.Print("Action Hold");
			}
		}

	}
}
