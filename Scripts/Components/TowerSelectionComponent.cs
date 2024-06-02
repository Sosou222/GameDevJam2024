using Godot;
using System;

public partial class TowerSelectionComponent : Area2D
{
	[Export] Tower owner;


	public override void _Ready()
	{
		this.InputEvent += OnInputEvent;

	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton button)
		{
			if (button.ButtonIndex == MouseButton.Left && !button.Pressed)
			{
				return;
			}
			GameManager.Instance.SetTargetTower(null);
		}
	}

	private void OnInputEvent(Node viewport, InputEvent inputEvent, long shapeIDX)
	{
		if (inputEvent is InputEventMouseButton button)
		{
			if (button.ButtonIndex == MouseButton.Left && button.Pressed)
			{
				GameManager.Instance.SetTargetTower(owner);
			}
		}
	}
}
