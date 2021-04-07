using System;
using System.Collections.Generic;
using System.Text;

namespace Школа
{
    public class RelStudentBook
    {
        public Student Student { get; set; }
        public Book Book { get; set; }
        public RelStudentBook() { }
        public RelStudentBook(Student student, Book book)
        {
            this.Student = student;
            this.Book = book;
        }
    }
}
