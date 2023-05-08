using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            string contraseña = txtcontraseña.Text;

            if ( contraseña == "1234")
            {
                MessageBox.Show("¡Bienvenido!");
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña son incorrectos. Por favor, inténtelo de nuevo.");
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 formulario2 = new Form2(); // Crea una instancia del formulario 2
            formulario2.ShowDialog(); // Muestra el formulario 2 de manera modal
        }
    }
}
