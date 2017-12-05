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
    public class RegisterTest
    {
        [Test]
        public void AddUserAddsAUserToUserList()
        {
            Register.AddUser(new Student(
                "Name",
                "Username",
                "Password"));

            Register.AddUser(new Student(
                "Name2",
                "Username2",
                "Password2"));

            Register.AddUser(new Teacher(
                "Name3",
                "Username3",
                "Password3"));

            Register.AddUser(new Admin(
                "Name4",
                "Username4",
                "Password4"));

            Assert.AreEqual(5, Register.UserList.Count());

        }

        [Test]
        public void AddClassroomAddsAClassroomToClassroomList()
        {
            Register.AddClassroom(new Classroom("Testclassroom1", 30));
            Register.AddClassroom(new Classroom("Testclassroom2", 40));
            Register.AddClassroom(new Classroom("Tesstclassroom3", 25));

            Assert.AreEqual(3, Register.ClassroomList.Count());
        }

        [Test]
        public void AddCourseAddsACourseToCourseList()
        {
            Register.AddCourse(new Course(
                "Svengelska",
                new DateTime(2015,07,06),
                new DateTime(2015,07,09),
                30,
                new Teacher("Teacher1", "LärarN", "Passwordtest1")));

            Register.AddCourse(new Course(
                "Enklastekursen",
                new DateTime(2017,12,10),
                new DateTime(2017,12,15),
                34,
                new Teacher("Teacher2", "Kaninteundervisa", "Passwordtest2")));

            Assert.AreEqual(2, Register.CourseList.Count());
        }

        [Test]
        public void CheckPasswordReturnsFalseIfPasswordIsNotCorrectAndTrueIfCorrect()
        {
            Assert.True(Register.CheckPassword(new Student(
                "Student1",
                "Aiallaämnen",
                "1256"),"1256"));

            Assert.True(Register.CheckPassword(new Teacher(
                "Teacher1",
                "GerallaF",
                "1337"), "1337"));

            Assert.True(Register.CheckPassword(new Admin(
                "Admin1",
                "Görvadhanvill",
                "9999"), "9999"));

            Assert.False(Register.CheckPassword(new Student(
                "Student2",
                "Aiallaämnen2",
                "1213"), "12543"));

            Assert.False(Register.CheckPassword(new Teacher(
                "Teacher2",
                "GerallaF2",
                "123123"), "514"));

            Assert.False(Register.CheckPassword(new Admin(
                "Admin2",
                "Görvadhanvill2",
                "547"), "31241"));
        }

        [Test]
        public void SaveUserListToXmlSavesAllSavedUsersToXml()
        {
            
        }

        [Test]
        public void SearchForUsernameCheckIfEnteredUserNameExist()
        {
            Assert.AreNotSame(Register.SearchForUsername("Hallo"),
                Register.AddUser(new Student(
                    "Student1",
                    "hallo1",
                    "12556")));
        }

        [Test]
        public void LoadUserFromXmlGetsAllUsersSavedInXml()
        {
            
        }

        [Test]
        public void SaveCourseListToXmlSavesAllSavedCoursesToXml()
        {

        }

        [Test]
        public void LoadCourseListFromXmlGetsAllCoursesSavedInXml()
        {

        }

        [Test]
        public void SaveClassroomListToXmlSavesAllSavedClassroomsToXml()
        {

        }

        [Test]
        public void LoadClassrooomListToXmlGetsAllClassroomsSavedToXml()
        {

        }

        [Test]
        public void SaveScheduleToXmlSavesAllSavedSchedulesToXml()
        {

        }

        [Test]
        public void LoadScheduleFromXmlGetsAllSavedSchedulesSavedToXml()
        {

        }
    }
}
