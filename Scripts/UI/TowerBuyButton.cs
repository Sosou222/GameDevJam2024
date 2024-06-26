using Godot;
using System;
using Godot.Collections;

public partial class TowerBuyButton : Button
{
	[Export] private PackedScene towerScene;
	[Export] private int Cost = 10;
	private bool isDraging = false;

	private Tower tmpTower;

	private bool canBePlaced = false;

	public override void _Ready()
	{
		this.ButtonDown += OnButtonDown;
		this.ButtonUp += OnButtonUp;
		this.GuiInput += OnGuiInput;
	}

	public int GetCost()
	{
		return Cost;
	}
	private void OnButtonDown()
	{
		GameManager.Instance.SetTargetTower(null);
		if (Cost > GameManager.Instance.Gold)
		{
			return;
		}
		isDraging = true;
		UIControl.ToggleButton();

		tmpTower = towerScene.Instantiate<Tower>();
		tmpTower.ProcessMode = ProcessModeEnum.Disabled;
		GameManager.Instance.TowerHolder.AddChild(tmpTower);
	}

	private void OnButtonUp()
	{
		if (!isDraging)
			return;

		isDraging = false;

		if (canBePlaced)
		{
			tmpTower.ProcessMode = ProcessModeEnum.Inherit;
			tmpTower.TowerPlacementComponent.ProcessMode = ProcessModeEnum.Inherit;
			tmpTower.Modulate = Colors.White;
			GameManager.PayGold(Cost);
			GameManager.Instance.SetTargetTower(null);
		}
		else
		{
			tmpTower.QueueFree();
		}
		UIControl.ToggleButton();
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
