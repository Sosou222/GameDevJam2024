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
		UIControl.SetTowerInfoVisibility(true);
		selectedTower.showAreaComponent.ShowArea = true;
		towerName.Text = selectedTower.Name;
		upgradeButton.Disabled = selectedTower.upgradedTower == null;
	}


	private void Reset()
	{
		UIControl.SetTowerInfoVisibility(false);
		towerName.Text = "";
		upgradeButton.Disabled = true;
	}

	private void OnUpgradeButtonPressed()
	{
		if (selectedTower == null)
		{
			return;
		}

		GD.Print($"Upgrading tower:{selectedTower.Name}");
		if (selectedTower.upgradedTower == null)
		{
			return;
		}

		Tower tmpTower = selectedTower.upgradedTower.Instantiate<Tower>();
		GameManager.Instance.TowerHolder.AddChild(tmpTower);
		tmpTower.GlobalPosition = selectedTower.GlobalPosition;

		selectedTower.QueueFree();

		GameManager.Instance.SetTargetTower(null);
	}
}
