using Hakawy.Core.Entities;
using Hakawy.Core.Identity;
using Hakawy.Repository.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hakawy.Repository.Data
{
	public class HakawyDBContext : IdentityDbContext<AppUser>
	{
        public HakawyDBContext(DbContextOptions<HakawyDBContext> options) : base(options) 
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.ApplyConfiguration(new StoryConfigurations());
			//modelBuilder.ApplyConfiguration(new WriterConfigurations());
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Writer> Writers { get; set; }
		public DbSet<Story> Stories { get; set; }
	}
}
