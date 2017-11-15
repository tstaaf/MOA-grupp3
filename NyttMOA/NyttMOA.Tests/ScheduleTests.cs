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
        public void LessonsCanBeAddedToSchedule()
        {
            Schedule sut = new Schedule();
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

            //Add schedule...
        }
    }
}
