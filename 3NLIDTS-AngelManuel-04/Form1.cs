using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3NLIDTS_AngelManuel_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            string edad = txtEdad.Text;
            string estatura = txtEstatura.Text;
            string telefono = txtTelefono.Text;

            string genero = "";
            if(rbHombre.Checked )
            {
                genero = "Hombre";
            }
            else if(rbMujer.Checked ) 
            {
                genero = "Mujer";           
            }

            string datos = $"Nombres: {nombres}\r\nApellidos: {apellidos}\r\nEdad: {edad} años\r\nEstatura: {estatura} cm\r\nTelefono: {telefono}\r\nGenero: {genero}";
            string rutaArchivo = "C:\\Users\\Angel-PC\\Documents\\FormularioDatos.txt";

            bool archivoExiste = File.Exists(rutaArchivo);

            using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
            {
                writer.WriteLine(datos);
                writer.WriteLine();
            }
            MessageBox.Show("Datos guardados exitosamente.");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtEdad.Clear();
            txtTelefono.Clear();
            txtEstatura.Clear();
            rbHombre.Checked = false;
            rbMujer.Checked = false;

        }
    }
}
