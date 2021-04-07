using System;
using System.Collections.Generic;
using System.Text;

namespace Школа
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person() { }
        public Person(int id, string name, string lastName, int age)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Age = age;
        }
        public override string ToString()
        {
            return $"ID: [{Id}], Имя: {Name} Фамилия: {LastName}, Возраст: {Age}";
        }
    }
}
