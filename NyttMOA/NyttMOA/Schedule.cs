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
        DateTime Date { get; set; }

        List<Lesson> SortLessonsByTime(List<Lesson> lessons)
        {
            lessons.Sort((x, y) => DateTime.Compare(x.StartTime, y.StartTime));
            return lessons;
        }

        public IEnumerable<Lesson> GetSchedule(Student student)
        {
            List<Lesson> schedule = new List<Lesson>();
            foreach (Lesson i in this.lessons)
            {
                if (i.Course.Students.Contains(student))
                {
                    schedule.Add(i);
                }
            }
            return SortLessonsByTime(schedule);
        }

        public IEnumerable<Lesson> GetSchedule(Teacher teacher)
        {
            List<Lesson> schedule = new List<Lesson>();
            foreach (Lesson i in this.lessons)
            {
                if (i.Teacher == teacher)
                {
                    schedule.Add(i);
                }
            }
            return SortLessonsByTime(schedule);
        }

        public IEnumerable<Lesson> GetSchedule(Classroom classroom)
        {
            List<Lesson> schedule = new List<Lesson>();
            foreach (Lesson i in this.lessons)
            {
                if (i.Classroom == classroom)
                {
                    schedule.Add(i);
                }
            }
            return SortLessonsByTime(schedule);
        }

        public IEnumerable<Lesson> GetSchedule(Course course)
        {
            List<Lesson> schedule = new List<Lesson>();
            foreach (Lesson i in this.lessons)
            {
                if (i.Course == course)
                {
                    schedule.Add(i);
                }
            }
            return SortLessonsByTime(schedule);
        }

        public IEnumerable<Lesson> GetSchedule(Student student, DateTime startDate, DateTime endDate)
        {
            IEnumerable<Lesson> completeSchedule = GetSchedule(student);
            List<Lesson> schedule = new List<Lesson>();
            foreach (Lesson i in completeSchedule)
            {
                if (i.StartTime > startDate && i.EndTime < endDate)
                {
                    schedule.Add(i);
                }
            }
            return schedule;
        }

        public bool AddLesson(Lesson lesson) //Här måste vi kolla om lektionen redan är inlagd o sånt...
        {
            if (LessonResourcesAreAvailiable(lesson))
            {
                lessons.Add(lesson);
                return true;
            }
            else
            {
                return false;
            }
        }

        bool LessonResourcesAreAvailiable(Lesson lesson)
        {
            foreach (Lesson i in lessons)
            {
                if ((lesson.Classroom == i.Classroom ||
                    lesson.Teacher == i.Teacher ||
                    lesson.Course == i.Course) &&
                    (lesson.EndTime < i.StartTime ||
                    lesson.StartTime > i.EndTime))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Lesson
    {
        public Teacher Teacher { get; set; }
        public Classroom Classroom { get; set; }
        public Course Course { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Lesson(Teacher teacher, Classroom classroom, Course course, DateTime startTime, DateTime endTime)
        {
            Teacher = teacher;
            Classroom = classroom;
            Course = course;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
