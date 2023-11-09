using Godot;
using MonoTest.Entities.Actors;
using MonoTest.PlayerModules.Abilities;

public partial class Player : Actor
{
	[Export] public float Acceleration = 5;

	[Export] public float Resistance = 0.9f;
	
	public override void _Ready()
	{
		base._Ready();
		AbilityManager.AddAbility(this, EAbilityType.Dash);
		AbilityManager.ChangeAbilityState(this, EAbilityType.Dash, true);
	}

	public override void _PhysicsProcess(double delta)
	{
		Direction = Input.GetVector("LEFT", "RIGHT", "UP", "DOWN");
		
		Velocity += (Direction * Acceleration);

		Velocity *= Resistance;
		
		MoveAndSlide();
	}
}
