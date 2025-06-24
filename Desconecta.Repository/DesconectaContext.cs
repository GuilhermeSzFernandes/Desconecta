using Desconecta.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconecta.Repository
{
    public class DesconectaContext : DbContext
    {
        public DesconectaContext(DbContextOptions<DesconectaContext> options) : base(options) { }

        public DbSet<tabUsuariosResponsaveis> UsuariosResponsaveis { get; set; }
        public DbSet<tabDispositivosFilhos> DispositivosFilhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabUsuariosResponsaveis>().ToTable("tabUsuariosResponsaveis");
            modelBuilder.Entity<tabDispositivosFilhos>().ToTable("tabDispositivosFilhos");
        }
    }
}
