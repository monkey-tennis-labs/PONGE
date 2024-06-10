using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
	private float _speed = 1000f;

	public void MoveUp(float delta)
	{
		Position = new Vector2(Position.X, Position.Y - delta * _speed);
	}

	public void MoveDown(float delta)
	{
		Position = new Vector2(Position.X, Position.Y - delta * _speed);
	}
}
