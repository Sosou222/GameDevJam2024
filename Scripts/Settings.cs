using Godot;
using System;

public partial class Settings : Control
{

	private int busMusicID = AudioServer.GetBusIndex("Music");
	private int busSFXID = AudioServer.GetBusIndex("SFX");

	public override void _Ready()
	{
		GetNode<HSlider>("MusicHSlider").ValueChanged += OnValueChangedMusic;
		GetNode<HSlider>("SFXHSlider").ValueChanged += OnValueChangedSFX;
		GetNode<HSlider>("SFXHSlider").DragEnded += OnDragEndedSFX;
		GetNode<Button>("Button").Pressed += OnBackButtonPressed;
	}

	private void OnValueChangedMusic(double value)
	{
		AudioServer.SetBusVolumeDb(busMusicID, (float)Mathf.LinearToDb(value));
		AudioServer.SetBusMute(busMusicID, value < 0.05f);
	}
	private void OnValueChangedSFX(double value)
	{
		AudioServer.SetBusVolumeDb(busSFXID, (float)Mathf.LinearToDb(value));
		AudioServer.SetBusMute(busSFXID, value < 0.05f);
	}

	private void OnDragEndedSFX(bool value)
	{
		if (value)
			AudioManager.PlaySound("ArrowLaunch");
	}

	private void OnBackButtonPressed()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
