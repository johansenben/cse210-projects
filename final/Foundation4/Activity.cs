abstract class Activity
{
    public static readonly double KM_PER_MILE = 1.60934; //used for conversions
    private string _date;
    private double _minutes;

    public Activity(string date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract string GetActivityType();
    public double GetMinutes()
    {
        return _minutes;
    }

    protected abstract double GetDistance(bool convertToMiles = false);
    protected abstract double GetSpeed(bool covertToMPH = false);
    protected abstract double GetPace(bool convertToMinPerMile = false);
    public string GetSummary()
    {
        return $"{_date} | {GetActivityType()} | ({_minutes} min) - Distance: {GetDistance().ToString("n2")} km ({GetDistance(true).ToString("n2")} miles) | Speed: {GetSpeed().ToString("n2")} km/h ({GetSpeed(true).ToString("n2")} MPH) | Pace: {GetPace().ToString("n2")} min per km ({GetPace(true).ToString("n2")} min per mile)";
    }
}