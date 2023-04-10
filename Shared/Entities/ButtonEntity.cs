using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Shared.Entities;

/// <summary>
/// Сущность кнопки.
/// </summary>
public class ButtonEntity
{
    /// <summary>
    /// ID.
    /// </summary>
    [Key]
    public Guid ID { get; set; }
    
    /// <summary>
    /// Название кнопки.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Значение кнопки.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Тип кнопки.
    /// Связано с параметром Key.
    /// </summary>
    public ButtonType Type { get; set; } = ButtonType.Command;
}

/// <summary>
/// Перечисление возможных функционалов кнопки.
/// </summary>
public enum ButtonType
{
    [Display(Name = "Вызов команды")]
    Command
}