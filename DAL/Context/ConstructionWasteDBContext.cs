using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public partial class ConstructionWasteDBContext : IdentityDbContext<AppUser>
    {
        public ConstructionWasteDBContext(DbContextOptions options)
            :base(options)
        {
        }

        //public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<AuthToken> AuthTokens { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarDriver> CarDrivers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientType> ClientTypes { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractType> ContractTypes { get; set; }
        public virtual DbSet<Excel> Excels { get; set; }
        public virtual DbSet<ExecutionAct> ExecutionActs { get; set; }
        public virtual DbSet<PolygonType> PolygonTypes { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<AuthToken>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("auth_token");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Val)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("val");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("car");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MarkName)
                    .HasMaxLength(200)
                    .HasColumnName("markName");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("number");

                entity.Property(e => e.Number1)
                    .HasMaxLength(50)
                    .HasColumnName("number_1");

                entity.Property(e => e.Number2)
                    .HasMaxLength(50)
                    .HasColumnName("number_2");
            });

            modelBuilder.Entity<CarDriver>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("car_driver");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(200)
                    .HasColumnName("fullname");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LegalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("legal_id");
            });

            modelBuilder.Entity<Client>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("client");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdentityCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("identity_code");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insert_time");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.Representative)
                    .HasMaxLength(200)
                    .HasColumnName("representative");

                entity.Property(e => e.TypeId).HasColumnName("type_id");
            });

            modelBuilder.Entity<ClientType>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("client_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("contract");

                entity.Property(e => e.DeletedFlag).HasColumnName("deleted_flag");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdentityCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("identity_code");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insert_time");

                entity.Property(e => e.IsPaid).HasColumnName("is_paid");

                entity.Property(e => e.IsSpecific).HasColumnName("is_specific");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("number");

                entity.Property(e => e.PolygonTypeId).HasColumnName("polygon_type_id");

                entity.Property(e => e.Price)
                    .HasMaxLength(50)
                    .HasColumnName("price");

                entity.Property(e => e.Representative)
                    .HasMaxLength(100)
                    .HasColumnName("representative");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("contract_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Excel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("excel");

                entity.Property(e => e.F2).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Number1)
                    .HasMaxLength(255)
                    .HasColumnName("number_1");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.Property(e => e._)
                    .HasMaxLength(255)
                    .HasColumnName("#");
            });

            modelBuilder.Entity<ExecutionAct>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("execution_act");

                entity.Property(e => e.ApprovedStatus).HasColumnName("approvedStatus");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedFlag).HasColumnName("deleted_flag");

                entity.Property(e => e.DriverId).HasColumnName("driver_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("price");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(50)
                    .HasColumnName("projectCode");

                entity.Property(e => e.Receiver)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("receiver");

                entity.Property(e => e.Representative)
                    .HasMaxLength(200)
                    .HasColumnName("representative");

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("weight");
            });

            modelBuilder.Entity<PolygonType>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("polygon_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Result>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("result");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Sysdiagram>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sysdiagrams");

                entity.Property(e => e.Definition).HasColumnName("definition");

                entity.Property(e => e.DiagramId).HasColumnName("diagram_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name");

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("transaction");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ContractNumber)
                    .HasMaxLength(50)
                    .HasColumnName("contract_number");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Executed).HasColumnName("executed");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdentityCode)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("identity_code");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insert_time");

                entity.Property(e => e.PayId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("pay_id");

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("transaction_id");
            });

            
        }

    }
}
