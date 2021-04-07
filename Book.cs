using System;
using System.Collections.Generic;
using System.Text;

namespace Школа
{
    public class Book
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public Book() { }
        public Book(string name, long id)
        {
            Name = name;
            Id = id;
        }
        public override string ToString()
        {
            return $"ID: [{Id}], Имя: {Name}";
        }
    }
}
