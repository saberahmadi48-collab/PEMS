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



    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added)
            {
                var property = entry.Entity
                    .GetType()
                    .GetProperty("CreatedDate");

                if (property != null)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }
            }
        }

        return base.SaveChanges();
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // ==============================
        // Functional Location
        // ==============================

        modelBuilder.Entity<FunctionalLocation>()
            .HasOne(x => x.Parent)
            .WithMany(x => x.Children)
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.Restrict);



        // ==============================
        // Maintenance Relations
        // ==============================

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

        // ==============================
        // Engineering Documents
        // ==============================


        modelBuilder.Entity<EngineeringDocument>()
            .HasOne(x => x.Project)
            .WithMany(x => x.EngineeringDocuments)
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);



        modelBuilder.Entity<EngineeringDocument>()
            .HasOne(x => x.Discipline)
            .WithMany(x => x.EngineeringDocuments)
            .HasForeignKey(x => x.DisciplineId)
            .OnDelete(DeleteBehavior.Restrict);



        modelBuilder.Entity<DocumentAttachment>()
            .HasOne(x => x.Document)
            .WithMany(x => x.Attachments)
            .HasForeignKey(x => x.DocumentId)
            .OnDelete(DeleteBehavior.Restrict);


        // EngineeringDocument - Revision

        modelBuilder.Entity<DocumentRevision>()
            .HasOne(x => x.Document)
            .WithMany(x => x.Revisions)
            .HasForeignKey(x => x.DocumentId)
            .OnDelete(DeleteBehavior.Restrict);



        // EngineeringDocument - Workflow

        modelBuilder.Entity<DocumentWorkflow>()
            .HasOne(x => x.Document)
            .WithMany(x => x.Workflows)
            .HasForeignKey(x => x.DocumentId)
            .OnDelete(DeleteBehavior.Restrict);




        // ==============================
        // Decimal Precision
        // ==============================


        modelBuilder.Entity<Alarm>()
            .Property(x => x.SetPoint)
            .HasPrecision(18, 3);



        modelBuilder.Entity<Cable>()
            .Property(x => x.Length)
            .HasPrecision(18, 3);



        modelBuilder.Entity<ElectricalEquipment>()
            .Property(x => x.PowerKW)
            .HasPrecision(18, 3);


        modelBuilder.Entity<ElectricalEquipment>()
            .Property(x => x.RatedCurrent)
            .HasPrecision(18, 3);


        modelBuilder.Entity<ElectricalEquipment>()
            .Property(x => x.Voltage)
            .HasPrecision(18, 3);



        modelBuilder.Entity<EquipmentDatasheet>()
            .Property(x => x.DesignPressure)
            .HasPrecision(18, 3);


        modelBuilder.Entity<EquipmentDatasheet>()
            .Property(x => x.DesignTemperature)
            .HasPrecision(18, 3);


        modelBuilder.Entity<EquipmentDatasheet>()
            .Property(x => x.OperatingPressure)
            .HasPrecision(18, 3);


        modelBuilder.Entity<EquipmentDatasheet>()
            .Property(x => x.OperatingTemperature)
            .HasPrecision(18, 3);




        modelBuilder.Entity<FailureRecord>()
            .Property(x => x.DowntimeHours)
            .HasPrecision(18, 3);




        modelBuilder.Entity<Instrument>()
            .Property(x => x.RangeMin)
            .HasPrecision(18, 3);


        modelBuilder.Entity<Instrument>()
            .Property(x => x.RangeMax)
            .HasPrecision(18, 3);




        modelBuilder.Entity<MaintenanceHistory>()
            .Property(x => x.Cost)
            .HasPrecision(18, 2);


        modelBuilder.Entity<MaintenanceHistory>()
            .Property(x => x.DurationHours)
            .HasPrecision(18, 3);




        modelBuilder.Entity<MaintenanceSpareUsage>()
            .Property(x => x.Quantity)
            .HasPrecision(18, 3);


        modelBuilder.Entity<MaintenanceSpareUsage>()
            .Property(x => x.UnitCost)
            .HasPrecision(18, 2);


        modelBuilder.Entity<MaintenanceSpareUsage>()
            .Property(x => x.TotalCost)
            .HasPrecision(18, 2);




        // ==============================
        // Mechanical Equipment
        // ==============================


        modelBuilder.Entity<MechanicalEquipment>()
            .Property(x => x.DesignPressure)
            .HasPrecision(18, 3);


        modelBuilder.Entity<MechanicalEquipment>()
            .Property(x => x.DesignTemperature)
            .HasPrecision(18, 3);


        modelBuilder.Entity<MechanicalEquipment>()
            .Property(x => x.OperatingPressure)
            .HasPrecision(18, 3);


        modelBuilder.Entity<MechanicalEquipment>()
            .Property(x => x.OperatingTemperature)
            .HasPrecision(18, 3);




        // ==============================
        // Rotating Equipment
        // ==============================


        modelBuilder.Entity<RotatingEquipment>()
            .Property(x => x.FlowRate)
            .HasPrecision(18, 3);


        modelBuilder.Entity<RotatingEquipment>()
            .Property(x => x.Head)
            .HasPrecision(18, 3);


        modelBuilder.Entity<RotatingEquipment>()
            .Property(x => x.PowerKW)
            .HasPrecision(18, 3);




        // ==============================
        // Static Equipment
        // ==============================


        modelBuilder.Entity<StaticEquipment>()
            .Property(x => x.DesignPressure)
            .HasPrecision(18, 3);


        modelBuilder.Entity<StaticEquipment>()
            .Property(x => x.DesignTemperature)
            .HasPrecision(18, 3);


        modelBuilder.Entity<StaticEquipment>()
            .Property(x => x.Volume)
            .HasPrecision(18, 3);




        // ==============================
        // Piping
        // ==============================


        modelBuilder.Entity<PipingLine>()
            .Property(x => x.DesignPressure)
            .HasPrecision(18, 3);


        modelBuilder.Entity<PipingLine>()
            .Property(x => x.DesignTemperature)
            .HasPrecision(18, 3);



        modelBuilder.Entity<PipeSpecification>()
            .Property(x => x.DesignPressure)
            .HasPrecision(18, 3);


        modelBuilder.Entity<PipeSpecification>()
            .Property(x => x.DesignTemperature)
            .HasPrecision(18, 3);


        // ==============================
        // Seed Master Data
        // ==============================


        modelBuilder.Entity<Discipline>().HasData(

            new Discipline
            {
                DisciplineId = 1,
                Code = "PROC",
                Name = "Process",
                Description = "Process Engineering",
                IsActive = true,
                CreatedDate = new DateTime(2026, 1, 1)
            },


            new Discipline
            {
                DisciplineId = 2,
                Code = "MECH",
                Name = "Mechanical",
                Description = "Mechanical Engineering",
                IsActive = true,
                CreatedDate = new DateTime(2026, 1, 1)
            },


            new Discipline
            {
                DisciplineId = 3,
                Code = "ELEC",
                Name = "Electrical",
                Description = "Electrical Engineering",
                IsActive = true,
                CreatedDate = new DateTime(2026, 1, 1)
            },


            new Discipline
            {
                DisciplineId = 4,
                Code = "INST",
                Name = "Instrumentation",
                Description = "Instrumentation and Control Engineering",
                IsActive = true,
                CreatedDate = new DateTime(2026, 1, 1)
            },


            new Discipline
            {
                DisciplineId = 5,
                Code = "PIPE",
                Name = "Piping",
                Description = "Piping Engineering",
                IsActive = true,
                CreatedDate = new DateTime(2026, 1, 1)
            },


            new Discipline
            {
                DisciplineId = 6,
                Code = "CIVL",
                Name = "Civil",
                Description = "Civil Engineering",
                IsActive = true,
                CreatedDate = new DateTime(2026, 1, 1)
            }

        );



        modelBuilder.Entity<Project>().HasData(

            new Project
            {
                ProjectId = 1,
                ProjectCode = "PEMS-001",
                ProjectName = "Polymer Plant Development",
                ClientName = "Petrochemical",
                Location = "Assaluyeh",
                Status = "Active",
                IsActive = true,
                CreatedDate = new DateTime(2026, 1, 1)
            }

        );

    }

}