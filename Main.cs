using Godot;
using System;

public partial class Main : Node2D
{
	private CharacterBody2D _paddle;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_paddle = GetNode<CharacterBody2D>("Paddle");
		GD.Print(_paddle);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
