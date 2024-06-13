using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
    private float _speed = 1000f;

    private void MoveUp(float delta)
    {
        Velocity = new Vector2(0, -_speed);
    }

    private void MoveDown(float delta)
    {
        Velocity = new Vector2(0, _speed);
    }

    public override void _Process(double delta)
    {
        CheckInput(delta);
        MoveAndCollide(Velocity * (float)delta);
        Velocity = Vector2.Zero;
    }

    private void CheckInput(double delta)
    {
        if (Input.IsKeyPressed(Key.Up))
        {
            MoveUp((float)delta);
        }
        else if (Input.IsKeyPressed(Key.Down))
        {
            MoveDown((float)delta);
        }
    }
}