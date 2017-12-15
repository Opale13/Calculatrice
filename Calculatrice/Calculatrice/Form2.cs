using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculatrice;

namespace Calculatrice
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            display.Text = "Pour utiliser notre calculatrice, il vous suffit d'indiquer le nom de la fonction que vous voulez utiliser" +
                           " suivi d'un espace suivi par les nombres à donner en paramètre separes chacun par un point-virgule";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //if you press enter and not the "Search" button
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                display.Text = string.Format("> {0} \r\n", textBox1.Text);
                display.Text = string.Format("{0} \r\n", Help());
                textBox1.Text = "";
            }
        }

        private void display_TextChanged(object sender, EventArgs e)
        {
        }

        //starts the action of the search button
        private void Search_Click(object sender, EventArgs e)
        {
            display.Text = string.Format("> {0} \r\n", textBox1.Text);
            display.Text = string.Format("{0} \r\n", Help());
            textBox1.Text = "";
        }

        private void Calculatrice_Click(object sender, EventArgs e)
        {
            Close();
        }

        //displays a help message depending on the command
        private string Help()
        {
            //desired command
            string function = textBox1.Text.ToLower();

            //dll dictionary recovery
            Form1 test = new Form1();
            Dictionary<string, Type> dicoDll = test.DicoDll;

            try
            {
                string result = "";
                object o = Activator.CreateInstance(dicoDll[function]);

                //recovery of the help message associated with the command
                result += (string) dicoDll[function].GetProperty("HelpMessage").GetValue(o) + "\r\n\r\n";

                //recovering parameter names
                string[] param = (string[]) dicoDll[function].GetProperty("ParametersName").GetValue(o);

                result += "Le(s) paramètre(s) à donner:\r\n";

                //shaping
                foreach (string para in param)
                {
                    result += "\t-->" + para + "\r\n";
                }
                result += "\r\n";

                return result;
            }
            catch
            {
                return "Cette fonction n'existe pas";
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //place the cursor in the input box
            textBox1.Select();
        }
    }
}
