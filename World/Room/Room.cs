using Godot;
using System;

public class Room : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var evannaScene = GD.Load<PackedScene>("res://Characters/Evanna/Evanna.tscn");
		var evannaInstance = evannaScene.Instance();
		AddChild(evannaInstance);
		var evanna = evannaInstance.GetTree().Root.GetNode<Node2D>("Room").GetNode<Node2D>("Evanna");
		evanna.Position = new Vector2(96, 50);

		var worldStateScene = GD.Load<PackedScene>("res://Characters/Evanna/State/WorldState.tscn");
		var worldStateInstance = worldStateScene.Instance();
		evanna.AddChild(worldStateInstance);

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }
	}
}
