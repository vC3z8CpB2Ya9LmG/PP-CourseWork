using System.Collections.Generic;
using System.Collections.Specialized;

namespace PP_CourseWork_Students
{
    class Student
    {

        public string FullName { get; }
        public OrderedDictionary Semesters { get; }

        public Student(string fullName)
        {
            FullName = fullName;
            Semesters = new OrderedDictionary();
        }

        public Student(string fullName, List<Semester> semesters) : this(fullName)
        {
            Semesters = new OrderedDictionary();
            foreach (var item in semesters)
            {
                Semesters.Add(item.SemesterID,item);
            }
        }

        public void AddSemester(Semester semester)
        {
            Semesters.Add(semester.SemesterID, semester);
        }

        public void AddDiscipline(Discipline discipline)
        {
            Semester semester;
            if (Semesters.Contains(discipline.Semester.ToString()))
            {
                semester = (Semester)Semesters[discipline.Semester.ToString()];
                semester.AddDiscipline(discipline);
            }
            else
            {
                Semesters.Add(discipline.Semester.ToString(), new Semester(discipline.Semester));
                AddDiscipline(discipline);
            }
        }
    }
}
