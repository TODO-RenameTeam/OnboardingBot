namespace OnboardingBot.Shared.ViewModels;

public class PositionViewModel
{
    public Guid ID { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}