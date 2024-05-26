using Godot;
using System;

using Godot.Collections;

namespace Constants;

public partial class WaveInfo : RefCounted
{
    public string EnemyType;
    public int Amount;

    public WaveInfo(string enemyType, int amount)
    {
        EnemyType = enemyType;
        Amount = amount;
    }
}

public class WaveData
{
    public static readonly Dictionary<int, Array<WaveInfo>> Info = new()
    {
        { 0,  new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.FireBug,3),
            new WaveInfo(EnemyType.Leafbug,5)
        }},
        { 1, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.FireBug,5),
            new WaveInfo(EnemyType.Leafbug,7)
        }},
        { 2, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,10),
            new WaveInfo(EnemyType.FireBug,5),
            new WaveInfo(EnemyType.Leafbug,3),
        }}
    };
}
