using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ah4cClientApp.Models;

public partial class Ah4cContext : DbContext
{
    public Ah4cContext()
    {
    }

    public Ah4cContext(DbContextOptions<Ah4cContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Animalbreed> Animalbreeds { get; set; }

    public virtual DbSet<Animaltype> Animaltypes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roomstatus> Roomstatuses { get; set; }

    public virtual DbSet<Roomtype> Roomtypes { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Servicecategory> Servicecategories { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    public virtual DbSet<Workerpost> Workerposts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=ah4c", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PRIMARY");

            entity.ToTable("animals");

            entity.HasIndex(e => e.AnimalBreedid, "breedid_idx");

            entity.HasIndex(e => e.AnimalClientid, "clientid_idx");

            entity.Property(e => e.AnimalId)
                .ValueGeneratedNever()
                .HasColumnName("animal_id");
            entity.Property(e => e.AnimalBreedid).HasColumnName("animal_breedid");
            entity.Property(e => e.AnimalClientid).HasColumnName("animal_clientid");
            entity.Property(e => e.AnimalGen)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("animal_gen");
            entity.Property(e => e.AnimalHeight).HasColumnName("animal_height");
            entity.Property(e => e.AnimalName)
                .HasMaxLength(45)
                .HasColumnName("animal_name");
            entity.Property(e => e.AnimalOld).HasColumnName("animal_old");
            entity.Property(e => e.AnimalWeight).HasColumnName("animal_weight");

            entity.HasOne(d => d.AnimalBreed).WithMany(p => p.Animals)
                .HasForeignKey(d => d.AnimalBreedid)
                .HasConstraintName("breedid");

            entity.HasOne(d => d.AnimalClient).WithMany(p => p.Animals)
                .HasForeignKey(d => d.AnimalClientid)
                .HasConstraintName("clientid");
        });

        modelBuilder.Entity<Animalbreed>(entity =>
        {
            entity.HasKey(e => e.AnimalbreedId).HasName("PRIMARY");

            entity.ToTable("animalbreeds");

            entity.HasIndex(e => e.AnimalTypeid, "typeid_idx");

            entity.Property(e => e.AnimalbreedId)
                .ValueGeneratedNever()
                .HasColumnName("animalbreed_id");
            entity.Property(e => e.AnimalTypeid).HasColumnName("animal_typeid");
            entity.Property(e => e.AnimalbreedName)
                .HasMaxLength(45)
                .HasColumnName("animalbreed_name");

            entity.HasOne(d => d.AnimalType).WithMany(p => p.Animalbreeds)
                .HasForeignKey(d => d.AnimalTypeid)
                .HasConstraintName("typeid");
        });

        modelBuilder.Entity<Animaltype>(entity =>
        {
            entity.HasKey(e => e.AnimaltypeId).HasName("PRIMARY");

            entity.ToTable("animaltypes");

            entity.Property(e => e.AnimaltypeId)
                .ValueGeneratedNever()
                .HasColumnName("animaltype_id");
            entity.Property(e => e.AnimaltypeName)
                .HasMaxLength(45)
                .HasColumnName("animaltype_name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("client_id");
            entity.Property(e => e.ClientEmail)
                .HasMaxLength(45)
                .HasColumnName("client_email");
            entity.Property(e => e.ClientImage)
                .HasColumnType("text")
                .HasColumnName("client_image");
            entity.Property(e => e.ClientLogin)
                .HasMaxLength(45)
                .HasColumnName("client_login");
            entity.Property(e => e.ClientName)
                .HasMaxLength(45)
                .HasColumnName("client_name");
            entity.Property(e => e.ClientPassword)
                .HasMaxLength(45)
                .HasColumnName("client_password");
            entity.Property(e => e.ClientPhone)
                .HasPrecision(11)
                .HasColumnName("client_phone");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderNoteid).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.AnimalId, "animal_id_idx");

            entity.HasIndex(e => e.ClientId, "client_id_idx");

            entity.HasIndex(e => e.OrderNoteid, "order_noteid_UNIQUE").IsUnique();

            entity.HasIndex(e => e.OrderStatusid, "orderstatus_id_idx");

            entity.HasIndex(e => e.RoomId, "room_id_idx");

            entity.HasIndex(e => e.ServiceId, "service_id_idx");

            entity.HasIndex(e => e.WorkerId, "worker_id_idx");

            entity.Property(e => e.OrderNoteid)
                .ValueGeneratedNever()
                .HasColumnName("order_noteid");
            entity.Property(e => e.AdmissionDate).HasColumnName("admission_date");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderStatusid).HasColumnName("order_statusid");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");
            entity.Property(e => e.WorkerId).HasColumnName("worker_id");

            entity.HasOne(d => d.Animal).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("animal_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_id");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusid)
                .HasConstraintName("orderstatus_id");

            entity.HasOne(d => d.Room).WithMany(p => p.Orders)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("room_id");

            entity.HasOne(d => d.Service).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("service_id");

            entity.HasOne(d => d.Worker).WithMany(p => p.Orders)
                .HasForeignKey(d => d.WorkerId)
                .HasConstraintName("worker_id");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderstatusId).HasName("PRIMARY");

            entity.ToTable("order_status");

            entity.Property(e => e.OrderstatusId)
                .ValueGeneratedNever()
                .HasColumnName("orderstatus_id");
            entity.Property(e => e.OrderstatusName)
                .HasMaxLength(45)
                .HasColumnName("orderstatus_name");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PRIMARY");

            entity.ToTable("rooms");

            entity.HasIndex(e => e.RoomStatusid, "roomstatusid_idx");

            entity.HasIndex(e => e.RoomTypeid, "roomtypeid_idx");

            entity.Property(e => e.RoomId)
                .ValueGeneratedNever()
                .HasColumnName("room_id");
            entity.Property(e => e.RoomDescription)
                .HasColumnType("text")
                .HasColumnName("room_description");
            entity.Property(e => e.RoomImage)
                .HasColumnType("text")
                .HasColumnName("room_image");
            entity.Property(e => e.RoomNumber).HasColumnName("room_number");
            entity.Property(e => e.RoomStatusid).HasColumnName("room_statusid");
            entity.Property(e => e.RoomTypeid).HasColumnName("room_typeid");

            entity.HasOne(d => d.RoomStatus).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomStatusid)
                .HasConstraintName("roomstatusid");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeid)
                .HasConstraintName("roomtypeid");
        });

        modelBuilder.Entity<Roomstatus>(entity =>
        {
            entity.HasKey(e => e.RoomstatusId).HasName("PRIMARY");

            entity.ToTable("roomstatuses");

            entity.Property(e => e.RoomstatusId)
                .ValueGeneratedNever()
                .HasColumnName("roomstatus_id");
            entity.Property(e => e.RoomstatusName)
                .HasMaxLength(45)
                .HasColumnName("roomstatus_name");
        });

        modelBuilder.Entity<Roomtype>(entity =>
        {
            entity.HasKey(e => e.RoomtypeId).HasName("PRIMARY");

            entity.ToTable("roomtypes");

            entity.Property(e => e.RoomtypeId)
                .ValueGeneratedNever()
                .HasColumnName("roomtype_id");
            entity.Property(e => e.RoomtypeDescription)
                .HasColumnType("text")
                .HasColumnName("roomtype_description");
            entity.Property(e => e.RoomtypeName)
                .HasMaxLength(45)
                .HasColumnName("roomtype_name");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PRIMARY");

            entity.ToTable("services");

            entity.HasIndex(e => e.ServiceCategid, "categid_idx");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("service_id");
            entity.Property(e => e.ServiceCategid).HasColumnName("service_categid");
            entity.Property(e => e.ServiceDescription)
                .HasMaxLength(200)
                .HasColumnName("service_description");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(45)
                .HasColumnName("service_name");
            entity.Property(e => e.ServicePrice).HasColumnName("service_price");

            entity.HasOne(d => d.ServiceCateg).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServiceCategid)
                .HasConstraintName("categid");
        });

        modelBuilder.Entity<Servicecategory>(entity =>
        {
            entity.HasKey(e => e.ServicecategoryId).HasName("PRIMARY");

            entity.ToTable("servicecategories");

            entity.Property(e => e.ServicecategoryId)
                .ValueGeneratedNever()
                .HasColumnName("servicecategory_id");
            entity.Property(e => e.ServicecategoryName)
                .HasMaxLength(45)
                .HasColumnName("servicecategory_name");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.WorkerId).HasName("PRIMARY");

            entity.ToTable("workers");

            entity.HasIndex(e => e.WorkerPostid, "postid_idx");

            entity.Property(e => e.WorkerId)
                .ValueGeneratedNever()
                .HasColumnName("worker_id");
            entity.Property(e => e.WorkerEmail)
                .HasMaxLength(45)
                .HasColumnName("worker_email");
            entity.Property(e => e.WorkerImage)
                .HasColumnType("text")
                .HasColumnName("worker_image");
            entity.Property(e => e.WorkerLogin)
                .HasMaxLength(45)
                .HasColumnName("worker_login");
            entity.Property(e => e.WorkerName)
                .HasMaxLength(45)
                .HasColumnName("worker_name");
            entity.Property(e => e.WorkerPassword)
                .HasMaxLength(45)
                .HasColumnName("worker_password");
            entity.Property(e => e.WorkerPhone)
                .HasPrecision(11)
                .HasColumnName("worker_phone");
            entity.Property(e => e.WorkerPostid).HasColumnName("worker_postid");

            entity.HasOne(d => d.WorkerPost).WithMany(p => p.Workers)
                .HasForeignKey(d => d.WorkerPostid)
                .HasConstraintName("postid");
        });

        modelBuilder.Entity<Workerpost>(entity =>
        {
            entity.HasKey(e => e.WorkerpostId).HasName("PRIMARY");

            entity.ToTable("workerposts");

            entity.Property(e => e.WorkerpostId)
                .ValueGeneratedNever()
                .HasColumnName("workerpost_id");
            entity.Property(e => e.WorkerpostName)
                .HasMaxLength(45)
                .HasColumnName("workerpost_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
