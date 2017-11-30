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
            
        }

        [Test]
        public void SaveUserListToXmlSavesAllSavedUsersToXml()
        {
            
        }

        [Test]
        public void SearchForUsernameCheckIfEnteredUserNameExist()
        {
            
        }

        [Test]
        public void LoadUserFromXmlGetsAllUsersSavedInXml()
        {
            
        }
    }
}
