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
