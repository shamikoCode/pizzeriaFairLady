//LLENAR EL GRIDVIEW DENTRO DEL GRIDCONTROL
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

// Suponiendo que tienes un objeto DataTable llamado "dataTable" que contiene los datos que deseas mostrar en el GridView.

// Obtén la vista de la grilla dentro del GridControl
GridView gridView = gridView1; // Reemplaza "gridView1" con el nombre de tu GridView dentro del GridControl

// Asigna el DataTable como origen de datos para el GridView
gridView.GridControl.DataSource = dataTable;

// Opcionalmente, puedes ajustar las columnas manualmente o permitir que DevExpress las genere automáticamente.

// Para ajustar las columnas manualmente:
// Por ejemplo, supongamos que tienes columnas en el DataTable llamadas "ID", "Nombre" y "Edad", y quieres mostrarlas en el GridView.
// Puedes agregar columnas manualmente al GridView:

// Limpiar las columnas existentes
gridView.Columns.Clear();

// Agregar nuevas columnas
gridView.Columns.Add(new GridColumn() { Caption = "ID", FieldName = "ID" });
gridView.Columns.Add(new GridColumn() { Caption = "Nombre", FieldName = "Nombre" });
gridView.Columns.Add(new GridColumn() { Caption = "Edad", FieldName = "Edad" });

// Si prefieres que DevExpress genere automáticamente las columnas, puedes habilitar la opción AutoGenerateColumns:
// gridView.OptionsView.ColumnAutoWidth = true;
// Esto hará que DevExpress cree automáticamente columnas para cada campo en el origen de datos.

// También puedes personalizar otras opciones de presentación y comportamiento del GridView según tus necesidades.

-------------------------------------------------------------------------------------------------------------------------------------------
//LLENAR TXTBOX
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;

// Supongamos que tienes un TextBox llamado "textBox1" donde quieres mostrar el valor seleccionado.

// En el constructor de tu formulario o en algún otro lugar donde configures tus componentes:
public Form1()
{
    InitializeComponent();

    // Suscribirte al evento FocusedRowChanged del GridView
    gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
}

// Evento para manejar el cambio de fila enfocada en el GridView
private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
{
    if (e.FocusedRowHandle >= 0) // Verifica que haya una fila seleccionada
    {
        // Obtiene el valor de la celda en la columna "Nombre" (reemplaza "Nombre" con el nombre de la columna que contiene el valor que deseas mostrar)
        object cellValue = gridView1.GetRowCellValue(e.FocusedRowHandle, "Nombre");

        // Si el valor no es nulo, lo muestra en el TextBox
        if (cellValue != null)
        {
            textBox1.Text = cellValue.ToString();
        }
        else
        {
            textBox1.Text = ""; // Limpia el TextBox si el valor es nulo
        }
    }
    else
    {
        textBox1.Text = ""; // Limpia el TextBox si no hay fila seleccionada
    }
}
