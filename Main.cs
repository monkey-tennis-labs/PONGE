using System;
using Godot;

public partial class Main : Node2D
{
	[Export]
	public PackedScene BallScene { get; set; }
    private Paddle _paddle;

    public override void _Ready()
    {
        InitializePaddle();
        InitializeBoundaries();
		LaunchBall();
    }

    public override void _Process(double delta)
    {
        CheckInput(delta);
    }

    private void CheckInput(double delta)
    {
        if (Input.IsKeyPressed(Key.Up))
        {
            _paddle.MoveUp((float)delta);
        }
        else if (Input.IsKeyPressed(Key.Down))
        {
            _paddle.MoveDown((float)delta);
        }
    }

    private void InitializePaddle()
    {
        _paddle = GetNode<Paddle>("Paddle");
        _paddle.Position = new Vector2(ScreenSize.X / 8, ScreenSize.Y / 2);
    }

    private void InitializeBoundaries()
    {
        var topBoundary = GetNode<StaticBody2D>("TopBoundary");
        topBoundary.Rotation = Mathf.Pi;

        var bottomBoundary = GetNode<StaticBody2D>("BottomBoundary");
        bottomBoundary.Position = new Vector2(0, ScreenSize.Y);
    }

	private void LaunchBall() {
		RigidBody2D ball = BallScene.Instantiate<RigidBody2D>();
		ball.Position = new Vector2(ScreenSize.X / 2, ScreenSize.Y / 2);
		ball.LinearVelocity = Vector2.Left.Rotated(Mathf.Pi / 4) * 500;
		AddChild(ball);
	}


    private Vector2 ScreenSize => GetWindow().Size;
}