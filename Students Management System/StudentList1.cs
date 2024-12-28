using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Management_System
{
    internal class StudentList1
    {
         List<Student1> stud1 = new List<Student1>();

        public void Add2(Student1 student)
        {
            stud1.Add(student);
            Console.WriteLine($"Student {student.Name} added successfully.");
        }

        public List<Student1> Get1()
        {
            return stud1.ToList();
        }

        // Merger Display And Search
        public List<Student1> Search2(string name, string grade)
        {
            return stud1.Where(student => (name != null && student.Name.Equals(name)) || (grade != null && student.Grade.Equals(grade))).ToList();

        }

        public bool Update2(int studentId, Student1 updatedStudent)
        {
            try
            {
                var student = stud1.FirstOrDefault(s => s.StudentID == studentId);
                if (student == null)
                {
                    throw new CustExp1("Student not found.");
                }
                student.Name = updatedStudent.Name;
                student.Age = updatedStudent.Age;
                student.Grade = updatedStudent.Grade;
                student.Email = updatedStudent.Email;
                return true;

            }
            catch (CustExp1 e)
            {
                
                Console.WriteLine($"Custom Exception : {e.ToString()}");
                return false;
            }

        }

        public bool Delete2(int studentId)
        {
            var student = stud1.FirstOrDefault(s => s.StudentID == studentId);
            if (student != null)
            {
                stud1.Remove(student);
                return true;
            }
            return false;
        }
    }
}
