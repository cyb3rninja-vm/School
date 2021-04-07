using System;
using System.Collections.Generic;
using System.Text;

namespace Школа.Repository
{
    class StudentPredmetRepository
    {
        public static RelStudentPredmet Create(Student student, Predmet predmet)
        {
            var relSP = new RelStudentPredmet(student, predmet);
            var list = Storage.ReadFile<RelStudentPredmet>();

            list.Add(relSP);
            Storage.WriteFile(list);
            return relSP;
        }
        public static List<RelStudentPredmet> GetAll()
        {
            var list = Storage.ReadFile<RelStudentPredmet>();
            return list;
        }
    }
}
