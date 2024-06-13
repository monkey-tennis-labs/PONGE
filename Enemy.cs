using Godot;
using System;

public partial class Enemy : RigidBody2D
{
    public void OnBodyEntered(Node body)
    {
        QueueFree();
    }
}
