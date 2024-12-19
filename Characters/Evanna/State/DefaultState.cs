using Godot;
using System;

public class DefaultState : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	public Node2D character;
	public KinematicBody2D characterKinematic;
	public float speed = 20f;
	public Vector2 moveDirection;
	public Vector2 mousePosition;
	public Vector2 velocity;
	public float distance;
	public bool isMouseClicked = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		character = GetParent<Node2D>();
		characterKinematic = GetParent<Node2D>().GetNode<KinematicBody2D>("KinematicBody2D");
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("MouseLeft") == true && @event is InputEventMouseButton eventMouseButton)
		{
			mousePosition = eventMouseButton.Position;
			isMouseClicked = true;
		}
	}

	public override void _Process(float delta)
	{
		if (isMouseClicked == true)
		{
			moveDirection = mousePosition - characterKinematic.GlobalPosition;
			velocity = moveDirection.Normalized() * speed;
			characterKinematic.MoveAndSlide(velocity);
		}
		distance = characterKinematic.GlobalPosition.DistanceTo(mousePosition);

		if (Mathf.IsZeroApprox(distance))
		{
			isMouseClicked = false;
		}
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }

}
