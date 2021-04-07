using System;
using System.Collections.Generic;
using System.Text;

namespace Школа.Repository
{
    class TeacherRepository
    {
        public static Teacher Create()
        {
            var teacher = new Teacher();
            Console.WriteLine("Введите имя учителя:");
            teacher.Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            teacher.LastName = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            teacher.Age = int.Parse(Console.ReadLine());

            teacher.Id = IdRepository.Get();
            IdRepository.Next();

            //Console.WriteLine("Введите название предмета:");
            //PredmetRepository.Create();

            Console.Clear();
            Console.WriteLine("Учитель успешно добавлен\n");

            var list = Storage.ReadFile<Teacher>();
            list.Add(teacher);

            Storage.WriteFile(list);              
            return teacher;
        }
        public static void Delete(Teacher teacher)
        {
            var list = Storage.ReadFile<Teacher>();
            list.RemoveAll(x => x.Id == teacher.Id);
            Storage.WriteFile(list);
        }
        public static void Update(Teacher teacher)
        {
            var list = Storage.ReadFile<Teacher>();
            var index = list.FindLastIndex(x => x.Id == teacher.Id);

            list.RemoveAt(index);
            list.Add(teacher);

            Storage.WriteFile(list);
        }
        public static List<Teacher> GetAll()
        {
            var list = Storage.ReadFile<Teacher>();
            return list;
        }
        public static Teacher Get(int id)
        {
            var list = Storage.ReadFile<Teacher>();

            foreach(var s in list)
            {
                if (s.Id == id)
                {
                    return s;
                }
            }
            return null;
        }
        public static List<Student> GetStudents(int id)
        {
            var list = Storage.ReadFile<RelStudentTeacher>();
            var st = new List<Student>();

            foreach (var s in list)
            {
                if (s.Teacher.Id == id)
                {
                    st.Add(s.Student);
                }
            }
            return st;
        }
    }
}
