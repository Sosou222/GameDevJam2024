using Godot;
using System;

public partial class UIControl : CanvasLayer
{
	private Button toggleButton;
	private AnimationPlayer animationPlayer;
	public override void _Ready()
	{
		toggleButton = GetNode<Button>("ToggleButton");
		toggleButton.Toggled += OnToggleButton;
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}


	private void OnToggleButton(bool isOn)
	{
		if (isOn)
		{
			toggleButton.Text = "<";
			animationPlayer.Play("Close");
		}
		else
		{
			toggleButton.Text = ">";
			animationPlayer.Play("Open");
		}
	}
}
