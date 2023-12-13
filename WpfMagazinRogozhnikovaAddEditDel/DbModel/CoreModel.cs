using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfMagazinRogozhnikovaAddEditDel;

public partial class CoreModel : DbContext
{
    private static CoreModel instanse;
    public static CoreModel init()
    {
        if (instanse == null)
        {
            instanse = new CoreModel();
        }
        return instanse;
    }
    public CoreModel()
    {
    }

    public CoreModel(DbContextOptions<CoreModel> options)
        : base(options)
    {
    }

    public virtual DbSet<Authorization> Authorizations { get; set; }

    public virtual DbSet<Deliviry> Deliviries { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Tovar> Tovars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=ISPr23-35_RogozhnikovaYO;database=ISPr23-35_RogozhnikovaYO_magazin;password=ISPr23-35_RogozhnikovaYO;character set=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Authorization>(entity =>
        {
            entity.HasKey(e => e.Idauthorization).HasName("PRIMARY");

            entity.ToTable("authorization");

            entity.Property(e => e.Idauthorization).HasColumnName("idauthorization");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Deliviry>(entity =>
        {
            entity.HasKey(e => e.Iddeliviries).HasName("PRIMARY");

            entity.ToTable("deliviries");

            entity.HasIndex(e => e.PostsIdposts, "fk_deliviries_posts1_idx");

            entity.HasIndex(e => e.TovarsIdtovars, "fk_deliviries_tovars_idx");

            entity.Property(e => e.Iddeliviries).HasColumnName("iddeliviries");
            entity.Property(e => e.DeliviriesCena).HasColumnName("deliviriesCena");
            entity.Property(e => e.DeliviriesData)
                .HasMaxLength(45)
                .HasColumnName("deliviriesData");
            entity.Property(e => e.DeliviriesV).HasColumnName("deliviriesV");
            entity.Property(e => e.PostsIdposts).HasColumnName("posts_idposts");
            entity.Property(e => e.TovarsIdtovars).HasColumnName("tovars_idtovars");

            entity.HasOne(d => d.PostsIdpostsNavigation).WithMany(p => p.Deliviries)
                .HasForeignKey(d => d.PostsIdposts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_deliviries_posts1");

            entity.HasOne(d => d.TovarsIdtovarsNavigation).WithMany(p => p.Deliviries)
                .HasForeignKey(d => d.TovarsIdtovars)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_deliviries_tovars");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Idmanagers).HasName("PRIMARY");

            entity.ToTable("managers");

            entity.Property(e => e.Idmanagers).HasColumnName("idmanagers");
            entity.Property(e => e.ManagersFio)
                .HasMaxLength(45)
                .HasColumnName("managersFIO");
            entity.Property(e => e.ManagersOklad).HasColumnName("managersOklad");
            entity.Property(e => e.Managersprocent)
                .HasMaxLength(45)
                .HasColumnName("managersprocent");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Idposts).HasName("PRIMARY");

            entity.ToTable("posts");

            entity.Property(e => e.Idposts).HasColumnName("idposts");
            entity.Property(e => e.PostsName)
                .HasMaxLength(45)
                .HasColumnName("postsName");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Idsales).HasName("PRIMARY");

            entity.ToTable("sales");

            entity.HasIndex(e => e.ManagersIdmanagers, "fk_sales_managers1_idx");

            entity.HasIndex(e => e.TovarsIdtovars, "fk_sales_tovars1_idx");

            entity.Property(e => e.Idsales).HasColumnName("idsales");
            entity.Property(e => e.ManagersIdmanagers).HasColumnName("managers_idmanagers");
            entity.Property(e => e.SalesCena).HasColumnName("salesCena");
            entity.Property(e => e.SalesData)
                .HasMaxLength(45)
                .HasColumnName("salesData");
            entity.Property(e => e.SalesV).HasColumnName("salesV");
            entity.Property(e => e.TovarsIdtovars).HasColumnName("tovars_idtovars");

            entity.HasOne(d => d.ManagersIdmanagersNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ManagersIdmanagers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sales_managers1");

            entity.HasOne(d => d.TovarsIdtovarsNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.TovarsIdtovars)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sales_tovars1");
        });

        modelBuilder.Entity<Tovar>(entity =>
        {
            entity.HasKey(e => e.Idtovars).HasName("PRIMARY");

            entity.ToTable("tovars");

            entity.Property(e => e.Idtovars).HasColumnName("idtovars");
            entity.Property(e => e.TovarsColvo)
                .HasColumnType("blob")
                .HasColumnName("tovarsColvo");
            entity.Property(e => e.TovarsName)
                .HasMaxLength(45)
                .HasColumnName("tovarsName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
