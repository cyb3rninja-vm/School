using System;
using System.Collections.Generic;
using System.Text;

namespace Школа.Repository
{
    class PredmetRepository
    {
        public static Predmet Create()
        {
            var predmet = new Predmet();
            predmet.Name = Console.ReadLine();

            predmet.Id = IdRepository.Get();
            IdRepository.Next();

            var list = Storage.ReadFile<Predmet>();
            list.Add(predmet);
            Storage.WriteFile(list);
            return predmet;
        }
    }
}
