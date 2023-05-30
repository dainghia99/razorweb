using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using razorweb.Models;

namespace razorweb.AppDbContext {
    public partial  class BlogContext : IdentityDbContext<AppUser>
{
    public BlogContext()
    {
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=DESKTOP-GUQBECH;Database=Razorweb;Trusted_Connection=True; TrustServerCertificate=True; encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.ToTable("Article");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContentArticle).HasColumnType("ntext");
            entity.Property(e => e.PublishDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(500);
        });

        base.OnModelCreating(modelBuilder); // Phải có trường này mới có thể add migrations 

        OnModelCreatingPartial(modelBuilder);

        // Xóa tiền tố AspNet Khỏi các bảng
        foreach (var entity in modelBuilder.Model.GetEntityTypes()) {
            var tableName = entity.GetTableName();
            if (tableName.StartsWith("AspNet")) {
                entity.SetTableName(tableName.Substring(6));
            }
        }

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
