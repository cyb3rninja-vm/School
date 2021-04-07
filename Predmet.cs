using System;
using System.Collections.Generic;
using System.Text;

namespace Школа
{
    class Predmet
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public Predmet() { }
        public Predmet(string name, long id)
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
