using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Школа.Repository
{
    public class StudentTeacherRepository
    {
        public static List<RelStudentTeacher> listOfRelationStudentAndTeachers = new List<RelStudentTeacher>();
        public static List<RelStudentBook> listOfRelationStudentAndBooks = new List<RelStudentBook>();
        public static RelStudentTeacher Create(Student student, Teacher teacher)
        {
            var relST = new RelStudentTeacher(student, teacher);

            var list = Storage.ReadFile<RelStudentTeacher>();
            list.Add(relST);
            Storage.WriteFile(list);
            return relST;
        }
        public static List<RelStudentTeacher> GetAll()
        {
            var list = Storage.ReadFile<RelStudentTeacher>();
            return list;
        }
    }
}
