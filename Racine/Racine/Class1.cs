using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;


namespace Racine
{
    public class Racine : Function<double[]>
    {
        private string helpMessage = "Cette fonction permet calculer les racines d'un polynome du second degré" +
                                        "(les valeurs peuvent être réelles ou non).\r\nLe type de la variable de retour est " +
                                        "un tableau de double";

        private string[] parametersName = { "a", "b", "c" };

        //Renvoie le nom de la fonction
        public string Name { get { return "Racine"; } }

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
        public double[] Evaluate(string[] args)
        {
            if (args.Length == 3)
            {
                try
                {
                    double a = Convert.ToDouble(args[0]);
                    double b = Convert.ToDouble(args[1]);
                    double c = Convert.ToDouble(args[2]);

                    double delta = b * b - (4 * a * c);

                    if (delta == 0)
                    {
                        double x = -b / (2 * a);
                        double[] result = new double[] { x };
                        return result;
                    }
                    else if (delta > 0)
                    {
                        double x1 = (-b + Math.Pow(delta, 0.5)) / (2 * a);
                        double x2 = (-b - Math.Pow(delta, 0.5)) / (2 * a);
                        double[] result = new double[] { Math.Round(x1, 2), Math.Round(x2, 2) };
                        return result;
                    }
                    else
                    {
                        double[] result = new double[] { 0, 0, 0 };
                        return result;
                    }
                }
                catch { throw new EvaluationException("Un probléme est survenu lors du calcul"); }
            }
            else { throw new EvaluationException("Veuillez rentrer trois valeurs"); }
        }
    }
}
