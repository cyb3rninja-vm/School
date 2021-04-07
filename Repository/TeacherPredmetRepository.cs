using System;
using System.Collections.Generic;
using System.Text;

namespace Школа.Repository
{
    class TeacherPredmetRepository
    {
        public static RelTeacherPredmet Create(Teacher teacher, Predmet predmet)
        {
            var relTP = new RelTeacherPredmet(teacher, predmet);
            var list = Storage.ReadFile<RelTeacherPredmet>();

            list.Add(relTP);
            Storage.WriteFile(list);
            return relTP;
        }
        public static List<RelTeacherPredmet> GetAll()
        {
            var list = Storage.ReadFile<RelTeacherPredmet>();
            return list;
        }
    }
}
