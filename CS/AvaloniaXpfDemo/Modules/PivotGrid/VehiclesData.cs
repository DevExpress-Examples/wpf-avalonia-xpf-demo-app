#nullable disable
using System.Data;
using DevExpress.AvaloniaXpfDemo.DemoData;
using DevExpress.Data.Utils;
using DevExpress.Internal;
using Microsoft.EntityFrameworkCore;

namespace DevExpress.AvaloniaXpfDemo.PivotGridModules;

public class VehiclesData {
    public static List<OrderItem> GetMDBData() {
        return InitOrdersData(null, 10000, 3 * 365);
    }
    public class Trademark {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class BodyStyle {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class OrderItem {
        internal Model Model;
        public OrderItem(Model model, int days, NonCryptographicRandom rnd, int id) {
            Model = model;
            ModelPrice = model.Price;
            Trademark = model.Trademark;
            Name = model.Name;
            Modification = model.Modification;
            Category = model.Category;
            MPGCity = model.MPGCity;
            MPGHighway = model.MPGHighway;
            Doors = model.Doors;
            BodyStyle = model.BodyStyle.ToString();
            Cylinders = model.Cylinders;
            Horsepower = model.Horsepower;
            Torque = model.Torque;
            TransmissionSpeeds = model.TransmissionSpeeds;
            TransmissionType = model.TransmissionType;
            InStock = model.InStock;

            SalesDate = DateTime.Now.AddDays(-rnd.Next(days));
            Discount = Math.Round(0.05 * rnd.Next(4), 2);
            OrderID = id;
        }
        public int OrderID { get; set; }
        public DateTime SalesDate { get; set; }
        public double Discount { get; set; }
        public decimal ModelPrice { get; set; }
        public string Trademark { get; set; }
        public string Name { get; set; }
        public string Modification { get; set; }
        public int Category { get; set; }
        public int? MPGCity { get; set; }
        public int? MPGHighway { get; set; }
        public int Doors { get; set; }
        public string BodyStyle { get; set; }
        public int Cylinders { get; set; }
        public string Horsepower { get; set; }
        public string Torque { get; set; }
        public int TransmissionSpeeds { get; set; }
        public int TransmissionType { get; set; }
        public bool InStock { get; set; }
    }
    public class Model {
        public int ID { get; set; }
        public string Trademark { get; set; }
        public string Name { get; set; }
        public string Modification { get; set; }
        public int Category { get; set; }
        public decimal Price { get; set; }
        public int? MPGCity { get; set; }
        public int? MPGHighway { get; set; }
        public int Doors { get; set; }
        public string BodyStyle { get; set; }
        public int Cylinders { get; set; }
        public string Horsepower { get; set; }
        public string Torque { get; set; }
        public int TransmissionSpeeds { get; set; }
        public int TransmissionType { get; set; }
        public string Description { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool InStock { get; set; }
    }
    public static List<OrderItem> InitOrdersData(string connectionString, int itemCount, int dataInterval) {
        NonCryptographicRandom rnd = NonCryptographicRandom.Default;
        List<Model> listModels = InitDataCore(1);
        List<OrderItem> orders = new List<OrderItem>();
        decimal averagePrice = listModels.Select(x => x.Price).Average();
        int averageOrders = itemCount / listModels.Count;
        foreach(Model model in listModels)
            for(int i = 0; i < averageOrders * averagePrice / model.Price; i++)
                orders.Add(new OrderItem(model, dataInterval, rnd, i + 1));
        return orders;
    }
    static List<Model> InitDataCore(int dataInterval) {
        var rnd = NonCryptographicRandom.Default;
        var listModels = new List<Model>();

        var vehiclesContext = new VehiclesContext();
        vehiclesContext.Models.Load();
        vehiclesContext.BodyStyles.Load();
        vehiclesContext.Categories.Load();
        vehiclesContext.Trademarks.Load();
        vehiclesContext.TransmissionTypes.Load();

        vehiclesContext.Models.Local.ToList().ForEach(source => listModels.Add(new Model() {
            ID = (int)source.ID,
            Trademark = source.TrademarkName,
            Name = source.Name,
            Modification = source.Modification,
            Category = (int)source.CategoryID,
            Price = source.Price,
            MPGCity = source.MPGCity,
            MPGHighway = source.MPGHighway,
            Doors = source.Doors,
            BodyStyle = source.BodyStyleName,
            Cylinders = source.Cylinders,
            Horsepower = source.Horsepower,
            Torque = source.Torque,
            TransmissionSpeeds = Convert.ToInt32(source.TransmissionSpeeds),
            TransmissionType = (int)source.TransmissionTypeID,
            Description = source.Description,
            DeliveryDate = DateTime.Now.AddDays(rnd.Next(dataInterval)),
            InStock = rnd.Next(100) < 95
        }));
        return listModels;
    }
}