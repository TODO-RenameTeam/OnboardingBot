using System.ComponentModel.DataAnnotations;
using OnboardingBot.Server.Models;

namespace OnboardingBot.Shared.Entities;

/// <summary>
/// Сущность сотрудников.
/// </summary>
public class UserEntity
{
    /// <summary>
    /// ID.
    /// </summary>
    [Key]
    public Guid ID { get; set; }
    
    /// <summary>
    /// Telegram ID.
    /// </summary>
    public long? TelegramID { get; set; }
    
    /// <summary>
    /// Last Name.
    /// </summary>
    [Required]
    public string LastName { get; set; }
    
    /// <summary>
    /// First Name.
    /// </summary>
    [Required]
    public string FirstName { get; set; }
    
    /// <summary>
    /// Middle Name.
    /// </summary>
    public string? MiddleName { get; set; }
    
    
    
    public UserRole Role { get; set; } = UserRole.User;
}