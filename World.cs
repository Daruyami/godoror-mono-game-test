using Godot;

public partial class World : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var playerScene = GD.Load<PackedScene>("res://Entities/Actors/Player/Player.tscn");
		var player = playerScene.Instantiate();
		this.AddChild(player);
	}
}
