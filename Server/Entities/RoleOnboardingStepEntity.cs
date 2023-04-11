using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Server.Entities;

public class RoleOnboardingStepEntity
{
    [Key] public Guid RoleOnboardingID { get; set; }

    [ForeignKey(nameof(RoleOnboardingID))] public RoleOnboardingEntity? RoleOnboarding { get; set; }
    [Key] public Guid StepID { get; set; }
    [ForeignKey(nameof(StepID))] public StepEntity? Step { get; set; }
    [Key] public int Position { get; set; }
}