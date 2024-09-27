using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3NLIDTS_AngelManuel_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtEdad.TextChanged += ValidarEdad;
            txtTelefono.TextChanged += ValidarTelefono;
            txtNombres.TextChanged += ValidarNombre;
            txtApellidos.TextChanged += ValidarApellido;
            txtEstatura.TextChanged += ValidarEstatura;
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
            string rutaArchivo = "C:\\Users\\Angel-PC\\Documents\\3NLIDTS-AngelManuel-04.txt";

            bool archivoExiste = File.Exists(rutaArchivo);

            using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
            {
                writer.WriteLine(datos);
                writer.WriteLine();
            }
            MessageBox.Show("Datos guardados exitosamente.");
        }
//Revision
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
        private bool EsEnteroValido(string valor)
        {
            int resultado;
            return int.TryParse(valor, out resultado);
        }

        public bool EsDecimalValido(string valor)
        {
            decimal resultado;
            return decimal.TryParse(valor, out resultado);
        }
        private bool EsEnteroValido10Digitos(string valor)
        {
            string formato = @"^\d{10}$";
            return Regex.IsMatch(valor, formato);
        }

        private bool EsTextoValido(string valor)
        {
            return Regex.IsMatch(valor, @"^[a-zA-Z\s]+$");
        }

        private void ValidarEdad(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EsEnteroValido(textbox.Text))
            {
                MessageBox.Show("Ingrese una edad valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }
        }

        private void ValidarEstatura(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EsDecimalValido(textbox.Text))
            {
                MessageBox.Show("Ingrese una Estatura valida", "Error estatura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }
        }
        private void ValidarApellido(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EsTextoValido(textbox.Text))
            {
                MessageBox.Show("Ingrese un apellido valido", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }
        }

        private void ValidarTelefono(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Text.Length == 10 && EsEnteroValido10Digitos(textbox.Text))
            {
                textbox.BackColor = Color.Green;
            }
            else
            {
                textbox.BackColor = Color.Red;
                MessageBox.Show("Ingrese un Telefono valido", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //textbox.Clear();
            }

        }
        private void ValidarNombre(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EsTextoValido(textbox.Text))
            {
                MessageBox.Show("Ingrese un Nombre valido", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }
        }
        //Hola Angel Daniel Manuel Torres

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
