using System;
namespace PP_CourseWork_Students
{
    class Program
    {
        static private readonly string STUDENT_LABEL = "Студент:";
        private static readonly string DELIMETER = ", ";

        static void Main()
        {
            SemesterStatisticsLauncher();
        }

        static void SemesterStatisticsLauncher()
        {
            String studentNameInput = Console.ReadLine();

            if (studentNameInput == null || !studentNameInput.StartsWith(STUDENT_LABEL) || studentNameInput.Trim().Length <= STUDENT_LABEL.Length)
            {
                SemesterStatisticsLauncher();
            }
            String name = studentNameInput.Substring(STUDENT_LABEL.Length).Trim();
            
            String disciplinesInput = Console.ReadLine();
            String[] discElements = disciplinesInput.Trim().Split(";");
            
            Student student = new Student(name);

            foreach (String item in discElements)
            {
                Discipline d = ReadDisciplineInput(item);
                if(d == null) { continue; }
                student.AddDiscipline(d);
            }
            Statistics.StudentStatistics statistics = new Statistics.StudentStatistics(student);

            Console.WriteLine(statistics);
            
        }

        private static Discipline ReadDisciplineInput(string input)
        {
            String[] items = input.Split(DELIMETER);
            Discipline discipline;
            try
            {
                discipline = new Discipline(byte.Parse(items[0]), items[1], ushort.Parse(items[2]), ushort.Parse(items[3]), items[4], float.Parse(items[5]));
            }
            catch {
                discipline = null;
                Console.WriteLine(Constants.Messages.INVALID_INPUT);
            }
            return discipline;
        }
    }
}
