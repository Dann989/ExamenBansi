var builder = WebApplication.CreateBuilder(args);

// Agregar servicios a la colección de dependencias
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<MX.BANSI.BLAZOR.WEB.ExamenBansi.Services.ExamenApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7204"); // Cambia esto a la URL base de tu API
});

var app = builder.Build();

// Configurar el middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();