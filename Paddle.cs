using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
    public event EventHandler<PaddleHealthArgs> HealthChanged;
    private float _speed = 1000f;

    private ulong _lastColliderId;

    private int _health = 100;

    public override void _Process(double delta)
    {
        HandleCollision(MoveAndCollide(GetMotion() * (float)delta));
    }


    public void Hit(PaddleHealthArgs e)
    {
        HealthChanged?.Invoke(this, e);
        GD.Print("health: " + _health);
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

    private void HandleCollision(KinematicCollision2D collision)
    {
        if (collision == null)
        {
            return;
        }

        var currentColliderId = collision.GetColliderId();
        if (currentColliderId != _lastColliderId)
        {
            _lastColliderId = currentColliderId;
            _health--;
            Hit(new PaddleHealthArgs(_health));
        }
    }
}

public class PaddleHealthArgs : EventArgs
{
    public int Health { get; set; }

    public PaddleHealthArgs(int health)
    {
        Health = health;
    }
}