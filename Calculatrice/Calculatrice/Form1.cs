using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using SuperComputer;

namespace Calculatrice
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Type> dicoDll = new Dictionary<string, Type>();
        private string pattern = @"^(?<function>[a-zA-Z]+) (?<args>[\;\d\s]+)$";

        public Form1()
        {
            InitializeComponent();
            string path = Path.GetFullPath(@"..\..\..\..\dll");
            foreach (string dllName in Directory.GetFiles(path))
            {
                if (Path.GetExtension(dllName) == ".dll")
                {
                    Assembly dll = Assembly.LoadFile(dllName);
                    Type type = dll.GetExportedTypes()[0];
                    object o = Activator.CreateInstance(type);
                    dicoDll.Add((string)type.GetProperty("Name").GetValue(o), type);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            display.Text += string.Format(" > {0} \r\n", this.textBox1.Text);
            Calculate();
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void display_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveTrace_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("../../../Trace.txt");

                sw.WriteLine(this.display.Text);
                sw.Close();
            }
            catch (Exception a)
            {
                Console.WriteLine("Exception: " + a.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private void AvailableFonction_Click(object sender, EventArgs e)
        {
            string availableFonction = "Fonctions disponibles :\r\n";
            foreach (KeyValuePair<string, Type> kvp in dicoDll)
            {
                availableFonction += "\t" + kvp.Key + "\r\n";
            }
            MessageBox.Show(availableFonction);
        }

        private void Help_Click(object sender, EventArgs e)
        {
            Form2 testDialog = new Form2();
            testDialog.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Calculate()
        {
            try
            {
                //génére les regex
                Regex reg = new Regex(pattern);

                //verifie si les regex match bien
                if (reg.IsMatch(textBox1.Text.Replace(".", ",")))
                {
                    //recuperation des différents match
                    MatchCollection matches = reg.Matches(textBox1.Text.Replace(".", ","));
                    //recupération des groupes matchés
                    GroupCollection groups = matches[0].Groups;

                    //convertion des arguments pour l'evaluation
                    string[] element = Convert.ToString(groups["args"]).Split(';');

                    Type function = dicoDll[Convert.ToString(groups["function"])];
                    Object o = Activator.CreateInstance(function);

                    object result = function.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                           null, o, new object[] { element });

                    if (result is int[] || result is double[] || result is string[])
                    {
                        string text = "";
                        foreach (object elem in (double[])result)
                        {
                            text += Convert.ToString(elem);
                        }

                        display.Text += text + "\r\n";
                    }
                    else
                    {
                        result = Convert.ToString(result);
                        display.Text += result + "\r\n";
                    }  
                }
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException is EvaluationException)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
                else
                {
                    MessageBox.Show("Suivez l'exemple svp !\r\n ex : 5 + 6 (oubliez pas les espaces!)");
                }
            }
        }

        public Dictionary<string, Type> DicoDll
        {
            get { return dicoDll; }
        }
    }
}
