using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2
{
    internal class CSVSaver : ISaver
    {
        public void Save(ListOfEquations EqList)
        {
            string fileName = "ListOfEquations.csv";
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (Equation equation in EqList.EqList)
                {
                    writer.Write(equation.firstType + ";");
                    writer.Write(equation.k + ";");
                    writer.Write(equation.b + ";");
                    writer.Write(equation.c + ";");
                    writer.Write(equation.ans + ";");
                    writer.Write(equation.ans2 + ";");
                    writer.Write(equation.hasSolution);
                    writer.Write('\n');
                }          
            }
        }
    }
}
