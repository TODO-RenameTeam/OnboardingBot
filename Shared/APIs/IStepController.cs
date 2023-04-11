using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;
using Refit;

namespace OnboardingBot.Shared.APIs;

public interface IStepController
{
    [Get("/api/step")]
    Task<List<StepViewModel>> GetAll();
    
    [Get("/api/step/{id}")]
    Task<StepViewModel> GetByID(Guid id);

    [Post("/api/step")]
    Task<StepViewModel> Create(StepEditModel step);
    
    [Put("/api/step")]
    Task<StepViewModel> Update(Guid id, StepEditModel step);
    
    [Delete("/api/step")]
    Task Delete(Guid id);
}