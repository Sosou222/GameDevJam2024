using Godot;
using System;

public partial class TowerInfoUI : Panel
{
	private static Tower selectedTower = null;

	private Label towerName;
	private Button upgradeButton;

	private static TowerInfoUI Instance = null;
	public override void _Ready()
	{
		Instance = this;

		towerName = GetNode<Label>("TowerName");
		upgradeButton = GetNode<Button>("UpgradeButton");

		upgradeButton.Pressed += OnUpgradeButtonPressed;
	}

	public static void SetSelectedTower(Tower tower)
	{
		selectedTower = tower;
		if (selectedTower == null)
		{
			Instance.Reset();
			return;
		}

		Instance.SetTowerInfo();
	}

	private void SetTowerInfo()
	{
		selectedTower.showAreaComponent.ShowArea = true;
		towerName.Text = selectedTower.Name;
	}


	private void Reset()
	{
		towerName.Text = "";
	}

	private void OnUpgradeButtonPressed()
	{
		if (selectedTower == null)
		{
			return;
		}

		GD.Print($"Upgrading tower:{selectedTower.Name}");
	}
}
