using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TuTor_cho_nguoi_than.DomainClass;

namespace TuTor_cho_nguoi_than.Context;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HocSinh> HocSinhs { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PHAMDUCHOANG\\SQLEXPRESS;Initial Catalog=TUTOR_CHO_NGUOI_THAN;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HocSinh>(entity =>
        {
            entity.Property(e => e.IdHocSinh).ValueGeneratedNever();

            entity.HasOne(d => d.IdLopNavigation).WithMany(p => p.HocSinhs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HocSinh_Lop");
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.Property(e => e.IdLop).HasDefaultValueSql("(newsequentialid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
