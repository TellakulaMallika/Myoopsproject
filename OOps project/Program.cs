using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOps_project
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create some sample data
            List<Student> students = new List<Student>
        {
            new Student("Mallika", "ClassA", "Section1"),
            new Student("Lakshmi", "ClassB", "Section2"),
            // Add more students as needed
        };

            List<Teacher> teachers = new List<Teacher>
        {
            new Teacher("Prudhvi", "ClassA", "Section1"),
            new Teacher("Swathi", "ClassB", "Section2"),
                // Add more teachers as needed
        };

            List<Subject> subjects = new List<Subject>
            {
                new Subject("Math", "MATH101", teachers[0]),
                new Subject("Science", "SCI202", teachers[1]),
            // Add more subjects as needed
        };

            // Perform operations
            DisplayStudents(students);
            DisplayTeachers(teachers);
            DisplaySubjects(subjects);
            DisplayStudentsInEveryClass(students);
            DisplaySubjectsTaughtByEveryTeacher(subjects, teachers);

            DisplayStudentsInClass(students,"ClassB");
            DisplaySubjectsTaughtByTeacher(subjects, teachers[0]);
           
        }

        static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine("Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Class: {student.Class}, Section: {student.Section}");
            }
            Console.WriteLine();
        }

        static void DisplayTeachers(List<Teacher> teachers)
        {
            Console.WriteLine("Teachers:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Name: {teacher.Name}, Class: {teacher.Class}, Section: {teacher.Section}");
            }
            Console.WriteLine();
        }

        static void DisplaySubjects(List<Subject> subjects)
        {
            Console.WriteLine("Subjects:");
            foreach (var subject in subjects)
            {
                Console.WriteLine($"Name: {subject.Name}, Code: {subject.Code}, Teacher: {subject.Teacher.Name}");
            }
            
        }
        static void DisplayStudentsInEveryClass(List<Student>students)
        {
            var uniqueClasses = students.Select(student => student.Class).Distinct();
            foreach(var className in uniqueClasses)
            {
                Console.WriteLine($"Students in Class {className}:");
                var studentsInClass = students.Where(student => student.Class == className);
                foreach(var student in studentsInClass)
                {
                    Console.WriteLine($"Name:{student.Name}");
                }
                Console.WriteLine();
            }
        }
        static void DisplaySubjectsTaughtByEveryTeacher(List<Subject>subjects,List<Teacher>teachers)
        {
            foreach(var teacher in teachers)
            {
                Console.WriteLine($"Subjects taught by {teacher.Name}:");
                var subjectsTaughtByTeacher = subjects.Where(subject => subject.Teacher == teacher);
                foreach(var subject in subjectsTaughtByTeacher)
                {
                    Console.WriteLine($"Name:{subject.Name}");
                }
                Console.WriteLine();
            }
        }

        static void DisplayStudentsInClass(List<Student>students,string className)
        {
            Console.WriteLine($"Students in Class {className}:");
            var studentsInClass = students.Where(student => student.Class == className);
            foreach (var student in studentsInClass)
            {
                Console.WriteLine($"Name: {student.Name},Class:{student.Class},Section:{student.Section}");
            }
            Console.WriteLine();

            
        }
        static void DisplaySubjectsTaughtByTeacher(List<Subject>subjects,Teacher teacher)
        {
            Console.WriteLine($"Subjects taught by {teacher.Name}:");
            var SubjectsTaughtByTeacher = subjects.Where(subject => subject.Teacher == teacher);
            foreach(var subject in SubjectsTaughtByTeacher)
            {
                Console.WriteLine($"Name:{subject.Name},Code:{subject.Code}");
            }
            Console.WriteLine();
        }

    }   
    class Student
    {
        public string Name { get; }
        public string Class { get; }
        public string Section { get; }

        public Student(string name, string className, string section)
        {
            Name = name;
            Class = className;
            Section = section;
        }
    }

    class Teacher
    {
        public string Name { get; }
        public string Class { get; }
        public string Section { get; }

        public Teacher(string name, string className, string section)
        {
            Name = name;
            Class = className;
            Section = section;
        }
    }

    class Subject
    {
        public string Name { get; }
        public string Code { get; }
        public Teacher Teacher { get; }

        public Subject(string name, string code, Teacher teacher)
        {
            Name = name;
            Code = code;
            Teacher = teacher;
        }
    }
}


    