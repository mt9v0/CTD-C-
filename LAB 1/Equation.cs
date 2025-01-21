using System.Runtime.Serialization;

namespace Lab1
{
    [DataContract]
    public class Equation
    {
        [DataMember] public bool firstType {  get; set; }
        [DataMember] public float k { get; set; }
        [DataMember] public float b { get; set; }
        [DataMember] public float c { get; set; }
        [DataMember] public float ans { get; set; }
        [DataMember] public float ans2 { get; set; }
        [DataMember] public bool hasSolution { get; set; }

        public Equation()
        {
            firstType = true;
            k = 0;
            b = 0;
            c = 0;
            ans = 0;
            ans2 = 0;
            hasSolution = false;
        }

        public Equation(bool firstType, float k, float b, float c, float ans, float ans2, bool hasSolution)
        {
            this.firstType = firstType;
            this.k = k;
            this.b = b;
            this.c = c;
            this.ans = ans;
            this.ans2 = ans2;
            this.hasSolution = hasSolution;
        }

        public Equation(float k, float b, float ans)
        {
            firstType = true;
            this.k = k;
            this.b = b;
            c = 0;
            ans2 = 0;
            this.ans = ans;
            hasSolution = true;
        }

        public Equation(float k, float b, float c, float ans, float ans2)
        {
            firstType = false;
            this.k = k;
            this.b = b;
            this.c = c;
            this.ans = ans;
            this.ans2 = ans2;
            hasSolution = true;
        }

        public Equation(float k, float b, float c, bool s)
        {
            firstType = false;
            this.k = k;
            this.b = b;
            this.c = c;
            ans = 0;
            ans2 = 0;
            hasSolution = false;
        }


        public string PrintEquation()
        {
            if (firstType)
            {
                return string.Format("{0:f1} * x + ", k) + string.Format("{0:f1} = 0, solution: x = ", b) +
                string.Format("{0:f1}", ans);
            }
            if (!hasSolution)
            {
                return string.Format("{0:f1} * x^2 + ", k) + string.Format("{0:f1} * x + ", b) + string.Format("{0:f1}, x has no solutions", c);
            }
            return string.Format("{0:f1} * x^2 + ", k) + string.Format("{0:f1} * x + ", b) + string.Format("{0:f1}, solutions: x = ", c) +
                string.Format("{0:f1}, x = ", ans) + string.Format("{0:f1}", ans2);
        }
    }
}
