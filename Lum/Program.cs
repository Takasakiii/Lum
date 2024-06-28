using Lum.Core;
using Lum.Layouts;
using TakasakiStudio.Lina.AspNet.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddFileVersionProvider();
builder.Services.AddSwaggerGen();

builder.Services.AddLum();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}


app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.MapRazorComponents<AppLayout>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Lum.Client._Imports).Assembly);


await app.RunAsync();