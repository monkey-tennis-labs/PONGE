using Godot;
using System;

public partial class BallManager : Node
{
    [Export] public PackedScene BallScene { get; set; }
    private Vector2 ScreenSize => GetWindow().Size;

    public override void _Ready()
    {
        LaunchBall();
    }
    public void LaunchBall()
    {
        RigidBody2D ball = BallScene.Instantiate<RigidBody2D>();
        ball.Position = new Vector2(ScreenSize.X / 2, ScreenSize.Y / 2);
        ball.LinearVelocity = Vector2.Left.Rotated(Mathf.Pi / 4) * 500;
        AddChild(ball);
    }
}
