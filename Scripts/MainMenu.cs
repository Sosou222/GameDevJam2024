using Godot;
using System;

public partial class MainMenu : Control
{

	public override void _Ready()
	{
		GetNode<Button>("StartButton").Pressed += OnStartButtonPressed;
		GetNode<Button>("SettingsButton").Pressed += OnSettingsButtonPressed;
		GetNode<Button>("QuitButton").Pressed += OnQuitButtonPressed;

		AudioManager.PlayMusic("BasicMusic");
	}

	private void OnStartButtonPressed()
	{
		SceneManager.LoadScene("Level1Scene");
	}

	private void OnSettingsButtonPressed()
	{
		SceneManager.LoadScene("Settings");
	}

	private void OnQuitButtonPressed()
	{
		SceneManager.QuitGame();
	}
}
