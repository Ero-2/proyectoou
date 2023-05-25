using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using static proyectoou.MembresiaSemana;

namespace proyectoou
{
    public partial class Form2 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private fotito foto = new fotito();

        private fotito instanciaFotito;


        public DataGridView DataGridViewClientes
        {
            get { return dataGridView1; }
        }


        private Form1 form1;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        public Form2()
        {
            

            InitializeComponent();

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoDevice.NewFrame += VideoDevice_NewFrame;
                videoDevice.Start();
            }

        }

       


        private void Form2_Load(object sender, EventArgs e)
        {


        }

        private void VideoDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            if (bitmap != null)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = bitmap;

                foto.Image = bitmap;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoDevice != null && videoDevice.IsRunning)
            {
                videoDevice.SignalToStop();
                videoDevice.WaitForStop();
                videoDevice.NewFrame -= VideoDevice_NewFrame;
                videoDevice = null;


               
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    
                    string nombre = row.Cells["NombreData"].Value?.ToString();
                    string edad = row.Cells["EdadData"].Value?.ToString();
                    string telefono = row.Cells["TelefonoData"].Value?.ToString();
                    string saldo = row.Cells["SaldoData"].Value?.ToString();
                    string fotoPath = row.Cells["FotoData"].Value?.ToString();
                    string codigo = row.Cells["CodigoData"].Value?.ToString();

                    
                    string infoCliente = "Nombre: " + nombre + Environment.NewLine +
                                         "Edad: " + edad + Environment.NewLine +
                                         "Teléfono: " + telefono + Environment.NewLine +
                                         "Saldo: " + saldo + Environment.NewLine +
                                         "FotoPath: " + fotoPath + Environment.NewLine +
                                         "Código: " + codigo + Environment.NewLine;

                    
                    string rutaArchivo = "C:\\Users\\erick garcia\\Desktop\\datosdelagente.txt";
                    File.AppendAllText(rutaArchivo, infoCliente);

                }
            }

        }





        private void button2_Click(object sender, EventArgs e)
        {
            foto.SaveImage();



        }

        int saldo = 0;

       private Membresia membresia;

        private void button3_Click(object sender, EventArgs e)
        {
            membresia = new MembresiaSemana();
            membresia.FechaInicio = DateTime.Now;

            TimeSpan tiempoRestante = membresia.TiempoRestante();
            DateTime fechaFin = membresia.FechaFin();

            string mensaje = "Se ha cobrado 100 pesos por una semana de membresía." + Environment.NewLine +
                             "Tiempo restante: " + tiempoRestante.Days + " días" + Environment.NewLine +
                             "Fecha de finalización: " + fechaFin.ToString("dd/MM/yyyy");

            MessageBox.Show(mensaje);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            membresia = new MembresiaMes();
            membresia.FechaInicio = DateTime.Now;

            TimeSpan tiempoRestante = membresia.TiempoRestante();
            DateTime fechaFin = membresia.FechaFin();

            string mensaje = "Se ha cobrado 300 pesos por un mes de membresía." + Environment.NewLine +
                             "Tiempo restante: " + tiempoRestante.Days + " días" + Environment.NewLine +
                             "Fecha de finalización: " + fechaFin.ToString("dd/MM/yyyy");

            MessageBox.Show(mensaje);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            membresia = new Membresiaño();
            membresia.FechaInicio = DateTime.Now;

            TimeSpan tiempoRestante = membresia.TiempoRestante();
            DateTime fechaFin = membresia.FechaFin();

            string mensaje = "Se ha cobrado 3200 pesos por un año de membresía." + Environment.NewLine +
                             "Tiempo restante: " + tiempoRestante.Days + " días" + Environment.NewLine +
                             "Fecha de finalización: " + fechaFin.ToString("dd/MM/yyyy");

            MessageBox.Show(mensaje);
        }



        private void button6_Click(object sender, EventArgs e)
        {
            
            string nombre = Nombre.Text;
            string codigo = nombre.Length >= 3 ? nombre.Substring(0, 3) : nombre;
            string edad = Edad.Text;
            string telefono = Telefono.Text;

            fotito instanciaFotito = new fotito();
            instanciaFotito.Image = foto.Image;
            instanciaFotito.SaveImage();


            
            string infoCliente = "Nombre: " + nombre + Environment.NewLine +
                                 "edad: " + edad + Environment.NewLine +
                                 "telefono: " + telefono + Environment.NewLine +
                                 "Saldo: " + saldo;


           

            DataGridView dataGridView = dataGridView1; 
            int rowIndex = dataGridView.Rows.Add();
            dataGridView.Rows[rowIndex].Cells["NombreData"].Value = nombre;
            dataGridView.Rows[rowIndex].Cells["EdadData"].Value = edad;
            dataGridView.Rows[rowIndex].Cells["TelefonoData"].Value = telefono;
             dataGridView.Rows[rowIndex].Cells["SaldoData"].Value = membresia.Saldo;
            dataGridView.Rows[rowIndex].Cells["FotoData"].Value = instanciaFotito.FilePath;
            dataGridView.Rows[rowIndex].Cells["CodigoData"].Value = codigo;

           


            MessageBox.Show("Cliente registrado correctamente.");

            
            Nombre.Text = "";
            Edad.Text = "";
            Telefono.Text = "";
            saldo = 0;

          
        }

        private void button1_Click(object sender, EventArgs e)
        {

           

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string nombre = row.Cells["NombreData"].Value?.ToString();
                    string edad = row.Cells["EdadData"].Value?.ToString();
                    string telefono = row.Cells["TelefonoData"].Value?.ToString();
                    string saldo = row.Cells["SaldoData"].Value?.ToString();
                    string fotoPath = row.Cells["FotoData"].Value?.ToString();
                    string codigo = row.Cells["CodigoData"].Value?.ToString();

                    
                    string infoCliente = "Nombre: " + nombre + Environment.NewLine +
                                         "Edad: " + edad + Environment.NewLine +
                                         "Teléfono: " + telefono + Environment.NewLine +
                                         "Saldo: " + saldo + Environment.NewLine +
                                         "FotoPath: " + fotoPath + Environment.NewLine +
                                         "Código: " + codigo + Environment.NewLine;

                    string rutaArchivo = "C:\\Users\\erick garcia\\Desktop\\datosdelagente.txt";
                    File.AppendAllText(rutaArchivo, infoCliente);

                   

                }
            }


          
            this.Close();
        }

       
    }

}
