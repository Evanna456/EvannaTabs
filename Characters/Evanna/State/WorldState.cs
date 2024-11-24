using Godot;
using System;

public class WorldState : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	public Node2D character;
	public KinematicBody2D characterKinematic;
	public int Speed { get; set; } = 15;
	private Vector2 _mousePosition;
	public Vector2 velocity;
	private bool _mouseClicked = false;
	public Timer timer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		character = GetParent<Node2D>();
		GD.Print(character.Name);
		characterKinematic = GetParent<Node2D>().GetNode<KinematicBody2D>("KinematicBody2D");
		timer = GetNode<Timer>("Timer");
		timer.Connect("timeout", this, nameof(OnTimerTimeout));
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("MouseLeft") == true && @event is InputEventMouseButton eventMouseButton)
		{
			GD.Print("Mouse Click/Unclick at: ", eventMouseButton.Position);
			_mousePosition = eventMouseButton.Position;
			_mouseClicked = true;
			timer.Start();
		}
	}

	public override void _Process(float delta)
	{
		if (_mouseClicked == true)
		{
			velocity = character.Position.DirectionTo(_mousePosition) * Speed;
			characterKinematic.MoveAndSlide(velocity);
		}
	}

	private void OnTimerTimeout()
	{
		_mouseClicked = false;
		GD.Print("The World");
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }

}
