using Demo.Client.Blazor.Options;
using googleLocation.gprc;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.Extensions.Options;

namespace Demo.Client.Blazor.Services;

public class GoogleClient
{
    private readonly GoogleOptions GoogleOptions;

    public GoogleClient(IOptions<GoogleOptions> options)
    {
        GoogleOptions = options.Value;
    }

    public async Task<IEnumerable<GooglePoint>> GetPoints()
    {
        var channel = GrpcChannel.ForAddress(GoogleOptions.Url, new GrpcChannelOptions
        {
            HttpHandler = new GrpcWebHandler(new HttpClientHandler())
        });

        var client = new GooglePoints.GooglePointsClient(channel);
        var response = await client.GetPointsAsync(
                          new PointsRequest { Top = 10 });
        return response.Data;
    }

    public async Task<string> GetKey()
    {
        var channel = GrpcChannel.ForAddress(GoogleOptions.Url, new GrpcChannelOptions
        {
            HttpHandler = new GrpcWebHandler(new HttpClientHandler())
        });

        var client = new GooglePoints.GooglePointsClient(channel);
        var response = await client.GetKeyAsync(
                          new EmptyRequest());
        return response.Key;
    }

}
