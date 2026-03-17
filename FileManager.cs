using System;
using System.Collections.Generic;
using System.IO;

public class FileManager
{
    private static string filePath = "students.txt";

    public static void SaveStudents(List<Student> students)
    {
        List<string> lines = new List<string>();

        foreach (Student student in students)
        {
            string line = $"{student.Id},{student.Name},{student.Age}";
            lines.Add(line);
        }

        File.WriteAllLines(filePath, lines);
    }

    public static List<Student> LoadStudents()
    {
        List<Student> students = new List<Student>();

        if (!File.Exists(filePath))
        {
            return students;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            int id = int.Parse(parts[0]);
            string name = parts[1];
            int age = int.Parse(parts[2]);

            Student student = new Student(id, name, age);
            students.Add(student);
        }

        return students;
    }
}