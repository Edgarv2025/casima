using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace casima.informes
{
    public partial class eliminar : Form

    {
        public eliminar()
        {
            InitializeComponent();
            // Cargar los datos al iniciar el formulario
            CargarInventario();

        }

        private void CargarInventario()
        {
            using (SqlConnection connection = new SqlConnection(Class1.ConnectionString))
            {
                try
                {
                    // Abrir la conexión a la base de datos
                    connection.Open();

                    // Consulta para obtener los datos de la tabla Productos con un alias "Idproducto"
                    string query = "SELECT idproducto AS Codigo, descripcion as Descripcion, valorund as [Valor Unitario], saldos as [Saldo Actual] FROM Productos WHERE tipo = 'inventario' AND estado = 'activo'";

                    // Cargar los datos en un DataTable
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Asignar el DataTable como fuente de datos para el DataGridView
                    datainventario.DataSource = dataTable;

                    // Configurar el DataGridView en modo lectura
                    datainventario.ReadOnly = true;

                    // Manejar el formato de la columna Idproducto en el DataGridView
                    datainventario.CellFormatting += Datainventario_CellFormatting;
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje en caso de error
                    MessageBox.Show("Error al cargar el inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento CellFormatting para Idproducto con tres dígitos
        private void Datainventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica si la columna es "Valor Unitario"
            if (datainventario.Columns[e.ColumnIndex].Name == "Valor Unitario" && e.Value != null)
            {
                // Si el valor es un número (decimal), lo formateamos como moneda
                if (decimal.TryParse(e.Value.ToString(), out decimal valorUnitario))
                {
                    e.Value = valorUnitario.ToString("C");  // Formato de moneda
                    e.FormattingApplied = true;
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void txtpdf_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar el cuadro de diálogo para elegir dónde guardar el archivo PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Guardar archivo PDF",
                    FileName = "Listado de Inventario.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Crear un archivo de salida
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        // Crear el documento PDF
                        Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        // Título del PDF con fuente en negrita
                        Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                        Paragraph title = new Paragraph("Listado de Inventario", titleFont)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        doc.Add(title);

                        // Fecha actual con fuente normal
                        Font dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                        Paragraph date = new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"), dateFont)
                        {
                            Alignment = Element.ALIGN_RIGHT
                        };
                        doc.Add(date);

                        // Salto de línea
                        doc.Add(new Paragraph("\n"));

                        // Crear tabla para los datos del inventario
                        PdfPTable table = new PdfPTable(datainventario.Columns.Count)
                        {
                            WidthPercentage = 100
                        };

                        // Agregar encabezados de columna con fuente en negrita
                        Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                        foreach (DataGridViewColumn column in datainventario.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                BackgroundColor = BaseColor.LIGHT_GRAY,
                                Padding = 5
                            };
                            table.AddCell(cell);
                        }

                        // Agregar filas de datos con fuente normal
                        Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                        foreach (DataGridViewRow row in datainventario.Rows)
                        {
                            if (row.IsNewRow) continue;
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                // Verificar si la columna es "Valor Unitario" y formatear como moneda
                                string cellValue = cell.Value?.ToString() ?? "";
                                bool isMoneda = datainventario.Columns[cell.ColumnIndex].Name == "Valor Unitario";

                                // Si es la columna "Valor Unitario", formatear el valor como moneda
                                if (isMoneda && decimal.TryParse(cellValue, out decimal valorUnitario))
                                {
                                    cellValue = valorUnitario.ToString("C"); // Formato de moneda
                                }

                                // Definir la alineación, alineación derecha si es "Valor Unitario"
                                int alignment = isMoneda ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT;

                                PdfPCell dataCell = new PdfPCell(new Phrase(cellValue, cellFont))
                                {
                                    HorizontalAlignment = alignment,  // Alineación derecha para la columna "Valor Unitario"
                                    Padding = 5,
                                    MinimumHeight = 20f,
                                    NoWrap = false
                                };
                                table.AddCell(dataCell);
                            }
                        }

                        // Agregar la tabla al documento
                        doc.Add(table);

                        // Salto de línea
                        doc.Add(new Paragraph("\n"));

                        // Cerrar el documento PDF
                        doc.Close();
                    }

                    // Abrir el archivo PDF después de guardarlo
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);

                    MessageBox.Show("PDF exportado con éxito.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a PDF: " + ex.Message);
            }
        }

    }
}

