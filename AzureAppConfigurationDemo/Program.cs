using AzureAppConfigurationDemo;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureAppConfiguration(configurationOptions =>
{
    configurationOptions.Connect(builder.Configuration["AzureAppConfigurationEndpoint"]);
    configurationOptions.Select($"{nameof(AzureAppConfigurationDemoSettings)}:*");
    configurationOptions.ConfigureRefresh(refreshOptions =>
    {
        refreshOptions.Register($"{nameof(AzureAppConfigurationDemoSettings)}:Sentinel", refreshAll: true);
    });
});

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddOptions<AzureAppConfigurationDemoSettings>()
    .Bind(builder.Configuration.GetSection(nameof(AzureAppConfigurationDemoSettings)))
    .ValidateDataAnnotations();
builder.Services.AddAzureAppConfiguration();
builder.Services.AddFeatureManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAzureAppConfiguration();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
