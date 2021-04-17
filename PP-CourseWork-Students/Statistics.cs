using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Students
{
    class Statistics
    {

        public class StudentStatistics
        {
            private readonly List<SemesterStatistics> SemesterStatistics;
            private readonly int TotalDisciplinesCount;
            private readonly float TotalGPA;
            private readonly string StudentName;

            public StudentStatistics(Student student)
            {
                SemesterStatistics = new List<SemesterStatistics>();
                StudentName = student.FullName;

                int disciplinesCount = 0;
                float gradesSum = 0f;
                float totalGradesSum = 0f;
                int horarium = 0;
                int totalHorarium = 0;

                foreach (Semester semester in student.Semesters.Values)
                {
                    disciplinesCount += semester.Disciplines.Count;

                    foreach (var discipline in semester.Disciplines)
                    {
                        gradesSum += discipline.Grade;
                        horarium += (discipline.LectureHorarium + discipline.PracticeHorarium);
                    }

                    totalGradesSum += gradesSum;
                    totalHorarium += horarium;
                    float gpa = gradesSum > 0 ? gradesSum / semester.Disciplines.Count : 0f;
                    SemesterStatistics.Add(new Statistics.SemesterStatistics(semester.SemesterID, gpa, horarium));
                    gradesSum = 0f;
                    horarium = 0;
                }
                TotalDisciplinesCount = disciplinesCount;
                TotalGPA = totalGradesSum > 0 ? totalGradesSum / disciplinesCount : 0f;
            }

            public override string ToString()
            {
                StringBuilder result = new StringBuilder(
                    String.Format(Constants.Messages.GENERAL_STATISTIC,
                    StudentName, TotalDisciplinesCount));
                for (int i = 0; i < SemesterStatistics.Count; i++)
                {
                    result.Append(String.Format("\t{0}. {1:F2}\n", i+1,SemesterStatistics[i].ToString()));
                }
                result.Append(String.Format(Constants.Messages.TOTAL_GPA,TotalGPA));
                return result.ToString();
            }
        }

        public struct SemesterStatistics
        {
            public short SemesterID { get; }
            public float GPA { get; } //Great Point Average
            public int TotalHorarium { get; }

            public SemesterStatistics(short semesterID, float gpa, int totalHorarium)
            {
                SemesterID = semesterID;
                GPA = gpa;
                TotalHorarium = totalHorarium;
            }

            public override string ToString()
            {
                return String.Format(Constants.Messages.SEMESTER_STATS, SemesterID, TotalHorarium, GPA);
            }
        }
    }
    
}
