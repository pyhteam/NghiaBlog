using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NghiaBlog.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<tintuc> tintucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
                

            modelBuilder.Entity<account>()
                .Property(e => e.username)
                .IsFixedLength();

            modelBuilder.Entity<account>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<account>()
                .Property(e => e.displayname)
                .IsFixedLength();
        }
    }
}
