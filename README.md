# pizzeriaFairLady
It´s a pizzeria that would be a real aplication if I need buy pizzas

Mini ayuda para el CRUD
https://github.com/SaadARazzaq/CRUD-Operations-In-Oracle-Database-Using-Visual-Studio-2019

DataGridView in TextBox
using System;
using System.Windows.Forms;

namespace DataGridViewExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Aquí puedes cargar datos en el DataGridView, por ejemplo, desde una base de datos o una lista.
            // En este ejemplo, se crea una tabla simple con dos columnas.
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Nombre", typeof(string));

            dataTable.Rows.Add(1, "Ejemplo 1");
            dataTable.Rows.Add(2, "Ejemplo 2");
            dataTable.Rows.Add(3, "Ejemplo 3");

            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtiene la fila seleccionada.
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Obtiene el valor de la celda en la columna "Nombre" (o la columna que desees).
                string nombre = row.Cells["Nombre"].Value.ToString();

                // Muestra el valor en el TextBox.
                textBox1.Text = nombre;
            }
        }
    }
}

Login
using System;
using System.Data;
using Oracle.ManagedDataAccess.Client; // Asegúrate de tener esta referencia agregada a tu proyecto

namespace OracleLoginForm
{
    public partial class LoginForm : Form
    {
        private OracleConnection connection;
        
        public LoginForm()
        {
            InitializeComponent();
            string connectionString = "Data Source=TuFuenteDeDatosOracle;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;";
            connection = new OracleConnection(connectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                connection.Open();

                // Aquí puedes ejecutar una consulta para verificar las credenciales del usuario
                // Por ejemplo:
                string query = "SELECT COUNT(*) FROM usuarios WHERE username = :username AND password = :password";
                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
                command.Parameters.Add(":password", OracleDbType.Varchar2).Value = password;

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Inicio de sesión exitoso");
                    // Si las credenciales son válidas, puedes abrir el siguiente formulario o realizar otras acciones.
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
