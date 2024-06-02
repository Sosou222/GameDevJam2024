using Godot;
using System;

public partial class TowerSelectionComponent : Area2D
{
	[Export] Tower owner;


	public override void _Ready()
	{
		this.InputEvent += OnInputEvent;

	}

	private void OnInputEvent(Node viewport, InputEvent inputEvent, long shapeIDX)
	{
		if (inputEvent is InputEventMouseButton button)
		{
			if (button.ButtonIndex == MouseButton.Left && button.Pressed)
			{
				GD.Print($"Tower name:{owner.Name}");
			}
		}
	}
}
