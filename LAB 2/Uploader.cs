using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace Lab2
{
    internal class Uploader
    {
        public static ListOfEquations JSONUpload()
        {
            string fileName = "ListOfEquations.json";
            if (!File.Exists(fileName)) { return new ListOfEquations(); }

            string jsonString = File.ReadAllText(fileName);
            OpenList Olist = JsonSerializer.Deserialize<OpenList>(jsonString)!;
            return new ListOfEquations(Olist.EqList);
        }

        public static ListOfEquations XMLUpload()
        {
            string fileName = "ListOfEquations.xml";
            if (!File.Exists(fileName)) { return new ListOfEquations(); }
            ListOfEquations list;
            using (Stream stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(ListOfEquations));
                list = (ListOfEquations)ser.ReadObject(stream);
            }
            return list;
        }

        public static ListOfEquations CSVUpload()
        {
            string fileName = "ListOfEquations.csv";
            if (!File.Exists(fileName)) { return new ListOfEquations(); }
            ListOfEquations list = new ListOfEquations();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string? str = reader.ReadLine();
                string[] args;
                while (str != null)
                {
                    args = str.Split(';');
                    list.Add(new Equation(bool.Parse(args[0]), float.Parse(args[1]), 
                        float.Parse(args[2]), float.Parse(args[3]), float.Parse(args[4]), float.Parse(args[5]), bool.Parse(args[6])));
                    str = reader.ReadLine();
                }
            }
            return list;
        }

        public static ListOfEquations SQLUpload()
        {
            using (SQLManager db = new SQLManager())
            {
                db.Database.EnsureCreated();
                if (db.EqList.Count() == 0)
                {
                    return new ListOfEquations();
                }
                return new ListOfEquations(db.EqList.ToList());
            }
        }
    }
}
