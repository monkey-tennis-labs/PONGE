using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
    public event EventHandler HealthChanged;
    private float _speed = 1000f;
    
    public override void _Process(double delta)
    {
        var collision = MoveAndCollide(GetMotion() * (float)delta);
        if (collision != null) {
            GD.Print(delta);
            var eventargs = new EventArgs();
            Hit(eventargs);
        }
    }

    public void Hit(EventArgs e) {
        HealthChanged?.Invoke(this, e);
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