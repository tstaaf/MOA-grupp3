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
            Register.AddClassroom(new Classroom("Sal 1", 23));
            Assert.AreEqual(1, Register.ClassroomList.Count());
        }

        [Test]
        public void RemoveClassRoomRemovesAClassroom(Classroom classroom)
        {
            Register.AddClassroom(new Classroom("Test", 20));
            Register.RemoveClassroom(classroom);
            Assert.AreEqual(0, Register.ClassroomList);
        }
        
    }
}
