using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServicioPrueba.Application.Atributos.GetAtributos;
using ServicioPrueba.Domain.Atributo;
using ServicioPrueba.Domain.SeedWork;
using ServicioPrueba.Infrastructure.Domain.Atributo;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioPrueba.Infrastructure.Database
{
    public class BDContext : DbContext
    {

        public DbSet<AtributoEntity> Atributo { get; set; }

        public BDContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BDContext).Assembly);
        }
    }
}
