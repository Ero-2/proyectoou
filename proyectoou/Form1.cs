using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoou
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Form2 form2;

        public Form2 Form2Instance { get; private set; }

        private Form2 ObtenerForm2Instance()
        {
            if (form2 == null || form2.IsDisposed)
            {
                form2 = new Form2();
            }

            return form2;
        }


        


        private void button2_Click_1(object sender, EventArgs e)
        {
            form2 = new Form2();
            Form2Instance = form2;
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string codigo = TEXTBOX.Text;

            string rutaArchivo = "C:\\Users\\erick garcia\\Desktop\\datosdelagente.txt";
            string[] lineas = File.ReadAllLines(rutaArchivo);

            foreach (string linea in lineas)
            {
                if (linea.Contains("Código:"))
                {
                    string codigoRegistrado = linea.Substring(linea.IndexOf(":") + 1).Trim();

                    if (codigoRegistrado == codigo)
                    {
                        CodeVerified(this, codigo); 
                        return;
                    }
                }
            }

            MessageBox.Show("Código no encontrado.");






        }

        public void CodeVerified(object sender, string codigo)
        {
            MessageBox.Show("¡Bienvenido!");

            
        }

        


        private void label7_Click(object sender, EventArgs e)
        {

        }

        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

