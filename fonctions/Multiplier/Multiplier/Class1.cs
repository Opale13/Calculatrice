using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace Multiplier
{
    public class Multiplier : Function<double>
    {
        private string helpMessage = "Cette fonction permet de multiplier deux valeurs entre elles.\r\n" +
                                     "Les valeurs peuvent être réelles ou non. Le type de la variable de retour est " +
                                     "double";

        private string[] parametersName = { "numerator", "denominator" };

        //Renvoie le nom de la fonction
        public string Name { get { return "Multiplier"; } }

        //Renvoir un message d'aide disant ce que fais la fonction et le type des paramétres
        public string HelpMessage
        {
            get { return helpMessage; }
        }

        //Renvoie un liste avec les noms des paramétres
        public string[] ParametersName
        {
            get { return parametersName; }
        }

        //Calcul la somme des deux paramétres
        public double Evaluate(string[] args)
        {
            if (args.Length == 2)
            {
                try
                {
                    double numerator = Convert.ToDouble(args[0]);
                    double denominator = Convert.ToDouble(args[1]);
                    return numerator * denominator;
                }
                //léve une exception si une erreur est produite lors du calcul
                catch { throw new EvaluationException("Un probléme est survenu lors du calcul"); }
            }
            //léve une exception si une erreur est produite si il n'y a pas deux valeurs
            else { throw new EvaluationException("Veuillez rentrez deux valeurs"); }
        }
    }
}
