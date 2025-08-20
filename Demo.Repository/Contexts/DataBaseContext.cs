using Database.ADO;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace GrpcService1.Contexts;

public class DataBaseContext
{
    DataBaseWithADO DataBase;

    public DataBaseContext(IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("demo");
        DataBase = new DataBaseWithADO(connectionString);
    }

    public async Task<DataTable> getData()
    {
        string sql = "select Category, Latitude, Longitude from Companies";
        DataTable table = await DataBase.GetDataTableAsync(sql);
        return table;
    }
}
