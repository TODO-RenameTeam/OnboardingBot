using System.ComponentModel.DataAnnotations;
using OnboardingBot.Shared.Models;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Shared.EditModels;

public class 
    UserEditModel
{
    [Required]
    public string LastName { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public UserRole Role { get; set; }  = UserRole.User;
    
    public Guid? PositionID { get; set; }
    public PositionViewModel? Position { get; set; }
}