using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;
using Refit;

namespace OnboardingBot.Shared.APIs;

public interface ITextCommandController
{
    [Get("/api/textcommand")]
    Task<List<TextCommandViewModel>> GetAll();
    
    [Get("/api/textcommand/{id}")]
    Task<TextCommandViewModel> GetByID(Guid id);

    [Post("/api/textCommand")]
    Task<TextCommandViewModel> Create(TextCommandEditModel textCommand);
    
    [Put("/api/textCommand")]
    Task<TextCommandViewModel> Update(Guid id, TextCommandEditModel textCommand);
    
    [Delete("/api/textCommand")]
    Task Delete(Guid id);
}