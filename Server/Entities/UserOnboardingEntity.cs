using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Server.Entities;

public class UserOnboardingEntity
{
    public Guid ID { get; set; }
    [Required]
    public Guid UserID { get; set; }
    [ForeignKey(nameof(UserID))] public UserEntity User { get; set; }

    [Required]
    public Guid RoleOnboardingID { get; set; }
    [ForeignKey(nameof(RoleOnboardingID))] public RoleOnboardingEntity RoleOnboarding { get; set; }

    [Required]
    public Guid UserCurrentStepID { get; set; }
    [ForeignKey(nameof(UserCurrentStepID))]
    public StepEntity? UserCurrentStep { get; set; }
}