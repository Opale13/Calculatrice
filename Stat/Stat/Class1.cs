using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace Stat
{
    public class Stat : Function<string[]>
    {
        private string helpMessage = "Cette fonction permet de calculer la moyenne, la variance\r\n" +
                                     "et l'ecart type des données fournis.";

        private string[] parametersName = { "data" };

        //Renvoie le nom de la fonction
        public string Name { get { return "Stat"; } }

        //Renvoir un message d'aide disant ce que fais la fonction et le type des paramétres
        public string HelpMessage { get { return helpMessage; } }

        //Renvoie un liste avec les noms des paramétres
        public string[] ParametersName
        {
            get { return parametersName; }
        }

        //Calcul la somme des deux paramétres
        public string[] Evaluate(string[] args)
        {
            string[] result = new string[3];

            double average = 0;
            double deviation = 0;
            double variance = 0;

            try
            {
                //Average calculate
                foreach (string number in args)
                {
                    average += Convert.ToDouble(number);
                }
                average = Math.Round((average / args.Length), 2);

                //Deviation calculate
                foreach (string number in args)
                {
                    double num = Convert.ToDouble(number);
                    variance += Math.Pow((num-average), 2);
                }

                variance = Math.Round((variance / args.Length), 2);
                deviation = Math.Round(Math.Sqrt(variance), 2);

                result = new string[] { "    Moyenne: " + Convert.ToString(average) + "\r\n",
                                        "    Variance: " + Convert.ToString(variance) + "\r\n",
                                        "    Deviation: " + Convert.ToString(deviation)};

                return result;
            }
            //léve une exception si une erreur est produite lors du calcul
            catch { throw new EvaluationException("Un probléme est survenu lors du calcul"); }
            
        }
    }
}
