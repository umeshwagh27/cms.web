using cms.web.Service;
using cms.web.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("CMSHttpClient", client =>
{
    var baseURL = builder.Configuration["baseURL"];
    if (baseURL is not null)
    {
        client.BaseAddress = new Uri(baseURL);
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    }
    else
    {
        throw new InvalidOperationException("Base URL is not configured.");
    }
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ICar, CarService>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


var clientFactory = app.Services.GetRequiredService<IHttpClientFactory>();
ClientRequest.Initialize(clientFactory);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Car}/{action=Index}/{id?}");
app.Run();
