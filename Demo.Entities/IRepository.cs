using googleLocation.gprc;

namespace Demo.Entities;

public interface IRepository
{
    Task<GooglePoint[]> GetPoints(int top);
}
