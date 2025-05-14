#nullable disable
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Gantt;
using DevExpress.Mvvm.POCO;

namespace DevExpress.AvaloniaXpfDemo.GanttControlModules;

[POCOViewModel]
public class StartupBusinessPlanViewModel {
    public List<GanttTask> Items { get; private set; }
    public IEnumerable<GanttStripLineBase> StripLines { get; private set; }
    public List<GanttResource> Resources { get; private set; }

    readonly DateTime ProjectStart = new DateTime(2018, 10, 25, 8, 0, 0);
    readonly DateTime ProjectFinish = new DateTime(2019, 4, 16, 12, 0, 0);

    public StartupBusinessPlanViewModel() {
        this.Items = CreateData();
        this.Resources = CreateResources();
        this.StripLines = CreateStripLinesData();
    }

    List<GanttTask> CreateData() {
        var tasks = new List<GanttTask>();
        #region Data generation
        tasks.Add(new GanttTask { Id = 0, Name = "New Business", StartDate = new DateTime(2018, 10, 25, 8, 0, 0), FinishDate = new DateTime(2019, 4, 16, 12, 0, 0), BaselineStartDate = new DateTime(2018, 10, 25, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 4, 16, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 1, ParentId = 0, Name = "Phase 1 - Strategic Plan", StartDate = new DateTime(2018, 10, 25, 8, 0, 0), FinishDate = new DateTime(2018, 11, 27, 12, 0, 0), BaselineStartDate = new DateTime(2018, 10, 25, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 26, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 2, ParentId = 1, Name = "Self-Assessment", StartDate = new DateTime(2018, 10, 25, 8, 0, 0), FinishDate = new DateTime(2018, 10, 30, 12, 0, 0), BaselineStartDate = new DateTime(2018, 10, 25, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 10, 29, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 3, ParentId = 2, Name = "Define business vision", StartDate = new DateTime(2018, 10, 25, 8, 0, 0), FinishDate = new DateTime(2018, 10, 26, 12, 0, 0), BaselineStartDate = new DateTime(2018, 10, 25, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 10, 25, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 4, ParentId = 2, Name = "Identify available skills, information and support", StartDate = new DateTime(2018, 10, 26, 13, 0, 0), FinishDate = new DateTime(2018, 10, 29, 12, 0, 0), BaselineStartDate = new DateTime(2018, 10, 26, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 10, 26, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 5, ParentId = 2, Name = "Decide whether to proceed", StartDate = new DateTime(2018, 10, 29, 13, 0, 0), FinishDate = new DateTime(2018, 10, 30, 12, 0, 0), BaselineStartDate = new DateTime(2018, 10, 29, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 10, 29, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 6, ParentId = 1, Name = "Define the Opportunity", StartDate = new DateTime(2018, 10, 30, 13, 0, 0), FinishDate = new DateTime(2018, 11, 12, 12, 0, 0), BaselineStartDate = new DateTime(2018, 10, 30, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 12, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 7, ParentId = 6, Name = "Research the market and competition", StartDate = new DateTime(2018, 10, 30, 13, 0, 0), FinishDate = new DateTime(2018, 10, 31, 12, 0, 0), BaselineStartDate = new DateTime(2018, 10, 30, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 10, 30, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 8, ParentId = 6, Name = "Interview owners of similar businesses", StartDate = new DateTime(2018, 10, 31, 13, 0, 0), FinishDate = new DateTime(2018, 11, 6, 17, 0, 0), BaselineStartDate = new DateTime(2018, 10, 31, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 6, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 9, ParentId = 6, Name = "Identify needed resources", StartDate = new DateTime(2018, 11, 7, 8, 0, 0), FinishDate = new DateTime(2018, 11, 8, 17, 0, 0), BaselineStartDate = new DateTime(2018, 11, 7, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 8, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 10, ParentId = 6, Name = "Identify operating cost elements", StartDate = new DateTime(2018, 11, 9, 8, 0, 0), FinishDate = new DateTime(2018, 11, 12, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 9, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 12, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 11, ParentId = 1, Name = "Evaluate Business Approach", StartDate = new DateTime(2018, 11, 12, 13, 0, 0), FinishDate = new DateTime(2018, 11, 16, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 13, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 16, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 12, ParentId = 11, Name = "Define new entity requirements", StartDate = new DateTime(2018, 11, 12, 13, 0, 0), FinishDate = new DateTime(2018, 11, 13, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 13, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 13, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 13, ParentId = 11, Name = "Identify on-going business purchase opportunities", StartDate = new DateTime(2018, 11, 13, 13, 0, 0), FinishDate = new DateTime(2018, 11, 14, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 14, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 14, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 14, ParentId = 11, Name = "Research franchise possibilities", StartDate = new DateTime(2018, 11, 14, 13, 0, 0), FinishDate = new DateTime(2018, 11, 15, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 15, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 15, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 15, ParentId = 11, Name = "Summarize business approach", StartDate = new DateTime(2018, 11, 15, 13, 0, 0), FinishDate = new DateTime(2018, 11, 16, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 16, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 16, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 16, ParentId = 1, Name = "Evaluate Potential Risks and Rewards", StartDate = new DateTime(2018, 11, 13, 13, 0, 0), FinishDate = new DateTime(2018, 11, 22, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 14, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 22, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 17, ParentId = 16, Name = "Assess market size and stability", StartDate = new DateTime(2018, 11, 13, 13, 0, 0), FinishDate = new DateTime(2018, 11, 15, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 14, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 15, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 18, ParentId = 16, Name = "Estimate the competition", StartDate = new DateTime(2018, 11, 15, 13, 0, 0), FinishDate = new DateTime(2018, 11, 16, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 16, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 16, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 19, ParentId = 16, Name = "Assess needed resource availability", StartDate = new DateTime(2018, 11, 16, 13, 0, 0), FinishDate = new DateTime(2018, 11, 20, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 19, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 20, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 20, ParentId = 16, Name = "Evaluate realistic initial market share", StartDate = new DateTime(2018, 11, 20, 13, 0, 0), FinishDate = new DateTime(2018, 11, 21, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 21, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 21, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 21, ParentId = 16, Name = "Determine financial requirements", StartDate = new DateTime(2018, 11, 16, 13, 0, 0), FinishDate = new DateTime(2018, 11, 20, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 19, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 20, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 22, ParentId = 16, Name = "Review personal suitability", StartDate = new DateTime(2018, 11, 20, 13, 0, 0), FinishDate = new DateTime(2018, 11, 21, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 21, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 21, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 23, ParentId = 16, Name = "Evaluate initial profitability", StartDate = new DateTime(2018, 11, 21, 13, 0, 0), FinishDate = new DateTime(2018, 11, 22, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 22, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 22, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 24, ParentId = 1, Name = "Review and modify the strategic plan", StartDate = new DateTime(2018, 11, 22, 13, 0, 0), FinishDate = new DateTime(2018, 11, 27, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 23, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 26, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 25, ParentId = 1, Name = "Confirm decision to proceed", StartDate = new DateTime(2018, 11, 27, 12, 0, 0), FinishDate = new DateTime(2018, 11, 27, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 26, 17, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 26, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 26, ParentId = 0, Name = "Phase 2 - Define the Business Opportunity", StartDate = new DateTime(2018, 11, 27, 13, 0, 0), FinishDate = new DateTime(2019, 1, 3, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 27, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 2, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 27, ParentId = 26, Name = "Define the Market", StartDate = new DateTime(2018, 11, 27, 13, 0, 0), FinishDate = new DateTime(2018, 12, 14, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 27, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 13, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 28, ParentId = 27, Name = "Access available information", StartDate = new DateTime(2018, 11, 27, 13, 0, 0), FinishDate = new DateTime(2018, 11, 28, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 27, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 27, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 29, ParentId = 27, Name = "Create market analysis plan", StartDate = new DateTime(2018, 11, 28, 13, 0, 0), FinishDate = new DateTime(2018, 11, 30, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 28, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 11, 29, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 30, ParentId = 27, Name = "Implement market analysis plan", StartDate = new DateTime(2018, 11, 30, 13, 0, 0), FinishDate = new DateTime(2018, 12, 7, 12, 0, 0), BaselineStartDate = new DateTime(2018, 11, 30, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 6, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 31, ParentId = 27, Name = "Identify competition", StartDate = new DateTime(2018, 12, 7, 13, 0, 0), FinishDate = new DateTime(2018, 12, 11, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 7, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 10, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 32, ParentId = 27, Name = "Summarize the market", StartDate = new DateTime(2018, 12, 11, 13, 0, 0), FinishDate = new DateTime(2018, 12, 13, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 11, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 12, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 33, ParentId = 27, Name = "Identify target market niche", StartDate = new DateTime(2018, 12, 13, 13, 0, 0), FinishDate = new DateTime(2018, 12, 14, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 13, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 13, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 34, ParentId = 26, Name = "Identify Needed Materials and Supplies", StartDate = new DateTime(2018, 12, 14, 13, 0, 0), FinishDate = new DateTime(2018, 12, 25, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 14, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 24, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 35, ParentId = 34, Name = "Select a business approach (from \"Evaluate Business Approach\" above)", StartDate = new DateTime(2018, 12, 14, 13, 0, 0), FinishDate = new DateTime(2018, 12, 18, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 14, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 17, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 36, ParentId = 34, Name = "Identify management staff resources", StartDate = new DateTime(2018, 12, 18, 13, 0, 0), FinishDate = new DateTime(2018, 12, 19, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 18, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 18, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 37, ParentId = 34, Name = "Identify staffing requirements", StartDate = new DateTime(2018, 12, 19, 13, 0, 0), FinishDate = new DateTime(2018, 12, 20, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 19, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 19, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 38, ParentId = 34, Name = "Identify needed raw materials", StartDate = new DateTime(2018, 12, 20, 13, 0, 0), FinishDate = new DateTime(2018, 12, 21, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 20, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 20, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 39, ParentId = 34, Name = "Identify needed utilities", StartDate = new DateTime(2018, 12, 21, 13, 0, 0), FinishDate = new DateTime(2018, 12, 24, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 21, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 21, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 40, ParentId = 34, Name = "Summarize operating expenses and financial projections", StartDate = new DateTime(2018, 12, 24, 13, 0, 0), FinishDate = new DateTime(2018, 12, 25, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 24, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 24, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 41, ParentId = 26, Name = "Evaluate Potential Risks and Rewards", StartDate = new DateTime(2018, 12, 25, 13, 0, 0), FinishDate = new DateTime(2019, 1, 2, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 25, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 1, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 42, ParentId = 41, Name = "Assess market size and stability", StartDate = new DateTime(2018, 12, 25, 13, 0, 0), FinishDate = new DateTime(2018, 12, 27, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 25, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 26, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 43, ParentId = 41, Name = "Assess needed resources availability", StartDate = new DateTime(2018, 12, 27, 13, 0, 0), FinishDate = new DateTime(2018, 12, 31, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 27, 8, 0, 0), BaselineFinishDate = new DateTime(2018, 12, 28, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 44, ParentId = 41, Name = "Forecast financial returns", StartDate = new DateTime(2018, 12, 31, 13, 0, 0), FinishDate = new DateTime(2019, 1, 2, 12, 0, 0), BaselineStartDate = new DateTime(2018, 12, 31, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 1, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 45, ParentId = 26, Name = "Review and modify the business opportunity", StartDate = new DateTime(2019, 1, 2, 13, 0, 0), FinishDate = new DateTime(2019, 1, 3, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 2, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 2, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 46, ParentId = 26, Name = "Confirm decision to proceed", StartDate = new DateTime(2019, 1, 3, 12, 0, 0), FinishDate = new DateTime(2019, 1, 3, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 2, 17, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 2, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 47, ParentId = 0, Name = "Phase 3 - Plan for Action", StartDate = new DateTime(2019, 1, 3, 13, 0, 0), FinishDate = new DateTime(2019, 2, 4, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 3, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 31, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 48, ParentId = 47, Name = "Develop Detailed 5-Year Business Plan", StartDate = new DateTime(2019, 1, 3, 13, 0, 0), FinishDate = new DateTime(2019, 2, 4, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 3, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 31, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 49, ParentId = 48, Name = "Describe the vision and opportunity", StartDate = new DateTime(2019, 1, 3, 13, 0, 0), FinishDate = new DateTime(2019, 1, 4, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 3, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 3, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 50, ParentId = 48, Name = "List assumptions", StartDate = new DateTime(2019, 1, 4, 13, 0, 0), FinishDate = new DateTime(2019, 1, 7, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 4, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 4, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 51, ParentId = 48, Name = "Describe the market", StartDate = new DateTime(2019, 1, 7, 13, 0, 0), FinishDate = new DateTime(2019, 1, 8, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 7, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 7, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 52, ParentId = 48, Name = "Describe the new business", StartDate = new DateTime(2019, 1, 8, 13, 0, 0), FinishDate = new DateTime(2019, 1, 9, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 8, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 8, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 53, ParentId = 48, Name = "Describe strengths, weaknesses, assets and threats", StartDate = new DateTime(2019, 1, 9, 13, 0, 0), FinishDate = new DateTime(2019, 1, 10, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 9, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 9, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 54, ParentId = 48, Name = "Estimate sales volume during startup period", StartDate = new DateTime(2019, 1, 10, 13, 0, 0), FinishDate = new DateTime(2019, 1, 11, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 10, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 10, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 55, ParentId = 48, Name = "Forecast operating costs", StartDate = new DateTime(2019, 1, 11, 13, 0, 0), FinishDate = new DateTime(2019, 1, 14, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 11, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 11, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 56, ParentId = 48, Name = "Establish pricing strategy", StartDate = new DateTime(2019, 1, 14, 13, 0, 0), FinishDate = new DateTime(2019, 1, 15, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 14, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 14, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 57, ParentId = 48, Name = "Forecast revenue", StartDate = new DateTime(2019, 1, 15, 13, 0, 0), FinishDate = new DateTime(2019, 1, 16, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 15, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 15, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 58, ParentId = 48, Name = "Summarize pro-forma financial statement", StartDate = new DateTime(2019, 1, 16, 13, 0, 0), FinishDate = new DateTime(2019, 1, 18, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 16, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 17, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 59, ParentId = 48, Name = "Develop break-even analysis", StartDate = new DateTime(2019, 1, 18, 13, 0, 0), FinishDate = new DateTime(2019, 1, 18, 17, 0, 0), BaselineStartDate = new DateTime(2019, 1, 18, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 18, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 60, ParentId = 48, Name = "Develop cash-flow projection", StartDate = new DateTime(2019, 1, 21, 8, 0, 0), FinishDate = new DateTime(2019, 1, 21, 17, 0, 0), BaselineStartDate = new DateTime(2019, 1, 21, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 21, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 61, ParentId = 48, Name = "Identify licensing and permitting requirements", StartDate = new DateTime(2019, 1, 22, 8, 0, 0), FinishDate = new DateTime(2019, 1, 22, 17, 0, 0), BaselineStartDate = new DateTime(2019, 1, 22, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 22, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 62, ParentId = 48, Name = "Develop startup plan", StartDate = new DateTime(2019, 1, 23, 8, 0, 0), FinishDate = new DateTime(2019, 1, 24, 17, 0, 0), BaselineStartDate = new DateTime(2019, 1, 23, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 24, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 63, ParentId = 48, Name = "Develop sales and marketing strategy", StartDate = new DateTime(2019, 1, 25, 8, 0, 0), FinishDate = new DateTime(2019, 1, 25, 17, 0, 0), BaselineStartDate = new DateTime(2019, 1, 25, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 25, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 64, ParentId = 48, Name = "Develop distribution structure", StartDate = new DateTime(2019, 1, 28, 8, 0, 0), FinishDate = new DateTime(2019, 1, 28, 17, 0, 0), BaselineStartDate = new DateTime(2019, 1, 28, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 28, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 65, ParentId = 48, Name = "Describe risks and opportunities", StartDate = new DateTime(2019, 1, 29, 8, 0, 0), FinishDate = new DateTime(2019, 2, 1, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 29, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 30, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 66, ParentId = 48, Name = "Publish the business plan", StartDate = new DateTime(2019, 2, 1, 13, 0, 0), FinishDate = new DateTime(2019, 2, 4, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 31, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 31, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 67, ParentId = 48, Name = "Confirm decision to proceed", StartDate = new DateTime(2019, 2, 4, 12, 0, 0), FinishDate = new DateTime(2019, 2, 4, 12, 0, 0), BaselineStartDate = new DateTime(2019, 1, 31, 17, 0, 0), BaselineFinishDate = new DateTime(2019, 1, 31, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 68, ParentId = 0, Name = "Phase 4 - Proceed With Startup Plan", StartDate = new DateTime(2019, 2, 4, 13, 0, 0), FinishDate = new DateTime(2019, 4, 16, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 1, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 4, 16, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 69, ParentId = 68, Name = "Choose a location", StartDate = new DateTime(2019, 2, 4, 13, 0, 0), FinishDate = new DateTime(2019, 2, 4, 17, 0, 0), BaselineStartDate = new DateTime(2019, 2, 1, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 1, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 70, ParentId = 68, Name = "Establish Business Structure", StartDate = new DateTime(2019, 2, 5, 8, 0, 0), FinishDate = new DateTime(2019, 3, 7, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 4, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 7, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 71, ParentId = 70, Name = "Choose a Name", StartDate = new DateTime(2019, 2, 5, 8, 0, 0), FinishDate = new DateTime(2019, 2, 6, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 4, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 5, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 72, ParentId = 71, Name = "Identify implications", StartDate = new DateTime(2019, 2, 5, 8, 0, 0), FinishDate = new DateTime(2019, 2, 5, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 4, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 4, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 73, ParentId = 71, Name = "Research name availability", StartDate = new DateTime(2019, 2, 5, 13, 0, 0), FinishDate = new DateTime(2019, 2, 6, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 5, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 5, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 74, ParentId = 70, Name = "Choose a Bank", StartDate = new DateTime(2019, 2, 6, 13, 0, 0), FinishDate = new DateTime(2019, 2, 12, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 6, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 12, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 75, ParentId = 74, Name = "Establish accounts", StartDate = new DateTime(2019, 2, 6, 13, 0, 0), FinishDate = new DateTime(2019, 2, 11, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 6, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 11, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 76, ParentId = 74, Name = "Establish line of credit", StartDate = new DateTime(2019, 2, 11, 13, 0, 0), FinishDate = new DateTime(2019, 2, 12, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 12, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 12, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 77, ParentId = 70, Name = "Choose legal representation", StartDate = new DateTime(2019, 2, 12, 13, 0, 0), FinishDate = new DateTime(2019, 2, 13, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 13, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 13, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 78, ParentId = 70, Name = "Select business tax-basis category", StartDate = new DateTime(2019, 2, 13, 13, 0, 0), FinishDate = new DateTime(2019, 2, 15, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 14, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 15, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 79, ParentId = 70, Name = "Choose capital funding source", StartDate = new DateTime(2019, 2, 15, 13, 0, 0), FinishDate = new DateTime(2019, 2, 19, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 18, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 19, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 80, ParentId = 70, Name = "Commit capital funding", StartDate = new DateTime(2019, 2, 19, 12, 0, 0), FinishDate = new DateTime(2019, 2, 19, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 19, 17, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 19, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 81, ParentId = 70, Name = "Establish the Operating Control Base", StartDate = new DateTime(2019, 2, 19, 13, 0, 0), FinishDate = new DateTime(2019, 3, 7, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 20, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 7, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 82, ParentId = 81, Name = "Choose and set up the accounting system", StartDate = new DateTime(2019, 2, 19, 13, 0, 0), FinishDate = new DateTime(2019, 2, 21, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 20, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 21, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 83, ParentId = 81, Name = "Obtain required licenses and permits", StartDate = new DateTime(2019, 2, 21, 13, 0, 0), FinishDate = new DateTime(2019, 2, 27, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 22, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 27, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 84, ParentId = 81, Name = "Obtain needed insurance", StartDate = new DateTime(2019, 2, 27, 13, 0, 0), FinishDate = new DateTime(2019, 3, 5, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 28, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 5, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 85, ParentId = 81, Name = "Establish security plan", StartDate = new DateTime(2019, 3, 5, 13, 0, 0), FinishDate = new DateTime(2019, 3, 7, 12, 0, 0), BaselineStartDate = new DateTime(2019, 3, 6, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 7, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 86, ParentId = 70, Name = "Develop Marketing Program", StartDate = new DateTime(2019, 2, 5, 13, 0, 0), FinishDate = new DateTime(2019, 2, 11, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 5, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 8, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 87, ParentId = 86, Name = "Establish an advertising program", StartDate = new DateTime(2019, 2, 5, 13, 0, 0), FinishDate = new DateTime(2019, 2, 7, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 5, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 6, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 88, ParentId = 86, Name = "Develop a logo", StartDate = new DateTime(2019, 2, 7, 13, 0, 0), FinishDate = new DateTime(2019, 2, 8, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 7, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 7, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 89, ParentId = 86, Name = "Order promotional materials", StartDate = new DateTime(2019, 2, 8, 13, 0, 0), FinishDate = new DateTime(2019, 2, 11, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 8, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 2, 8, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 90, ParentId = 68, Name = "Provide Physical Facilities", StartDate = new DateTime(2019, 3, 7, 13, 0, 0), FinishDate = new DateTime(2019, 3, 28, 12, 0, 0), BaselineStartDate = new DateTime(2019, 3, 8, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 28, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 91, ParentId = 90, Name = "Secure operation space", StartDate = new DateTime(2019, 3, 7, 13, 0, 0), FinishDate = new DateTime(2019, 3, 14, 12, 0, 0), BaselineStartDate = new DateTime(2019, 3, 8, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 14, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 92, ParentId = 90, Name = "Select computer network hardware", StartDate = new DateTime(2019, 3, 14, 13, 0, 0), FinishDate = new DateTime(2019, 3, 15, 12, 0, 0), BaselineStartDate = new DateTime(2019, 3, 15, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 15, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 93, ParentId = 90, Name = "Select computer software", StartDate = new DateTime(2019, 3, 15, 13, 0, 0), FinishDate = new DateTime(2019, 3, 18, 12, 0, 0), BaselineStartDate = new DateTime(2019, 3, 18, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 18, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 94, ParentId = 90, Name = "Establish utilities", StartDate = new DateTime(2019, 3, 18, 13, 0, 0), FinishDate = new DateTime(2019, 3, 21, 12, 0, 0), BaselineStartDate = new DateTime(2019, 3, 19, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 21, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 95, ParentId = 90, Name = "Provide furniture and equipment", StartDate = new DateTime(2019, 3, 21, 13, 0, 0), FinishDate = new DateTime(2019, 3, 27, 12, 0, 0), BaselineStartDate = new DateTime(2019, 3, 22, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 27, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 96, ParentId = 90, Name = "Move in", StartDate = new DateTime(2019, 3, 27, 13, 0, 0), FinishDate = new DateTime(2019, 3, 28, 12, 0, 0), BaselineStartDate = new DateTime(2019, 3, 28, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 28, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 97, ParentId = 68, Name = "Provide Staffing", StartDate = new DateTime(2019, 2, 19, 13, 0, 0), FinishDate = new DateTime(2019, 4, 16, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 20, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 4, 16, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 98, ParentId = 97, Name = "Interview and test candidates", StartDate = new DateTime(2019, 2, 19, 13, 0, 0), FinishDate = new DateTime(2019, 3, 11, 12, 0, 0), BaselineStartDate = new DateTime(2019, 2, 20, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 11, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 99, ParentId = 97, Name = "Hire staff", StartDate = new DateTime(2019, 3, 11, 13, 0, 0), FinishDate = new DateTime(2019, 3, 25, 12, 0, 0), BaselineStartDate = new DateTime(2019, 3, 12, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 3, 25, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 100, ParentId = 97, Name = "Train staff", StartDate = new DateTime(2019, 3, 25, 13, 0, 0), FinishDate = new DateTime(2019, 4, 16, 12, 0, 0), BaselineStartDate = new DateTime(2019, 3, 26, 8, 0, 0), BaselineFinishDate = new DateTime(2019, 4, 16, 17, 0, 0) });
        tasks.Add(new GanttTask { Id = 101, ParentId = 68, Name = "Start up the business", StartDate = new DateTime(2019, 4, 16, 12, 0, 0), FinishDate = new DateTime(2019, 4, 16, 12, 0, 0), BaselineStartDate = new DateTime(2019, 4, 16, 17, 0, 0), BaselineFinishDate = new DateTime(2019, 4, 16, 17, 0, 0) });
        tasks[4].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 3 });
        tasks[5].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 4 });
        tasks[7].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 5 });
        tasks[8].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 7 });
        tasks[9].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 8 });
        tasks[10].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 9 });
        tasks[12].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 10 });
        tasks[13].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 12 });
        tasks[14].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 13 });
        tasks[15].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 14 });
        tasks[17].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 12 });
        tasks[18].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 17 });
        tasks[19].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 18 });
        tasks[20].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 19 });
        tasks[21].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 15 });
        tasks[22].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 21 });
        tasks[23].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 22 });
        tasks[24].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 23 });
        tasks[25].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 24 });
        tasks[28].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 25 });
        tasks[29].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 28 });
        tasks[30].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 29 });
        tasks[31].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 30 });
        tasks[32].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 31 });
        tasks[33].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 32 });
        tasks[35].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 28 });
        tasks[35].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 33 });
        tasks[36].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 35 });
        tasks[37].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 36 });
        tasks[38].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 37 });
        tasks[39].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 38 });
        tasks[40].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 39 });
        tasks[42].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 40 });
        tasks[43].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 42 });
        tasks[44].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 43 });
        tasks[45].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 44 });
        tasks[46].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 45 });
        tasks[49].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 46 });
        tasks[50].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 49 });
        tasks[51].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 50 });
        tasks[52].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 51 });
        tasks[53].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 52 });
        tasks[54].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 53 });
        tasks[55].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 54 });
        tasks[56].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 55 });
        tasks[57].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 56 });
        tasks[58].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 57 });
        tasks[59].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 58 });
        tasks[60].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 59 });
        tasks[61].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 60 });
        tasks[62].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 61 });
        tasks[63].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 62 });
        tasks[64].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 63 });
        tasks[65].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 64 });
        tasks[66].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 65 });
        tasks[67].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 66 });
        tasks[69].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 67 });
        tasks[72].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 69 });
        tasks[73].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 72 });
        tasks[75].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 73 });
        tasks[76].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 75 });
        tasks[77].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 75 });
        tasks[77].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 76 });
        tasks[78].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 77 });
        tasks[79].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 78 });
        tasks[80].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 79 });
        tasks[82].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 79 });
        tasks[82].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 80 });
        tasks[83].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 82 });
        tasks[84].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 83 });
        tasks[85].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 84 });
        tasks[87].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 73 });
        tasks[88].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 87 });
        tasks[89].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 88 });
        tasks[91].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 85 });
        tasks[91].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 89 });
        tasks[92].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 91 });
        tasks[93].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 92 });
        tasks[94].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 93 });
        tasks[95].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 94 });
        tasks[96].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 95 });
        tasks[98].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 79 });
        tasks[99].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 98 });
        tasks[100].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 99 });
        tasks[101].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 96 });
        tasks[101].PredecessorLinks.Add(new GanttPredecessorLink() { PredecessorTaskId = 100 });
        tasks[3].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[4].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[4].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[5].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[7].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[8].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 6 });
        tasks[9].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[9].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 2 });
        tasks[10].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 7 });
        tasks[12].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[13].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[14].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[15].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[17].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[18].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[19].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[20].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[21].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[22].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[23].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[28].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[29].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[30].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[31].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[32].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[33].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[35].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[36].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[37].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[38].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[39].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[40].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[42].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[43].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[44].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 7 });
        tasks[46].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[46].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 2 });
        tasks[46].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 3 });
        tasks[46].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 7 });
        tasks[49].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[50].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[51].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[52].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[53].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[54].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[54].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 7 });
        tasks[55].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[55].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 7 });
        tasks[56].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[57].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[58].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[59].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[60].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[61].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[62].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[63].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[64].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[65].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[66].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[67].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[72].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 3 });
        tasks[73].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 3 });
        tasks[75].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 8 });
        tasks[76].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 8 });
        tasks[77].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 3 });
        tasks[78].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 3 });
        tasks[78].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 7 });
        tasks[79].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[80].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[82].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 7 });
        tasks[83].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 3 });
        tasks[83].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 4 });
        tasks[84].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 7 });
        tasks[85].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[85].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 3 });
        tasks[87].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[88].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[88].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 3 });
        tasks[89].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 1 });
        tasks[91].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 3 });
        tasks[92].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 9 });
        tasks[93].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 9 });
        tasks[94].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[95].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[96].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[98].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[99].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[100].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        tasks[101].ResourceLinks.Add(new GanttResourceLink() { ResourceId = 5 });
        #endregion
        return tasks;
    }
    List<GanttResource> CreateResources() {
        var resources = new List<GanttResource>();
        #region Data generation
        resources.Add(new GanttResource { Name = "Business Advisor", Id = 1 });
        resources.Add(new GanttResource { Name = "Peers", Id = 2 });
        resources.Add(new GanttResource { Name = "Lawyer", Id = 3 });
        resources.Add(new GanttResource { Name = "Government Agency", Id = 4 });
        resources.Add(new GanttResource { Name = "Manager", Id = 5 });
        resources.Add(new GanttResource { Name = "Owners", Id = 6 });
        resources.Add(new GanttResource { Name = "Accountant", Id = 7 });
        resources.Add(new GanttResource { Name = "Banker", Id = 8 });
        resources.Add(new GanttResource { Name = "Information Services", Id = 9 });
        #endregion
        return resources;
    }
    IEnumerable<GanttStripLineBase> CreateStripLinesData() {
        return new GanttStripLineBase[] {
                GanttStripLine.Create(ProjectStart, TimeSpan.Zero, "Project Start"),
                GanttStripLine.Create(ProjectFinish, TimeSpan.Zero, "Project Finish"),
                WeeklyStripLine.Create(DayOfWeek.Wednesday, ProjectStart, TimeSpan.FromHours(15), ProjectFinish, TimeSpan.FromMinutes(90), "Weekly meeting"),
            };
    }
}
public abstract class GanttStripLineBase {
    public virtual DateTime StartDate { get; set; }
    public virtual TimeSpan Duration { get; set; }
    public virtual string Caption { get; set; }

    protected GanttStripLineBase(DateTime startDate, TimeSpan duration, string caption) {
        StartDate = startDate;
        Duration = duration;
        Caption = caption;
    }
}

[POCOViewModel]
public class GanttStripLine : GanttStripLineBase {
    protected GanttStripLine(DateTime startDate, TimeSpan duration, string caption)
        : base(startDate, duration, caption) { }

    public static GanttStripLine Create(DateTime startDate, TimeSpan duration, string caption) {
        return ViewModelSource.Create(() => new GanttStripLine(startDate, duration, caption));
    }
}
[POCOViewModel]
public class WeeklyStripLine : GanttStripLineBase {
    public virtual DateTime FinishDate { get; set; }
    public virtual DayOfWeek DayOfWeek { get; set; }
    public virtual TimeSpan StartTime { get; set; }

    protected WeeklyStripLine(DayOfWeek dayOfWeek, DateTime startDate, TimeSpan startTime, DateTime finishDate, TimeSpan duration, string caption)
        : base(startDate, duration, caption) {
        DayOfWeek = dayOfWeek;
        FinishDate = finishDate;
        StartTime = startTime;
    }

    public static WeeklyStripLine Create(DayOfWeek dayOfWeek, DateTime startDate, TimeSpan startTime, DateTime finishDate, TimeSpan duration, string caption) {
        return ViewModelSource.Create(() => new WeeklyStripLine(dayOfWeek, startDate, startTime, finishDate, duration, caption));
    }
}
