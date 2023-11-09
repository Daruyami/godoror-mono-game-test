using Godot;
using MonoTest.PlayerModules.Abilities;

public partial class DashAbility : Ability
{
	public override EAbilityType AbilityType => EAbilityType.Dash;
	
	public override bool Enabled { get; set; }
	
	public override void Destruct() { }

	[Signal]
	public delegate void CanDashUpdatedEventHandler(bool canDash);

	[Export]
	public const float DashVelocity = 300;

	private bool _canDash = true;
	public bool CanDash
	{
		get => _canDash;
		set
		{
			_canDash = value;
			EmitSignal(SignalName.CanDashUpdated, CanDash);
		}
	}
	
	public double DashCooldownLength
	{
		get => DashCooldownTimer.WaitTime;
		set => DashCooldownTimer.WaitTime = value;
	}

	public Timer DashCooldownTimer = new Timer()
	{
		Name = "DashCooldownTimer",
		EditorDescription = "Dash Cooldown Timer",
		WaitTime = 5,
	};
	
	public override void _Ready()
	{
		DashCooldownTimer.Timeout += () => CanDash = true;
		this.AddChild(DashCooldownTimer);
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		
		if (Enabled && CanDash && 
		    Input.IsActionJustPressed("DASH") &&
		    AbilityOwner.Direction.Normalized().Length() != 0)
		{
			AbilityOwner.Velocity = AbilityOwner.Direction.Normalized() * DashVelocity;
			CanDash = false;
			DashCooldownTimer.Start();
		}
	}

}
