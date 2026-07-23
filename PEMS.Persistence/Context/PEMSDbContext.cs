using Microsoft.EntityFrameworkCore;
using PEMS.Domain.Entities;

namespace PEMS.Persistence.Context;

public class PEMSDbContext : DbContext
{
    public PEMSDbContext(DbContextOptions<PEMSDbContext> options)
        : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EngineeringDocument> EngineeringDocuments { get; set; }
    public DbSet<DocumentAttachment> DocumentAttachments { get; set; }
    public DbSet<DocumentRevision> DocumentRevisions { get; set; }
    public DbSet<DocumentWorkflow> DocumentWorkflows { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<EquipmentTag> EquipmentTags { get; set; }
    public DbSet<Instrument> Instruments { get; set; }
    public DbSet<IOPoint> IOPoints { get; set; }
    public DbSet<EquipmentDatasheet> EquipmentDatasheets { get; set; }
    public DbSet<ControlLoop> ControlLoops { get; set; }
    public DbSet<Alarm> Alarms { get; set; }
    public DbSet<CauseEffect> CauseEffects { get; set; }
    public DbSet<ElectricalEquipment> ElectricalEquipments { get; set; }
    public DbSet<Cable> Cables { get; set; }
    public DbSet<Panel> Panels { get; set; }
    public DbSet<CableConnection> CableConnections { get; set; }
    public DbSet<MechanicalEquipment> MechanicalEquipments { get; set; }
    public DbSet<RotatingEquipment> RotatingEquipments { get; set; }
    public DbSet<StaticEquipment> StaticEquipments { get; set; }
    public DbSet<PipingLine> PipingLines { get; set; }
    public DbSet<Valve> Valves { get; set; }
    public DbSet<PipingComponent> PipingComponents { get; set; }
    public DbSet<PipeSpecification> PipeSpecifications { get; set; }
    public DbSet<EquipmentNozzle> EquipmentNozzles { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<FunctionalLocation> FunctionalLocations { get; set; }
    public DbSet<EquipmentCriticality> EquipmentCriticalities { get; set; }
    public DbSet<MaintenanceStrategy> MaintenanceStrategies { get; set; }
    public DbSet<MaintenancePlan> MaintenancePlans { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }
    public DbSet<MaintenanceHistory> MaintenanceHistories { get; set; }
    public DbSet<SparePart> SpareParts { get; set; }
    public DbSet<MaintenanceSpareUsage> MaintenanceSpareUsages { get; set; }
    public DbSet<FailureRecord> FailureRecords { get; set; }
    public DbSet<InspectionRecord> InspectionRecords { get; set; }
    public DbSet<InspectionChecklist> InspectionChecklists { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<FunctionalLocation>()
    .HasOne(x => x.Parent)
    .WithMany(x => x.Children)
    .HasForeignKey(x => x.ParentId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MaintenancePlan>()
    .HasOne(x => x.MaintenanceStrategy)
    .WithMany()
    .HasForeignKey(x => x.MaintenanceStrategyId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<WorkOrder>()
    .HasOne(x => x.MaintenancePlan)
    .WithMany()
    .HasForeignKey(x => x.MaintenancePlanId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MaintenanceHistory>()
    .HasOne(x => x.WorkOrder)
    .WithMany()
    .HasForeignKey(x => x.WorkOrderId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MaintenanceSpareUsage>()
    .HasOne(x => x.WorkOrder)
    .WithMany()
    .HasForeignKey(x => x.WorkOrderId)
    .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<MaintenanceSpareUsage>()
            .HasOne(x => x.SparePart)
            .WithMany()
            .HasForeignKey(x => x.SparePartId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<FailureRecord>()
    .HasOne(x => x.WorkOrder)
    .WithMany()
    .HasForeignKey(x => x.WorkOrderId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<InspectionChecklist>()
    .HasOne(x => x.InspectionRecord)
    .WithMany()
    .HasForeignKey(x => x.InspectionRecordId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DocumentAttachment>()
       .HasOne(x => x.Document)
       .WithMany(x => x.Attachments)
       .HasForeignKey(x => x.DocumentId)
       .OnDelete(DeleteBehavior.Restrict);
    }
   
   
}