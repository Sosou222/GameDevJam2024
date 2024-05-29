using Godot;
using System;

public partial class ToDirectionMovementComponent : IMovementComponent
{
    [Export] private Node2D owner;
    [Export] private float Speed = 300.0f;
    private Vector2 direction;
    public override void Init(Vector2 targetPos)
    {
        direction = (targetPos - owner.GlobalPosition).Normalized();
    }

    public override void _Process(double delta)
    {
        owner.GlobalPosition += direction * Speed * (float)delta;
    }
}
