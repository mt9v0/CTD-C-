using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class OpenList
    {
        public List<Equation> EqList { get; set; }

        public OpenList() { EqList = new List<Equation>(); }
    }
}
