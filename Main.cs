using Godot;
using System;

public partial class Main : Node2D
{
	private CharacterBody2D _paddle;
	public override void _Ready()
	{
		InitializePaddle();
	}
	
	public override void _Process(double delta)
	{
		
	}

	private void InitializePaddle()
	{
		_paddle = GetNode<CharacterBody2D>("Paddle");
		var screenSize = GetWindow().Size;
		_paddle.Position = new Vector2(screenSize.X / 8, screenSize.Y / 2);
	}
}
