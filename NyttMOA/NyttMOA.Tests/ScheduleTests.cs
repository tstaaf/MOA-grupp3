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
        public void AddLessonReturnsTrueAndAddsLessonIfTeacherAndClassroomIsAvailable()
        {
            ScheduleManager sut = new ScheduleManager();
            Course testCourse = new Course(
                "TestCourse1",
                DateTime.Now,
                DateTime.Now.AddDays(3),
                30,
                "This should be a Teacher type"
            );
            Lesson lesson = new Lesson(
                new Teacher(
                    "Name",
                    "TestTeacher1",
                    "bestPasswordEver"
                ),
                new Classroom(
                    "Classroom1",
                    37,
                    "this should be a Course type"
                ),
                testCourse,
                new DateTime(2017, 11, 30, 9, 30, 0),
                new DateTime(2017, 11, 30, 15, 30, 0)
            );

            Assert.True(sut.AddLesson(lesson));
            Assert.AreEqual(1, sut.Lessons.Count());
        }

        [Test]
        public void AddLessonReturnsFalseAndDoesNotAddLessonIfClassroomIsUnavailable()
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
                30,
                "This should be a Teacher type"
            );
            Course testCourse2 = new Course(
                "TestCourse2",
                DateTime.Now,
                DateTime.Now.AddDays(3),
                30,
                "This should be a Teacher type"
            );
            Classroom classroom =  new Classroom(
                "The only classroom",
                37,
                "this should be a Course type"
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
        public void GetScheduleStudentReturnsCorrectSchedule()
        {

        }
    }
}
