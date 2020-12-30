using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assessment6bversion2.Data
{
    public partial class JellyBean3DbContext : DbContext
    {
        public JellyBean3DbContext()
        {
        }

        public JellyBean3DbContext(DbContextOptions<JellyBean3DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JellyBean3> JellyBean3 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=LAPTOP-1QFGMM00\\SQLEXPRESS; database=JellyBean3Db; Trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JellyBean3>(entity =>
            {
                entity.Property(e => e.Style).HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
