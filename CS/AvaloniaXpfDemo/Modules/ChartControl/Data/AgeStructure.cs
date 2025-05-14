#nullable disable
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Media;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Charts;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public class AgeStructure {
    DataTable ageStructureTable;
    DataTable AgeStructureTable {
        get {
            if(this.ageStructureTable == null)
                this.ageStructureTable = LoadPopulationAgeStructure();
            return this.ageStructureTable;
        }
    }

    DataTable LoadPopulationAgeStructure() {
        Stream xmlStream = DataProvider.GetPopulationStream();
        DataSet xmlDataSet = new DataSet();
        xmlDataSet.ReadXml(xmlStream);
        xmlStream.Close();
        return xmlDataSet.Tables["Population"];
    }

    public IList DataByAgeAndGender {
        get {
            return AgeStructureTable.AsEnumerable()
                .Select(row => new {
                    GenderAge = new GenderAgeInfo(row.Field<string>("Gender"), row.Field<string>("Age")),
                    Country = row.Field<string>("Country"),
                    Population = row.Field<long>("Population")
                }).ToList();
        }
    }
    public IList GetDataByMaleAge() {
        return AgeStructureTable.AsEnumerable()
            .Where(row => row.Field<string>("Gender") == "Male")
            .Select(row => new {
                Age = row.Field<string>("Age"),
                Country = row.Field<string>("Country"),
                Population = row.Field<long>("Population")
            }).ToList();
    }
    public IList GetPopulationAgeStructure() {
        return AgeStructureTable.AsEnumerable()
            .Select(row => new AgePopulation(row.Field<string>("Country"), row.Field<string>("Age"), row.Field<string>("Gender"), row.Field<long>("Population"))).ToList();
    }

    public IList GetGenderAgeItemsWithPopulation() {
        Dictionary<string, List<PopulationItem>> genderAgePopulationItemPair = new Dictionary<string, List<PopulationItem>>();
        foreach(DataRow row in AgeStructureTable.AsEnumerable()) {
            string gender = row.Field<string>("Gender");
            long population = row.Field<long>("Population");
            string populationString = population.ToString("0,,.00");
            string country = row.Field<string>("Country");
            string age = row.Field<string>("Age");
            string key = gender + ": " + age;

            List<PopulationItem> populationItemsBuffer = new List<PopulationItem>();
            if(genderAgePopulationItemPair.TryGetValue(key, out populationItemsBuffer)) {
                populationItemsBuffer.Add(new PopulationItem(country, gender, population, populationString));
            }
            else {
                List<PopulationItem> newPopulationItemsBuffer = new List<PopulationItem>() {
                        new PopulationItem(country, gender, population, populationString)
                    };
                genderAgePopulationItemPair.Add(key, newPopulationItemsBuffer);
            }
        }

        List<GenderAgeItem> genderAgeItems = new List<GenderAgeItem>();
        foreach(KeyValuePair<string, List<PopulationItem>> keyValue in genderAgePopulationItemPair) {
            genderAgeItems.Add(GenderAgeItem.Create(keyValue.Key, keyValue.Value));
        }
        return genderAgeItems;
    }
}

public struct GenderAgeInfo {
    readonly string gender;
    readonly string age;

    public string Gender { get { return this.gender; } }
    public string Age { get { return this.age; } }

    public GenderAgeInfo(string gender, string age) {
        this.gender = gender;
        this.age = age;
    }

    public override string ToString() {
        return this.gender + ": " + this.age;
    }
}

public class GenderAgeItem {
    public static GenderAgeItem Create(string name, IList<PopulationItem> items) {
        return ViewModelSource.Create(() => new GenderAgeItem(name, items));
    }
    public virtual string Name { get; protected set; }
    public virtual Color Color { get; set; }
    public virtual IList<PopulationItem> Items { get; protected set; }
    public virtual bool IsShowLabelsChecked { get; set; }
    public virtual bool IsShowToolTipsChecked { get; set; }
    public virtual Bar2DModel Model { get; set; }
    public virtual LegendViewModel Legend { get; set; }
    public virtual PaneViewModel Pane { get; set; }

    protected GenderAgeItem(string name, IList<PopulationItem> items) {
        Name = name;
        Items = items;
        IsShowToolTipsChecked = true;
    }
}

public struct PopulationItem {
    readonly string country;
    readonly string gender;
    readonly long population;
    readonly string populationString;

    public string Country { get { return country; } }
    public string Gender { get { return gender; } }
    public long Population { get { return population; } }
    public string PopulationString { get { return populationString; } }

    public PopulationItem(string country, string gender, long population, string populationString) {
        this.country = country;
        this.gender = gender;
        this.population = population;
        this.populationString = populationString;
    }
}

public class AgePopulation {
    readonly string name;
    readonly string age;
    readonly string sex;
    readonly double population;

    public string Name { get { return this.name; } }
    public string Age { get { return this.age; } }
    public string Sex { get { return this.sex; } }
    public string SexAgeKey { get { return this.sex.ToString() + ": " + this.age; } }
    public string CountryAgeKey { get { return this.name + ": " + this.age; } }
    public string CountrySexKey { get { return this.name + ": " + this.sex.ToString(); } }
    public double Population { get { return this.population; } }

    public AgePopulation(string name, string age, string gender, double population) {
        this.name = name;
        this.age = age;
        this.sex = gender;
        this.population = population;
    }
}

public class LegendViewModel : BindableBase {
    public static LegendViewModel Create(PaneViewModel Pane) {
        return ViewModelSource.Create(() => new LegendViewModel(Pane));
    }

    public virtual PaneViewModel Pane { get; set; }

    protected LegendViewModel(PaneViewModel Pane) {
        this.Pane = Pane;
    }
}

public class PaneViewModel : BindableBase {
    public static PaneViewModel Create() {
        return ViewModelSource.Create(() => new PaneViewModel());
    }

    public virtual bool IsShowTotalLabelsChecked { get; set; }

    protected PaneViewModel() {
        IsShowTotalLabelsChecked = true;
    }
}