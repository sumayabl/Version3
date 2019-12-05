using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        delegate void DelegadoParaEscribir(string mensaje);
        Socket server;
        string name;


        public Form2(Socket ser, string nombre)
        {
            InitializeComponent();
            server = ser;
            name = nombre;
            label1.Text = nombre;
        }

        public void Conectados(string mensaje) {

            MessageBox.Show(mensaje);

            string[] words = mensaje.Split('/');
            ListaC.Items.Clear();

            int i = 0;
            int result = Int32.Parse(words[1]);

            while (i < result)
            {
                ListaC.Items.Add(words[i + 2]);
                i++;
            }
        }

        public void Actualizar(string mensaje) {

            string[] words = mensaje.Split('/');
            ListaC.Items.Clear();

            int i = 0;
            int result = Int32.Parse(words[1]);

            while (i < result)
            {
                ListaC.Items.Add(words[i + 2]);
                i++;
            }
        
        }

        public void Lista(string mensaje) {

            string[] words = mensaje.Split('/');
            ListaC.Items.Clear();

            int i = 0;
            int result = Int32.Parse(words[1]);

            while (i < result)
            {
                ListaC.Items.Add(words[i + 2]);
                i++;
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\abc_s\OneDrive\Escritorio\cliente\WindowsFormsApplication1\bin\Debug\Uno.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = "3/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "4/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            Form1 Game = new Form1();
            this.Close();
            this.Hide();
            Game.ShowDialog();
            //Game.Show();
            //this.Show();
        }
    }
}
