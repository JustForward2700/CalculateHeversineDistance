namespace Ilmhub.HeversineDistanceCalculateApp;

internal struct Coordinate(double latitude, double longitude)
{
    const double EARTH_RADIUS = 6371;
    private double latitude = latitude;
    private double longitude = longitude;

    public double Latitude
    {
        get => latitude;
        set
        {
            if (value > 0)
                latitude = value;
            else
                throw new ArgumentException("Latitude must be positive number!");
        }
    }
    public double Longitude
    {
        get => longitude;
        set
        {
            if (value > 0)
                longitude = value;
            else
                throw new ArgumentException("Longitude must be positive number!");
        }
    }


    public Coordinate(string? stringPoint) : this(0, 0)
    {
        var pointCoordinates = stringPoint?.
            Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse).ToArray();

        if (pointCoordinates is { Length: 2 })
        {
            Latitude = ToRadian(pointCoordinates[0]);
            Longitude = ToRadian(pointCoordinates[1]);
        }
        else
        {
            Console.WriteLine("Iltimos nuqtaning kenglik va uzunlik qiymatlarini to'g'ri kiriting!");
            new Coordinate(Console.ReadLine());
        }
    }

    private double ToRadian(double angle)
    {
        return angle * Math.PI / 180;
    }

    public double GetHaversineDistance(Coordinate otherPoint)
    {
        double delta_Latitude = otherPoint.Latitude - latitude;
        double delta_Longitude = otherPoint.Longitude - longitude;

        double haversine = Math.Pow(Math.Sin(delta_Latitude / 2), 2) +
            Math.Cos(longitude) * Math.Cos(longitude) * Math.Pow(Math.Sin(delta_Longitude / 2), 2);

        return 2 * EARTH_RADIUS * Math.Asin(Math.Sqrt(haversine)) * 1000;
    }
}
