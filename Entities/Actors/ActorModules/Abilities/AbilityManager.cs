using System.Linq;
using Godot;
using MonoTest.Entities.Actors;

namespace MonoTest.PlayerModules.Abilities;

public static class AbilityManager
{
	public static void AddAbility(Actor target, EAbilityType targetAbilityType)
	{
		if (target.Abilities.Exists(x => x.AbilityType == targetAbilityType))
			return;
		
		Ability ability;
		
		switch (targetAbilityType)
		{
			case EAbilityType.Dash:
				ability = GD.Load<PackedScene>("res://Entities/Actors/ActorModules/Abilities/DashAbility/DashAbility.tscn").Instantiate<Ability>();
				break;
			default:
				return;
		}
		
		target.FindChild("Abilities").AddChild(ability);
		target.Abilities.Add(ability);
		
		ability.Initialize(target);
	}

	public static void RemoveAbility(Actor target, EAbilityType targetAbilityType)
	{
		foreach (var ability in target.Abilities.Where(ability => ability.AbilityType == targetAbilityType))
		{
			ability.Destruct();
		}

		target.Abilities.RemoveAll(x => x.AbilityType == targetAbilityType);
	}

	public static void ChangeAbilityState(Actor target, EAbilityType targetAbilityType, bool state)
	{
		foreach (var ability in target.Abilities.Where(ability => ability.AbilityType == targetAbilityType))
		{
			ability.Enabled = state;
		}
	}
	
}
