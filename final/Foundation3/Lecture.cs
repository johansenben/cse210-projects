class Lecture : Event
{
    private string _speakerName;
    private int _capacity;

    public Lecture(string speakerName, int capacity, string title, string description, string date, string time, Address address) : base(title, description, date, time, address)
    {
        _speakerName = speakerName;
        _capacity = capacity;
    }

    public override string GetEventType()
    {
        return "Lecture";
    }

    public override string GetFullDetails()
    {
        return GetStandardDetails() + '\n'
            + $"Type: {GetEventType()}, Speaker Name: {_speakerName}, Capacity: {_capacity}\n"
            + GetDescription();
    }

    public override bool MoreGuestsAllowed()
    {
        return GetAttendanceCount() < _capacity;
    }
}