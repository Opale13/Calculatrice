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

        //regular expression to capture the command
        private string pattern = @"^(?<function>[a-zA-Z\d]+) (?<args>[-\d;\,]+)$";

        public Form1()
        {
            InitializeComponent();

            //creation of the dictionary containing "functions"
            string path = Path.GetFullPath(@"..\..\..\..\dll");
            foreach (string dllName in Directory.GetFiles(path))
            {
                if (Path.GetExtension(dllName) == ".dll")
                {
                    //dynamic loading of dll by reflection
                    Assembly dll = Assembly.LoadFile(dllName);
                    Type type = dll.GetExportedTypes()[0];
                    object o = Activator.CreateInstance(type);

                    try
                    {
                        int suffix = 1;
                        //recovering the return value of the "Name" method
                        string name = ((string)type.GetProperty("Name").GetValue(o)).ToLower();

                        //Allows you to add a function that has the same name as an already present 
                        //in the dictionary
                        while (true)
                        {
                            if (!dicoDll.ContainsKey(name))
                            {
                                dicoDll.Add(name, type);
                                break;
                            }
                            //if the name of the dll is already present we add a suffix.
                            else
                            {
                                suffix++;
                                name += Convert.ToString(suffix);
                            }
                        }
                    }
                    //capture exceptions
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

        //if you press enter and not the "Compute" button
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                display.Text += string.Format(" > {0} \r\n", textBox1.Text);
                Calculate();
                textBox1.Text = "";
            }
        }

        private void display_TextChanged(object sender, EventArgs e)
        {
        }

        //Save the calculation of the session in a "Trace.txt" file
        private void SaveTrace_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("../../../../Trace.txt");

                sw.WriteLine(display.Text);
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

        //
        private void AvailableFonction_Click(object sender, EventArgs e)
        {
            string availableFonction = "Fonctions disponibles :\r\n";
            foreach (KeyValuePair<string, Type> kvp in dicoDll)
            {
                availableFonction += "\t" + kvp.Key + "\r\n";
            }
            MessageBox.Show(availableFonction);
        }
        
        //run Form2 for help messages
        private void Help_Click(object sender, EventArgs e)
        {
            Form2 testDialog = new Form2();
            testDialog.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //place the cursor in the input box
            textBox1.Select(); 
        }

        private void Calculate()
        {
            //generate the regex
            Regex reg = new Regex(pattern);

            //check if the regex match well
            string texte = textBox1.Text.Replace(".", ",");
            if (reg.IsMatch(texte))
            {
                //recovery of different matches
                MatchCollection matches = reg.Matches(texte.ToLower());
                //recovery of matched groups
                GroupCollection groups = matches[0].Groups;

                //conversion of arguments for evaluation
                string[] element = Convert.ToString(groups["args"]).Split(';');

                try
                {

                    Type function = dicoDll[Convert.ToString(groups["function"])];
                    Object o = Activator.CreateInstance(function);

                    object result = function.InvokeMember("Evaluate", BindingFlags.InvokeMethod,
                                            null, o, new object[] { element });

                    //recovery of the return type of the Evaluate method
                    Type info = function.GetMethod("Evaluate").ReturnType;                    
                    string type = Convert.ToString(info).Split('.')[1].ToLower();

                    //processes the return values, according to their type
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

        //getter for Form2
        public Dictionary<string, Type> DicoDll
        {
            get { return dicoDll; }
        }
    }
}
