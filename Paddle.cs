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
        var motion = NewVelocity() * (float)delta;
        HandleCollision(MoveAndCollide(motion));
    }
    
    private void TakeDamage()
    {
        HealthChanged?.Invoke(this, new PaddleHealthArgs(_health));
        GD.Print("health: " + _health);
    }

    private Vector2 NewVelocity()
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
        if (collision == null || SameCollider(collision))
        {
            return;
        }

        _lastColliderId = collision.GetColliderId();
        _health--;
        TakeDamage();
    }

    private bool SameCollider(KinematicCollision2D collision)
    {
        return collision.GetColliderId() == _lastColliderId;
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