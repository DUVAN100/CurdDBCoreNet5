using Microsoft.EntityFrameworkCore;
using MVCCRUDASP.NET6.Models;

namespace MVCCRUDASP.NET6.Datos
{
    public class ApplicationDbContexxt : DbContext 
    {
        public ApplicationDbContexxt(DbContextOptions<ApplicationDbContexxt> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuaio { get; set; }
    }
}
