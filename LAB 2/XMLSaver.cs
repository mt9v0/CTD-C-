using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class XMLSaver : ISaver
    {
        public void Save(ListOfEquations list)
        {
            string fileName = "ListOfEquations.xml";
            if (File.Exists(fileName)) { File.Delete(fileName); }
            DataContractSerializer xmlSerializer = new DataContractSerializer(typeof(ListOfEquations));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.WriteObject(fs, list);
            }
        }
    }
}
