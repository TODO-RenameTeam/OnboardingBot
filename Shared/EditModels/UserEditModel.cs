using System.ComponentModel.DataAnnotations;
using OnboardingBot.Shared.Models;

namespace OnboardingBot.Shared.EditModels;

public class UserEditModel
{
    [Required]
    public string LastName { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public UserRole Role { get; set; }  = UserRole.User;
}