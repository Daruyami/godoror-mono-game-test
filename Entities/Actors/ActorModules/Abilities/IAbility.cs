using MonoTest.Entities.Actors;

namespace MonoTest.PlayerModules.Abilities;

public interface IAbility
{
	EAbilityType AbilityType { get; }
	
	bool Enabled { get; set; }

	Actor AbilityOwner { get; }

	void Destruct();
}
