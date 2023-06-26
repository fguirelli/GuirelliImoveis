using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Imovel> Imoveis { get; set; }
    public virtual DbSet<Cidade> Cidades { get; set; }
    public virtual DbSet<ImovelImagem> ImovelImagens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=TI-1329\\SQLDEV;Database=GuirelliImoveis;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<ImovelImagem>()
        .HasKey(o => new { o.ImovelId, o.NumeroImagem });
    }
}
