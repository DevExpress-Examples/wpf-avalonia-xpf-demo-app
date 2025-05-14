#nullable disable
using System.IO;
using DevExpress.AvaloniaXpfDemo.DemoData.Vehicles;
using Microsoft.EntityFrameworkCore;
using DbModelBuilder = Microsoft.EntityFrameworkCore.ModelBuilder;

namespace DevExpress.AvaloniaXpfDemo.DemoData {
    public partial class VehiclesContext : DbContext {
        public VehiclesContext() : base() {
            SetFilePath();
            connectionString = string.Format("Data Source={0}", filePath);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseLazyLoadingProxies().UseSqlite(connectionString);
        }
        string connectionString;
        public static Task Preload() {
            return DbContextPreloader<VehiclesContext>.Preload();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Model>()
                .ToTable("Model");
            modelBuilder.Entity<BodyStyle>()
                .ToTable("BodyStyle");
            modelBuilder.Entity<Category>()
                .ToTable("Category");
            modelBuilder.Entity<Trademark>()
                .ToTable("Trademark");
            modelBuilder.Entity<TransmissionType>()
                .ToTable("TransmissionType");
            modelBuilder.Entity<Model>()
                .Property(x => x.MPGCity)
                .HasColumnName("MPG City");
            modelBuilder.Entity<Model>()
                .Property(x => x.MPGHighway)
                .HasColumnName("MPG Highway");
            modelBuilder.Entity<Model>()
                .Property(x => x.TransmissionSpeeds)
                .HasColumnName("Transmission Speeds");
            modelBuilder.Entity<Model>()
                .Property(x => x.TransmissionTypeID)
                .HasColumnName("Transmission Type");
            modelBuilder.Entity<Model>()
                .Property(x => x.DeliveryDate)
                .HasColumnName("Delivery Date");
            modelBuilder.Entity<Model>()
                .Property(x => x.LicenseName)
                .HasColumnName("License Name");
        }

        static string filePath;
        static void SetFilePath() {
            if(filePath == null) {
                filePath = DataProvider.VehiclesDBPath;
            }
            try {
                var attributes = File.GetAttributes(filePath);
                if(attributes.HasFlag(FileAttributes.ReadOnly)) {
                    File.SetAttributes(filePath, attributes & ~FileAttributes.ReadOnly);
                }
            }
            catch { }
        }
        public DbSet<Model> Models { get; set; }
        public DbSet<BodyStyle> BodyStyles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Trademark> Trademarks { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
    }

    public class VehiclesData {
        VehiclesContext context = new VehiclesContext();
        IEnumerable<Model> models;
        public IEnumerable<Model> Models {
            get {
                if(models == null) {
                    var list = new List<Model>();
                    models = list;
                    context.Models.Load();
                    context.Trademarks.Load();
                    list.AddRange(context.Models.Local);
                }
                return models;
            }
        }
    }
}

namespace DevExpress.AvaloniaXpfDemo.DemoData.Vehicles {
    public class Model {
        public long ID { get; set; }
        public long TrademarkID { get; set; }
        public string Name { get; set; }
        public string Modification { get; set; }
        public long CategoryID { get; set; }
        public decimal Price { get; set; }
        public int? MPGCity { get; set; }
        public int? MPGHighway { get; set; }
        public int Doors { get; set; }
        public long BodyStyleID { get; set; }
        public int Cylinders { get; set; }
        public string Horsepower { get; set; }
        public string Torque { get; set; }
        public string TransmissionSpeeds { get; set; }
        public long TransmissionTypeID { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool InStock { get; set; }
        public string LicenseName { get; set; }
        public string Author { get; set; }
        public string Source { get; set; }
        public string Edits { get; set; }

        public string TrademarkName { get { return Trademark.Name; } }
        public string CategoryName { get { return Category.Name; } }
        public string BodyStyleName { get { return BodyStyle.Name; } }
        public string TransmissionTypeName { get { return TransmissionType.Name; } }

        public virtual Trademark Trademark { get; set; }
        public virtual Category Category { get; set; }
        public virtual BodyStyle BodyStyle { get; set; }
        public virtual TransmissionType TransmissionType { get; set; }
    }

    public class BodyStyle {
        public long ID { get; set; }
        public string Name { get; set; }
    }

    public class Category {
        public long ID { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
    }

    public class Trademark {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Site { get; set; }
        public byte[] Logo { get; set; }
        public string Description { get; set; }
    }

    public class TransmissionType {
        public long ID { get; set; }
        public string Name { get; set; }
    }
}