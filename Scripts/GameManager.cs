using Constants;
using Godot;
using System;

public partial class GameManager : Node
{
    private WaveManager waveManager;

    private TileMap tileMap;

    private Node2D towerHolder;

    private static GameManager instance;

    public override void _Ready()
    {
        instance = this;

        waveManager = GetNode<WaveManager>("WaveManager");
        tileMap = GetNode<TileMap>("TileMap");
        towerHolder = GetNode<Node2D>("TowerHolder");

        waveManager.WaveEnd += BeginNewWave;
        waveManager.StartWave(2);
    }

    private void BeginNewWave(int lastWave)
    {
        if (!WaveData.Info.ContainsKey(lastWave + 1))
        {
            return;
        }

        waveManager.StartWave(lastWave + 1);
    }

    public static Node2D GetTowerHolder()
    {
        return instance.towerHolder;
    }

    public static bool CanPlaceTowerTile(Area2D towerArea)
    {
        return false;
    }
}
