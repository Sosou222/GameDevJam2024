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
            new WaveInfo(EnemyType.Leafbug,20),
        }},
        { 1, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,20),
            new WaveInfo(EnemyType.FireBug,5),
        }},
        { 2, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.FireBug,4),
            new WaveInfo(EnemyType.Leafbug,10),
            new WaveInfo(EnemyType.FireBug,4),
            new WaveInfo(EnemyType.Leafbug,10),
        }}
        ,
        { 3, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,15),
            new WaveInfo(EnemyType.FireBug,5),
            new WaveInfo(EnemyType.Leafbug,15),
        }}
        ,
        { 4, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,5),
            new WaveInfo(EnemyType.FireBug,10),
            new WaveInfo(EnemyType.Leafbug,5),
            new WaveInfo(EnemyType.FireBug,20),
        }}
        ,
        { 5, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.FireBug,45),
        }}
        ,
        { 6, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,20),
            new WaveInfo(EnemyType.FireBug,15),
            new WaveInfo(EnemyType.Leafbug,20),
        }}
        ,
        { 7, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.FireBug,20),
            new WaveInfo(EnemyType.Leafbug,30),
            new WaveInfo(EnemyType.FireBug,15),
        }}
        ,
        { 8, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,30),
            new WaveInfo(EnemyType.FireBug,15),
            new WaveInfo(EnemyType.Leafbug,30),
        }}
        ,
        { 9, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.Leafbug,40),
            new WaveInfo(EnemyType.FireBug,30),
            new WaveInfo(EnemyType.Leafbug,15),
        }}
        ,
        { 10, new Array<WaveInfo>
        {
            new WaveInfo(EnemyType.FireBug,50),
            new WaveInfo(EnemyType.Leafbug,60),
        }}
    };
}
