using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;
using Refit;

namespace OnboardingBot.Shared.APIs;

public interface IQuizController
{
    [Get("/api/quiz")]
    Task<List<QuizViewModel>> GetAll();
    
    [Get("/api/quiz/{id}")]
    Task<QuizViewModel> GetByID(Guid id);

    [Post("/api/quiz")]
    Task<QuizViewModel> Create(QuizEditModel quiz);
    
    [Put("/api/quiz")]
    Task<QuizViewModel> Update(Guid id, QuizEditModel quiz);
    
    [Delete("/api/quiz")]
    Task Delete(Guid id);
}