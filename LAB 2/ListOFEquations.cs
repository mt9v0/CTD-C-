using System.Runtime.Serialization;

namespace Lab2
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
            if (EqList[ind - 1].number == ind)
                return EqList[ind - 1].PrintEquation();
            foreach (Equation eq in EqList)
            {
                if (eq.number == ind)
                    return eq.PrintEquation();
            }
            return "";
        }

        public void Add(Equation equation)
        {
            equation.number = EqList.Count + 1;
            EqList.Add(equation);
        }

    }
}
