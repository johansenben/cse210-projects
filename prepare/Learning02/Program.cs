using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1.DisplayJobDetails();

        Job job2 = new Job();
        job2._jobTitle = "Web Developer";
        job2.DisplayJobDetails();

        Resume resume = new Resume();
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume.Display();
    }
}