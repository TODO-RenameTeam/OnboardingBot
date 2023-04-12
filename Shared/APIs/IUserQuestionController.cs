using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;
using Refit;

namespace QuestionBot.Shared.APIs;

public interface IUserQuestionController
{
    [Get("/api/userquestion")]
    Task<List<UserQuestionViewModel>> GetAll();
    
    [Get("/api/userquestion/{id}")]
    Task<UserQuestionViewModel> GetByID(Guid id);

    [Post("/api/userquestion")]
    Task<UserQuestionViewModel> Create(UserQuestionEditModel userquestion);
    
    [Put("/api/userquestion")]
    Task<UserQuestionViewModel> Update(Guid id, UserQuestionEditModel userquestion);
    
    [Delete("/api/userquestion")]
    Task Delete(Guid id);
}