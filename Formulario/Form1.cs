using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace Formulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            string Nombres = textBoxNombre.Text;
            string Apellidos = textBoxApellidos.Text;
            string Edad = textBoxEdad.Text;
            string Estatura = textBoxEstatura.Text;
            string Telefono = textBoxTelefono.Text;
            string Genero = "";
            if (rbHombre.Checked)
            {
                Genero = "Hombre";
            }
            else if (rbMujer.Checked) 
            {
                Genero = "Mujer";
            }
            if (EsEnteroValido(Edad) && EsDecimalValido(Estatura) && EsEnteroValidoDe10Digitos(Telefono) && EsTextoValido(Nombres) && EsTextoValido(Apellidos))
            {
                string datos = $"Nombres: {Nombres}\r\nApellidos: {Apellidos} \r\nTelefono: {Telefono} kg\r\nEstatura:{Estatura} cm\r\nEdad:{Edad} años\r\nGenero: {Genero}";
                string ruta = "C:/Users/JoseB/OneDrive/Documentos/prueba.txt";
                //File.WriteAllText(ruta,datos);
                bool archivoExiste = File.Exists(ruta);
                Console.WriteLine(archivoExiste);
                if (archivoExiste == false)
                {
                    File.WriteAllText(ruta, datos);
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(ruta))
                    {
                        if (archivoExiste)
                        {
                            writer.WriteLine();
                        }
                        writer.WriteLine(datos);
                    }
                }
                MessageBox.Show("Datos guardados correctamente:\n\n" + datos, "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Datos no validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool EsEnteroValido(string valor)
        {
            int resultado;
            return int.TryParse(valor, out resultado);
        }
        private bool EsDecimalValido(string valor)
        {
            decimal resultado;
            return decimal.TryParse(valor, out resultado);
        }
        private bool EsEnteroValidoDe10Digitos(string valor)
        {
            long resultado;
            return long.TryParse(valor, out resultado);
        }
        private bool EsTextoValido(string valor)
        {
            return Regex.IsMatch(valor, @"^[a-zA-Z\s]+$");
        }
        private void ValidarTelefono(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            string input = textbox.Text;
            input = input.Replace(" ", "").Replace("-", "");
            if (input.Length > 10)
            {
                if (!EsEnteroValidoDe10Digitos(input))
                {
                    MessageBox.Show("El telefono no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textbox.Clear();
                }

            }
            else if (!EsEnteroValidoDe10Digitos(input))
            {
                MessageBox.Show("El telefono no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ValidarEstatura(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EsDecimalValido(textbox.Text))
            {
                MessageBox.Show("La estatura no es valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }
        }
        private void ValidarEdad(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EsEnteroValido(textbox.Text))
            {
                MessageBox.Show("La edad no es valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }
        }
        private void ValidarApellido(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EsTextoValido(textbox.Text))
            {
                MessageBox.Show("El apellido no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }
        }
        private void ValidarNombre(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EsTextoValido(textbox.Text))
            {
                MessageBox.Show("El nombre no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            textBoxApellidos.Clear();
            textBoxEstatura.Clear();
            textBoxTelefono.Clear();
            textBoxEdad.Clear();

        }

    }
}
