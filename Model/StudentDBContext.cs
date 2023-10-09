using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lab05.Model
{
    public partial class StudentDBContext : DbContext
    {
        public StudentDBContext()
            : base("name=StudentDBContext")
        {
        }

        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
                .Property(e => e.Faculty1)
                .IsFixedLength();

            modelBuilder.Entity<Faculty>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Faculty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentID)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.FullName)
                .IsFixedLength();
        }
    }
}
