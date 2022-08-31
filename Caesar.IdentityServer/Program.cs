using Caesar.Application.Aggregates.Customers.Commands.CreateCustomer;
using Caesar.Application.Aggregates.Customers.Queries.GetClientByEmail;
using Caesar.Application.Aggregates.Customers.Queries.GetClientById;
using Caesar.Application.Interfaces;
using Caesar.Application.Mappings;
using Caesar.Application.Models;
using Caesar.IdentityServer;
using Caesar.IdentityServer.Services;
using Caesar.Persistence;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using MediatR.Registration;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));
var serviceConfig = new MediatRServiceConfiguration();
ServiceRegistrar.AddRequiredServices(builder.Services, serviceConfig);
builder.Services.AddScoped<IRequestHandler<GetClientByIdQuery, Customer>, GetClientByIdQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetClientByEmailQuery, Customer>, GetClientByEmailQueryHandler>();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.ConfigureIdentityServer();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseIdentityServer();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.Run();

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection ConfigureIdentityServer(this IServiceCollection services)
    {
        var builder = services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
        });

        builder.AddInMemoryIdentityResources(Config.IdentityResources);
        builder.AddInMemoryApiScopes(Config.ApiScopes);
        builder.AddInMemoryClients(Config.Clients);

        builder.AddDeveloperSigningCredential();

        //services.AddTransient<IUserService, UserService>();
        services.AddTransient<IResourceOwnerPasswordValidator, CustomResourceOwnerPasswordValidator>();
        services.AddTransient<IProfileService, ProfileService>();
        return services;
    }
}
