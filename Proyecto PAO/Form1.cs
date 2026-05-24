using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_PAO
{
    public partial class Form1 : Form
    {
        // VARIABLES PARA VERIFICAR DATOS
        bool nombreLleno = false;
        bool pesoLleno = false;
        bool alturaLlena = false;
        bool sexoLleno = false;
        bool edadLlena = false;

        public Form1()
        {
            InitializeComponent();

            // OCULTAR BOTON DE CAMBIO DE VENTANA
            button7.Visible = false;
        }

        // FUNCION PARA VERIFICAR SI TODO ESTA COMPLETO
        private void VerificarDatos()
        {
            if (nombreLleno &&
                pesoLleno &&
                alturaLlena &&
                sexoLleno &&
                edadLlena)
            {
                button7.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = Interaction.InputBox("Ingresa el nombre:", "Registro");

            nombreLleno = true;

            VerificarDatos();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string cadenaConexion = "Database=proyecto; Data source=localhost; User Id=root; Password=; SSL Mode=Preferred";

            MySqlConnection conexionDB;

            DataTable usuarios = new DataTable();

            MySqlDataReader consulta;

            try
            {
                conexionDB = new MySqlConnection(cadenaConexion);

                MySqlCommand instruccion = new MySqlCommand("Select * FROM usuarios;", conexionDB);

                instruccion.CommandType = CommandType.Text;

                conexionDB.Open();

                consulta = instruccion.ExecuteReader();

                usuarios.Load(consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dataGridView1.DataSource = usuarios;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int peso = Convert.ToInt32(
                Interaction.InputBox("Ingresa el peso:", "Registro"));

            pesoLleno = true;

            VerificarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double altura = Convert.ToDouble(
                Interaction.InputBox("Ingresa la altura:", "Registro"));

            alturaLlena = true;

            VerificarDatos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sexo = Interaction.InputBox(
                "Ingresa el sexo:", "Registro");

            sexoLleno = true;

            VerificarDatos();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int edad = Convert.ToInt32(
                Interaction.InputBox("Ingresa la edad:", "Registro"));

            edadLlena = true;

            VerificarDatos();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 ventana = new Form2();

            ventana.Show();

            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}