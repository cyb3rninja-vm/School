using System;
using System.Collections.Generic;
using System.Text;

namespace Школа
{
    public class RelStudentTeacher
    {
        public Student Student { get; set; }

        public Teacher Teacher { get; set; }

        public RelStudentTeacher() { }

        public RelStudentTeacher(Student student, Teacher teacher)
        {
            this.Student = student;
            this.Teacher = teacher;
        }
    }
}
