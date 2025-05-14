#nullable disable
using DevExpress.Map;
using DevExpress.Xpf.Map;

namespace DevExpress.AvaloniaXpfDemo.MapControlModules;

public static class BingKeyProvider {
    const string key = DevExpress.Map.Native.DXBingKeyVerifier.BingKeyWpfMapDemo;

    public static string BingKey { get { return key; } }
}
public static class AzureKeyProvider {
    const string key = "4N1lTIecnJuZPVsproIYPBTM4HHiSMQPdvsBbk7YCJoEZiPzYGv6JQQJ99AKACYeBjFllM6LAAAgAZMPq8QZ";

    public static string AzureKey { get { return key; } }
}
public enum TemperatureScale { Fahrenheit, Celsius };

public class DemoValuesProvider {
    public string DevexpressBingKey { get { return BingKeyProvider.BingKey; } }
    public string DevExpressAzureKey { get { return AzureKeyProvider.AzureKey; } }
    public IEnumerable<BingMapKind> BingMapKinds {
        get {
            return new BingMapKind[] { BingMapKind.Area, BingMapKind.Road, BingMapKind.Hybrid,
            BingMapKind.RoadLight, BingMapKind.RoadGray, BingMapKind.RoadDark };
        }
    }

    public IEnumerable<OpenStreetMapKind> OSMBaseLayers { get { return new OpenStreetMapKind[] { OpenStreetMapKind.Basic, OpenStreetMapKind.CycleMap, OpenStreetMapKind.Hot, OpenStreetMapKind.Transport }; } }
    public IEnumerable<object> OSMOverlayLayers { get { return new object[] { "None", OpenStreetMapKind.SeaMarks, OpenStreetMapKind.HikingRoutes, OpenStreetMapKind.CyclingRoutes, OpenStreetMapKind.PublicTransport }; } }
    public IEnumerable<string> ShapeMapTypes { get { return new string[] { "GDP", "Population", "Political" }; } }
    public IEnumerable<string> ShapefileMapTypes { get { return new string[] { "World", "Africa", "South America", "North America", "Australia", "Eurasia" }; } }

    public IEnumerable<TemperatureScale> TemperatureUnit { get { return new TemperatureScale[] { TemperatureScale.Celsius, TemperatureScale.Fahrenheit }; } }
    public IEnumerable<MarkerType> BubbleMarkerTypes {
        get {
            return new MarkerType[] { MarkerType.Circle, MarkerType.Cross, MarkerType.Diamond, MarkerType.Hexagon,
                                                                MarkerType.InvertedTriangle, MarkerType.Triangle, MarkerType.Pentagon, MarkerType.Plus,
                                                                MarkerType.Square, MarkerType.Star5, MarkerType.Star6, MarkerType.Star8 };
        }
    }
    public IEnumerable<BingRouteOptimization> RouteOptimizations { get { return new BingRouteOptimization[] { BingRouteOptimization.MinimizeTimeWithTraffic, BingRouteOptimization.MinimizeTime, BingRouteOptimization.MinimizeDistance }; } }
    public IEnumerable<BingTrafficIncidentType> TrafficIncidentTypes {
        get {
            return new BingTrafficIncidentType[] { BingTrafficIncidentType.Accident, BingTrafficIncidentType.Congestion,
            BingTrafficIncidentType.DisabledVehicle, BingTrafficIncidentType.MassTransit, BingTrafficIncidentType.Miscellaneous, BingTrafficIncidentType.OtherNews, BingTrafficIncidentType.PlannedEvent,
            BingTrafficIncidentType.RoadHazard, BingTrafficIncidentType.Construction, BingTrafficIncidentType.Alert, BingTrafficIncidentType.Weather };
        }
    }


    static List<Projection> projections = null;
    public List<Projection> Projections {
        get {
            if(projections == null)
                projections = PopulateProjectionData();
            return projections;
        }
    }
    public Projection DefaultProjection { get { return Projections[12]; } }

    static List<Projection> PopulateProjectionData() {
        Projection LAEAParent = new Projection() { Name = "Lambert Azimuthal Equal Area", PrjInstance = null };
        return new List<Projection>()  {
            new Projection() { Name = "Spherical Mercator", PrjInstance = new SphericalMercatorProjection() },
            new Projection() { Name = "Equal Area", PrjInstance = new EqualAreaProjection()},
            new Projection() { Name = "Equirectangular", PrjInstance = new EquirectangularProjection()},
            new Projection() { Name = "Elliptical Mercator", PrjInstance = new EllipticalMercatorProjection()},
            new Projection() { Name = "Miller", PrjInstance = new MillerProjection()},
            new Projection() { Name = "Equidistant", PrjInstance = new EquidistantProjection() },
            new Projection() { Name = "Lambert Cylindrical Equal Area", PrjInstance = new LambertCylindricalEqualAreaProjection() },
            LAEAParent,
            new Projection() { Name = "ETRS89", PrjInstance = new Etrs89LambertAzimuthalEqualAreaProjection(), ParentPrjName = LAEAParent.Name},
            new Projection() { Name = "North Pole", PrjInstance = new NorthPole(), ParentPrjName = LAEAParent.Name},
            new Projection() { Name = "South Pole", PrjInstance = new SouthPole(), ParentPrjName = LAEAParent.Name},
            new Projection() { Name = "Braun Stereographic", PrjInstance = new BraunStereographicProjection() },
            new Projection() { Name = "Kavrayskiy VII", PrjInstance = new KavrayskiyProjection() },
            new Projection() { Name = "Sinusoidal", PrjInstance = new SinusoidalProjection() },
            new Projection() { Name = "EPSG:4326", PrjInstance = new EPSG4326Projection()},
            };
    }
}
public class Projection {
    public string Name { get; set; }
    public ProjectionBase PrjInstance { get; set; }
    public string ParentPrjName { get; set; }
}

public class SouthPole : LambertAzimuthalEqualAreaProjectionBase {
    protected override bool IsPredefined { get { return false; } }
    public SouthPole() {
        OriginLatitude = -90.0;
        BoundingBox = new MapBounds(-180.0, -90.0, 180.0, 0.0);
    }
    public override GeoPoint MapUnitToGeoPoint(MapUnit mapPoint) {
        GeoPoint res = base.MapUnitToGeoPoint(mapPoint);
        if(mapPoint.X > 0.5 && mapPoint.Y > 0.5)
            res = new GeoPoint(res.GetY(), 180.0 + res.GetX());
        if(mapPoint.X <= 0.5 && mapPoint.Y > 0.5)
            res = new GeoPoint(res.GetY(), res.GetX() - 180.0);
        return res;
    }
}

public class NorthPole : LambertAzimuthalEqualAreaProjectionBase {
    protected override bool IsPredefined { get { return false; } }
    public NorthPole() {
        OriginLatitude = 90.0;
        BoundingBox = new MapBounds(-180.0, 0.0, 180.0, 90.0);
    }
    public override GeoPoint MapUnitToGeoPoint(MapUnit mapPoint) {
        GeoPoint res = base.MapUnitToGeoPoint(mapPoint);
        if(mapPoint.X >= 0.5 && mapPoint.Y < 0.5)
            res = new GeoPoint(res.GetY(), 180.0 + res.GetX());
        if(mapPoint.X < 0.5 && mapPoint.Y < 0.5)
            res = new GeoPoint(res.GetY(), res.GetX() - 180.0);
        return res;
    }
}