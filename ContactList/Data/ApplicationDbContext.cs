using ContactList.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContactList.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Session> Session { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Contact>()
				.Property(c => c.Created)
				.HasDefaultValueSql("GETDATE()");

		}
	}
}
