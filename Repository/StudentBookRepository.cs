using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Школа.Repository
{
    class StudentBookRepository
    {
        public static RelStudentBook Create(Student student, Book book)
        {
            var relSB = new RelStudentBook(student, book);
            var list = Storage.ReadFile<RelStudentBook>();

            list.Add(relSB);
            Storage.WriteFile(list);
            return relSB;
        }
        public static List<RelStudentBook> GetAll()
        {
            var list = Storage.ReadFile<RelStudentBook>();
            return list;
        }
    }
}
