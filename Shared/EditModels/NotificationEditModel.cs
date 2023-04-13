using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Shared.EditModels;

public class NotificationEditModel
{
    [Required] public string Name { get; set; }

    [Required] public string Text { get; set; }

    [DefaultValue(0)] public int Minutes { get; set; }

    [DefaultValue(0)] public int? Count { get; set; }

    [DefaultValue(0)] public int? Sending { get; set; }

    public Guid? PositionID { get; set; }
    public PositionViewModel? Position { get; set; }
}