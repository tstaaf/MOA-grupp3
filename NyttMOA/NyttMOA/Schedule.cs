using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    public class ScheduleManager
    {
        public Schedule mainSchedule = new Schedule();
        public IEnumerable<Lesson> Lessons => mainSchedule.Lessons;

        public Schedule GetSchedule(Student student)
        {
            return new Schedule(mainSchedule.Lessons.Where(a => a.Course.Students.Contains(student)));
        }

        public Schedule GetSchedule(Teacher teacher)
        {
            return new Schedule(mainSchedule.Lessons.Where(a => a.Course.Teacher == teacher));
        }

        public Schedule GetSchedule(Classroom classroom)
        {
            return new Schedule(mainSchedule.Lessons.Where(a => a.Classroom == classroom));
        }

        public Schedule GetSchedule(Course course)
        {
            return new Schedule(mainSchedule.Lessons.Where(a => a.Course == course));
        }

        public Schedule GetSchedule(Student student, DateTime startDate, DateTime endDate)
        {
            return new Schedule(GetSchedule(student).Lessons.Where(a => a.StartTime >= startDate && a.EndTime <= endDate));
        }

        public Schedule GetSchedule(Teacher teacher, DateTime startDate, DateTime endDate)
        {
            return new Schedule(GetSchedule(teacher).Lessons.Where(a => a.StartTime >= startDate && a.EndTime <= endDate));
        }

        public Schedule GetSchedule(Classroom classroom, DateTime startDate, DateTime endDate)
        {
            return new Schedule(GetSchedule(classroom).Lessons.Where(a => a.StartTime >= startDate && a.EndTime <= endDate));
        }

        public Schedule GetSchedule(Course course, DateTime startDate, DateTime endDate)
        {
            return new Schedule(GetSchedule(course).Lessons.Where(a => a.StartTime >= startDate && a.EndTime <= endDate));
        }


        public bool AddLesson(Lesson lesson)
        {
            if (!LessonCanBeScheduled(lesson)) return false;
            mainSchedule.AddLesson(lesson);
            return true;
        }

        public bool AddLesson(IEnumerable<Lesson> lessons)
        {
            if (lessons.Any(i => !LessonCanBeScheduled(i)))
            {
                return false;
            }
            foreach (Lesson i in lessons)
            {
                AddLesson(i);
            }
            return true;
        }

        public void RemoveLesson(Lesson lesson)
        {
            mainSchedule.RemoveLesson(lesson);
        }

        bool LessonCanBeScheduled(Lesson lesson)
        {
            foreach (Lesson i in mainSchedule.Lessons)
            {
                if ((lesson.Classroom == i.Classroom ||
                    lesson.Course.Teacher == i.Course.Teacher ||
                    lesson.Course == i.Course) &&
                    !(lesson.EndTime <= i.StartTime ||
                      lesson.StartTime >= i.EndTime))
                {
                    return false;
                }
            }
            if (lesson.StartTime > lesson.Course.EndDate || lesson.EndTime < lesson.Course.StartDate)
            {
                return false;
            }
            return lesson.Course.Students.Count() <= lesson.Classroom.Seats;
        }

        public override string ToString()
        {
            return mainSchedule.ToString();
        }
    }

    public class Schedule
    {
        List<Lesson> lessons;
        public IEnumerable<Lesson> Lessons { get { return lessons; } }

        public Schedule()
        {
            lessons = new List<Lesson>();
        }

        public Schedule(IEnumerable<Lesson> _lessons)
        {
            lessons = new List<Lesson>(_lessons);
        }

        void SortLessonsByStartTime()
        {
            lessons.OrderBy(x => x.StartTime);
        }

        public void AddLesson(Lesson lesson)
        {
            lessons.Add(lesson);
            SortLessonsByStartTime();
        }

        public void RemoveLesson(Lesson lesson)
        {
            lessons.Remove(lesson);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Lesson i in lessons)
            {
                output += i + Environment.NewLine;
            }
            output += "----------";
            return output;
        }
    }

    public class Lesson
    {
        public int ID { get; set; }
        public Classroom Classroom { get; set; }
        public Course Course { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Lesson(Classroom classroom, Course course, DateTime startTime, DateTime endTime)
        {
            Classroom = classroom;
            Course = course;
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
        {
            return
                "----------" + Environment.NewLine +
                StartTime + Environment.NewLine +
                EndTime + Environment.NewLine +
                Course.Name + Environment.NewLine +
                Classroom.Name + Environment.NewLine +
                Course.Teacher.Name;
        }
    }
}
