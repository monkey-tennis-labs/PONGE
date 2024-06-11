using Godot;
using System;

public partial class Main : Node2D
{
	private Paddle _paddle;

	public override void _Ready()
	{
		InitializePaddle();
		InitializeBoundaries();
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
		_paddle.Position = new Vector2(ScreenSize.X / 8, ScreenSize.Y / 2);
	}

	private void InitializeBoundaries()
	{
		var topBoundary = GetNode<StaticBody2D>("TopBoundary");
		var topCollisionShape = topBoundary.GetNode<CollisionShape2D>("CollisionShape2D");
		var topWorldBoundaryShape = topCollisionShape.Shape as WorldBoundaryShape2D;
		topWorldBoundaryShape.Normal = Vector2.Down;

		var bottomBoundary = GetNode<StaticBody2D>("BottomBoundary");
		bottomBoundary.Position = new Vector2(0, ScreenSize.Y);
	}

	private Vector2 ScreenSize => GetWindow().Size;
}
