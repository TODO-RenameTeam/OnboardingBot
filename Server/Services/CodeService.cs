using OnboardingBot.Server.Entities;

namespace OnboardingBot.Server.Services;

public class CodeService
{
    private DBContext Context;
    private Random Random;

    private const string LETTERS = "QWERTYUIOPASDFGHJKLZXCVBNM";

    public CodeService(DBContext context)
    {
        Context = context;
        Random = new Random();
    }

    public async Task<TelegramCodeEntity> GenerateCode(Guid userId)
    {
        var entity = new TelegramCodeEntity
        {
            UserID = userId,
        };
        entity.Code = entity.UserID.ToString().Substring(0,5);


        Context.Add(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    private string generateCode(int length = 6)
    {
        var code = string.Empty;

        while (Context.TelegramCodes.FirstOrDefault(x => x.Code == code) == null 
               && !string.IsNullOrWhiteSpace(code))
        {
            code = string.Empty;
            while (code.Length != 6)
            {
                code += LETTERS[Random.Next(0, LETTERS.Length - 1)];
            }
        }

        return code;
    }
}