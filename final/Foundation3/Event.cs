abstract class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;
    private int _attendanceCount = 0;

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public int GetAttendanceCount()
    {
        return _attendanceCount;
    }
    public abstract string GetEventType();
    public string GetDescription()
    {
        return _description;
    }

    public abstract bool MoreGuestsAllowed();
    public void AddGuest()
    {
        if (MoreGuestsAllowed())
            _attendanceCount++;
    }

    public string GetStandardDetails()
    {
        return $"Title: {_title}, Description: {_description}, Date: {_date}, Time: {_time}, Address: {_address.GetAddress()}";
    }
    public abstract string GetFullDetails();
    public string GetMarketingMessage()
    {
        return GetFullDetails() + '\n' + GetShortDescription();
    }

    public string GetShortDescription()
    {
        return $"Type: {GetEventType()}, Title: {_title}, Time: {_date} @ {_time}";
    }
    public void Display()
    {
        Console.WriteLine(GetMarketingMessage());
    }
}