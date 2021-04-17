
namespace PP_CourseWork_Students
{
    class Discipline
    {
        public short Semester { get; }
        string Name { get; }
        public ushort LectureHorarium { get; }
        public ushort PracticeHorarium { get; }
        string AcademicName;
        public float Grade { get; }

        public Discipline(short semester, string name, ushort lectureHorarium, ushort practiceHorarium, string academicName, float grade)
        {
            Semester = semester;
            Name = name;
            LectureHorarium = lectureHorarium;
            PracticeHorarium = practiceHorarium;
            AcademicName = academicName;
            Grade = grade;
        }
    }
}
