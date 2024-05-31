using Godot;
using System;
using Godot.Collections;

public partial class TowerBuyButton : Button
{
	[Export] private PackedScene towerScene;
	private bool isDraging = false;

	private Tower tmpTower;

	public override void _Ready()
	{
		this.ButtonDown += OnButtonDown;
		this.ButtonUp += OnButtonUp;
		this.GuiInput += OnGuiInput;
	}
	private void OnButtonDown()
	{
		GD.Print("ButtonDown");
		isDraging = true;

		tmpTower = towerScene.Instantiate<Tower>();
		tmpTower.ProcessMode = ProcessModeEnum.Disabled;
		GetTree().Root.AddChild(tmpTower);
	}

	private void OnButtonUp()
	{
		GD.Print("ButtonUp");
		isDraging = false;

		tmpTower.ProcessMode = ProcessModeEnum.Inherit;
		tmpTower = null;
	}

	private void OnGuiInput(InputEvent inputEvent)
	{
		if (!isDraging)
		{
			return;
		}

		if (inputEvent is InputEventMouseMotion motion)
		{
			tmpTower.GlobalPosition = motion.GlobalPosition;
		}
	}


}