using Godot;
using System;

public partial class Main : Node2D
{
	private Paddle _paddle;

	public override void _Ready()
	{
		InitializePaddle();
	}

	public override void _Process(double delta)
	{
		CheckInput(delta);
	}

	private void CheckInput(double delta)
	{
		if (Input.IsKeyPressed(Key.Up))
		{
		   _paddle.MoveUp((float) delta);
		}
		else if (Input.IsKeyPressed(Key.Down))
		{
			_paddle.MoveDown((float) delta);
		}
	}

	private void InitializePaddle()
	{
		_paddle = GetNode<Paddle>("Paddle");
		var screenSize = GetWindow().Size;
		_paddle.Position = new Vector2(screenSize.X / 8, screenSize.Y / 2);
	}
}
