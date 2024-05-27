using Constants;
using Godot;
using System;

public partial class GameManager : Node
{
    private WaveManager waveManager;

    public override void _Ready()
    {
        waveManager = GetNode<WaveManager>("WaveManager");

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
