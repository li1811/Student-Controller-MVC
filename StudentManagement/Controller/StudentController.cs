using System;
using System.IO;
// Step one add json namespace
using System.Text.Json;
using System.Collections.Generic;

namespace StudentManagement;

public class StudentController
{
    private List<Student> students = new List<Student>();
    private StudentView view = new StudentView();
    private int nextId = 1;
    // Step 2: we add file path
    private string filePath = "students.json";

    // Step 3 we add constructor
    public StudentController()
    {
        LoadFromFile(); // for file handling
    }
    public void AddStudent ()
    {
        Console.WriteLine("\nEnter student name: ");
        string name = Console.ReadLine() ?? "Name not given";
        Console.Write("Enter age: ");
        bool ageCheck = false;
        int age = 0;
        while(!ageCheck)
        {
            Console.WriteLine("Invalid input, please try again");
            ageCheck = int.TryParse(Console.ReadLine()?? "0", out age);

        }
        Console.Write("Enter email: ");
        string email = Console.ReadLine() ?? "Email not given";

        students.Add(new Student {
            Id = nextId++, 
            Name = name,
            Age = age, 
            Email = email
        });

        Console.WriteLine("Student added successfully.");
        SaveToFile();
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
            bool ageCheck = false;
            int age = 0;
            while(!ageCheck)
        {
            Console.WriteLine("Invalid input, please try again");
            ageCheck = int.TryParse(Console.ReadLine()?? "0", out age);

        }
            Console.Write("Enter new email: ");
            existingStudent.Email = Console.ReadLine() ?? existingStudent.Email;
            SaveToFile();
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
                SaveToFile();
                Console.WriteLine("Student deleted successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
    }

    private void SaveToFile()
    {
        string jsonData = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true});
        File.WriteAllText(filePath, jsonData);
    }

    private void LoadFromFile()
    {
        string jsonData = File.ReadAllText(filePath);
        students = JsonSerializer.Deserialize<List<Student>>(jsonData) ?? new List<Student>();

        // Ensure nextId is correct 
        if ( students.Count > 0)
        {
            nextId = students.Max(s => s.Id) + 1;
        }
    }

}