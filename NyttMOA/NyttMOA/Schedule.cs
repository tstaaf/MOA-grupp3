﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    public class ScheduleManager
    {
        Schedule mainSchedule = new Schedule();

        public Schedule GetSchedule(Student student)
        {
            Schedule schedule = new Schedule();
            foreach (Lesson i in schedule.Lessons)
            {
                if (i.Course.Students.Contains(student))
                {
                    schedule.AddLesson(i);
                }
            }
            return schedule;
        }

        public Schedule GetSchedule(Teacher teacher)
        {
            Schedule schedule = new Schedule();
            foreach (Lesson i in schedule.Lessons)
            {
                if (i.Teacher == teacher)
                {
                    schedule.AddLesson(i);
                }
            }
            return schedule;
        }

        public Schedule GetSchedule(Classroom classroom)
        {
            Schedule schedule = new Schedule();
            foreach (Lesson i in schedule.Lessons)
            {
                if (i.Classroom == classroom)
                {
                    schedule.AddLesson(i);
                }
            }
            return schedule;
        }

        public Schedule GetSchedule(Course course)
        {
            Schedule schedule = new Schedule();
            foreach (Lesson i in schedule.Lessons)
            {
                if (i.Course == course)
                {
                    schedule.AddLesson(i);
                }
            }
            return schedule;
        }

        public Schedule GetSchedule(Student student, DateTime startDate, DateTime endDate)
        {
            Schedule completeSchedule = GetSchedule(student);
            Schedule schedule = new Schedule();
            foreach (Lesson i in completeSchedule.Lessons)
            {
                if (i.StartTime > startDate && i.EndTime < endDate)
                {
                    schedule.AddLesson(i);
                }
            }
            return schedule;
        }

        public Schedule GetSchedule(Teacher teacher, DateTime startDate, DateTime endDate)
        {
            Schedule completeSchedule = GetSchedule(teacher);
            Schedule schedule = new Schedule();
            foreach (Lesson i in completeSchedule.Lessons)
            {
                if (i.StartTime > startDate && i.EndTime < endDate)
                {
                    schedule.AddLesson(i);
                }
            }
            return schedule;
        }

        public Schedule GetSchedule(Classroom classroom, DateTime startDate, DateTime endDate)
        {
            Schedule completeSchedule = GetSchedule(classroom);
            Schedule schedule = new Schedule();
            foreach (Lesson i in completeSchedule.Lessons)
            {
                if (i.StartTime > startDate && i.EndTime < endDate)
                {
                    schedule.AddLesson(i);
                }
            }
            return schedule;
        }

        public Schedule GetSchedule(Course course, DateTime startDate, DateTime endDate)
        {
            Schedule completeSchedule = GetSchedule(course);
            Schedule schedule = new Schedule();
            foreach (Lesson i in completeSchedule.Lessons)
            {
                if (i.StartTime > startDate && i.EndTime < endDate)
                {
                    schedule.AddLesson(i);
                }
            }
            return schedule;
        }


        public bool AddLesson(Lesson lesson)
        {
            if (LessonResourcesAreAvailiable(lesson))
            {
                mainSchedule.AddLesson(lesson);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddLesson(IEnumerable<Lesson> lessons)
        {
            foreach (Lesson i in lessons)
            {
                if (!LessonResourcesAreAvailiable(i))
                {
                    return false;
                }
            }
            foreach (Lesson i in lessons)
            {
                AddLesson(i);
            }
            return true;
        }

        bool LessonResourcesAreAvailiable(Lesson lesson)
        {
            foreach (Lesson i in lessons)
            {
                if ((lesson.Classroom == i.Classroom ||
                    lesson.Teacher == i.Teacher ||
                    lesson.Course == i.Course) &&
                    !((lesson.EndTime <= i.StartTime ||
                    lesson.StartTime >= i.EndTime)))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Schedule
    {
        List<Lesson> lessons = new List<Lesson>();
        public IEnumerable<Lesson> Lessons { get { return lessons; } }

        void SortLessonsByStartTime()
        {
            lessons.OrderBy(x => x.StartTime);
        }

        public void AddLesson(Lesson lesson)
        {
            lessons.Add(lesson);
            SortLessonsByStartTime();
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
