using System;

public class Hello
{
    public static void Main()
    {
        Console.WriteLine("Enter Your name : ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Number of courses: ");
        string number_of_course = Console.ReadLine();
        int number = int.Parse(number_of_course);

        Dictionary<string, int> subject = new Dictionary<string, int>();
        
        for(int i = 0; i < number; i++){
            Console.WriteLine("Enter subject name : ");
            string sName = Console.ReadLine();
            Console.WriteLine("Enter the grade: ");
            string grade = Console.ReadLine();
            int sGrade = int.Parse(grade);
            subject.Add(sName, sGrade);
        }

      
        Console.WriteLine($"Name: {name}");

        float sumC = 0;
        
        foreach( KeyValuePair<string, int> kvp in subject )
        {
            Console.WriteLine("Subject Name = {0}, Grade = {1}", kvp.Key, kvp.Value);
            sumC += kvp.Value;
        }
        Console.WriteLine($"The average is {sumC / number}");
    }

}