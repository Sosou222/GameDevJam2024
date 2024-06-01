using Constants;
using Godot;
using System;

public partial class GameManager : Node
{

    public static GameManager Instance { private set; get; }

    public Node2D TowerHolder { private set; get; }
    public Node2D BulletHolder { private set; get; }
    public Node2D AfterEffectHolder { private set; get; }


    private WaveManager waveManager;

    public override void _Ready()
    {
        Instance = this;

        waveManager = GetNode<WaveManager>("WaveManager");
        TowerHolder = GetNode<Node2D>("TowerHolder");
        BulletHolder = GetNode<Node2D>("BulletHolder");
        AfterEffectHolder = GetNode<Node2D>("AfterEffectHolder");

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

}
