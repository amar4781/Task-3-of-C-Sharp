namespace Student_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            var instructors = new List<Instructor>();
            var courses = new List<Course>();

            StudentManager manager = new(students, instructors, courses);
            bool Quit = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n===============================");
                Console.WriteLine("   Student Management System");
                Console.WriteLine("===============================");
                Console.WriteLine("1 - Add Student");
                Console.WriteLine("2 - Add Instructor");
                Console.WriteLine("3 - Add Course");
                Console.WriteLine("4 - Enroll Student In Course");
                Console.WriteLine("5 - Show All Students");
                Console.WriteLine("6 - Show All Courses");
                Console.WriteLine("7 - Show All Instructors");
                Console.WriteLine("8 - Find Student By Id");
                Console.WriteLine("9 - Find Course By Id");
                Console.WriteLine("0 - Quit");
                Console.WriteLine("===============================");
                Console.Write("==> ");
                Console.ResetColor();

                if(!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input, Please enter a number.");
                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddStudent(manager);
                        break;
                    case 2:
                        AddInstructor(manager);
                        break;
                    case 3:
                        AddCourse(manager);
                        break;
                    case 4:
                        EnrollStudentInCourse(manager);
                        break;
                    case 5:
                        ShowAllStudents(manager);
                        break;
                    case 6:
                        ShowAllCourses(manager);
                        break;
                    case 7:
                        ShowAllInstructors(manager);
                        break;
                    case 8:
                        FindStudentById(manager);
                        break;
                    case 9:
                        FindCourseById(manager);
                        break;
                    case 0:
                        Quit = true;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("GoodBye - See you later!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input, Please enter a number.");
                        Console.ResetColor();
                        break;
                }
            }
            while (!Quit);
        }

        static void AddStudent(StudentManager manager)
        {
            Console.WriteLine("Enter Student ID: ");
            if (!int.TryParse(Console.ReadLine(),out int studentId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for student id, Please enter a number.");
                Console.ResetColor();
            }

            Console.WriteLine("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Student Age");
            if (!int.TryParse(Console.ReadLine(),out int age))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for student id, Please enter a number.");
                Console.ResetColor();
            }

            Student student = new(studentId,name,age);

            manager.AddStudent(student);
        }

        static void AddInstructor(StudentManager manager)
        {
            Console.WriteLine("Enter an instructorId: ");
            if (!int.TryParse(Console.ReadLine(),out int instructorId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for instructor id, Please enter a number.");
                Console.ResetColor();
            }

            Console.WriteLine("Enter an instructor name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter an instructor specialization: ");
            string specialization = Console.ReadLine();

            Instructor instructor = new(instructorId,name,specialization);

            manager.AddInstructor(instructor);
        }

        static void AddCourse(StudentManager manager)
        {
            Console.WriteLine("Enter course Id: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for course id, Please enter a number.");
                Console.ResetColor();
            }

            Console.WriteLine("Enter course name: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter an instructor id for this course: ");
            if (!int.TryParse(Console.ReadLine(), out int instructorId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for instructor id, Please enter a number.");
                Console.ResetColor();
            }

            Instructor instructor = manager.FindInstructor(instructorId);

            Course course = new(courseId,title,instructor);

            manager.AddCourse(course);
        }

        static void EnrollStudentInCourse(StudentManager manager)
        {
            Console.WriteLine("Enter Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for student id, Please enter a number.");
                Console.ResetColor();
            }

            Console.WriteLine("Enter course Id: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for course id, Please enter a number.");
                Console.ResetColor();
            }

            manager.EnrollStudentInCourse(studentId, courseId);
        }

        static void ShowAllStudents(StudentManager manager)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n======== All Students ========");
            Console.ResetColor();

            if (manager.Students.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no students yet!");
                Console.ResetColor();
            }
            else
            {
                foreach (var student in manager.Students)
                {
                    student.PrintDetails();
                }   
            }
        }

        static void ShowAllCourses(StudentManager manager)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n======== All Courses ========");
            Console.ResetColor();

            if (manager.Courses.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no courses yet!");
                Console.ResetColor();
            }
            else
            {
                foreach (var course in manager.Courses)
                {
                    course.PrintDetails();
                }
            }
        }

        static void ShowAllInstructors(StudentManager manager)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n======== All Instructors ========");
            Console.ResetColor();

            if (manager.Instructors.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no instructors yet!");
                Console.ResetColor();
            }
            else
            {
                foreach (var instructor in manager.Instructors)
                {
                    instructor.PrintDetails();
                }
            }
        }

        static void FindStudentById(StudentManager manager)
        {
            Console.WriteLine("Enter Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for student id, Please enter a number.");
                Console.ResetColor();
            }

            Student student = manager.FindStudent(studentId);
            if(student != null)
            {
                student.PrintDetails();
            }
        }

        static void FindCourseById(StudentManager manager)
        {
            Console.WriteLine("Enter Course ID: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for course id, Please enter a number.");
                Console.ResetColor();
            }

            Course course = manager.FindCourse(courseId);
            if (course != null)
            {
                course.PrintDetails();
            }
        }
    }
}
