using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;
using Refit;

namespace OnboardingBot.Shared.APIs;

public interface IPositionController
{
    [Get("/api/position")]
    Task<List<PositionViewModel>> GetAll();
    
    [Get("/api/position/{id}")]
    Task<PositionViewModel> GetByID(Guid id);

    [Post("/api/position")]
    Task<PositionViewModel> Create(PositionEditModel position);
    
    [Put("/api/position")]
    Task<PositionViewModel> Update(Guid id, PositionEditModel position);
    
    [Delete("/api/position")]
    Task Delete(Guid id);
}