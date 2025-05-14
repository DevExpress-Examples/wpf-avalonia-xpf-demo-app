#nullable disable
using DevExpress.Mvvm.POCO;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

public class ChartDataSourceViewModel<T> {
    public List<ChartDataSource<T>> Sources { get; set; }
    public virtual ChartDataSource<T> SelectedSource { get; set; }
    public virtual IChartAnimationService ChartAnimationService { get { return null; } }

    public void Animate() {
        if(ChartAnimationService != null)
            ChartAnimationService.Animate();
    }
    protected void OnSelectedSourceChanged() {
        Animate();
    }
}


public class ChartDataSource<T> {
    public string Description { get; set; }
    public List<T> DataSource { get; set; }
}

public static class ChartViewModelFactory {
    #region Nested classes
    static class PolarFunctionsPointGenerator {
        public static List<RangeDataPoint> CreateLemniskateData() {
            List<RangeDataPoint> list = new List<RangeDataPoint>();
            for(double x = 0; x < 360; x += 5) {
                double xRadian = DegreeToRadian(x);
                double cos = Math.Cos(2 * xRadian);
                double y = Math.Pow(Math.Abs(cos), 2);
                list.Add(new RangeDataPoint(x, y, 1));
            }
            return list;
        }

        public static List<RangeDataPoint> CreateCardioidData() {
            List<RangeDataPoint> list = new List<RangeDataPoint>();
            const double a = 0.5;
            for(double x = 0; x < 360; x += 15) {
                double y = 2 * a * Math.Cos(DegreeToRadian(x));
                list.Add(new RangeDataPoint(x, y, 1));
            }
            return list;
        }

        public static List<RangeDataPoint> CreateTaubinsHeartData() {
            List<RangeDataPoint> list = new List<RangeDataPoint>();
            for(double x = 0; x < 360; x += 15) {
                double xRadian = DegreeToRadian(x);
                double y = 2 - 0.5 * Math.Sin(xRadian) + Math.Sin(xRadian) * Math.Sqrt(Math.Abs(Math.Cos(xRadian))) / (Math.Sin(xRadian) + 1.4);
                list.Add(new RangeDataPoint(x, y, 1));
            }
            return list;
        }

        static double DegreeToRadian(double degree) {
            return 2 * Math.PI / 360 * degree;
        }
    }

    public struct RangeDataPoint {
        readonly double x;
        readonly double y1;
        readonly double y2;

        public double X { get { return this.x; } }
        public double Y1 { get { return this.y1; } }
        public double Y2 { get { return this.y2; } }

        public RangeDataPoint(double x, double y1, double y2) {
            this.x = x;
            this.y1 = y1;
            this.y2 = y2;
        }
    }

    static class CartesianFunctionsPointGenerator {
        const int a = 10;

        public static List<Point> CreateArchimedianSpiralPoints() {
            var points = new List<Point>();
            for(int i = 0; i < 720; i += 15) {
                double t = (double)i / 180 * Math.PI;
                double x = t * Math.Cos(t);
                double y = t * Math.Sin(t);
                points.Add(new Point(x, y));
            }
            return points;
        }
        public static List<Point> CreateCardioidPoints() {
            var points = new List<Point>();
            for(int i = 0; i < 360; i += 10) {
                double t = (double)i / 180 * Math.PI;
                double x = a * (2 * Math.Cos(t) - Math.Cos(2 * t));
                double y = a * (2 * Math.Sin(t) - Math.Sin(2 * t));
                points.Add(new Point(x, y));
            }
            return points;
        }
        public static List<Point> CreateCartesianFoliumPoints() {
            var points = new List<Point>();
            for(int i = -30; i < 125; i += 5) {
                double t = Math.Tan((double)i / 180 * Math.PI);
                double x = 3 * (double)a * t / (t * t * t + 1);
                double y = x * t;
                points.Add(new Point(x, y));
            }
            return points;
        }
    }

    abstract class ScatterFunctionCalculatorBase {
        const int spiralIntervalsCount = 72;
        const int roseIntervalsCount = 288;
        const int foliumSegmentIntervalsCount = 30;

        const double roseParameter = 7.0d / 4.0d;
        const double foliumDistanceLimit = 3.0;

        protected abstract double NormalizeAngle(double angle);
        protected abstract double ToRadian(double angle);
        protected abstract double FromDegrees(double angle);

        List<Point> FilterPointsByRange(List<Point> points, double min, double max) {
            List<Point> resultPoints = new List<Point>();
            foreach(Point point in points) {
                double pointValue = point.Y;
                if(pointValue <= max && pointValue >= min)
                    resultPoints.Add(point);
            }
            return resultPoints;
        }
        List<Point> CreatePolarFunctionPoints(double minAngleDegree, double maxAngleDegree, int intervalsCount, Func<double, double> function) {
            var points = new List<Point>();
            double minAngle = FromDegrees(minAngleDegree);
            double maxAngle = FromDegrees(maxAngleDegree);
            double angleStep = (maxAngle - minAngle) / intervalsCount;
            for(int pointIndex = 0; pointIndex <= intervalsCount; pointIndex++) {
                double angle = minAngle + pointIndex * angleStep;
                double angleRadians = ToRadian(angle);
                double distance = function(angleRadians);
                double normalAngle = NormalizeAngle(angle);
                points.Add(new Point(normalAngle, distance));
            }
            return points;
        }
        double ArchimedeanSpiralFunction(double angleRadians) {
            return angleRadians;
        }
        double PolarRoseFunction(double angleRadians) {
            return Math.Max(0.0, Math.Sin(roseParameter * angleRadians));
        }
        double PolarFoliumFunction(double angleRadians) {
            double sin = Math.Sin(angleRadians);
            double cos = Math.Cos(angleRadians);
            return (3.0 * sin * cos) / (Math.Pow(sin, 3.0) + Math.Pow(cos, 3.0));
        }

        public List<Point> CreateArchimedeanSpiralData() {
            return CreatePolarFunctionPoints(0.0, 720.0, spiralIntervalsCount, ArchimedeanSpiralFunction);
        }
        public List<Point> CreateRoseData() {
            return CreatePolarFunctionPoints(0.0, 1440.0, roseIntervalsCount, PolarRoseFunction);
        }
        public List<Point> CreateFoliumData() {
            var points1 = CreatePolarFunctionPoints(120.0, 180.0, foliumSegmentIntervalsCount, PolarFoliumFunction);
            var points2 = CreatePolarFunctionPoints(0.0, 90.0, foliumSegmentIntervalsCount, PolarFoliumFunction);
            var points3 = CreatePolarFunctionPoints(270.0, 330.0, foliumSegmentIntervalsCount, PolarFoliumFunction);
            return FilterPointsByRange(points1.Concat(points2).Concat(points3).ToList(), 0.0, foliumDistanceLimit);
        }
    }


    class RadianScatterFunctionCalculator : ScatterFunctionCalculatorBase {
        protected override double NormalizeAngle(double angle) {
            return angle % (Math.PI * 2.0);
        }
        protected override double ToRadian(double angle) {
            return angle;
        }
        protected override double FromDegrees(double angle) {
            return angle * Math.PI / 180.0;
        }
    }


    class DegreeScatterFunctionCalculator : ScatterFunctionCalculatorBase {
        protected override double NormalizeAngle(double angle) {
            return angle % 360;
        }
        protected override double ToRadian(double angle) {
            return angle * Math.PI / 180.0;
        }
        protected override double FromDegrees(double angle) {
            return angle;
        }
    }
    #endregion

    #region Scatter Line ViewModels

    public static ChartDataSourceViewModel<Point> CreatePolarScatterLineViewModel() {
        return CreateScatterViewModel(new DegreeScatterFunctionCalculator());
    }
    public static ChartDataSourceViewModel<Point> CreateRadarScatterLineViewModel() {
        return CreateScatterViewModel(new RadianScatterFunctionCalculator());
    }

    static ChartDataSourceViewModel<Point> CreateScatterViewModel(ScatterFunctionCalculatorBase calculator) {
        var viewModel = ViewModelSource.Create<ChartDataSourceViewModel<Point>>();
        viewModel.Sources = new List<ChartDataSource<Point>> {
                new ChartDataSource<Point> { Description = "Archimedean Spiral", DataSource = calculator.CreateArchimedeanSpiralData() },
                new ChartDataSource<Point> { Description = "Polar Rose", DataSource = calculator.CreateRoseData() },
                new ChartDataSource<Point> { Description = "Polar Folium", DataSource = calculator.CreateFoliumData() }
            };
        viewModel.SelectedSource = viewModel.Sources.First();
        return viewModel;
    }

    #endregion

    #region Polar ViewModel

    public static ChartDataSourceViewModel<RangeDataPoint> CreatePolarViewModel() {
        var viewModel = ViewModelSource.Create<ChartDataSourceViewModel<RangeDataPoint>>();
        viewModel.Sources = new List<ChartDataSource<RangeDataPoint>> {
                new ChartDataSource<RangeDataPoint> { Description = "Taubin's Heart", DataSource = PolarFunctionsPointGenerator.CreateTaubinsHeartData() },
                new ChartDataSource<RangeDataPoint> { Description = "Cardioid", DataSource = PolarFunctionsPointGenerator.CreateCardioidData() },
                new ChartDataSource<RangeDataPoint> { Description = "Lemniscate", DataSource = PolarFunctionsPointGenerator.CreateLemniskateData() }
            };
        viewModel.SelectedSource = viewModel.Sources.Last();
        return viewModel;
    }

    #endregion

    #region Cartesian ViewModel

    public static ChartDataSourceViewModel<Point> CreateCartesianViewModel() {
        var viewModel = ViewModelSource.Create<ChartDataSourceViewModel<Point>>();
        viewModel.Sources = new List<ChartDataSource<Point>> {
                new ChartDataSource<Point> { Description = "Archimedean Spiral", DataSource = CartesianFunctionsPointGenerator.CreateArchimedianSpiralPoints() },
                new ChartDataSource<Point> { Description = "Cardioid", DataSource = CartesianFunctionsPointGenerator.CreateCardioidPoints() },
                new ChartDataSource<Point> { Description = "Cartesian Folium", DataSource = CartesianFunctionsPointGenerator.CreateCartesianFoliumPoints() }
            };
        viewModel.SelectedSource = viewModel.Sources.First();
        return viewModel;
    }

    #endregion
}
