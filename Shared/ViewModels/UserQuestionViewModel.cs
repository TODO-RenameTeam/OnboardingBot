namespace OnboardingBot.Shared.ViewModels;

public class UserQuestionViewModel
{
    public Guid ID { get; set; }

    public string Question { get; set; }
    
    public string? Answer { get; set; }
    
    public DateTime DateTimeQuestion { get; set; } = DateTime.Now;
    
    public DateTime? DateTimeAnswering { get; set; }
    
    public Guid UserQuestionID { get; set; }
    
    public UserViewModel? UserQuestion { get; set; }
}