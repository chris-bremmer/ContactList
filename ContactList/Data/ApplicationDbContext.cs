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
		public DbSet<PhoneType> PhoneTypes { get; set; }
		public DbSet<PhoneNumber> PhoneNumbers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Contact>()
				.Property(c => c.Created)
				.HasDefaultValueSql("GETDATE()");

			// Seed data for PhoneType
			modelBuilder.Entity<PhoneType>().HasData(
				new PhoneType { PhoneTypeId = 1, PhoneTypeName = "Home", IsMobile = false },
				new PhoneType { PhoneTypeId = 2, PhoneTypeName = "Work", IsMobile = false },
				new PhoneType { PhoneTypeId = 3, PhoneTypeName = "Mobile", IsMobile = true },
				new PhoneType { PhoneTypeId = 4, PhoneTypeName = "Fax", IsMobile = false },
				new PhoneType { PhoneTypeId = 5, PhoneTypeName = "Other", IsMobile = false }
			);
		}
	}
}
