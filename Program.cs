using System;
using System.Collections.Generic;

class Program
{
    static List<Student> students = FileManager.LoadStudents();

    static void Main()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n=== Student Management System ===");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Show Students");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ShowStudents();
                    break;
                case "3":
                    DeleteStudent();
                    break;
                case "4":
                    isRunning = false;
                    Console.WriteLine("Program ended.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter student ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter student age: ");
        int age = int.Parse(Console.ReadLine());

        Student newStudent = new Student(id, name, age);
        students.Add(newStudent);
        FileManager.SaveStudents(students);

        Console.WriteLine("Student added successfully.");
    }

    static void ShowStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine("\n--- Student List ---");
        foreach (Student student in students)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}");
        }
    }

    static void DeleteStudent()
    {
        Console.Write("Enter student ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        Student studentToRemove = students.Find(s => s.Id == id);

        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
            FileManager.SaveStudents(students);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}