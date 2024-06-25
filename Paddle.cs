using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
    private float _speed = 1000f;

    public override void _Process(double delta)
    {
        var collision = MoveAndCollide(GetMotion() * (float)delta);
        if (collision != null) {
            Hit();
        }
    }

    public static void Hit() {
        GD.Print("****HiRT****");
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