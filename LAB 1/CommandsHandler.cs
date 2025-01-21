namespace Lab1
{
    internal class CommandsHandler
    {
        private ListOfEquations listOfEquations;
        private bool SAVED;
        private ISaver saver;

        public CommandsHandler(string saverNum) 
        {
            if (saverNum == "1")
            {
                listOfEquations = Uploader.JSONUpload();
                saver = new JSONSaver();
            }
            else if (saverNum == "2")
            {
                listOfEquations = Uploader.XMLUpload();
                saver = new XMLSaver();
            }
            else if (saverNum == "3")
            {
                listOfEquations = Uploader.CSVUpload();
                saver = new CSVSaver();
            }
            SAVED = true;
        }

        public void Solve()
        {
            Console.WriteLine("Select the type:\n1 - k * x + b = 0\n2 - a * x^2 + b * x + c = 0");
            string? str = Console.ReadLine();
            switch (str) {
                case "1":
                    Solve1();
                    break;
                case "2":
                    Solve2();
                    break;
                default:
                    Console.WriteLine("Incorrect answer");
                    break;
            }
        }

        private void Solve1()
        {
            Console.WriteLine("Input the factors:\nFactor k:");
            string? ans = Console.ReadLine();
            float k;
            bool res = float.TryParse(ans, out k);
            if (!res)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            if (k == 0)
            {
                Console.WriteLine("k should not be 0");
                return;
            }
            Console.WriteLine("Free member b:");
            ans = Console.ReadLine();
            float b;
            res = float.TryParse(ans, out b);
            if (!res)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            Equation result = new Equation(k, b, -b / k);
            listOfEquations.Add(result);
            Console.WriteLine(result.PrintEquation());
            SAVED = false;
        }

        private void Solve2()
        {
            Console.WriteLine("Input the factors:\nFactor a:");
            string? ans = Console.ReadLine();
            float a;
            bool res = float.TryParse(ans, out a);
            if (!res)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            if (a == 0)
            {
                Console.WriteLine("a should not be 0");
                return;
            }
            Console.WriteLine("Factor b:");
            ans = Console.ReadLine();
            float b;
            res = float.TryParse(ans, out b);
            if (!res)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            Console.WriteLine("Factor c:");
            ans = Console.ReadLine();
            float c;
            res = float.TryParse(ans, out c);
            if (!res)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            float d = b * b - 4 * a * c;
            Equation result;
            if (d < 0)
            {
                result = new Equation(a, b, c, false);
            }
            else if (d == 0)
            {
                result = new Equation(a, b, c, (-b) / (2 * a), (-b) / (2 * a));
            }
            else
            {
                result = new Equation(a, b, c, (-b + MathF.Sqrt(d)) / (2 * a), (-b - MathF.Sqrt(d)) / (2 * a));
            }
            listOfEquations.Add(result);
            Console.WriteLine(result.PrintEquation());
            SAVED = false;


        }

        public void Find()
        {
            Console.WriteLine("Input the number:");
            string? ans = Console.ReadLine();
            int ind;
            bool res = int.TryParse(ans, out ind);
            if (!res)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            else
            {
                Console.WriteLine(listOfEquations.Find(ind));
            }
            
        }

        public void Clear()
        {
            listOfEquations.Clear();
            Console.WriteLine("The list of equations is now empty");
            SAVED = false;
        }

        public void Save()
        {
            saver.Save(listOfEquations);
            SAVED = true;
            Console.WriteLine("Saved!");
        }

        public void Quit() 
        {
            while (!SAVED)
            {
                Console.WriteLine("Save changes? 1 - yes, 0 - no");
                string? response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        Save(); SAVED = true; break;
                    case "0":
                        SAVED = true; break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            }
            Environment.Exit(0); 
        }
    }
}