using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server;
using OnboardingBot.Server.Jobs;
using OnboardingBot.Server.Services;
using OnboardingBot.Shared.APIs.Bot;
using Quartz.Impl;
using Refit;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Intialize DB Context.
builder.Services.AddDbContext<DBContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")));

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddTransient<CodeService>();
builder.Services.AddTransient<NotificationService>();

builder.Services.AddTransient<NotificationSender>();
builder.Services.AddTransient<JobFactory>(o => new JobFactory(builder.Services.BuildServiceProvider()));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

builder.Services.AddAutoMapper(typeof(Mappings));

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(allowIntegerValues: false));
    options.JsonSerializerOptions.Converters.Add(new ObjectToInferredTypesConverter());

    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition
        = JsonIgnoreCondition.WhenWritingNull;
});
var serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
serializerOptions.PropertyNameCaseInsensitive = true;
serializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
serializerOptions.Converters.Add(new ObjectToInferredTypesConverter());
serializerOptions.Converters.Add(new JsonStringEnumConverter(allowIntegerValues: false));

var serializer = new SystemTextJsonContentSerializer(serializerOptions);

var botUrlStr = Environment.GetEnvironmentVariable("BOT_URL");
if (string.IsNullOrWhiteSpace(botUrlStr))
{
    Console.WriteLine("ERROR! LINK TO BOT NOT SETTED!");
}
else
{
    var botUrl = new Uri(botUrlStr);

    var refitSettings = new RefitSettings()
    {
        ContentSerializer = serializer
    };

    builder.Services.AddRefitClient<ITelegramBotInterface>(refitSettings)
        .ConfigureHttpClient(c => c.BaseAddress = botUrl);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

var scope = app.Services.CreateScope().ServiceProvider;
await scope.GetService<DBContext>().Database.EnsureCreatedAsync();
await scope.GetService<NotificationService>().Start();

app.Run();