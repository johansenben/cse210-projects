class Cycling : Activity
{
    private double _speed; //km/h

    public Cycling(string date, float minutes, float speed, bool isKmPerHour = true) : base(date, minutes)
    {
        _speed = speed * (isKmPerHour ? 1 : KM_PER_MILE);
    }

    protected override double GetDistance(bool convertToMiles)
    {
        return _speed / (convertToMiles ? KM_PER_MILE : 1) * (GetMinutes() / 60);
    }
    protected override double GetSpeed(bool convertToMPH)
    {
        return convertToMPH ? _speed / KM_PER_MILE : _speed;
    }
    protected override double GetPace(bool convertToMinPerMile)
    {
        return GetMinutes() / GetDistance(convertToMinPerMile);
    }

    public override string GetActivityType()
    {
        return "Cycling";
    }
}