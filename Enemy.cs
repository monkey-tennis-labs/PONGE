using Godot;
using System;

public partial class Enemy : RigidBody2D
{
    public event EventHandler EnemyDestroyed;

    public void OnBodyEntered(Node body)
    {
        EnemyDestroyed?.Invoke(this, EventArgs.Empty);
        QueueFree();
    }
}
