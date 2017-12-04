﻿using System;
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
                30,
                new Teacher("Teacher1", "LärarN", "Passwordtest1")));

            sut.AddCourse(new Course(
                "Enklastekursen",
                new DateTime(2017,12,10),
                new DateTime(2017,12,15),
                34,
                new Teacher("Teacher2", "Kaninteundervisa", "Passwordtest2")));

            Assert.AreEqual(2, sut.CourseList.Count());
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
