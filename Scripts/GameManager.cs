using Constants;
using Godot;
using GodotPlugins.Game;
using System;
using System.Linq;

public partial class GameManager : Node
{
    [Signal]
    public delegate void GoldChangeEventHandler(int newCost);

    [Export] private Control GameOverCotnrol;
    [Export] private Control PauseCotnrol;
    [Export] private Button PauseButton;
    public static GameManager Instance { private set; get; }

    public Node2D TowerHolder { private set; get; }
    public Node2D BulletHolder { private set; get; }
    public Node2D AfterEffectHolder { private set; get; }
    public HealthComponent HpComponent { private set; get; }

    private Label label;

    public int Gold { private set; get; } = 100;

    private WaveManager waveManager;

    public override void _Ready()
    {
        Instance = this;

        waveManager = GetNode<WaveManager>("WaveManager");
        HpComponent = GetNode<HealthComponent>("HealthComponent");
        TowerHolder = GetNode<Node2D>("TowerHolder");
        BulletHolder = GetNode<Node2D>("BulletHolder");
        AfterEffectHolder = GetNode<Node2D>("AfterEffectHolder");

        label = GameOverCotnrol.GetNode<Label>("Label");
        GameOverCotnrol.GetNode<Button>("RestartButton").Pressed += () => SceneManager.ReloadScene();
        GameOverCotnrol.GetNode<Button>("MenuButton").Pressed += () => SceneManager.LoadScene("MainMenu");

        PauseCotnrol.GetNode<Button>("ResumeButton").Pressed += OnUnPause;
        PauseCotnrol.GetNode<Button>("QuitButton").Pressed += () => SceneManager.LoadScene("MainMenu");

        PauseButton.Pressed += OnPause;


        waveManager.WaveEnd += BeginNewWave;
        waveManager.StartWave(0);

        HpComponent.Die += OnDie;
    }

    private void BeginNewWave(int lastWave)
    {
        if (!WaveData.Info.ContainsKey(lastWave + 1))
        {
            return;
        }

        waveManager.StartWave(lastWave + 1);
    }

    private void OnDie()
    {
        GameOverCotnrol.Visible = true;
        label.Text = "GameOver";

        this.ProcessMode = ProcessModeEnum.Disabled;
    }

    private void OnPause()
    {
        PauseCotnrol.Visible = true;
        this.ProcessMode = ProcessModeEnum.Disabled;
    }

    private void OnUnPause()
    {
        PauseCotnrol.Visible = false;
        this.ProcessMode = ProcessModeEnum.Inherit;
    }

    public static void PayGold(int gold)
    {
        Instance.Gold -= gold;
        Instance.EmitSignal(SignalName.GoldChange, Instance.Gold);
    }

    public static void AddGold(int gold)
    {
        Instance.Gold += gold;
        Instance.EmitSignal(SignalName.GoldChange, Instance.Gold);
    }

    public void SetTargetTower(Tower tower)
    {
        var towers = TowerHolder.GetChildren().OfType<Tower>().ToList();
        foreach (var tow in towers)
        {
            tow.showAreaComponent.ShowArea = false;
        }

        TowerInfoUI.SetSelectedTower(tower);
    }

}
