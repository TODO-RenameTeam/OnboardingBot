using OnboardingBot.Shared.ViewModels;
using Refit;

namespace OnboardingBot.Shared.APIs;

public interface ITelegramCodeController
{
    [Get("/api/telegramCode")]
    Task<List<TelegramCodeViewModel>> GetAll();
    
    [Get("/api/telegramCode/id/{id}")]
    Task<TelegramCodeViewModel> GetByID(Guid id);

    [Get("/api/telegramCode/code/{code}")]
    Task<TelegramCodeViewModel> GetByCode(string code);

    [Post("/api/telegramCode/generate")]
    Task<TelegramCodeViewModel> Generate(Guid userId);
    
    [Post("/api/telegramCode/connect")]
    Task Connect(string code, long telegramUserId);
    
    [Delete("/api/telegramCode")]
    Task Delete(Guid id);
}