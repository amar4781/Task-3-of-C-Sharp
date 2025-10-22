namespace Student_Management_System
{
    public class StudentManager
    {
        public StudentManager(List<Student> students, List<Instructor> instructors, List<Course> courses)
        {
            Students = students;
            Instructors = instructors;
            Courses = courses;
        }

        public List<Student> Students { get; set; }
        public List<Instructor> Instructors { get; set; }
        public List<Course> Courses { get; set; }

        public bool AddStudent(Student student)
        {
            if (student == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can't add a null student");
                Console.ResetColor();
                return false;
            }
            if (Students.Any(s => s.StudentId == student.StudentId))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Student ID [{student.StudentId}] is already exist!");
                Console.ResetColor();
                return false;
            }
            Students.Add(student);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Student ID [{student.StudentId}] added successfully");
            Console.ResetColor();
            return true;
        }

        public bool AddCourse(Course course)
        {
            if (course == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can't add a null course");
                Console.ResetColor();
                return false;
            }
            if (Courses.Any(c => c.CourseId == course.CourseId))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Course ID [{course.CourseId}] is already exist!");
                Console.ResetColor();
                return false;
            }
            Courses.Add(course);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Course ID [{course.CourseId}] added successfully");
            Console.ResetColor();
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            if (instructor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can't add a null instructor");
                Console.ResetColor();
                return false;
            }
            if (Instructors.Any(i => i.InstructorId == instructor.InstructorId))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Instructor ID [{instructor.InstructorId}] is already exist!");
                Console.ResetColor();
                return false;
            }
            Instructors.Add(instructor);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Instructor ID [{instructor.InstructorId}] added successfully");
            Console.ResetColor();
            return true;
        }

        public Student FindStudent(int studentId)
        {
            var student = Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Student with ID [{studentId}] not found");
                Console.ResetColor();
            }
            return student;
        }

        public Course FindCourse(int courseId)
        {
            var course = Courses.FirstOrDefault(c => c.CourseId == courseId);
            if (course == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Course with ID [{courseId}] not found");
                Console.ResetColor();
            }
            return course;
        }

        public Instructor FindInstructor(int instructorId)
        {
            var instructor = Instructors.FirstOrDefault(i => i.InstructorId == instructorId);
            if (instructor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Instructor with ID [{instructorId}] not found");
                Console.ResetColor();
            }
            return instructor;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student == null || course == null)
            {
                return false;
            }

            return student.Enroll(course);
        }
    }
}
