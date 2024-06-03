using Godot;
using System;

public partial class UIControl : CanvasLayer
{
	private Button toggleButton;
	private AnimationPlayer animationPlayer;
	private bool ISOn = false;

	private static UIControl insntance;
	public override void _Ready()
	{
		toggleButton = GetNode<Button>("ToggleButton");
		toggleButton.Toggled += OnToggleButton;
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		insntance = this;
	}
	public static void ToggleButton()
	{
		insntance.ISOn = !insntance.ISOn;
		insntance.toggleButton.SetPressedNoSignal(insntance.ISOn);
		insntance.toggleButton.EmitSignal("toggled", insntance.ISOn);
	}


	private void OnToggleButton(bool isOn)
	{
		ISOn = isOn;
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
