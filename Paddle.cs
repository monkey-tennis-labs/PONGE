using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
    private float _speed = 1000f;

    public override void _Process(double delta)
    {
        MoveAndCollide(GetMotion() * (float)delta);
    }

    private Vector2 GetMotion()
    {
        if (Input.IsKeyPressed(Key.Up))
        {
            return new Vector2(0, -_speed);
        }

        if (Input.IsKeyPressed(Key.Down))
        {
            return new Vector2(0, _speed);
        }

        return Vector2.Zero;
    }
}