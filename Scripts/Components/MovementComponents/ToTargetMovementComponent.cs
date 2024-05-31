using Godot;
using System;

public partial class ToTargetMovementComponent : IMovementComponent
{
    [Export] private Node2D owner;
    [Export] private float Speed = 300.0f;
    [Export] private bool DestroyOnArrival = true;
    private Vector2 targetPosition;
    public override void Init(Vector2 targetPos)
    {
        targetPosition = targetPos;
    }

    public override void _Process(double delta)
    {
        owner.GlobalPosition = owner.GlobalPosition.MoveToward(targetPosition, Speed * (float)delta);
        if (!DestroyOnArrival)
            return;
        if (owner.GlobalPosition == targetPosition)
            owner.QueueFree();
    }
}
