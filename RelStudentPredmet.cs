using System;
using System.Collections.Generic;
using System.Text;

namespace Школа
{
    class RelStudentPredmet
    {
        public Student Student { get; set; }
        public Predmet Predmet { get; set; }
        public RelStudentPredmet() { }
        public RelStudentPredmet(Student student, Predmet predmet)
        {
            this.Student = student;
            this.Predmet = predmet;
        }
    }
}
