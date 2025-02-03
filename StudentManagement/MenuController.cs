namespace StudentManagement;

internal partial class Program
{
    public static void Menu()
    {
        string menuText = @$"
    1- Show Student
    2- Show Students
    3- Add Student
    4- Update Student
    5- Delete Student
    6- Exit Program
    
        ";

        // While loop
        while(true)
        {
            Console.Clear();
            // Show menu
            Console.WriteLine(menuText);
            Console.WriteLine("Please choose an option.");
            string userInput = Console.ReadLine() ?? "0";

            // Switch
            switch (userInput)
            {
                case "1":
                    studentController.ShowStudent();
                    break;
                case "2":
                    studentController.ListStudents();
                    break;
                case "3":
                    studentController.AddStudent();
                    break;
                case "4":
                    studentController.EditStudent();
                    break;
                case "5":
                    studentController.DeleteStudent();
                    break;
                case "6":
                    Console.WriteLine("Exiting program...");
                    Thread.Sleep(3000);
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Invalid option try again");
                    break;
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}