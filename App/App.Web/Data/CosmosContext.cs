using App.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Data
{
	public class CosmosContext : DbContext
	{
        public CosmosContext(DbContextOptions<CosmosContext> options)
       : base(options)
        {
        }

        public DbSet<Folder> Folders { get; set; }

        protected override void
            OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>(x =>
            {
                x.ToContainer("Folders");
                x.HasKey(x => x.Id);
                x.HasPartitionKey(x => x.Id);
            });
        }
    }
}

