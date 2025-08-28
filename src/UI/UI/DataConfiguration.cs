using ProgrammingWithPalermo.ChurchBulletin.DataAccess;

namespace UI;

public class DataConfiguration : IDataConfiguration
{
    private readonly IConfiguration _configuration;

    public DataConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetConnectionString()
    {
        return _configuration.GetConnectionString("SqlConnectionString")!;
    }
}