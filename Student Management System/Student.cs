namespace Student_Management_System
{
    public class Student
    {
        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
            Courses = new List<Course>();
        }

        public int StudentId { get; init; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; } = [];

        public bool Enroll(Course course)
        {
            if (course == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can't enroll in a null course");
                Console.ResetColor();
                return false;
            }
            if (Courses.Any(c => c.CourseId == course.CourseId))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Student ID [{StudentId}] is already enrolled in course [{course.Title}] and not allowed to enrolled the same course again");
                Console.ResetColor();
                return false;
            }
            Courses.Add(course);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Student ID [{StudentId}] enrolled in course [{course.Title}]");
            Console.ResetColor();
            return true;
        }

        public void PrintDetails() 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Student Details =====");
            Console.ResetColor();
            Console.WriteLine($"Name {Name}");
            Console.WriteLine($"ID: {StudentId}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine("Courses registered in: ");
            if (Courses.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  There are no courses yet");
                Console.ResetColor();
            }
            else
            {
                foreach (var course in Courses)
                {
                    Console.WriteLine($"  -{course.Title} (Instructor: {course.Instructor.Name})");
                }
            }
        }
    }
}
