using System;
using System.Collections.Generic;
using System.Text;

namespace Школа.Repository
{
    class BookRepository
    {

        public static Book Create()
        {
            var book = new Book();
            Console.WriteLine("Введите название книги:");
            book.Name = Console.ReadLine();

            book.Id = IdRepository.Get();
            IdRepository.Next();

            var list = Storage.ReadFile<Book>();
            list.Add(book);
            Storage.WriteFile(list);
            return book;
        }
        public static void Delete(Book book)
        {
            var list = Storage.ReadFile<Book>();
            list.RemoveAll(x => x.Id == book.Id);
            Storage.WriteFile(list);
        }
        public static void Update(Book book)
        {
            var list = Storage.ReadFile<Book>();
            var index = list.FindLastIndex(x => x.Id == book.Id);

            list.RemoveAt(index);
            list.Add(book);

            Storage.WriteFile(list);
        }
        public static List<Book> GetAll()
        {
            var list = Storage.ReadFile<Book>();
            return list;
        }
        public static Book Get(int id)
        {
            var list = Storage.ReadFile<Book>();

            foreach (var s in list)
            {
                if (s.Id == id)
                {
                    return s;
                }
            }
            return null;
        }
    }
}
