using System.Runtime.Serialization;

namespace Lab1
{
    [DataContract]
    public class ListOfEquations
    {
        [DataMember]
        public List<Equation> EqList { get; internal set; }

        public ListOfEquations() { EqList = new List<Equation>(); }

        public ListOfEquations(List<Equation> EqList)
        {
            this.EqList = EqList;
        }

        public void Clear()
        {
            EqList.Clear();
        }

        public String Find(int ind)
        {
            if (ind > EqList.Count || ind < 1)
            {
                return "No such number on the list";
            }
            return $"#{ind}: {EqList[ind - 1].PrintEquation()}";
        }

        public void Add(Equation equation)
        {
            EqList.Add(equation);
        }

    }
}
