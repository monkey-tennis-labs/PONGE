using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
    private float _speed = 1000f;

    public void MoveUp(float delta)
    {
        Velocity = new Vector2(0, -_speed);
    }

    public void MoveDown(float delta)
    {
        Velocity = new Vector2(0, _speed);
    }

    public override void _Process(double delta)
    {
        MoveAndCollide(Velocity * (float)delta);
        Velocity = Vector2.Zero;
    }
}