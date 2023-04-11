using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Server.Entities;

/// <summary>
/// Сущность onboarding к роли.
/// </summary>
public class RoleOnboardingEntity
{
    [Key] public Guid ID { get; set; }
    [Required] public Guid PositionID { get; set; }
    [ForeignKey(nameof(PositionID))] public PositionEntity? Position { get; set; }

    public int StepsCount { get; set; }
    public HashSet<UserOnboardingEntity>? UserSteps { get; set; } = new();

    public HashSet<StepEntity>? Steps { get; set; } = new();
    
    public HashSet<RoleOnboardingStepEntity>? StepPositions { get; set; } = new();
}