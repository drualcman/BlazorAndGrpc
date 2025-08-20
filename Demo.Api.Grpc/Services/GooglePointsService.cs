using Demo.Entities;
using googleLocation.gprc;
using Grpc.Core;

namespace Demo.Api.Grpc.Services;

public class GooglePointsService(IRepository repository, IConfiguration configuration) : GooglePoints.GooglePointsBase
{
    public override async Task<PointsReply> GetPoints(PointsRequest request, ServerCallContext context)
    {
        var data = await repository.GetPoints(request.Top);
        var reply = new PointsReply();
        reply.Data.Add(data);
        return reply;
    }

    public override Task<KeyReply> GetKey(EmptyRequest request, ServerCallContext context)
    {
        return Task.FromResult(new KeyReply
        {
            Key = configuration["MapsKey"]
        });
    }
}
