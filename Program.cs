using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpClient("EverythingProxy", c =>
{
    c.Timeout = TimeSpan.FromSeconds(2); // short timeout per server
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Error");

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

// Proxy endpoint to query remote Everything servers asynchronously
app.MapGet("/proxy", async (IHttpClientFactory httpFactory, string host, HttpRequest req) =>
{
    var client = httpFactory.CreateClient("EverythingProxy");
    var query = req.QueryString.Value ?? "";
    var targetUrl = $"http://{host}:888{query}";

    try
    {
        var response = await client.GetAsync(targetUrl);
        if (!response.IsSuccessStatusCode)
            return Results.Problem($"Failed to reach {host}", statusCode: (int)response.StatusCode);

        var json = await response.Content.ReadAsStringAsync();
        return Results.Text(json, "application/json");
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error contacting {host}: {ex.Message}");
    }
});

app.Run();
