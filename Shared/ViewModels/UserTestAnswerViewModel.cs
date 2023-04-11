namespace OnboardingBot.Shared.ViewModels;

public class UserTestAnswerViewModel
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid TestID { get; set; }
    public HashSet<UserAnswerViewModel>? Answers { get; set; } = new();
    public DateTime DateTimeStarting { get; set; } = DateTime.Now;
    public DateTime? DateTimeEnding { get; set; }
}