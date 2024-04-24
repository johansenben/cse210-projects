
public class Resume
{
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        foreach (Job job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}