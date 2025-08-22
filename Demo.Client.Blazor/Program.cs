using Demo.Client.Blazor;
using Demo.Client.Blazor.Options;
using Demo.Client.Blazor.Services;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PointsClient = googleLocation.gprc.GooglePoints.GooglePointsClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//builder.Services.Configure<GoogleOptions>(options => builder.Configuration.GetSection(GoogleOptions.SectionName).Bind(options));
builder.Services.AddGrpcClient<PointsClient>(o =>
{
    GoogleOptions options = new GoogleOptions();
    builder.Configuration.GetSection(GoogleOptions.SectionName).Bind(options);
    o.Address = new Uri(options.Url);
}).ConfigurePrimaryHttpMessageHandler(() => new GrpcWebHandler(new HttpClientHandler()));
builder.Services.AddScoped<GoogleClient>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
