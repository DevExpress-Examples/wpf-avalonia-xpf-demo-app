#nullable disable
namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public class NestedDonutTabViewModel {
    const string AgeDataMember = "Age";
    const string GenderDataMember = "Sex";

    public virtual string ArgumentDataMember { get; set; }
    public virtual string SeriesDataMember { get; set; }
    public virtual string DemoTitle { get; set; }
    public virtual string HintDataMember { get; set; }
    public virtual bool GenderLegendVisible { get; set; }
    public virtual bool AgeLegendVisible { get; set; }
    public object DataSource { get; private set; }

    public NestedDonutTabViewModel() {
        DataSource = new AgeStructure().GetPopulationAgeStructure();
        ArgumentDataMember = AgeDataMember;
    }

    protected void OnArgumentDataMemberChanged() {
        HintDataMember = (ArgumentDataMember == AgeDataMember) ? GenderDataMember : AgeDataMember;
        SeriesDataMember = "Country" + HintDataMember + "Key";
        DemoTitle = "Population: " + ArgumentDataMember + " Structure";
        GenderLegendVisible = ArgumentDataMember == AgeDataMember;
        AgeLegendVisible = !GenderLegendVisible;
    }

}
