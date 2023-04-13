using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Server.Entities;

/// <summary>
/// Сущность прохождения онбординга пользователя.
/// </summary>
public class UserOnboardingEntity
{
    
    /// <summary>
    /// ID.
    /// </summary>
    [Key]
    public Guid ID { get; set; }
    
    /// <summary>
    /// ID сотрудника, начавшего проходить onboarding.
    /// </summary>
    [Required]
    public Guid UserID { get; set; }
    [ForeignKey(nameof(UserID))] public UserEntity? User { get; set; }
    
    /// <summary>
    /// ID проходимого onboarding'a.
    /// </summary>
    [Required]
    public Guid RoleOnboardingID { get; set; }
    [ForeignKey(nameof(RoleOnboardingID))] public RoleOnboardingEntity? RoleOnboarding { get; set; }
    
    /// <summary>
    /// Текущий или последний шаг.
    /// </summary>
    [Required]
    public Guid UserCurrentStepID { get; set; }
    [ForeignKey(nameof(UserCurrentStepID))]
    public StepEntity? UserCurrentStep { get; set; }

    public DateTime DateTimeStart { get; set; } = DateTime.Now;
    public DateTime? DateTimeEnd { get; set; }
}