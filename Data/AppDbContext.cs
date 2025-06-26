using Microsoft.EntityFrameworkCore;
using ApiOcorrenciaApi.Models;

namespace ApiOcorrenciaApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Ocorrencia> Ocorrencias { get; set; }
    }
}