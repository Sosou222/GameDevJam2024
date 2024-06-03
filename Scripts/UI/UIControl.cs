using Godot;
using System;

public partial class UIControl : CanvasLayer
{
	private Button toggleButton;
	private AnimationPlayer animationPlayer;
	private AnimationPlayer animationPlayer2;
	private bool ISOn = false;

	private bool IsOpen = false;

	private static UIControl insntance;
	public override void _Ready()
	{
		toggleButton = GetNode<Button>("ToggleButton");
		toggleButton.Toggled += OnToggleButton;
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animationPlayer2 = GetNode<AnimationPlayer>("AnimationPlayer2");

		insntance = this;
	}
	public static void ToggleButton()
	{
		insntance.ISOn = !insntance.ISOn;
		insntance.toggleButton.SetPressedNoSignal(insntance.ISOn);
		insntance.toggleButton.EmitSignal("toggled", insntance.ISOn);
	}

	public static void SetTowerInfoVisibility(bool isOpen)
	{
		if (isOpen && isOpen != insntance.IsOpen)
		{
			insntance.animationPlayer2.Play("Open");
		}
		else if (!isOpen && isOpen != insntance.IsOpen)
		{
			insntance.animationPlayer2.Play("Close");
		}

		insntance.IsOpen = isOpen;
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
