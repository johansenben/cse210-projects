class Reception : Event
{
    private List<string> _namesRegistered = new List<string>();
    private string _email;

    public Reception(string email, string title, string description, string date, string time, Address address) : base(title, description, date, time, address)
    {
        _email = email;
    }

    public override string GetEventType()
    {
        return "Reception";
    }

    public override string GetFullDetails()
    {
        return GetStandardDetails() + '\n'
            + $"Type: {GetEventType()}, Contact for RSVP: {_email}";
    }

    public override bool MoreGuestsAllowed()
    {
        return true; //no capacity, but guests are required to register
    }
    public void RegisterGuest(string guestName)
    {
        _namesRegistered.Add(guestName);
        AddGuest();
    }
}