using System;
using System.Collections.Generic;
using System.Text;

namespace Школа.Repository
{
    class StudentRepository
    {
        public static Student Create()
        {
            var student = new Student();
            Console.WriteLine("Введите имя студента:");
            student.Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            student.Age = int.Parse(Console.ReadLine());

            student.Id = IdRepository.Get();
            IdRepository.Next();

            //Console.WriteLine("Ввдедите название предмета");
            //PredmetRepository.Create();

            Console.Clear();
            Console.WriteLine("Студент успешно добавлен\n");

            var list = Storage.ReadFile<Student>();
            list.Add(student);
            Storage.WriteFile(list);

            return student;
        }
        public static void Delete(Student student)
        {
            var list = Storage.ReadFile<Student>();
            list.RemoveAll(x => x.Id == student.Id);
            Storage.WriteFile(list);
        }
        public static void Update(Student student)
        {
            var list = Storage.ReadFile<Student>();
            var index = list.FindLastIndex(x => x.Id == student.Id);

            list.RemoveAt(index);
            list.Add(student);

            Storage.WriteFile(list);
        }
        public static List<Student> GetAll()
        {
            var list = Storage.ReadFile<Student>();
            return list;
        }
        public static Student Get(int id)
        {
            var list = Storage.ReadFile<Student>();

            foreach (var s in list)
            {
                if (s.Id == id)
                {
                    return s;
                }
            }
            return null;
        }
        public static List<Teacher> GetTeachers(int id)
        {
            var list = Storage.ReadFile<RelStudentTeacher>();
            var teach = new List<Teacher>();

            foreach (var s in list)
            {
                if (s.Student.Id == id)
                {
                    teach.Add(s.Teacher);
                }
            }
            return teach;
        }
        public static void GetBooks()
        {
            var books = StudentBookRepository.GetAll();
            var readline = int.Parse(Console.ReadLine());
            foreach(var s in books)
            {
                if(readline == s.Student.Id)
                {
                    Console.WriteLine($"ID: {s.Book.Id} {s.Book.Name}");
                }
            }
        }
        public static void GetPredmet()
        {
            var predmet = StudentPredmetRepository.GetAll();
            var readline = int.Parse(Console.ReadLine());
            foreach(var s in predmet)
            {
                if(readline == s.Predmet.Id)
                {
                    Console.WriteLine($"ID: {s.Predmet.Id} {s.Predmet.Name}");
                }
            }
        }
    }
}
