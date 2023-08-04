using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public readonly int RollNumber;
    public string Grade { get; set; }

    public Student(){}

    public Student(string name, int age, int rollNumber, string grade)
    {
        Name = name;
        Age = age;
        RollNumber = rollNumber;
        Grade = grade;
    }
}

class StudentList<T>
{
    private List<T> students;

    public StudentList()
    {
        students = new List<T>();
    }

    public void AddStudent(T student)
    {
        students.Add(student);
        Console.WriteLine("Student added successfully!");
        Console.WriteLine();
    }

    public T GetStudentByName(string name)
    {
        return students.FirstOrDefault(s => (s as Student)?.Name == name);
    }

    public T GetStudentById(int rollNumber)
    {
        return students.FirstOrDefault(s => (s as Student)?.RollNumber == rollNumber);
    }

    public void DisplayAllStudents()
    {
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {(student as Student)?.Name}");
            Console.WriteLine($"Age: {(student as Student)?.Age}");
            Console.WriteLine($"Roll Number: {(student as Student)?.RollNumber}");
            Console.WriteLine($"Grade: {(student as Student)?.Grade}");
            Console.WriteLine();
        }
    }

    public void SerializeToJson(string filePath)
    {
        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
        Console.WriteLine("Student data serialized to JSON successfully!");
        Console.WriteLine();
    }

    public void DeserializeFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<T>>(json);
            Console.WriteLine("Student data deserialized from JSON successfully!");
            Console.WriteLine();
        }
        else{
            Console.WriteLine("Can't find the specified file");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        StudentList<Student> studentList = new StudentList<Student>();

        while (true)
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student by Name");
            Console.WriteLine("3. Search Student by ID");
            Console.WriteLine("4. Display All Students");
            Console.WriteLine("5. Serialize Student Data to JSON");
            Console.WriteLine("6. Deserialize Student Data from JSON");
            Console.WriteLine("7. Exit");
            Console.WriteLine();

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Roll Number: ");
                    int rollNumber = int.Parse(Console.ReadLine());
                    Console.Write("Enter Grade: ");
                    string grade = Console.ReadLine();

                    Student student = new Student(name, age, rollNumber, grade);
                    studentList.AddStudent(student);
                    break;

                case "2":
                    Console.Write("Enter Name to search: ");
                    string searchName = Console.ReadLine();
                    Student resultByName = studentList.GetStudentByName(searchName);
                    if (resultByName != null)
                    {
                        Console.WriteLine("Student found!");
                        Console.WriteLine($"Name: {resultByName.Name}");
                        Console.WriteLine($"Age: {resultByName.Age}");
                        Console.WriteLine($"Roll Number: {resultByName.RollNumber}");
                        Console.WriteLine($"Grade: {resultByName.Grade}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found!");
                    }
                    Console.WriteLine();
                    break;

                case "3":
                    Console.Write("Enter Roll Number to search: ");
                    int searchRollNumber = int.Parse(Console.ReadLine());
                    Student resultById = studentList.GetStudentById(searchRollNumber);
                    if (resultById != null)
                    {
                        Console.WriteLine("Student found!");
                        Console.WriteLine($"Name: {resultById.Name}");
                        Console.WriteLine($"Age: {resultById.Age}");
                        Console.WriteLine($"Roll Number: {resultById.RollNumber}");
                        Console.WriteLine($"Grade: {resultById.Grade}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found!");
                    }
                    Console.WriteLine();
                    break;

                case "4":
                    studentList.DisplayAllStudents();
                    break;

                case "5":
                    Console.Write("Enter file path to save JSON data: ");
                    string filePath = Console.ReadLine();
                    studentList.SerializeToJson(filePath);
                    break;

                case "6":
                    Console.Write("Enter file path to load JSON data: ");
                    string jsonFilePath = Console.ReadLine();
                    studentList.DeserializeFromJson(jsonFilePath);
                    break;

                case "7":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}