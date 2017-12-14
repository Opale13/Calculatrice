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
        private Assembly dll;
        private Type type = null;
        private Object o = null;

        private string helpMessage = "Cette fonction permet d'additionner/soustraire deux valeurs entre elles.\r\n" +
                                     "Les valeurs peuvent être réelles ou non. Le type de la variable de retour est " +
                                     "double";

        private string[] parametersName = { "first", "second" };

        [SetUp()]
        public void Init()
        {
            dll = Assembly.LoadFile(@"C:\git\Projet2_POObis\dll\Adder.dll");
            type = dll.GetExportedTypes()[0];
            o = Activator.CreateInstance(type);
        }        

        [Test()]
        public void TestName()
        {
            Assert.That ("Adder", Is.EqualTo(type.GetProperty("Name").GetValue(o)));
        }
        
        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(type.GetProperty("HelpMessage").GetValue(o)));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(type.GetProperty("ParametersName").GetValue(o)));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That (3, Is.EqualTo((double)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string []{ "2", "1" } })));

            Assert.That (-2, Is.EqualTo((double)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "-1", "-1" } })));

            /*Test Erreur [OK]
            Assert.That(3, Is.EqualTo(type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                           null, o, new object[] { new string[] { "2", "truc" } })));
            */
        }
    }

    [TestFixture()]
    public class TestSubtractor
    {
        private Assembly dll;
        private Type type = null;
        private Object o = null;

        private string helpMessage = "Cette fonction permet de soustraire deux valeurs entre elles.\r\n" +
                                     "Les valeurs peuvent être réelles ou non. Le type de la variable de retour est " +
                                     "double";

        private string[] parametersName = { "first", "second" };

        [SetUp()]
        public void Init()
        {
            dll = Assembly.LoadFile(@"C:\git\Projet2_POObis\dll\Subtractor.dll");
            type = dll.GetExportedTypes()[0];
            o = Activator.CreateInstance(type);
        }

        [Test()]
        public void TestName()
        {
            Assert.That("Subtractor", Is.EqualTo(type.GetProperty("Name").GetValue(o)));
        }
        
        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(type.GetProperty("HelpMessage").GetValue(o)));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(type.GetProperty("ParametersName").GetValue(o)));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That(1, Is.EqualTo((double)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "2", "1" } })));

            Assert.That(0, Is.EqualTo((double)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "-1", "-1" } })));

            Assert.That(0, Is.EqualTo((double)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "0.5", "0.5" } })));

            /*Test Erreur [OK]
            Assert.That(3, Is.EqualTo(type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                           null, o, new object[] { new string[] { "2", "0"} })));
            */

        }
    }

    [TestFixture()]
    public class TestMultiplier
    {
        private Assembly dll;
        private Type type = null;
        private Object o = null;

        private string helpMessage = "Cette fonction permet de multiplier/diviser deux valeurs entre elles.\r\n" +
                                     "Les valeurs peuvent être réelles ou non. Le type de la variable de retour est " +
                                     "double";

        private string[] parametersName = { "numerator", "denominator" };

        [SetUp()]
        public void Init()
        {
            dll = Assembly.LoadFile(@"C:\git\Projet2_POObis\dll\Multiplier.dll");
            type = dll.GetExportedTypes()[0];
            o = Activator.CreateInstance(type);
        }

        [Test()]
        public void TestName()
        {
            Assert.That("Multiplier", Is.EqualTo(type.GetProperty("Name").GetValue(o)));
        }

        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(type.GetProperty("HelpMessage").GetValue(o)));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(type.GetProperty("ParametersName").GetValue(o)));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That(2, Is.EqualTo((double)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "2", "1" } })));

            Assert.That(1, Is.EqualTo((double)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "-1", "-1" } })));

            Assert.That(0.25, Is.EqualTo((double)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "0,5", "0,5" } })));

            /*Test Erreur [OK]
            Assert.That(3, Is.EqualTo(type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                           null, o, new object[] { new string[] { "2", "truc" } })));
            */
        }
    }

    [TestFixture()]
    public class TestDivisor
    {
        private Assembly dll;
        private Type type = null;
        private Object o = null;

        private string helpMessage = "Cette fonction permet de diviser deux valeurs entre elles.\r\n" +
                                     "Les valeurs peuvent être réelles ou non. Le type de la variable de retour est " +
                                     "double";

        private string[] parametersName = { "numerator", "denominator" };

        [SetUp()]
        public void Init()
        {
            dll = Assembly.LoadFile(@"C:\git\Projet2_POObis\dll\Divisor.dll");
            type = dll.GetExportedTypes()[0];
            o = Activator.CreateInstance(type);
        }

        [Test()]
        public void TestName()
        {
            Assert.That("Divisor", Is.EqualTo(type.GetProperty("Name").GetValue(o)));
        }
        
        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(type.GetProperty("HelpMessage").GetValue(o)));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(type.GetProperty("ParametersName").GetValue(o)));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That(2, Is.EqualTo((double)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "2", "1" } })));

            Assert.That(1, Is.EqualTo((double)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "-1", "-1" } })));

            Assert.That(1, Is.EqualTo((double)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "0.5", "0.5" } })));

            /*Test Erreur [OK]
            Assert.That(3, Is.EqualTo(type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                           null, o, new object[] { new string[] { "2", "0"} })));
            */
            
        }
    }

    [TestFixture()]
    public class TestRacine
    {
        private Assembly dll;
        private Type type = null;
        private Object o = null;

        private string helpMessage = "Cette fonction permet calculer les racines d'un polynome du second degré" +
                                     "(les valeurs peuvent être réelles ou non).\r\nLe type de la variable de retour est " +
                                     "un tableau de double";

        private string[] parametersName = { "a", "b", "c" };

        [SetUp()]
        public void Init()
        {
            dll = Assembly.LoadFile(@"C:\git\Projet2_POObis\dll\Racine.dll");
            type = dll.GetExportedTypes()[0];
            o = Activator.CreateInstance(type);
        }

        [Test()]
        public void TestName()
        {
            Assert.That("Racine", Is.EqualTo(type.GetProperty("Name").GetValue(o)));
        }

        
        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(type.GetProperty("HelpMessage").GetValue(o)));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(type.GetProperty("ParametersName").GetValue(o)));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That(new double[] { 1, 0.67 }, Is.EqualTo((double[])type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "3", "-5", "2" } })));

            Assert.That(new double[] { 3, -2 }, Is.EqualTo((double[])type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "4", "-4", "-24" } })));

            Assert.That(new double[] { 0, 0, 0 }, Is.EqualTo((double[])type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "1", "1", "1" } })));

            /*Test Erreur [OK]
            Assert.That(3, Is.EqualTo(type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                           null, o, new object[] { new string[] { "2", "0"} })));
            */

        }
    }

    [TestFixture()]
    public class TestPolaire
    {
        private Assembly dll;
        private Type type = null;
        private Object o = null;

        private string helpMessage = "Cette fonction permet de calculer le module et l'argument" +
                                     "à partir de la forme cartésienne du complexe. \r\n" +
                                     "Il suffit de rentrer la partie réelle et imaginaire";

        private string[] parametersName = { "Re", "Im" };

        [SetUp()]
        public void Init()
        {
            dll = Assembly.LoadFile(@"C:\git\Projet2_POObis\dll\Polaire.dll");
            type = dll.GetExportedTypes()[0];
            o = Activator.CreateInstance(type);
        }

        [Test()]
        public void TestName()
        {
            Assert.That("Polaire", Is.EqualTo(type.GetProperty("Name").GetValue(o)));
        }


        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(type.GetProperty("HelpMessage").GetValue(o)));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(type.GetProperty("ParametersName").GetValue(o)));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That("    Cartesien: 1+(1i)\r\n" +
                        "    Polaire:\r\n" +
                        "        Module: 1,41\r\n" +
                        "        Arg: -45°", Is.EqualTo((string)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "1", "1" } })));

            Assert.That("    Cartesien: 2+(-4i)\r\n" +
                        "    Polaire:\r\n" +
                        "        Module: 4,47\r\n" +
                        "        Arg: 63,43°", Is.EqualTo((string)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "2", "-4" } })));

            Assert.That("    Cartesien: -1,33+(4,5i)\r\n" +
                        "    Polaire:\r\n" +
                        "        Module: 4,69\r\n" +
                        "        Arg: 73,53°", Is.EqualTo((string)type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "-1,33", "4,5" } })));

            /*Test Erreur [OK]
            Assert.That(3, Is.EqualTo(type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                           null, o, new object[] { new string[] { "2", "0"} })));
            */

        }
    }

    [TestFixture()]
    public class TestStat
    {
        private Assembly dll;
        private Type type = null;
        private Object o = null;

        private string helpMessage = "Cette fonction permet de calculer la moyenne, la variance\r\n" +
                                     "et l'ecart type des données fournis.";

        private string[] parametersName = { "data" };

        [SetUp()]
        public void Init()
        {
            dll = Assembly.LoadFile(@"C:\git\Projet2_POObis\dll\Stat.dll");
            type = dll.GetExportedTypes()[0];
            o = Activator.CreateInstance(type);
        }

        [Test()]
        public void TestName()
        {
            Assert.That("Stat", Is.EqualTo(type.GetProperty("Name").GetValue(o)));
        }


        [Test()]
        public void TestHelpMessage()
        {
            Assert.That(helpMessage, Is.EqualTo(type.GetProperty("HelpMessage").GetValue(o)));
        }

        [Test()]
        public void TestParametersName()
        {
            Assert.That(parametersName, Is.EqualTo(type.GetProperty("ParametersName").GetValue(o)));
        }

        [Test()]
        public void TestEvaluate()
        {
            Assert.That(new string[] { "    Moyenne: 1,5\r\n",
                        "    Variance: 0,25\r\n",
                        "    Deviation: 0,5" }, Is.EqualTo((string[])type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "1", "2" } })));

            Assert.That(new string[] { "    Moyenne: -0,5\r\n",
                        "    Variance: 11,25\r\n",
                        "    Deviation: 3,35" }, Is.EqualTo((string[])type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "-2", "4", "-5", "1" } })));

            Assert.That(new string[] { "    Moyenne: 19,25\r\n",
                        "    Variance: 666,69\r\n",
                        "    Deviation: 25,82" }, Is.EqualTo((string[])type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                                        null, o, new object[] { new string[] { "0", "-10", "32", "55" } })));
                    
            /*Test Erreur [OK]
            Assert.That(3, Is.EqualTo(type.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                           null, o, new object[] { new string[] { "2", "truc"} })));
            */

        }
    }
}
