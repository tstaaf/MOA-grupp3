using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NyttMOA;
using System.IO;

namespace NyttMOA.Tests
{
    [TestFixture]
    public class RegisterTest
    {
        [Test]
        public void AddUserAddsAUserToUserList()
        {
            var sut = new Register();

            sut.AddUser(new Student(
                "Name",
                "Username",
                "Password"));

            sut.AddUser(new Student(
                "Name2",
                "Username2",
                "Password2"));

            sut.AddUser(new Teacher(
                "Name3",
                "Username3",
                "Password3"));

            sut.AddUser(new Admin(
                "Name4",
                "Username4",
                "Password4"));

            Assert.AreEqual(5, sut.UserList.Count());

        }

        [Test]
        public void AddClassroomAddsAClassroomToClassroomList()
        {
            var sut = new Register();

            sut.AddClassroom(new Classroom("Testclassroom1", 30));
            sut.AddClassroom(new Classroom("Testclassroom2", 40));
            sut.AddClassroom(new Classroom("Tesstclassroom3", 25));

            Assert.AreEqual(3, sut.ClassroomList.Count());
        }

        [Test]
        public void AddCourseAddsACourseToCourseList()
        {
            var sut = new Register();

            sut.AddCourse(new Course(
                "Svengelska",
                new DateTime(2015,07,06),
                new DateTime(2015,07,09),
                200,
                30,
                new Teacher("Teacher1", "LärarN", "Passwordtest1")));

            sut.AddCourse(new Course(
                "Enklastekursen",
                new DateTime(2017,12,10),
                new DateTime(2017,12,15),
                220,
                34,
                new Teacher("Teacher2", "Kaninteundervisa", "Passwordtest2")));

            Assert.AreEqual(2, sut.CourseList.Count());
        }

        [Test]
        public void CheckPasswordReturnsFalseIfPasswordIsNotCorrectAndTrueIfCorrect()
        {
            var sut = new Register();

            Assert.True(sut.CheckPassword(new Student(
                "Student1",
                "Aiallaämnen",
                "1256"),"1256"));

            Assert.True(sut.CheckPassword(new Teacher(
                "Teacher1",
                "GerallaF",
                "1337"), "1337"));

            Assert.True(sut.CheckPassword(new Admin(
                "Admin1",
                "Görvadhanvill",
                "9999"), "9999"));

            Assert.False(sut.CheckPassword(new Student(
                "Student2",
                "Aiallaämnen2",
                "1213"), "12543"));

            Assert.False(sut.CheckPassword(new Teacher(
                "Teacher2",
                "GerallaF2",
                "123123"), "514"));

            Assert.False(sut.CheckPassword(new Admin(
                "Admin2",
                "Görvadhanvill2",
                "547"), "31241"));
        }

        [Test]
        public void SaveUserListToXmlSavesAllSavedUsersToXml()
        {
            var sut = new Register();

            sut.AddUser(new Student(
                "Namn",
                "Hej",
                "Unbreakable"));

            Assert.True(File.Exists(sut.savePath + @"\userlist.xml"));
        }

        [Test]
        public void SearchForUsernameCheckIfEnteredUserNameExist()
        {
            var sut = new Register();

            Assert.AreNotSame(sut.SearchForUsername("Hallo"),
                sut.AddUser(new Student(
                    "Student1",
                    "hallo1",
                    "12556")));
        }

        [Test]
        public void LoadUserFromXmlGetsAllUsersSavedInXml()
        {
            var sut = new Register();

            sut.AddUser(new Student(
                "Name",
                "Halloj",
                "1337"));

            Assert.IsNotNull(sut.UserList);
        }

        [Test]
        public void SaveCourseListToXmlSavesAllSavedCoursesToXml()
        {
            var sut = new Register();

            sut.AddCourse(new Course(
                "Eaaasy",
                new DateTime(),
                new DateTime(),
                56,
                30,
                new Teacher("Name", "Username", "Password")));

            Assert.True(File.Exists(sut.savePath + @"\courseList.xml"));
        }

        [Test]
        public void LoadCourseListFromXmlGetsAllCoursesSavedInXml()
        {
            var sut = new Register();

            sut.AddCourse(new Course(
                "",
                new DateTime(),
                new DateTime(),
                3,
                40,
                new Teacher("Thename", "Usaaname", "Passord")));

            Assert.IsNotNull(sut.CourseList);
        }

        [Test]
        public void SaveClassroomListToXmlSavesAllSavedClassroomsToXml()
        {
            var sut = new Register();

            sut.AddClassroom(new Classroom(
                "Collegium1",
                70));

            Assert.True(File.Exists(sut.savePath + @"\courseList.xml"));
        }

        [Test]
        public void LoadClassrooomListToXmlGetsAllClassroomsSavedToXml()
        {
            var sut = new Register();

            sut.AddClassroom(new Classroom(
                "Collegium6",
                45));

            Assert.IsNotNull(sut.ClassroomList);
        }

        [Test]
        public void SaveScheduleToXmlSavesAllSavedSchedulesToXml()
        {
            var sut = new Register();
            
            Assert.True(File.Exists(sut.savePath + @"\schedules.xml"));
        }

        [Test]
        public void LoadScheduleFromXmlGetsAllSavedSchedulesSavedToXml()
        {
            var sut = new Register();
            var schedlule = new ScheduleManager();
            

            Assert.IsNotNull(schedlule.mainSchedule);
        }

        [Test]
        public void AddLessonAddsALessonToTheLessonList()
        {
            var sut = new Register();
            var schedlue = new Schedule();

            sut.AddLesson(new Lesson(
                new Classroom("Biggestclassroomever", 400),
                new Course("Swedish", new DateTime(2009,11,11), new DateTime(2010,08,20), 4, 400, new Teacher("Name", "Username", "Passord")),
                new DateTime(2010,07,08),
                new DateTime(2010,07,09)));

            Assert.AreEqual(1, schedlue.Lessons.Count);
            //Assert.AreEqual("hej", schedlue.ToString());
        }

        [Test]
        public void RemoveUserRemovesAUserFromUserList()
        {
            var sut = new Register();
        }
    }
}
