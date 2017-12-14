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
        private string pattern = @"^(?<function>[a-zA-Z\d]+) (?<args>[-\d;\,]+)$";

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

                    try
                    {
                        int suffix = 1;
                        string name = ((string)type.GetProperty("Name").GetValue(o)).ToLower();

                        while (true)
                        {
                            if (!dicoDll.ContainsKey(name))
                            {
                                dicoDll.Add(name, type);
                                break;
                            }
                            else
                            {
                                suffix++;
                                name += Convert.ToString(suffix);
                            }
                        }
                    }
                    catch (TargetInvocationException ex)
                    {
                        if (ex.InnerException is EvaluationException)
                        {
                            MessageBox.Show(ex.InnerException.Message);
                        }
                    }
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
            textBox1.Select();
        }

        private void Calculate()
        {
            //génére les regex
            Regex reg = new Regex(pattern);

            //verifie si les regex match bien
            string texte = textBox1.Text.Replace(".", ",");
            if (reg.IsMatch(texte))
            {
                //recuperation des différents match
                MatchCollection matches = reg.Matches(textBox1.Text.Replace(".", ",").ToLower());
                //recupération des groupes matchés
                GroupCollection groups = matches[0].Groups;

                //convertion des arguments pour l'evaluation
                string[] element = Convert.ToString(groups["args"]).Split(';');

                try
                {
                    Type function = dicoDll[Convert.ToString(groups["function"])];
                    Object o = Activator.CreateInstance(function);
                    object result = function.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                            null, o, new object[] { element });

                    Type info = function.GetMethod("Evaluate").ReturnType;

                    string type = Convert.ToString(info).Split('.')[1].ToLower();

                    if (type == "double[]")
                    {
                        string simpleType = type.Split('[')[0];

                        string text = "";
                        foreach (double elem in (double[])result)
                        {
                            text += Convert.ToString(elem);
                        }

                        display.Text += text + "\r\n";
                    }
                    else if (type == "int16[]" || type == "int32[]" || type == "int64[]")
                    {
                        string simpleType = type.Split('[')[0];
                        string text = "";
                        foreach (int elem in (int[])result)
                        {
                            text += Convert.ToString(elem);
                        }

                        display.Text += text + "\r\n";
                    }
                    else if (type == "string[]")
                    {
                        string simpleType = type.Split('[')[0];

                        string text = "";
                        foreach (string elem in (string[])result)
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
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException is EvaluationException)
                    {
                        MessageBox.Show(ex.InnerException.Message);
                        display.Text += "Erreur\r\n";
                    }
                }
                catch
                {
                    MessageBox.Show("Votre fonction n'existe pas dans notre base de donnee.");
                    display.Text += "Erreur\r\n";
                }
            }
            else
            {
                MessageBox.Show("Veuillez respecter la mise en forme.\r\nPour plus d'informations, cliquez sur le bouton Help");
                display.Text += "Erreur\r\n";
            }
        }

        public Dictionary<string, Type> DicoDll
        {
            get { return dicoDll; }
        }
    }
}
