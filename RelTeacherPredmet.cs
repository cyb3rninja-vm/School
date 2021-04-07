using System;
using System.Collections.Generic;
using System.Text;

namespace Школа
{
    class RelTeacherPredmet
    {
        public Teacher Teacher { get; set; }
        public Predmet Predmet { get; set; }
        public RelTeacherPredmet() { }
        public RelTeacherPredmet(Teacher teacher, Predmet predmet)
        {
            this.Teacher = teacher;
            this.Predmet = predmet;
        }
    }
}
