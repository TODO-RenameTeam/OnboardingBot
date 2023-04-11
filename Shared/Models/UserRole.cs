using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Shared.Models;

public enum UserRole
{
    [Display(Name = "Сотрудник")]
    User,
    [Display(Name = "Администратор")]
    Admin
}