using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Server.Models;

public enum UserRole
{
    [Display(Name = "Сотрудник")]
    User,
    [Display(Name = "Администратор")]
    Admin
}