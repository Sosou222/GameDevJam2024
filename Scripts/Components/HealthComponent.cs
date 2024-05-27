using Godot;
using System;

public partial class HealthComponent : Node
{
    [Signal]
    public delegate void DieEventHandler();

    [Signal]
    public delegate void TakenDamageEventHandler(int newHealth);


    [Export] public int MaxHealth { get; private set; } = 5;

    private int health;
    public int Health
    {
        get
        {
            return health;
        }
        private set
        {
            if (health != value)
            {
                health = value;
                EmitSignal(SignalName.TakenDamage, health);
            }
        }
    }

    public override void _Ready()
    {
        Health = MaxHealth;

        this.Die += () => GD.Print($"{Owner.Name} has died");
        this.TakenDamage += (newHealth) => GD.Print($"{Owner.Name} has taken damage new hp:{newHealth}");
    }

    public void TakeDamage(int damage)
    {
        Health = Mathf.Max(Health - damage, 0);
        if (Health == 0)
        {
            EmitSignal(SignalName.Die);
        }
    }
}
