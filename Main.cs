using System;
using Godot;

public partial class Main : Node2D
{
    [Export] public PackedScene EnemyScene { get; set; }
    private Paddle _paddle;
    private BallManager _ballManager;

    private int _score = 0;

    public override void _Ready()
    {
        var _timer = new Timer();
        AddChild(_timer);
        _timer.Start(3f);
        _timer.Timeout += LaunchEnemy;
        InitializePaddle();
        InitializeBoundaries();
        InitializeHud();
        InitializeBallManager();
    }

    private void UpdateScore()
    {
        _score += 1;
        GD.Print("Score !!!!!!!!", _score);
        if(_score % 3 == 0){
            _ballManager.LaunchBall();
        }
    }

    private void InitializePaddle()
    {
        _paddle = GetNode<Paddle>("Paddle");
        _paddle.Position = new Vector2(ScreenSize.X / 8, ScreenSize.Y / 2);
    }

        private void InitializeBallManager()
    {
        _ballManager = GetNode<BallManager>("BallManager");
    }

    private void InitializeHud()
    {
        var hud = GetNode<HUD>("HUD");
        _paddle.HealthChanged += (sender, args) => hud.UpdateHealth(args.Health);
    }

    private void InitializeBoundaries()
    {
        var topBoundary = GetNode<StaticBody2D>("TopBoundary");
        topBoundary.Rotation = Mathf.Pi;

        var bottomBoundary = GetNode<StaticBody2D>("BottomBoundary");
        bottomBoundary.Position = new Vector2(0, ScreenSize.Y);

        var rightBoundary = GetNode<StaticBody2D>("RightBoundary");
        rightBoundary.Position = new Vector2(ScreenSize.X, 0);
        rightBoundary.Rotation = -Mathf.Pi / 2;
    }

    private void LaunchEnemy()
    {
        var random = new RandomNumberGenerator();
        var yPosition = random.RandfRange(100, ScreenSize.Y) - 100;
        var xPosition = ScreenSize.X;
        var enemy = EnemyScene.Instantiate<Enemy>();
        enemy.Position = new Vector2(ScreenSize.X - 100, yPosition);
        enemy.LinearVelocity = Vector2.Left * 250;
        enemy.GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play();
        AddChild(enemy);
        enemy.EnemyDestroyed += (eventos, argumentos) => UpdateScore();
    }

    private Vector2 ScreenSize => GetWindow().Size;
}