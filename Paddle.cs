using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
    public event EventHandler HealthChanged;
    private float _speed = 1000f;

    private ulong _lastColliderId;

    private int _health = 100;

    public override void _Process(double delta)
    {
        HandleCollision(MoveAndCollide(GetMotion() * (float)delta));
    }



    public void Hit(EventArgs e)
    {
        HealthChanged?.Invoke(this, e);
        _health -= 1;
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
        if (collision == null)
        {
            return;
        }
        var currentColliderId = collision.GetColliderId();
        if (currentColliderId != _lastColliderId)
        {
            _lastColliderId = currentColliderId;
            var eventargs = new EventArgs();
            Hit(eventargs);
        }
    }
}