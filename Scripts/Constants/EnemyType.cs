using Godot;
using System;
using Godot.Collections;

namespace Constants;

public class EnemyType
{
    public const string FireBug = "Firebug";

    public static readonly Array<string> All = new Array<string>() { FireBug };
}
