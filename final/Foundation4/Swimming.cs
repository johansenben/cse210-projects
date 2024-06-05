class Swimming : Activity
{
    private static readonly double LENGTH_OF_LAP = 50.0f / 1000; //km
    private int _laps;

    public Swimming(string date, float minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    protected override double GetDistance(bool convertToMiles)
    {
        return convertToMiles ? _laps * LENGTH_OF_LAP / KM_PER_MILE : _laps * LENGTH_OF_LAP;
    }
    protected override double GetSpeed(bool convertToMPH)
    {
        return GetDistance(convertToMPH) / (GetMinutes() / 60);
    }
    protected override double GetPace(bool convertToMinPerMile)
    {
        return GetMinutes() / GetDistance(convertToMinPerMile);
    }

    public override string GetActivityType()
    {
        return "Swimming";
    }
}