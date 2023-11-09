using System.Collections.Generic;
using Godot;
using MonoTest.PlayerModules.Abilities;

namespace MonoTest.Entities.Actors;

public abstract partial class Actor : CharacterBody2D
{
	public List<IAbility> Abilities = new();
	
	public Vector2 Direction;
}
