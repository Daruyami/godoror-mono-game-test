using Godot;
using MonoTest.Entities.Actors;

namespace MonoTest.PlayerModules.Abilities;

public abstract partial class Ability : Node, IAbility
{
	public abstract EAbilityType AbilityType { get; }
	
	public abstract bool Enabled { get; set; }

	public Actor AbilityOwner { get; set; }

	public void Initialize(Actor actor)
	{
		Owner = actor;
		AbilityOwner = actor;
	}
	
	public abstract void Destruct();
}
