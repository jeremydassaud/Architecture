using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domaine.Models;

namespace Domaine
{
    public partial class masterContext : DbContext
    {
		private static readonly object _padlock = new object();
		private static masterContext? _instance;
		//méthode statique qui renvoit une instance de ConDB
		public static masterContext Instance
		{
			get
			{
				//check pour éviter l'accés multi-thread
				lock(_padlock)
				{
					if(_instance == null) //si null on instancié
						_instance = new masterContext();
					return _instance;
				}
			}
		}

		public masterContext()
		{
		}

		public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

		public virtual DbSet<Student> Student { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localDB)\\mssqllocaldb;Initial Catalog=master;Integrated Security=True;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
