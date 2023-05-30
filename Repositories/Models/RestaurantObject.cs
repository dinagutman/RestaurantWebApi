using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repositories.Models
{
    public partial class RestaurantObject : DbContext
    {
        public RestaurantObject()
        {
        }

        public RestaurantObject(DbContextOptions<RestaurantObject> options)
            : base(options)
        {
        }

        public virtual DbSet<CallsToTheWaiter> CallsToTheWaiter { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Employment> Employment { get; set; }
        public virtual DbSet<MealCategory> MealCategory { get; set; }
        public virtual DbSet<MealIngredientsDetails> MealIngredientsDetails { get; set; }
        public virtual DbSet<Meals> Meals { get; set; }
        public virtual DbSet<MealStyle> MealStyle { get; set; }
        public virtual DbSet<MealTime> MealTime { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<RestaurantTables> RestaurantTables { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TablesForWaiter> TablesForWaiter { get; set; }
        public virtual DbSet<TableStatus> TableStatus { get; set; }
        public virtual DbSet<WorkingHours> WorkingHours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=H:\\RestaurantProject\\RestaurantWebApi\\DATA\\Restaurant.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CallsToTheWaiter>(entity =>
            {
                entity.HasKey(e => e.CallCode);

                entity.HasOne(d => d.RestaurantTableCodeNavigation)
                    .WithMany(p => p.CallsToTheWaiter)
                    .HasForeignKey(d => d.RestaurantTableCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CallsToTheWaiter__RestaurantTables");
            });


            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeCode);

                entity.Property(e => e.BaseSalary).HasColumnType("money");

                entity.Property(e => e.EmployeeFirstName).HasMaxLength(40);

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.EmployeeLastName).HasMaxLength(40);

                entity.Property(e => e.SalaryTip).HasColumnType("money");

                entity.Property(e => e.StartingDate).HasColumnType("datetime");

                entity.HasOne(d => d.EmploymentCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmploymentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__Emplo__09A971A2");
                            


                entity.HasOne(d => d.RoleCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleCode)
                    .HasConstraintName("FK__Employees__RoleC__08B54D69");
            });

            modelBuilder.Entity<Employment>(entity =>
            {
                entity.HasKey(e => e.EmploymentCode);

                entity.Property(e => e.EmploymentName).HasMaxLength(40);
            });

            modelBuilder.Entity<MealCategory>(entity =>
            {
                entity.HasKey(e => e.MealCategoryCode);

                entity.Property(e => e.MealCategoryName).HasMaxLength(40);
            });

            modelBuilder.Entity<MealIngredientsDetails>(entity =>
            {
                entity.HasKey(e => e.MealCode);

                entity.Property(e => e.MealCode).ValueGeneratedOnAdd();

                entity.Property(e => e.MealIngredientsDescription).HasMaxLength(60);

                entity.HasOne(d => d.MealCodeNavigation)
                    .WithOne(p => p.MealIngredientsDetails)
                    .HasForeignKey<MealIngredientsDetails>(d => d.MealCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MealIngre__MealC__25518C17");
            });

            modelBuilder.Entity<Meals>(entity =>
            {
                entity.HasKey(e => e.MealCode);

                entity.Property(e => e.MealName).HasMaxLength(60);

                entity.Property(e => e.MealPrice).HasColumnType("money");

                entity.Property(e => e.MealSalePrice).HasColumnType("money");

                entity.HasOne(d => d.MealCategoryCodeNavigation)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.MealCategoryCode)
                    .HasConstraintName("FK_Meals_MealCategory");

                entity.HasOne(d => d.MealStyleCodeNavigation)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.MealStyleCode)
                    .HasConstraintName("FK_Meals_MealStyle");

                entity.HasOne(d => d.MealTimeCodeNavigation)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.MealTimeCode)
                    .HasConstraintName("FK_Meals_MealTime");
            });

            modelBuilder.Entity<MealStyle>(entity =>
            {
                entity.HasKey(e => e.MealStyleCode);

                entity.Property(e => e.MealStyleDescription).HasMaxLength(40);
            });

            modelBuilder.Entity<MealTime>(entity =>
            {
                entity.HasKey(e => e.MealTimeCode);

                entity.Property(e => e.MealTimeDescription).HasMaxLength(40);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderCode, e.MealCode });

                entity.Property(e => e.HowMuchMealCreated).HasDefaultValueSql("((0))");

                entity.Property(e => e.ServingAmount)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MealCodeNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.MealCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderDetails_Meals");

                entity.HasOne(d => d.OrderCodeNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderDetails_Orders");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderCode);

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.Totalpayment).HasColumnType("money");

                entity.HasOne(d => d.EmployeeCodeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Orders__Employee__17F790F9");

                entity.HasOne(d => d.RestaurantTableCodeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RestaurantTableCode)
                    .HasConstraintName("FK__Orders__Restaura__17036CC0");
            });

            modelBuilder.Entity<RestaurantTables>(entity =>
            {
                entity.HasKey(e => e.RestaurantTableCode);

                entity.HasOne(d => d.TableStatusCodeNavigation)
                    .WithMany(p => p.RestaurantTables)
                    .HasForeignKey(d => d.TableStatusCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantTables_TableStatus");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleCode);

                entity.Property(e => e.RoleName).HasMaxLength(40);
            });

            modelBuilder.Entity<TablesForWaiter>(entity =>
            {
                entity.HasKey(e => new { e.RestaurantTableCode, e.WaiterCode });

                entity.HasOne(d => d.RestaurantTableCodeNavigation)
                    .WithMany(p => p.TablesForWaiter)
                    .HasForeignKey(d => d.RestaurantTableCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TablesFor__Resta__1332DBDC");

                entity.HasOne(d => d.WaiterCodeNavigation)
                    .WithMany(p => p.TablesForWaiter)
                    .HasForeignKey(d => d.WaiterCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TablesFor__Waite__14270015");
            });

            modelBuilder.Entity<TableStatus>(entity =>
            {
                entity.HasKey(e => e.StatusCode);

                entity.Property(e => e.StatusDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkingHours>(entity =>
            {
                entity.HasKey(e => e.WorkingHoursCode);

                entity.Property(e => e.EmployeeFirstName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.EmployeeLastName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.EnterTime)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ExitTime)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.TotalHoursForDay)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.WorkingDate).HasColumnType("date");

                entity.HasOne(d => d.EmployeeCodeNavigation)
                    .WithMany(p => p.WorkingHours)
                    .HasForeignKey(d => d.EmployeeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkingHours");
            });
        }
    }
}
