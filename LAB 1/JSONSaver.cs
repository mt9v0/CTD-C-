using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab1
{
    internal class JSONSaver : ISaver
    {
        public void Save(ListOfEquations list)
        {
            string fileName = "ListOfEquations.json";
            string jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
