using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoFinalEstadisticaII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool revEnter(KeyPressEventArgs e) => e.KeyChar == (char)Keys.Enter;

        private bool revRegex(string text) => Regex.IsMatch(text, @"^\d+$");

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (revEnter(e))
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Clear();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (revEnter(e) && revRegex(textBox2.Text))
            {
                listBox2.Items.Add(textBox2.Text);
                textBox2.Clear();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (revEnter(e) && revRegex(textBox3.Text))
            {
                listBox3.Items.Add(textBox3.Text);
                textBox3.Clear();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (revEnter(e) && revRegex(textBox4.Text))
            {
                listBox4.Items.Add(textBox4.Text);
                textBox4.Clear();
            }
        }

        private bool revListas()
        {
            int a = listBox2.Items.Count,
                b = listBox3.Items.Count,
                c = listBox4.Items.Count;

            if (a > 2)
            {
                MessageBox.Show("Ingresar solo 2 grupos porfis");
                return false;
            }

            if (a == b && b == c && a == 2 && a > 0)
            {
                return true;
            }

            MessageBox.Show("Verifica que todas las listas tengan 2 valores.");
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!revListas()) return;

            try
            {
                float[] pro = {
                    float.Parse(listBox2.Items[0].ToString()),
                    float.Parse(listBox2.Items[1].ToString())
                };
                float[] var = {
                    float.Parse(listBox3.Items[0].ToString()),
                    float.Parse(listBox3.Items[1].ToString())
                };
                int[] con = {
                    int.Parse(listBox4.Items[0].ToString()),
                    int.Parse(listBox4.Items[1].ToString())
                };

                PruebaT prueba = new PruebaT(pro, var, con);

                string resultado = prueba.ObtenerInterpretacion();

                MessageBox.Show(resultado, "Resultado Prueba t");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
