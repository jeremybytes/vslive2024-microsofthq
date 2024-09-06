WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IPeopleProvider, HardCodedPeopleProvider>();

builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.WriteIndented = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.MapGet("/people",
    (IPeopleProvider provider) => provider.GetPeople())
    .WithName("GetPeople");

app.MapGet("/people/{id}", (IPeopleProvider provider, int id) =>
    {
        Person? result = provider.GetPerson(id);
        return result switch
        {
            null => Results.NoContent(),
            _ => Results.Json(result)
        };
    })
    .WithName("GetPersonById");

app.MapGet("/people/ids",
    (IPeopleProvider provider) => provider.GetPeople().Select(p => p.Id).ToList())
    .WithName("GetAllPersonIds");

app.Run();
