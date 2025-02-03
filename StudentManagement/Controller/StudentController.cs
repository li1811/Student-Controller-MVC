using System;
using System.Collections.Generic;

namespace StudentManagement;

public class StudentController
{
    private List<Student> students = new List<Student>();
    private StudentView view = new StudentView();
    private int nextId = 1;

    public void AddStudent ()
    {
        Console.WriteLine("\nEnter student name: ");
        string name = Console.ReadLine() ?? "Name not given";
        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine()?? "0");
        Console.Write("Enter email: ");
        string email = Console.ReadLine() ?? "Email not given";

        students.Add(new Student {
            Id = nextId++, 
            Name = name,
            Age = age, 
            Email = email
        });

        Console.WriteLine("Student added successfully.");
    }

    public void ListStudents()
    {
        view.DisplayStudentList(students);
    }

    public void ShowStudent()
    {
        Console.WriteLine("Enter ID of the student you want to show:");
        int id = int.Parse(Console.ReadLine() ?? "0");
        var existingStudent = students.Find(s => s.Id == id);
        if (existingStudent != null)
        {
            view.DisplayStudent(existingStudent);
        }
        else 
        {
            Console.WriteLine("Student not found");
        }
    }

    public void EditStudent()
    {
        Console.WriteLine("Enter ID of student the student you want to edit:");
        int id = int.Parse(Console.ReadLine() ?? "0");
        var existingStudent = students.Find(s => s.Id == id);
        if (existingStudent != null)
        {
            Console.Write("Enter new name: ");
            existingStudent.Name = Console.ReadLine() ?? existingStudent.Name;
            Console.Write("Enter new age: ");
            existingStudent.Age = int.Parse(Console.ReadLine() ?? existingStudent.Age.ToString());
            Console.Write("Enter new email: ");
            existingStudent.Email = Console.ReadLine() ?? existingStudent.Email;
            Console.WriteLine("Student information updated successfully");
        }
        else 
        {
            Console.WriteLine("Student not found");
        }
    }

    public void DeleteStudent()
    {
        
        Console.Write("\nEnter Student ID to Delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var existingStudent = students.Find(s => s.Id == id);
            if (existingStudent != null)
            {
                students.Remove(existingStudent);
                Console.WriteLine("Student deleted successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
    }


}