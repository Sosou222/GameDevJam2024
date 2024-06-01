using Godot;
using System;
using Godot.Collections;

public partial class TowerBuyButton : Button
{
	[Export] private PackedScene towerScene;
	private bool isDraging = false;

	private Tower tmpTower;

	private bool canBePlaced = false;

	public override void _Ready()
	{
		this.ButtonDown += OnButtonDown;
		this.ButtonUp += OnButtonUp;
		this.GuiInput += OnGuiInput;
	}
	private void OnButtonDown()
	{
		isDraging = true;

		tmpTower = towerScene.Instantiate<Tower>();
		tmpTower.ProcessMode = ProcessModeEnum.Disabled;
		GameManager.Instance.TowerHolder.AddChild(tmpTower);
	}

	private void OnButtonUp()
	{
		isDraging = false;

		if (canBePlaced)
		{
			tmpTower.ProcessMode = ProcessModeEnum.Inherit;
			tmpTower.TowerPlacementComponent.ProcessMode = ProcessModeEnum.Inherit;
			tmpTower.Modulate = Colors.White;
		}
		else
		{
			tmpTower.QueueFree();
		}
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
			CheckPlacement();
			ChangeColor();
		}
	}

	private void CheckPlacement()
	{
		canBePlaced = tmpTower.TowerPlacementComponent.GetOverlappingAreas().Count == 0 && tmpTower.TowerPlacementComponent.GetOverlappingBodies().Count == 0;
	}

	private void ChangeColor()
	{
		if (canBePlaced)
		{
			tmpTower.Modulate = Colors.Lime;
		}
		else
		{
			tmpTower.Modulate = Colors.Red;
		}
	}


}
