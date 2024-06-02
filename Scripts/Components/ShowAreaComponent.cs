using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ShowAreaComponent : Node2D
{
	[Export] private Area2D area2D;



	private bool showArea = true;
	public bool ShowArea
	{
		get
		{
			return showArea;
		}
		set
		{
			if (showArea != value)
			{
				showArea = value;
				QueueRedraw();
			}
		}
	}

	private List<Shape2D> shapes = new();

	private Color color;
	public override void _Ready()
	{
		var tmp = area2D.GetChildren().OfType<CollisionShape2D>().ToList();
		foreach (var shape in tmp)
		{
			shapes.Add(shape.Shape);
			shape.Shape.Changed += QueueRedraw;
		}
		color = new(Colors.SkyBlue);
		color.A8 = 64;
	}

	public override void _Draw()
	{
		base._Draw();

		if (!ShowArea)
		{
			return;
		}

		foreach (var shape in shapes)
		{
			if (shape is CircleShape2D circle)
			{
				DrawCircle(new Vector2(0, 0), circle.Radius, color);
			}
			if (shape is RectangleShape2D square)
			{
				DrawRect(square.GetRect(), color);
			}
		}
	}
}
