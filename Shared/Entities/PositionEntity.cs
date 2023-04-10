using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Shared.Entities;

/// <summary>
/// Сущность должностей.
/// </summary>
public class PositionEntity
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public Guid MainUserID { get; set; }
    
    [ForeignKey(nameof(MainUserID))] public UserEntity MainUser { get; set; }
}