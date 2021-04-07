using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Школа
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfRelationStudentAndTeachers = Repository.StudentTeacherRepository.listOfRelationStudentAndTeachers;
            var listOfRelationStudentAndBooks = Repository.StudentTeacherRepository.listOfRelationStudentAndBooks;
            while (true)
            {
                Console.WriteLine("" +
                    "\n1.Создать учителя      3.Список студентов          5.Связать учителя со студентом" +
                    "\n2.Создать студента     4.Список учителей           8.Связать студента с книгой" +
                    "\n7.Создать книгу" +
                    "\n" +
                    "\n6.Показать связи учителей и студентов" +
                    "\n11.Показать содержимое файла" +
                    "\n" +
                    "\n9.Показать с какими книгами связан студент" +
                    "\n10.Показать список книг" +
                    "\n" +
                    "\n12.Показать с какими студентами связян учитель по его ID" +
                    "\n13.Показать с какими учителями связян студент по его ID " +
                    "\n");
                var cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 1:
                         Repository.TeacherRepository.Create();                      
                        break;
                    case 2:
                          Repository.StudentRepository.Create();
                        break;
                    case 3:
                        if (Repository.StudentRepository.GetAll().Count == 0)
                        {
                            Console.WriteLine("Список студентов пуст");
                            break;
                        }
                        foreach (var item in Repository.StudentRepository.GetAll())
                        {                     
                            Console.WriteLine($"Список студентов: {item.ToString()}");
                        }
                        break;
                    case 4:
                        if (Repository.TeacherRepository.GetAll().Count == 0)
                        {
                            Console.WriteLine("Список учителей пуст");
                            break;
                        }
                        foreach (var item in Repository.TeacherRepository.GetAll())
                        {
                            Console.WriteLine($"Список учителей: {item.ToString()}");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Введите ID учителя:");
                        var teacherId = int.Parse(Console.ReadLine());
                        var teacher = Repository.TeacherRepository.Get(teacherId);
                        if (teacher == null)
                        {
                            Console.WriteLine($"Учитель с ID [{teacherId}] не найден");
                            break;
                        }
                        Console.WriteLine("Введите ID студента:");
                        var studentId = int.Parse(Console.ReadLine());
                        var student = Repository.StudentRepository.Get(studentId);
                        if (student == null)
                        {
                            Console.WriteLine($"Студент с ID [{studentId}] не найден");
                        }
                        else
                        {
                            var create = Repository.StudentTeacherRepository.Create(student, teacher);
                        }
                        break;
                    case 6:
                        var sList = Repository.StudentRepository.GetAll();
                        if (sList.Count == 0)
                        {
                            Console.WriteLine("Список студентов пуст");
                        }
                        var tList = Repository.TeacherRepository.GetAll();
                        if (tList.Count == 0)
                        {
                            Console.WriteLine("\nСписок книг пуст\n");
                        }
                        var stList = Repository.StudentTeacherRepository.GetAll();
                        if (stList.Count == 0)
                        {
                            Console.WriteLine("Список связей пуст");
                        }
                        else
                        {
                            foreach (var item in stList)
                            {
                                Console.WriteLine($"ФИО учителя: {item.Teacher.ToString()}\nФИО студента: {item.Student.ToString()}");
                            }
                        }
                        break;
                    case 7:
                        Repository.BookRepository.Create();
                        break;
                    case 8:
                        Console.WriteLine("Введите ID студента:");
                        studentId = int.Parse(Console.ReadLine());
                        var studentb = Repository.StudentRepository.Get(studentId);
                        if (studentb == null)
                        {
                            Console.WriteLine($"Студент с ID [{studentId}] не найден");
                            break;
                        }              
                        Console.WriteLine("Введите ID книги:");
                        var bookId = int.Parse(Console.ReadLine());
                        var book = Repository.BookRepository.Get(bookId);
                        if (book == null)
                        {
                            Console.WriteLine($"Книга с ID [{bookId}] не найденa");
                        }
                        else
                        {
                            Console.WriteLine("Связь произошла успешно");
                            Repository.StudentBookRepository.Create(studentb, book);
                        }
                        break;
                    case 9:
                        var studList = Repository.StudentRepository.GetAll();
                        if (studList.Count == 0)
                        {
                            Console.WriteLine("Список студентов пуст");
                        }
                        var bList = Repository.BookRepository.GetAll();
                        if (bList.Count == 0)
                        {
                            Console.WriteLine("\nСписок книг пуст\n");
                        }
                        var sbList = Repository.StudentBookRepository.GetAll();
                        if (sbList.Count == 0)
                        {
                            Console.WriteLine("Список связей пуст");
                        }
                        else
                        {
                            foreach(var item in sbList)
                            {
                                Console.WriteLine($"Название книги: {item.Book.Name}\nФИО студента: {item.Student.ToString()}");
                            }
                        }                      
                        break;
                    case 10:
                        if (Repository.BookRepository.GetAll().Count == 0)
                        {
                            Console.WriteLine("Список книг пуст");
                            break;
                        }
                        foreach (var item in Repository.BookRepository.GetAll())
                        {
                            Console.WriteLine($"Список книг: {item.ToString()}");
                        }
                        break;
                    case 11:
                        if (Repository.TeacherRepository.GetAll().Count == 0)
                        {
                            Console.WriteLine("Список учителей пуст");
                        }
                        if (Repository.StudentRepository.GetAll().Count == 0)
                        {
                            Console.WriteLine("Список студентов пуст");
                        }
                        if (Repository.BookRepository.GetAll().Count == 0)
                        {
                            Console.WriteLine("Список книг пуст");
                        }
                        if (Repository.TeacherRepository.GetAll().Count > 0)
                        {
                            foreach (var item in Repository.TeacherRepository.GetAll())
                            {
                                Console.WriteLine($"Учитель: {item.ToString()}");
                            }
                        }
                        if (Repository.StudentRepository.GetAll().Count > 0)
                        {
                            foreach (var item in Repository.StudentRepository.GetAll())
                            {
                                Console.WriteLine($"Студент: {item.ToString()}");
                            }
                        }
                        if (Repository.BookRepository.GetAll().Count > 0)
                        {
                            foreach (var item in Repository.BookRepository.GetAll())
                            {
                                Console.WriteLine($"Книга: {item.ToString()}");
                            }
                        }
                        break;
                    case 12:
                        Console.WriteLine("Введите ID учителя:");
                        var tid = int.Parse(Console.ReadLine());
                        var st = Repository.TeacherRepository.GetStudents(tid);
                        foreach(var s in st)
                        {
                            Console.WriteLine(s.ToString());
                        }                  
                        break;
                    case 13:
                        Console.WriteLine("Введите ID студента:");
                        var sid = int.Parse(Console.ReadLine());
                        var teach = Repository.StudentRepository.GetTeachers(sid);
                        foreach (var s in teach)
                        {
                            Console.WriteLine(s.ToString());
                        }
                        break;
                }
            }
        }
    }
}