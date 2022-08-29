using Caesar.IdentityServer;
using Caesar.IdentityServer.Services;
using IdentityServer4.Services;
using IdentityServer4.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.ConfigureIdentityServer();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseIdentityServer();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

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

        builder.AddInMemoryIdentityResources(Configuration.IdentityResources);
        builder.AddInMemoryApiScopes(Configuration.ApiScopes);
        builder.AddInMemoryClients(Configuration.Clients);

        builder.AddDeveloperSigningCredential();

        //services.AddTransient<IUserService, UserService>();
        services.AddTransient<IResourceOwnerPasswordValidator, CustomResourceOwnerPasswordValidator>();
        services.AddTransient<IProfileService, ProfileService>();
        return services;
    }
}
