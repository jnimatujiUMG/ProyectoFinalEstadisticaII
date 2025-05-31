using System;
using System.Windows.Forms;

namespace ProyectoFinalEstadisticaII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Métodos Comunes

        private bool revEnter(KeyPressEventArgs e)
        {
            return e.KeyChar == (char)Keys.Enter;
        }

        private bool revRegex(string texto)
        {
            return float.TryParse(texto, out _);
        }

        #endregion

        #region Prueba T

        private bool revListasT()
        {
            int nombres = listBox1.Items.Count;
            int medias = listBox2.Items.Count;
            int desviaciones = listBox3.Items.Count;
            int tamanos = listBox4.Items.Count;

            if (medias > 2)
            {
                MessageBox.Show("Ingresar solo 2 grupos porfis");
                return false;
            }

            if (nombres == medias && medias == desviaciones && desviaciones == tamanos && nombres == 2)
            {
                return true;
            }

            MessageBox.Show("Verifica que todas las listas tengan 2 valores.");
            return false;
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!revListasT()) return;

            try
            {
                float[] medias = {
                    float.Parse(listBox2.Items[0].ToString()),
                    float.Parse(listBox2.Items[1].ToString())
                };
                float[] desviaciones = {
                    float.Parse(listBox3.Items[0].ToString()),
                    float.Parse(listBox3.Items[1].ToString())
                };
                int[] tamanos = {
                    int.Parse(listBox4.Items[0].ToString()),
                    int.Parse(listBox4.Items[1].ToString())
                };

                PruebaT prueba = new PruebaT(medias, desviaciones, tamanos);
                string resultado = prueba.ObtenerInterpretacion();
                MessageBox.Show(resultado, "Resultado Prueba T");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        #endregion

        #region Prueba F

        private bool revListasF()
        {
            int nombres = listBox7.Items.Count;
            int varianzas = listBox6.Items.Count;
            int tamanos = listBox5.Items.Count;

            if (varianzas > 2)
            {
                MessageBox.Show("Ingresar solo 2 grupos porfis");
                return false;
            }

            if (nombres == varianzas && varianzas == tamanos && nombres == 2)
            {
                return true;
            }

            MessageBox.Show("Verifica que todas las listas tengan 2 valores.");
            return false;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (revEnter(e))
            {
                listBox7.Items.Add(textBox7.Text);
                textBox7.Clear();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (revEnter(e) && revRegex(textBox6.Text))
            {
                listBox6.Items.Add(textBox6.Text);
                textBox6.Clear();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (revEnter(e) && revRegex(textBox5.Text))
            {
                listBox5.Items.Add(textBox5.Text);
                textBox5.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!revListasF()) return;

            try
            {
                float[] varianzas = {
                    float.Parse(listBox6.Items[0].ToString()),
                    float.Parse(listBox6.Items[1].ToString())
                };
                int[] tamanos = {
                    int.Parse(listBox5.Items[0].ToString()),
                    int.Parse(listBox5.Items[1].ToString())
                };

                PruebaF prueba = new PruebaF(varianzas, tamanos);
                string resultado = prueba.ObtenerInterpretacion();
                MessageBox.Show(resultado, "Resultado Prueba F");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!revListasF()) return;

            try
            {
                float[] varianzas = {
            float.Parse(listBox6.Items[0].ToString()),
            float.Parse(listBox6.Items[1].ToString())
        };
                int[] tamanos = {
            int.Parse(listBox5.Items[0].ToString()),
            int.Parse(listBox5.Items[1].ToString())
        };

                PruebaF prueba = new PruebaF(varianzas, tamanos);
                string resultado = prueba.ObtenerInterpretacion();
                MessageBox.Show(resultado, "Resultado Prueba F");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        #endregion


        #region Di}ferencia de medias

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener datos
                string nombre = textBox10.Text;
                double promedio1 = double.Parse(textBox9.Text);
                double promedio2 = double.Parse(textBox8.Text);

                // Instanciar objeto
                DiferenciaMedias diferencia = new DiferenciaMedias(nombre, promedio1, promedio2);

                // Agregar a los listbox
                listBox10.Items.Add(diferencia.Nombre);
                listBox9.Items.Add(diferencia.Promedio1.ToString("F2"));
                listBox8.Items.Add(diferencia.Promedio2.ToString("F2"));

                // Mostrar resultado
                MessageBox.Show($"La diferencia entre medias es: {diferencia.CalcularDiferencia():F2}");

                // Limpiar entradas
                textBox10.Clear();
                textBox9.Clear();
                textBox8.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingresa valores válidos para los promedios.");
            }
        }


        #endregion
    }
}
