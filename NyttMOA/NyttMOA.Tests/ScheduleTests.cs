using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NyttMOA;

namespace NyttMOA.Tests
{
    [TestFixture]
    public class SceduleTests
    {
        [Test]
        public void AddLessonReturnsTrueAndAddsLessonIfTeacherAndClassroomIsAvailableAtSpecifiedTime()
        {
            ScheduleManager sut = new ScheduleManager();
            Teacher teacher = new Teacher(
                    "Name",
                    "TestTeacher1",
                    "bestPasswordEver"
                );
            Course testCourse = new Course(
                "TestCourse1",
                DateTime.Now,
                DateTime.Now.AddDays(3),
                30
            );
            Lesson lesson = new Lesson(
                teacher,
                new Classroom(
                    "Classroom1",
                    37
                ),
                testCourse,
                DateTime.Now.AddHours(1),
                DateTime.Now.AddHours(3)
            );

            Assert.True(sut.AddLesson(lesson));
            Assert.AreEqual(1, sut.Lessons.Count());
        }

        [Test]
        public void AddLessonReturnsFalseAndDoesNotAddLessonIfClassroomIsUnavailableAtSpecifiedTime()
        {
            ScheduleManager sut = new ScheduleManager();
            Teacher teacher1 = new Teacher(
                "Name",
                "TestTeacher1",
                "bestPasswordEver"
            );
            Teacher teacher2 = new Teacher(
                "Name",
                "TestTeacher2",
                "bestPasswordEver"
            );
            Course testCourse1 = new Course(
                "TestCourse1",
                DateTime.Now,
                DateTime.Now.AddDays(3),
                30
            );
            Course testCourse2 = new Course(
                "TestCourse2",
                DateTime.Now,
                DateTime.Now.AddDays(3),
                30
            );
            Classroom classroom =  new Classroom(
                "The only classroom",
                37
            );
            DateTime startTime = DateTime.Now.AddDays(1);
            DateTime endTime = DateTime.Now.AddDays(3);

            Lesson lesson1 = new Lesson(
                teacher1,
                classroom, //Same classroom
                testCourse1,
                startTime,
                endTime
            );
            Lesson lesson2 = new Lesson(
                teacher2,
                classroom, //Same classroom
                testCourse2,
                startTime,
                endTime
            );

            sut.AddLesson(lesson1);
            Assert.False(sut.AddLesson(lesson2));
            Assert.AreEqual(1, sut.Lessons.Count());
        }

        [Test]
        public void AddLessonReturnsFalseAndDoesNotAddLessonIfTeacherIsUnavailableAtSpecifiedTime()
        {
            ScheduleManager sut = new ScheduleManager();
            Teacher teacher = new Teacher(
                "Name",
                "TestTeacher1",
                "bestPasswordEver"
            );
            Course testCourse1 = new Course(
                "TestCourse1",
                DateTime.Now,
                DateTime.Now.AddDays(3),
                30
            );
            Course testCourse2 = new Course(
                "TestCourse2",
                DateTime.Now,
                DateTime.Now.AddDays(3),
                30
            );
            Classroom classroom1 = new Classroom(
                "The only classroom",
                37
            );
            Classroom classroom2 = new Classroom(
                "The only classroom",
                37
            );
            DateTime startTime = DateTime.Now.AddDays(1);
            DateTime endTime = DateTime.Now.AddDays(3);

            Lesson lesson1 = new Lesson(
                teacher,    //Same teacher
                classroom1,
                testCourse1,
                startTime,
                endTime
            );
            Lesson lesson2 = new Lesson(
                teacher,    //Same teacher
                classroom2,
                testCourse2,
                startTime,
                endTime
            );

            sut.AddLesson(lesson1);
            Assert.False(sut.AddLesson(lesson2));
            Assert.AreEqual(1, sut.Lessons.Count());
        }

        [Test]
        public void GetScheduleStudentReturnsCorrectSchedule()
        {
            ScheduleManager sut = new ScheduleManager();
            Student student = new Student("Namn Namnsson", "user123", "passAwesome");
            Teacher teacher1 = new Teacher(
                "Name",
                "TestTeacher1",
                "bestPasswordEver"
            );
            Teacher teacher2 = new Teacher(
                "Name",
                "TestTeacher1",
                "bestPasswordEver"
            );
            Course testCourse1 = new Course(
                "TestCourse1",
                DateTime.Now,
                DateTime.Now.AddDays(10),
                30
            );
            Course testCourse2 = new Course(
                "TestCourse2",
                DateTime.Now,
                DateTime.Now.AddDays(10),
                30
            );
            Classroom classroom1 = new Classroom(
                "The only classroom",
                37
            );
            Classroom classroom2 = new Classroom(
                "The only classroom",
                37
            );
            DateTime startTime1 = DateTime.Now.AddDays(1);
            DateTime endTime1 = DateTime.Now.AddDays(2);
            DateTime startTime2 = DateTime.Now.AddDays(3);
            DateTime endTime2 = DateTime.Now.AddDays(4);

            Lesson lesson1 = new Lesson(
                teacher1,
                classroom1,
                testCourse1,
                startTime1,
                endTime1
            );
            Lesson lesson2 = new Lesson(
                teacher2,
                classroom2,
                testCourse2,
                startTime2,
                endTime2
            );

            testCourse1.Students.Add(student);
            testCourse2.Students.Add(student);

            sut.AddLesson(lesson1);
            sut.AddLesson(lesson2);

            Assert.AreEqual(lesson1, sut.GetSchedule(student).Lessons.First());
            Assert.AreEqual(lesson2, sut.GetSchedule(student).Lessons.Last());
        }

        [Test]
        public void GetScheduleStudentWithinSpecifiedTimeReturnsCorrectSchedule()
        {
            ScheduleManager sut = new ScheduleManager();
            Student student = new Student("Namn Namnsson", "user123", "passAwesome");
            Teacher teacher1 = new Teacher(
                "Name",
                "TestTeacher1",
                "bestPasswordEver"
            );
            Teacher teacher2 = new Teacher(
                "Name",
                "TestTeacher1",
                "bestPasswordEver"
            );
            Course testCourse1 = new Course(
                "TestCourse1",
                DateTime.Now,
                DateTime.Now.AddDays(10),
                30
            );
            Course testCourse2 = new Course(
                "TestCourse2",
                DateTime.Now,
                DateTime.Now.AddDays(10),
                30
            );
            Classroom classroom1 = new Classroom(
                "The only classroom",
                37
            );
            Classroom classroom2 = new Classroom(
                "The only classroom",
                37
            );
            DateTime startTime1 = DateTime.Now.AddHours(1);
            DateTime endTime1 = DateTime.Now.AddHours(2);
            DateTime startTime2 = DateTime.Now.AddDays(3);
            DateTime endTime2 = DateTime.Now.AddDays(4);

            Lesson lesson1 = new Lesson(
                teacher1,
                classroom1,
                testCourse1,
                startTime1,
                endTime1
            );
            Lesson lesson2 = new Lesson(
                teacher2,
                classroom2,
                testCourse2,
                startTime2,
                endTime2
            );

            testCourse1.Students.Add(student);
            testCourse2.Students.Add(student);

            sut.AddLesson(lesson1);
            sut.AddLesson(lesson2);

            DateTime testStart = DateTime.Today;
            DateTime testEnd = DateTime.Today.AddDays(1);

            Assert.AreEqual(1, sut.GetSchedule(student, testStart, testEnd).Lessons.Count());
            Assert.AreEqual(lesson1, sut.GetSchedule(student, testStart, testEnd).Lessons.First());
        }

        [Test]
        public void GetScheduleTeacherReturnsCorrectSchedule()
        {
            ScheduleManager sut = new ScheduleManager();
            Teacher teacher1 = new Teacher(     //Teacher whos schedule is checked
                "Name",
                "TestTeacher1",
                "bestPasswordEver"
            );
            Course testCourse1 = new Course(
                "TestCourse1",
                DateTime.Now,
                DateTime.Now.AddDays(10),
                30
            );
            Course testCourse2 = new Course(
                "TestCourse2",
                DateTime.Now,
                DateTime.Now.AddDays(10),
                30
            );
            Classroom classroom1 = new Classroom(
                "The only classroom",
                37
            );
            Classroom classroom2 = new Classroom(
                "The only classroom",
                37
            );
            DateTime startTime1 = DateTime.Now.AddDays(1);
            DateTime endTime1 = DateTime.Now.AddDays(2);
            DateTime startTime2 = DateTime.Now.AddDays(3);
            DateTime endTime2 = DateTime.Now.AddDays(4);

            Lesson lesson1 = new Lesson(
                teacher1,
                classroom1,
                testCourse1,
                startTime1,
                endTime1
            );
            Lesson lesson2 = new Lesson(
                teacher1,
                classroom2,
                testCourse2,
                startTime2,
                endTime2
            );

            sut.AddLesson(lesson1);
            sut.AddLesson(lesson2);

            Assert.AreEqual(lesson1, sut.GetSchedule(teacher1).Lessons.First());
            Assert.AreEqual(lesson2, sut.GetSchedule(teacher1).Lessons.Last());
        }

        [Test]
        public void GetScheduleTeacherWithinSpecifiedTimeReturnsCorrectSchedule()
        {
            ScheduleManager sut = new ScheduleManager();
            Teacher teacher1 = new Teacher(     //Teacher whos schedule is checked
                "Name",
                "TestTeacher1",
                "bestPasswordEver"
            );
            Course testCourse1 = new Course(
                "TestCourse1",
                DateTime.Now,
                DateTime.Now.AddDays(10),
                30
            );
            Course testCourse2 = new Course(
                "TestCourse2",
                DateTime.Now,
                DateTime.Now.AddDays(10),
                30
            );
            Classroom classroom1 = new Classroom(
                "The only classroom",
                37
            );
            Classroom classroom2 = new Classroom(
                "The only classroom",
                37
            );
            DateTime startTime1 = DateTime.Now.AddHours(1);
            DateTime endTime1 = DateTime.Now.AddHours(2);
            DateTime startTime2 = DateTime.Now.AddDays(1);
            DateTime endTime2 = DateTime.Now.AddDays(2);

            Lesson lesson1 = new Lesson(
                teacher1,
                classroom1,
                testCourse1,
                startTime1,
                endTime1
            );
            Lesson lesson2 = new Lesson(
                teacher1,
                classroom2,
                testCourse2,
                startTime2,
                endTime2
            );

            sut.AddLesson(lesson1);
            sut.AddLesson(lesson2);

            DateTime testStart = DateTime.Today;
            DateTime testEnd = DateTime.Today.AddDays(1);

            Assert.AreEqual(1, sut.GetSchedule(teacher1, testStart, testEnd).Lessons.Count());
            Assert.AreEqual(lesson1, sut.GetSchedule(teacher1, testStart, testEnd).Lessons.First());
        }
    }
}
