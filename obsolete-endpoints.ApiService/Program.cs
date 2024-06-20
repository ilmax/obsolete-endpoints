using ObsoleteEndpoints.ApiService;
using ObsoleteEndpoints.ApiService.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<ObsoleteActionFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/weatherforecast", [Obsolete]() => WeatherGenerator.Generate())
    .AddEndpointFilter<ObsoleteEndpointFilter>()
    .WithTags("MinimalApi");
    
app.MapControllers();

app.MapDefaultEndpoints();

app.Run();
