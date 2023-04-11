using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Shared.EditModels;

public class PositionEditModel
{
    [Required]
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public Guid? MainUserID { get; set; }
}