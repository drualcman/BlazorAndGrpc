using googleLocation.gprc;

namespace Demo.Client.Blazor.Services;

public class GoogleClient
{
    private readonly GooglePoints.GooglePointsClient Client;

    public GoogleClient(GooglePoints.GooglePointsClient client)
    {
        Client = client;
    }

    public async Task<IEnumerable<GooglePoint>> GetPoints()
    {
        var response = await Client.GetPointsAsync(
                          new PointsRequest { Top = 10 });
        return response.Data;
    }

    public async Task<string> GetKey()
    {
        var response = await Client.GetKeyAsync(
                          new EmptyRequest());
        return response.Key;
    }

}
