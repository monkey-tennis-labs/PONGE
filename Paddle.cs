using Godot;
using System;

public partial class Paddle : CharacterBody3D
{
    public event EventHandler<PaddleHealthArgs> HealthChanged;
    private float _speed = 1000f;
    private ulong _lastColliderId;
    private int _health = 100;
    private int _collisionCount = 0;

    public override void _PhysicsProcess(double delta)
    {
        var motion = NewVelocity() * (float)delta;
        MoveAndCollide(motion);
    }

    public void OnArea2dBodyEntered(Node3D body)
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        _health--;
        HealthChanged?.Invoke(this, new PaddleHealthArgs(_health));
        // GD.Print("health: " + _health);
    }

    private Vector3 NewVelocity()
    {
        if (Input.IsKeyPressed(Key.Up))
        {
            return new Vector3(0, -_speed,0);
        }

        if (Input.IsKeyPressed(Key.Down))
        {
            return new Vector3(0, _speed, 0);
        }

        return Vector3.Zero;
    }

    private void HandleCollision(KinematicCollision3D collision)
    {
        if (collision == null || SameCollider(collision))
        {
            return;
        }

        _collisionCount++;
        GD.Print("Collision count: " + _collisionCount + ", Current collider: " + collision.GetColliderId());
        _lastColliderId = collision.GetColliderId();
        _health--;
        TakeDamage();
    }

    private bool SameCollider(KinematicCollision3D collision)
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