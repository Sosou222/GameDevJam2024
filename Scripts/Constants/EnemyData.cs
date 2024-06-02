using Godot;
using System;

using Godot.Collections;

namespace Constants;

public partial class EnemyInfo : RefCounted
{
    public float Speed;
    public int Gold;
}

public class EnemyData
{
    public static readonly Dictionary<EnemyType, EnemyInfo> Info = new()
    {
        { EnemyType.FireBug, new EnemyInfo() { Speed = 100.0f, Gold = 5} },
        { EnemyType.Leafbug, new EnemyInfo() { Speed = 50.0f, Gold = 2} }
    };
}
