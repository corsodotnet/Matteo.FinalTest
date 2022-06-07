using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace PROGETTOMATTEO
{
    public class DatabaseCxt : DbContext
    {
        public readonly string _connectionString;

        public DatabaseCxt(DbContextOptions<DatabaseCxt> opts, IOptions<AppSettings> setting) : base(opts)
        {
            _connectionString = setting.Value.ConnectionString;
        }
        public DatabaseCxt()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Continent> _Continent { get; set; }
        public DbSet<Country> _Country { get; set; }
        public DbSet<City> _City { get; set; }
    }
}
