using Godot;
using System;

using Godot.Collections;

namespace Constants;

public partial class WaveInfo : RefCounted
{
    public EnemyType EnemyT;
    public int Amount;

    public WaveInfo(EnemyType enemyType, int amount)
    {
        EnemyT = enemyType;
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
        ,
        { 3, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,10),
            new WaveInfo(EnemyType.FireBug,5),
            new WaveInfo(EnemyType.Leafbug,3),
        }}
        ,
        { 4, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,10),
            new WaveInfo(EnemyType.FireBug,5),
            new WaveInfo(EnemyType.Leafbug,3),
        }}
        ,
        { 5, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,10),
            new WaveInfo(EnemyType.FireBug,5),
            new WaveInfo(EnemyType.Leafbug,3),
        }}
        ,
        { 6, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,10),
            new WaveInfo(EnemyType.FireBug,5),
            new WaveInfo(EnemyType.Leafbug,3),
        }}
        ,
        { 7, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,10),
            new WaveInfo(EnemyType.FireBug,5),
            new WaveInfo(EnemyType.Leafbug,3),
        }}
        ,
        { 8, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,10),
            new WaveInfo(EnemyType.FireBug,5),
            new WaveInfo(EnemyType.Leafbug,3),
        }}
        ,
        { 9, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,10),
            new WaveInfo(EnemyType.FireBug,5),
            new WaveInfo(EnemyType.Leafbug,3),
        }}
        ,
        { 10, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,10),
            new WaveInfo(EnemyType.FireBug,5),
            new WaveInfo(EnemyType.Leafbug,3),
        }}
    };
}
