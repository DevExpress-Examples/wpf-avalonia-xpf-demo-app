#nullable disable
using DevExpress.Data.Utils;

namespace DevExpress.AvaloniaXpfDemo.DemoData;

public static class OrderDataGenerator {
    static object SyncRoot = new object();
    static List<string> customerNames;
    static List<CategoryData> categoryData;
    static List<ProductData> productData;
    static List<string> vehicleOrderTrademarks;

    static List<string> ExtractCustomerNames() {
        if(customerNames == null) {
            customerNames = new List<string>();
            var customers = NWindContext.Create().Customers.ToList();
            customerNames.Capacity = customers.Count;
            foreach(var row in customers) {
                customerNames.Add(row.ContactName);
            }
        }
        return customerNames;
    }
    public static List<CategoryData> CategoryDataList {
        get {
            if(categoryData == null) {
                categoryData = new List<CategoryData>();
                var categories = NWindContext.Create().Categories.ToList();
                categoryData.Capacity = categories.Count;
                foreach(var row in categories) {
                    categoryData.Add(new CategoryData() {
                        Name = row.CategoryName,
                        Picture = row.Icon25
                    });
                }
            }
            return categoryData;
        }
    }
    public static List<ProductData> ExtractProductDataList(List<CategoryData> categoriesList) {
        if(productData == null) {
            productData = new List<ProductData>();
            var categoryProducts = NWindContext.Create().CategoryProducts.ToList();
            productData.Capacity = categoryProducts.Count;
            NonCryptographicRandom rand = NonCryptographicRandom.Default;
            foreach(var row in categoryProducts) {
                productData.Add(new ProductData() {
                    Category = FindCategory(categoriesList, row.CategoryName),
                    Name = row.ProductName,
                    Price = (decimal)(rand.Next(20) + rand.Next(99)) / 100m
                });
            }
        }
        return productData;
    }
    public static List<string> VehicleOrderTrademarks {
        get {
            if(vehicleOrderTrademarks == null) {
                vehicleOrderTrademarks = new List<string>();
                vehicleOrderTrademarks.AddRange(new VehiclesData()
                    .Models.Select(x => x.Trademark.Name).Distinct());
            }
            return vehicleOrderTrademarks;
        }
    }

    public static List<OrderData> GenerateOrders(int generateCount) {
        List<OrderData> result = new List<OrderData>(generateCount);
        List<string> customerNames = ExtractCustomerNames();
        List<CategoryData> categoriesList = CategoryDataList;
        List<ProductData> productsList = ExtractProductDataList(categoriesList);

        NonCryptographicRandom rand = NonCryptographicRandom.Default;
        for(int i = 0; i < generateCount; i++) {
            ProductData randomProduct = productsList[rand.Next(productsList.Count)];
            string randomName = customerNames[rand.Next(customerNames.Count)];
            OrderData data = new OrderData();
            data.OrderId = i;
            data.OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(rand.Next(180)));
            data.CustomerName = randomName;
            data.Quantity = rand.Next(200) + 1;
            data.CustomerID = i + 1;
            data.ProductCategory = randomProduct.Category;
            data.ProductName = randomProduct.Name;
            data.Price = randomProduct.Price;
            data.IsReady = (rand.Next(2) == 0);
            result.Add(data);
        }
        return result;
    }

    public static List<VehicleOrder> GenerateVehicleOrders(int generateCount) {
        var rnd = NonCryptographicRandom.Default;
        var models = new VehiclesData().Models.ToList();
        var orders = new List<VehicleOrder>();
        for(int i = 0; i < generateCount; i++) {
            var model = models[rnd.Next(0, models.Count - 1)];
            orders.Add(new VehicleOrder(
                orderID: i,
                discount: Math.Round(0.05 * rnd.Next(4), 2),
                salesDate: DateTime.Now.AddDays(-rnd.Next(400)),
                modelPrice: model.Price,
                modelTrademarkName: model.TrademarkName,
                modelName: model.Name,
                modelModification: model.Modification,
                modelMPGCity: model.MPGCity,
                modelMPGHighway: model.MPGHighway,
                modelCylinders: model.Cylinders));
        }
        return orders;
    }

    static CategoryData FindCategory(List<CategoryData> categoriesList, string name) {
        foreach(CategoryData category in categoriesList) {
            if(category.Name == name) return category;
        }
        return null;
    }
}

public class CategoryData : IComparable, IComparable<CategoryData> {
    public string Name { get; set; }
    public byte[] Picture { get; set; }
    public override string ToString() {
        return Name;
    }

    #region IComparable Members
    public int CompareTo(object obj) {
        if(obj is CategoryData)
            return CompareTo((CategoryData)obj);
        return -1;
    }
    #endregion
    #region IComparable<CategoryData> Members
    public int CompareTo(CategoryData other) {
        return StringComparer.CurrentCulture.Compare(Name, other.Name);
    }
    #endregion
}
public class ProductData {
    public string Name { get; set; }
    public CategoryData Category { get; set; }
    public decimal Price { get; set; }
    public override string ToString() {
        return Name;
    }
}

public class OrderData {
    public int OrderId { get; set; }
    public bool IsReady { get; set; }
    public string CustomerName { get; set; }
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public CategoryData ProductCategory { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

public class VehicleOrder {
    public VehicleOrder(int orderID, double discount, DateTime salesDate, decimal modelPrice, string modelTrademarkName, string modelName, string modelModification, int? modelMPGCity, int? modelMPGHighway, int modelCylinders) {
        OrderID = orderID;
        Discount = discount;
        SalesDate = salesDate;
        ModelPrice = modelPrice;
        ModelTrademarkName = modelTrademarkName;
        ModelName = modelName;
        ModelModification = modelModification;
        ModelMPGCity = modelMPGCity;
        ModelMPGHighway = modelMPGHighway;
        ModelCylinders = modelCylinders;
    }

    public int OrderID { get; set; }
    public double Discount { get; set; }
    public DateTime SalesDate { get; set; }
    public decimal ModelPrice { get; set; }
    public string ModelTrademarkName { get; set; }
    public string ModelName { get; set; }
    public string ModelModification { get; set; }
    public int? ModelMPGCity { get; set; }
    public int? ModelMPGHighway { get; set; }
    public int ModelCylinders { get; set; }
}
