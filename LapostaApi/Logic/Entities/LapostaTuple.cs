using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laposta.Entities
{
    public class LapostaTuple
    {
        public int item1 { get; set; }

        public string item2 { get; set; }

        public LapostaTuple(int item1, string item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

    }
}