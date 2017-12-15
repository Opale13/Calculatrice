using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework;
using System.IO;
using SuperComputer;

namespace UnitTest
{
    [TestFixture()]
    public class TestAdder
    {
        private Adder.Adder adder = new Adder.Adder();

        private string helpMessage = "Cette fonction permet d'additionner/soustraire deux valeurs entre elles.\r\n" +
                                     "Les valeurs peuvent être réelles ou non. Le type de la variable de retour est " +
                                     "double";

        private string[] parametersName = { "first", "second" };      

        [Test()]
        public void TestName()
        {
            Assert.That("Adder", Is.EqualTo(adder.Name));
        }
        
        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(adder.HelpMessage));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(adder.ParametersName));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That(3, Is.EqualTo(adder.Evaluate(new string[] { "2", "1" })));

            Assert.That(-2, Is.EqualTo(adder.Evaluate(new string[] { "-1", "-1" })));

            /*Tests qui ratent à coup sure, permet de verifier les exceptions*/
            Assert.That(delegate { adder.Evaluate(new string[] { "-1", "-1", "1" }); }, Throws.TypeOf<EvaluationException>());

            Assert.That(delegate { adder.Evaluate(new string[] { "-1", "truc" }); } , Throws.TypeOf<EvaluationException>());
        }
    }

    [TestFixture()]
    public class TestSubtractor
    {
        private Subtractor.Subtractor sub = new Subtractor.Subtractor();

        private string helpMessage = "Cette fonction permet de soustraire deux valeurs entre elles.\r\n" +
                                     "Les valeurs peuvent être réelles ou non. Le type de la variable de retour est " +
                                     "double";

        private string[] parametersName = { "first", "second" };

        [Test()]
        public void TestName()
        {
            Assert.That("Subtractor", Is.EqualTo(sub.Name));
        }
        
        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(sub.HelpMessage));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(sub.ParametersName));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That(1, Is.EqualTo(sub.Evaluate(new string[] { "2", "1" })));

            Assert.That(0, Is.EqualTo(sub.Evaluate(new string[] { "-1", "-1" })));

            Assert.That(0, Is.EqualTo(sub.Evaluate(new string[] { "0.5", "0.5" })));

            /*Tests qui ratent à coup sure, permet de verifier les exceptions*/
            Assert.That(delegate { sub.Evaluate(new string[] { "0.5", "0.5", "32" }); }, Throws.TypeOf<EvaluationException>());

            Assert.That(delegate { sub.Evaluate(new string[] { "0.5", "machin" }); }, Throws.TypeOf<EvaluationException>());
        }
    }

    [TestFixture()]
    public class TestMultiplier
    {
        private Multiplier.Multiplier mult = new Multiplier.Multiplier();

        private string helpMessage = "Cette fonction permet de multiplier/diviser deux valeurs entre elles.\r\n" +
                                     "Les valeurs peuvent être réelles ou non. Le type de la variable de retour est " +
                                     "double";

        private string[] parametersName = { "numerator", "denominator" };

        [Test()]
        public void TestName()
        {
            Assert.That("Multiplier", Is.EqualTo(mult.Name));
        }

        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(mult.HelpMessage));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(mult.ParametersName));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That(2, Is.EqualTo(mult.Evaluate(new string[] { "2", "1" })));

            Assert.That(1, Is.EqualTo(mult.Evaluate(new string[] { "-1", "-1" })));

            Assert.That(0.25, Is.EqualTo(mult.Evaluate(new string[] { "0,5", "0,5" })));

            /*Tests qui ratent à coup sure, permet de verifier les exceptions*/
            Assert.That(delegate { mult.Evaluate(new string[] { "42", "brol" }); }, Throws.TypeOf<EvaluationException>());

            Assert.That(delegate { mult.Evaluate(new string[] { "0,5", "0,5", "-1", "-10000" }); }, Throws.TypeOf<EvaluationException>());
        }
    }

    [TestFixture()]
    public class TestDivisor
    {
        private Divisor.Divisor div = new Divisor.Divisor();

        private string helpMessage = "Cette fonction permet de diviser deux valeurs entre elles.\r\n" +
                                     "Les valeurs peuvent être réelles ou non. Le type de la variable de retour est " +
                                     "double";

        private string[] parametersName = { "numerator", "denominator" };

        [Test()]
        public void TestName()
        {
            Assert.That("Divisor", Is.EqualTo(div.Name));
        }
        
        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(div.HelpMessage));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(div.ParametersName));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That(2, Is.EqualTo(div.Evaluate(new string[] { "2", "1" })));

            Assert.That(1, Is.EqualTo(div.Evaluate(new string[] { "-1", "-1" })));

            Assert.That(1, Is.EqualTo(div.Evaluate(new string[] { "0.5", "0.5" })));

            /*Tests qui ratent à coup sure, permet de verifier les exceptions*/
            Assert.That(delegate { div.Evaluate(new string[] { "42", "brol" }); }, Throws.TypeOf<EvaluationException>());

            Assert.That(delegate { div.Evaluate(new string[] { "42", "0" }); }, Throws.TypeOf<EvaluationException>());

            Assert.That(delegate { div.Evaluate(new string[] { "0,5", "0,5", "truc", "-10000" }); }, Throws.TypeOf<EvaluationException>());
        }
    }

    [TestFixture()]
    public class TestRacine
    {
        private Racine.Racine rac = new Racine.Racine();

        private string helpMessage = "Cette fonction permet calculer les racines d'un polynome du second degré" +
                                     "(les valeurs peuvent être réelles ou non).\r\nLe type de la variable de retour est " +
                                     "un tableau de double";

        private string[] parametersName = { "a", "b", "c" };

        [Test()]
        public void TestName()
        {
            Assert.That("Racine", Is.EqualTo(rac.Name));
        }

        
        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(rac.HelpMessage));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(rac.ParametersName));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That(new double[] { 1, 0.67 }, Is.EqualTo(rac.Evaluate(new string[] { "3", "-5", "2" })));

            Assert.That(new double[] { 3, -2 }, Is.EqualTo(rac.Evaluate(new string[] { "4", "-4", "-24" })));

            Assert.That(new double[] { 0, 0, 0 }, Is.EqualTo(rac.Evaluate(new string[] { "1", "1", "1" })));

            /*Tests qui ratent à coup sure, permet de verifier les exceptions*/
            Assert.That(delegate {rac.Evaluate(new string[] { "1", "42", "1", "6" }); }, Throws.TypeOf<EvaluationException>());

            Assert.That(delegate { rac.Evaluate(new string[] { "1", "truc", "1" }); }, Throws.TypeOf<EvaluationException>());

        }
    }

    [TestFixture()]
    public class TestPolaire
    {
        private Polaire.Polaire pol = new Polaire.Polaire();

        private string helpMessage = "Cette fonction permet de calculer le module et l'argument" +
                                     "à partir de la forme cartésienne du complexe. \r\n" +
                                     "Il suffit de rentrer la partie réelle et imaginaire";

        private string[] parametersName = { "Re", "Im" };

        [Test()]
        public void TestName()
        {
            Assert.That("Polaire", Is.EqualTo(pol.Name));
        }


        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(pol.HelpMessage));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(pol.ParametersName));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That("    Cartesien: 1+(1i)\r\n" +
                        "    Polaire:\r\n" +
                        "        Module: 1,41\r\n" +
                        "        Arg: 45°", Is.EqualTo(pol.Evaluate(new string[] { "1", "1" })));

            Assert.That("    Cartesien: 2+(-4i)\r\n" +
                        "    Polaire:\r\n" +
                        "        Module: 4,47\r\n" +
                        "        Arg: -63,43°", Is.EqualTo(pol.Evaluate(new string[] { "2", "-4" })));

            Assert.That("    Cartesien: -1,5+(-4,5i)\r\n" +
                        "    Polaire:\r\n" +
                        "        Module: 4,74\r\n" +
                        "        Arg: -108,43°", Is.EqualTo(pol.Evaluate(new string[] { "-1,5", "-4,5" })));

            /*Tests qui ratent à coup sure, permet de verifier les exceptions*/
            Assert.That(delegate { pol.Evaluate(new string[] { "-1,5", "-4,5", "50" }); }, Throws.TypeOf<EvaluationException>());

            Assert.That(delegate { pol.Evaluate(new string[] { "-1,5", "machin" }); }, Throws.TypeOf<EvaluationException>());
        }
    }

    [TestFixture()]
    public class TestStat
    {
        private Stat.Stat stat = new Stat.Stat();

        private string helpMessage = "Cette fonction permet de calculer la moyenne, la variance\r\n" +
                                     "et l'ecart type des données fournis.";

        private string[] parametersName = { "data" };

        [Test()]
        public void TestName()
        {
            Assert.That("Stat", Is.EqualTo(stat.Name));
        }


        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(stat.HelpMessage));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(stat.ParametersName));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That(new string[] { "    Moyenne: 1,5\r\n",
                        "    Variance: 0,25\r\n",
                        "    Deviation: 0,5" }, Is.EqualTo(stat.Evaluate(new string[] { "1", "2" })));

            Assert.That(new string[] { "    Moyenne: -0,5\r\n",
                        "    Variance: 11,25\r\n",
                        "    Deviation: 3,35" }, Is.EqualTo(stat.Evaluate(new string[] { "-2", "4", "-5", "1" })));

            Assert.That(new string[] { "    Moyenne: 19,25\r\n",
                        "    Variance: 666,69\r\n",
                        "    Deviation: 25,82" }, Is.EqualTo(stat.Evaluate(new string[] { "0", "-10", "32", "55" })));

            /*Tests qui ratent à coup sure, permet de verifier les exceptions*/
            Assert.That(delegate { stat.Evaluate(new string[] { "0", "-10", "machin", "55" }); }, Throws.TypeOf<EvaluationException>());

        }
    }
}
