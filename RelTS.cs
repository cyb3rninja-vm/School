using System;
using System.Collections.Generic;
using System.Text;

namespace Школа
{
    class RelTS
    {
        public long SId { get; set; }
        public long TId { get; set; }
        public RelTS(long tid, long sid)
        {
            TId = tid;
            SId = sid;
        }
    }
}
