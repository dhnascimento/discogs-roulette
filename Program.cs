using DiscogsRoulette.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register application services
builder.Services.AddHttpClient<IDiscogsService, DiscogsService>(client =>
{
    client.BaseAddress = new Uri("https://api.discogs.com");
    client.DefaultRequestHeaders.Add("User-Agent", 
        builder.Configuration["Discogs:UserAgent"] ?? "DiscogsRoulette/1.0");
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<DiscogsRoulette.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();
