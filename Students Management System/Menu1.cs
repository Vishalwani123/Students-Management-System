using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Students_Management_System
{
    internal class Menu1
    {
        public void Me()
        {
            var logic = new StudentList1();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(" Student Management System ");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Students");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Add1(logic);
                        break;
                    case "2":
                        Display1(logic);
                        break;
                    case "3":
                        Search1(logic);
                        break;
                    case "4":
                        Update1(logic);
                        break;
                    case "5":
                        Delete1(logic);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        public static void Add1(StudentList1 logic)
        {

            try
            {
                var student = new Student1();

                Console.Write("Enter Student ID: ");
                student.StudentID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Name: ");
                student.Name = Console.ReadLine();


                Console.Write("Enter Age between 5-25: ");
                student.Age = int.Parse(Console.ReadLine());
                if (student.Age < 5 || student.Age > 25)
                {
                    throw new CustExp1("Age must be between 5 and 25.");
                }

                Console.Write("Enter Grade between A-F: ");
                student.Grade = Console.ReadLine().ToUpper();

                Console.Write("Enter Email: ");
                student.Email = Console.ReadLine();

                logic.Add2(student);

            }
            catch (CustExp1 e)
            {
                
                Console.WriteLine($"Custom Exception : {e.ToString()}");

            }
        }


        public static void Display1(StudentList1 logic)
        {
            Console.WriteLine();
            var students = logic.Get1();
            if (students.Count == 0)
            {
                Console.WriteLine("No student records available.");
            }
            else
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.StudentID}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}, Email: {student.Email}");
                }
            }

        }

        public static void Search1(StudentList1 logic)
        {
            Console.WriteLine();
            Console.Write("Search by Name : ");
            string name = Console.ReadLine();

            Console.Write("Search by Grade : ");
            string grade = Console.ReadLine();

            var results = logic.Search2(name, grade);


            if (results.Count == 0)
            {
                Console.WriteLine("No matching records found.");
            }
            else
            {
                foreach (var student in results)
                {
                    Console.WriteLine($"ID: {student.StudentID}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}, Email: {student.Email}");
                }
            }
        }

        public static void Update1(StudentList1 logic)
        {
            Console.WriteLine();
            Console.Write("Enter Student ID to update: ");
            int studentId = Convert.ToInt32(Console.ReadLine());

            var updatedStudent = new Student1();

            Console.Write("Enter New Name: ");
            updatedStudent.Name = Console.ReadLine();

            Console.Write("Enter New Age between 5-25: ");
            updatedStudent.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Grade between A-F: ");
            updatedStudent.Grade = Console.ReadLine().ToUpper();

            Console.Write("Enter New Email: ");
            updatedStudent.Email = Console.ReadLine();
           
                if (logic.Update2(studentId, updatedStudent))
                {
                    Console.WriteLine("Student updated successfully.");
                }
               
            }
 

        public static void Delete1(StudentList1 logic)
        {
            Console.WriteLine();
            Console.Write("Enter Student ID to delete: ");
            int studentId = int.Parse(Console.ReadLine());

            if (logic.Delete2(studentId))
            {
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student ID not found.");
            }
        }


    }
}
