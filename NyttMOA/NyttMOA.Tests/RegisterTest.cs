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

            Assert.AreEqual(3, Register.UserList.Count);

        }

        [Test]
        public void AddClassroomAddsAClassroomToClassroomList()
        {
            
        }

        [Test]
        public void AddCourseAddsACourseToCourseList()
        {
            
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
