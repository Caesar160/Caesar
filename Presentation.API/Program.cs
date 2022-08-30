using Caesar.Application;
using Caesar.Application.Interfaces;
using Caesar.Application.Mappings;
using Caesar.Persistence;
using Caesar.Presentation.API.Extensions;
using Caesar.Presentation.API.Services;
using Caesar.Stripe;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddStripe(builder.Configuration);
builder.Services.ConfigureApplicationSettings(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
