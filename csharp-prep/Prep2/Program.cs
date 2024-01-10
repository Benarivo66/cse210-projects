using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep2 World!");
        Console.WriteLine("What is your grade? ");
        string gradeString = Console.ReadLine();
        int grade = int.Parse(gradeString);
        string letter;

        if(grade >= 90) {
            letter = "A";
        }
        else if(grade >= 80) {
            letter = "B";
        }
        else if(grade >= 70) {
            letter = "C";
        }
        else if(grade >= 60) {
            letter = "D";
        }
        else {
            letter = "F";
        }

        Console.WriteLine(letter);

        if(grade >= 70){
            Console.WriteLine("Congratulations, you passed the course");
        }else {
            Console.WriteLine("Sorry you did not pass, try again next time");
        }
        
    }
}