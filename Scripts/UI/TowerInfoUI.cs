using Godot;
using System;

public partial class TowerInfoUI : Panel
{
	private static Tower selectedTower = null;

	private Label towerName;
	private Label shootSpeedLabel;
	private Label damageInfoLabel;
	private Label upgradeAmountLabel;
	private Button upgradeButton;

	private static TowerInfoUI Instance = null;
	public override void _Ready()
	{
		Instance = this;

		towerName = GetNode<Label>("TowerName");
		shootSpeedLabel = GetNode<Label>("ShootSpeed");
		damageInfoLabel = GetNode<Label>("DamageInfo");
		upgradeAmountLabel = GetNode<Label>("UpgradeAmount");
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
		towerName.Text = selectedTower.TowerShowName;
		shootSpeedLabel.Text = $"Shoot Speed {selectedTower.ShootInterval.ToString("0.00")}s";
		damageInfoLabel.Text = selectedTower.DamageTextShow;
		upgradeAmountLabel.Text = $"Cost:{selectedTower.UpgradeCost}G";
		upgradeButton.Disabled = selectedTower.upgradedTower == null;
	}


	private void Reset()
	{
		UIControl.SetTowerInfoVisibility(false);
		towerName.Text = "";
		shootSpeedLabel.Text = "";
		damageInfoLabel.Text = "";
		upgradeAmountLabel.Text = "";
		upgradeButton.Disabled = true;
	}

	private void OnUpgradeButtonPressed()
	{
		if (selectedTower == null)
		{
			return;
		}

		if (selectedTower.UpgradeCost > GameManager.Instance.Gold)
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

		GameManager.PayGold(selectedTower.UpgradeCost);

		selectedTower.QueueFree();

		GameManager.Instance.SetTargetTower(null);
	}
}
