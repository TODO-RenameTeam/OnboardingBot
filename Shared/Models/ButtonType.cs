using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Shared.Models;

/// <summary>
/// Перечисление возможных функционалов кнопки.
/// </summary>
public enum ButtonType
{
    [Display(Name = "Вызов команды")]
    Command
}