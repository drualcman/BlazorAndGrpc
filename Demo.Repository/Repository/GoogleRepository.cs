using Demo.Entities;
using googleLocation.gprc;
using GrpcService1.Contexts;
using System.Data;

namespace GrpcService1.Repository;

public class GoogleRepository(DataBaseContext context) : IRepository
{
    public async Task<GooglePoint[]> GetPoints(int top)
    {
        var data = await context.getData();
        List<GooglePoint> points = new List<GooglePoint>();
        foreach (DataRow item in data.Rows)
        {
            points.Add(new GooglePoint
            {
                Description = item["Category"].ToString(),
                LatLong = new LatLong
                {
                    Lat = Convert.ToDouble(item["Latitude"]),
                    Long = Convert.ToDouble(item["Longitude"])
                }
            });
        }
        return points.ToArray();
    }
}
