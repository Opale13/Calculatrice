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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void display_TextChanged(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            display.Text = string.Format(" > {0} \r\n", textBox1.Text);
            display.Text = string.Format(" {0} \r\n", Help());
            textBox1.Text = "";
        }

        private void Calculatrice_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string Help()
        {
            string function = this.textBox1.Text.ToLower();

            Form1 test = new Form1();
            Dictionary<string, Type> dicoDll = test.DicoDll;

            try
            {
                string result = "";
                object o = Activator.CreateInstance(dicoDll[function]);
                result += (string)dicoDll[function].GetProperty("HelpMessage").GetValue(o) + "\r\n";

                string[] param = (string[])dicoDll[function].GetProperty("ParametersName").GetValue(o);

                foreach (string para in param)
                {
                    result += para + ", ";
                }
                result += "\r\n";
                return result;
            }
            catch
            {
                return "Cette fonction n'existe pas";
            }
        }
    }
}
