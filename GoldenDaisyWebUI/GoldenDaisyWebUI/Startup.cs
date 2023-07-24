using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GoldenDaisyWebUI.Data;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    //...

    public void ConfigureServices(IServiceCollection services)
    {
        // Configuration nesnesini kullanarak ba�lant� dizesini al�n
        string connectionString = _configuration.GetConnectionString("DefaultConnection");

        // DbContext'i ekleyin ve SQLite ba�lant�s�n� belirtin
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString));

        //...
    }
}
