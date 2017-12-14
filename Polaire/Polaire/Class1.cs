using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace Adder
{
    public class Polaire : Function<string>
    {
        private string helpMessage = "Cette fonction permet de calculer le module et l'argument" +
                                     "à partir de la forme cartésienne du complexe. \r\n" +
                                     "Il suffit de rentrer la partie réelle et imaginaire";

        private string[] parametersName = { "Re", "Im" };

        //Renvoie le nom de la fonction
        public string Name { get { return "Polaire"; } }

        //Renvoir un message d'aide disant ce que fais la fonction et le type des paramétres
        public string HelpMessage { get { return helpMessage; } }

        //Renvoie un liste avec les noms des paramétres
        public string[] ParametersName
        {
            get { return parametersName; }
        }

        //Calcul la somme des deux paramétres
        public string Evaluate(string[] args)
        {
            if (args.Length == 2)
            {
                try
                {
                    double re = Convert.ToDouble(args[0]);
                    double im = Convert.ToDouble(args[1]);

                    double modul = Math.Round(Math.Pow(Math.Pow(re, 2) + Math.Pow(im, 2), 0.5), 2);
                    double argument = Math.Round(( 180 / Math.PI ) * Math.Atan(im/re), 2);
                    
                    return String.Format("    Cartesien: {0}+({1}i)\r\n" +
                                         "    Polaire:\r\n" +
                                         "        Module: {2}\r\n" +
                                         "        Arg: {3}°", re, im, modul, argument);
                }
                //léve une exception si une erreur est produite lors du calcul
                catch { throw new EvaluationException("Un probléme est survenu lors du calcul"); }
            }
            //léve une exception si une erreur est produite si il n'y a pas deux valeurs
            else { throw new EvaluationException("Veuillez rentrez deux valeurs"); }
        }
    }
}
