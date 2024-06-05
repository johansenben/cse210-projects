class ExerciseTracker
{
    private List<Activity> _trackedActivities = new List<Activity>();

    public ExerciseTracker()
    {
        _trackedActivities.Add(new Cycling("04 June 2024", 45, 10));
        _trackedActivities.Add(new Running("05 June 2024", 30, 5));
        _trackedActivities.Add(new Swimming("06 June 2024", 20, 30));
    }
    public void Display()
    {
        foreach (Activity activity in _trackedActivities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}