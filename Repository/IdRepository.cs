using System;
using System.Collections.Generic;
using System.Text;

namespace Школа
{
    public static class IdRepository
    {
        public static int Get()
        {
            var id = Storage.ReadId();
            return id;
        }
        public static void Next()
        {
            var id = Storage.ReadId();
            Storage.CreateId(id+1);
        }
    }
}
