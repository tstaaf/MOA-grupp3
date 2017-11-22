using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    public class TempTests
    {
        ScheduleManager scheduleManager = new ScheduleManager();

        Classroom classroom1 = new Classroom("JIAsbdaj", 123, "SYNE17");
        Classroom classroom2 = new Classroom("fjsdi", 123, "SYNE17");
        Classroom classroom3 = new Classroom("duigisdkfsdf", 123, "SYNE17");

        Teacher teacher1 = new Teacher("knfdsj kjsadbkj", "oifndsn", "odsjnfjs");
        Teacher teacher2 = new Teacher("sakldjjf jkbchdssdf", "oifndsn", "odsjnfjs");
        Teacher teacher3 = new Teacher("knf dbdfs", "oifndsn", "odsjnfjs");

        Course course1 = new Course("SYNE17", DateTime.Now, DateTime.Now.AddMonths(2), 23, "jndsjl sldkfnlk");
        Course course2 = new Course("SYNE17", DateTime.Now, DateTime.Now.AddMonths(5), 23, "jndsjl sldkfnlk");
        Course course3 = new Course("SYNE17", DateTime.Now, DateTime.Now.AddMonths(4), 23, "jndsjl sldkfnlk");

        public void Main()
        {
            Lesson lesson1 = new Lesson(teacher1, classroom1, course1, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
            Lesson lesson2 = new Lesson(teacher2, classroom2, course2, DateTime.Now.AddHours(4), DateTime.Now.AddHours(2));
            Lesson lesson3 = new Lesson(teacher3, classroom3, course3, DateTime.Now.AddHours(2), DateTime.Now.AddHours(2));

            scheduleManager.AddLesson(lesson1);
            scheduleManager.AddLesson(lesson2);
            scheduleManager.AddLesson(lesson3);

            Console.WriteLine(scheduleManager.mainSchedule.ToString());
        }
    }
}
