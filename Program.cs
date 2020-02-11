using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoLaboratorioDeDiscretas
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int t = int.Parse(input);
            Console.WriteLine("");
            string final_output = "";

            for (int i = 1; i < (t + 1); i++)
            {
                string nAndK = Console.ReadLine(); //This is the variable for n & k together
                var nAndKSplit = nAndK.Split(' '); //This newly found command (For me) allows me to separate the input between spaces
                int n = int.Parse(nAndKSplit[0]); //This is the first integer of the input (n)
                int k = int.Parse(nAndKSplit[1]); //This is the second integer of the input (k)

                string n_List_String = Console.ReadLine();
                string[] n_List = n_List_String.Split(new Char[] { ' ' });
                int[] array_n = n_List.Select(int.Parse).ToArray();

                Array.Sort(array_n); //This command arranges the array

                int counter = 0;
                var pairs = new List<string>();

                for (int p = 0; p != n; p++)
                {
                    for (int j = p + 1; j != n; j++)
                    {
                        int p1 = array_n[p];
                        string p_str = p1.ToString();
                        int j1 = array_n[j];
                        string j_str = j1.ToString();
                        pairs.Add(string.Format("{0}{1}{2}", p_str, " ", j_str)); //This saves the pairs as string with a space between them
                    }
                }

                IEnumerable<string> distinctPairs = pairs.Distinct();

                foreach (var elem in distinctPairs)
                {
                    var elemSplit = elem.Split(' '); //Converts each one of the elements of the pair once again to int
                    int elem0 = int.Parse(elemSplit[0]);
                    int elem1 = int.Parse(elemSplit[1]);

                    //comprueba si su suma es divisible entre k
                    int suma = elem0 + elem1;
                    if ((suma % k) == 0)
                    {
                        counter += 1;
                    }
                }
                Console.WriteLine("\n");
                final_output += "Case " + i + ": " + counter + "\n";
            }
            Console.Write(final_output);
        }
    }
}
