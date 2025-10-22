namespace Student_Management_System
{
    public class Course
    {
        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            Instructor = instructor;
        }

        public int CourseId { get; init; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }

        public void PrintDetails()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Course Details =====");
            Console.ResetColor();
            Console.WriteLine($"Name: {Title}");
            Console.WriteLine($"ID: {CourseId}");
            Console.WriteLine($"Instructor: {Instructor.Name} (Specialization: {Instructor.Specialization})");
        }
    }
}
