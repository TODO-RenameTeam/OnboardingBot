using System.Text.Json;
using System.Text.Json.Serialization;
using OnboardingBot.Server.Shared;
using OnboardingBot.Server.Shared.APIs;
using Refit;

namespace OnboardingBot.Client.Providers;

public class RefitProvider
{
    public static void AddRefitInterfaces(IServiceCollection services, Uri url)
    {
        // Initialize refit.
        services.AddAutoMapper(typeof(Mappings));

        // Add services to the container.

        var serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        serializerOptions.PropertyNameCaseInsensitive = true;
        serializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        serializerOptions.Converters.Add(new ObjectToInferredTypesConverter());
        serializerOptions.Converters.Add(new JsonStringEnumConverter(allowIntegerValues: false));

        var serializer = new SystemTextJsonContentSerializer(serializerOptions);

        var refitSettings = new RefitSettings()
        {
            ContentSerializer = serializer
        };

        var apiUrl = url;

        services.AddRefitClient<IUserController>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = apiUrl);
    }
}