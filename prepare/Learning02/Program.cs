using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2020;

        Job job2 = new Job();
        job2._jobTitle = "Devops Engineer";
        job2._company = "AWS";
        job2._startYear = 2020;
        job2._endYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "Anthony Izekor";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();

        
        
    }
}