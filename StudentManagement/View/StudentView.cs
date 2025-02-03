using System;
using System.Collections.Generic;

namespace StudentManagement;

public class StudentView
{
    public void DisplayStudent(Student student)
    {
        Console.ForegroundColor=ConsoleColor.DarkMagenta;
        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Email: {student.Email}");
        Console.ResetColor();
    }
    public void DisplayStudentList (List<Student> students)
    {   
        if(students.Count == 0)
        {
            Console.WriteLine("No students in the list");
        }
        
        Console.WriteLine("\nStudent list:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Id}. {student.Name} - {student.Email}");
        }
        
    }
}