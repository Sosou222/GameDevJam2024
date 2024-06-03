using Godot;
using System;

public partial class MainMenu : Control
{

	public override void _Ready()
	{
		GetNode<Button>("StartButton").Pressed += OnStartButtonPressed;
		GetNode<Button>("SettingsButton").Pressed += OnSettingsButtonPressed;
		GetNode<Button>("QuitButton").Pressed += OnQuitButtonPressed;
	}

	private void OnStartButtonPressed()
	{
		SceneManager.LoadScene("TestScene");
	}

	private void OnSettingsButtonPressed()
	{

	}

	private void OnQuitButtonPressed()
	{
		SceneManager.QuitGame();
	}
}
