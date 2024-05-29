using Godot;
using System;

public abstract partial class IMovementComponent : Node
{
    public abstract void Init(Vector2 targetPos);
}
