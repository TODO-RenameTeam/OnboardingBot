using OnboardingBot.Shared.Models;

namespace OnboardingBot.Shared.ViewModels;

public class UserViewModel
{
    public Guid ID { get; set; }
    public long? TelegramID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public UserRole Role { get; set; } = UserRole.User;

}