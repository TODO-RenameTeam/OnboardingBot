using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Server.Entities;

public class UserAnswerEntity
{
    public Guid ID { get; set; }
    [ForeignKey(nameof(UserID))] public UserEntity? User { get; set; }
    public Guid UserID { get; set; }
    public Guid QuestionID { get; set; }
    [ForeignKey(nameof(QuestionID))] public QuestionEntity? Question { get; set; }
    public Guid AnswerID { get; set; }
    [ForeignKey(nameof(QuestionID))] public AnswerEntity? Answer { get; set; }
}