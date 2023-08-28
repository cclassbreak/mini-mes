using Microsoft.EntityFrameworkCore;
using mini_mes.Model;

public class MyDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerOrder> CustomerOrders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Part> Parts { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<ProcessFlow> ProcessFlows { get; set; }
    public DbSet<ProcessStep> ProcessSteps { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=YourDatabaseFileName.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerOrder>()
            .HasOne(co => co.Customer)
            .WithMany(c => c.CustomerOrders)
            .HasForeignKey(co => co.CustomerID);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.CustomerOrder)
            .WithMany(co => co.OrderItems)
            .HasForeignKey(oi => oi.CustomerOrderID);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductID);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Part)
            .WithMany(pt => pt.Products)
            .HasForeignKey(p => p.PartID);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.ProcessFlow)
            .WithMany(pf => pf.Products)
            .HasForeignKey(p => p.ProcessFlowID);

        modelBuilder.Entity<Part>()
            .HasOne(pt => pt.Customer)
            .WithMany(c => c.Parts)
            .HasForeignKey(pt => pt.CustomerID);

        modelBuilder.Entity<WorkOrder>()
            .HasOne(wo => wo.OrderItem)
            .WithMany(oi => oi.WorkOrders)
            .HasForeignKey(wo => wo.OrderItemID);

        modelBuilder.Entity<ProcessStep>()
            .HasOne(ps => ps.Station)
            .WithMany(s => s.ProcessSteps)
            .HasForeignKey(ps => ps.StationID);

        modelBuilder.Entity<ProcessStep>()
            .HasOne(ps => ps.ProcessFlow)
            .WithMany(pf => pf.ProcessSteps)
            .HasForeignKey(ps => ps.ProcessFlowID);

        modelBuilder.Entity<Customer>()
        .HasIndex(c => c.CustomerNumber)
        .IsUnique();

        modelBuilder.Entity<CustomerOrder>()
        .HasIndex(co => co.CustomerOrderNumber)
        .IsUnique();

        modelBuilder.Entity<ProcessFlow>()
        .HasIndex(pf => pf.ProcessFlowNumber)
        .IsUnique();

        modelBuilder.Entity<Part>()
        .HasIndex(p => p.PartNumber)
        .IsUnique();

        modelBuilder.Entity<WorkOrder>()
        .HasIndex(wo => wo.WorkOrderNumber)
        .IsUnique();

        modelBuilder.Entity<WorkOrder>()
        .HasIndex(wo => wo.WorkOrderNumber)
        .IsUnique();

    }

}
