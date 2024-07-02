using Godot;

public partial class HUD : CanvasLayer
{
    public void UpdateHealth(int health)
    {
        // GD.Print("Updating health to " + health);
        var healthLabel = GetNode<Label>("Health");
        healthLabel.Text = health.ToString();
        healthLabel.Show();
    }
}