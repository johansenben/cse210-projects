class Running : Activity
{
    private double _distance;

    public Running(string date, float minutes, double distance, bool isKm = true) : base(date, minutes)
    {
        _distance = distance * (isKm ? 1 : KM_PER_MILE);
    }

    protected override double GetDistance(bool convertToMiles)
    {
        return convertToMiles ? _distance / KM_PER_MILE : _distance;
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
        return "Running";
    }
}