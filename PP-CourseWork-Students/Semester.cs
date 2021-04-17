using System.Collections.Generic;

namespace PP_CourseWork_Students
{
    class Semester
    {
        public short SemesterID { get; }
        public List<Discipline> Disciplines { get; }

        public Semester(short semesterID)
        {
            SemesterID = semesterID;
            Disciplines = new List<Discipline>();
        }

        public void AddDiscipline(Discipline discipline)
        {
            Disciplines.Add(discipline);
        }
    }
}
