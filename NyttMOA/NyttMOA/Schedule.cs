using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    public class Schedule
    {
        List<Lesson> lessons = new List<Lesson>();

        public Lesson GetLesson(Student student)
        {
            List<Lesson> lessonsTemp = new List<Lesson>();
            foreach (Lesson i in lessons)
            {
                if (i.Student == student)
                {
                    lessonsTemp.Add(i);
                }
            }
        }
    }

    class Lesson
    {
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public Classroom Classroom { get; set; }
        public TimeSpan Duration { get; set; }

        public Lesson(Student student, Teacher teacher, Classroom classroom, TimeSpan duration)
        {
            Student = student;
            Teacher = teacher;
            Classroom = classroom;
            Duration = duration;
        }
    }
}
