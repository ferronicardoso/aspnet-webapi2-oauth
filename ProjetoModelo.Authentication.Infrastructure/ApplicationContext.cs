using ProjetoModelo.Authentication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Authentication.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("ApplicationContextConnectionString")
        {

        }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
        }
    }
}
