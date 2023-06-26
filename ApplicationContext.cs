using Microsoft.EntityFrameworkCore;

namespace CRUDUSUARIO.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Bypass sql server certificate
        string connectionString = @"Data Source=rita\SQLEXPRESS;Initial Catalog=projetoFinal2;Integrated Security=True;TrustServerCertificate=True";
        // Configure a conexão com o banco de dados
        optionsBuilder.UseSqlServer(connectionString);
    }
}