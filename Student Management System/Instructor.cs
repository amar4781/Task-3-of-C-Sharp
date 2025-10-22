namespace Student_Management_System
{
    public class Instructor 
    {
        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }

        public int InstructorId { get; init; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public void PrintDetails()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Instructor Details =====");
            Console.ResetColor();
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {InstructorId}");
            Console.WriteLine($"Specialization: {Specialization}");
        }
    }
}
