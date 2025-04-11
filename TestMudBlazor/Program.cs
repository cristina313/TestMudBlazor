using MudBlazor.Services;
using TestMudBlazor.Components;
using TestMudBlazor.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddSingleton<MessageLogService>();

//var unhandledExceptionSender = new UnhandledExceptionSender();
//var unhandledExceptionProvider = new UnhandledExceptionProvider(unhandledExceptionSender);
//builder.Logging.AddProvider(unhandledExceptionProvider);
//builder.Services.AddSingleton<IUnhandledExceptionSender>(unhandledExceptionSender);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
