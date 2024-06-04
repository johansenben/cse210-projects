class OutdoorGathering : Event
{
    private string _weatherForcast;
    public OutdoorGathering(string weatherForcast, string title, string description, string date, string time, Address address) : base(title, description, date, time, address)
    {
        _weatherForcast = weatherForcast;
    }

    public override string GetEventType()
    {
        return "Outdoor Gathering";
    }

    public override string GetFullDetails()
    {
        return GetStandardDetails() + '\n'
            + $"Type: {GetEventType()}, Weather Forcast: {_weatherForcast}\n"
            + GetDescription();
    }

    public override bool MoreGuestsAllowed()
    {
        return true; //never at capacity; no limit
    }
}