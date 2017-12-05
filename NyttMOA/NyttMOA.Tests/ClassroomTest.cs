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
    public class ClassroomTest
    {
        [Test]
        public void AddClassroomAddsAClassRoom()
        {
            var sut = new Register();

            sut.AddClassroom(new Classroom("Sal 1", 23));
            Assert.AreEqual(1, sut.ClassroomList.Count());
        }

        [Test]
        public void RemoveClassRoomRemovesAClassroom()
        {
            var sut = new Register();

            var classroom = new Classroom("Test", 20);

            sut.AddClassroom(classroom);
            Assert.AreEqual(1, sut.ClassroomList.Count());
            sut.RemoveClassroom(classroom);
            Assert.AreEqual(0, sut.ClassroomList.Count());
        }
        
    }
}
