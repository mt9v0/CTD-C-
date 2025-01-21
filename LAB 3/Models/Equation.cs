using System.Runtime.Serialization;

namespace Lab3.Models
{
    [DataContract]
    public class Equation
    {
        [DataMember] public bool firstType { get; set; }
        [DataMember] public float k { get; set; }
        [DataMember] public float b { get; set; }
        [DataMember] public float c { get; set; } = 0;
        [DataMember] public float ans { get; set; } = 0;
        [DataMember] public float ans2 { get; set; } = 0;
        [DataMember] public bool hasSolution { get; set; } = true;
        [DataMember] public int number { get; set; } = 0;

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

        public Equation(float k, float b)
        {
            firstType = true;
            this.k = k;
            this.b = b;
            ans = -b / k;
        }

        public Equation(float k, float b, float c)
        {
            firstType = false;
            this.k = k;
            this.b = b;
            this.c = c;
            float d = b * b - 4 * k * c;
            if (d < 0)
            {
                hasSolution = false;
            }
            else
            {
                hasSolution = true;
                ans = (-b + MathF.Sqrt(d)) / (2 * k);
                ans2 = (-b - MathF.Sqrt(d)) / (2 * k);
            }
        }

        public string PrintEquation()
        {
            if (firstType)
            {
                return $"#{number}: " + string.Format("{0:f1} * x + ", k) + string.Format("{0:f1} = 0, solution: x = ", b) +
                string.Format("{0:f1}", ans);
            }
            if (!hasSolution)
            {
                return $"#{number}: " + string.Format("{0:f1} * x^2 + ", k) + string.Format("{0:f1} * x + ", b) + string.Format("{0:f1}, x has no solutions", c);
            }
            return $"#{number}: " + string.Format("{0:f1} * x^2 + ", k) + string.Format("{0:f1} * x + ", b) + string.Format("{0:f1}, solutions: x = ", c) +
                string.Format("{0:f1}, x = ", ans) + string.Format("{0:f1}", ans2);
        }
    }
}
