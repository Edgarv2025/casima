using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml; // para exportar a Excel
using iTextSharp.text; // para exportar a PDF
using iTextSharp.text.pdf;

namespace casima.operacion
{
    public partial class Finformesventas : Form
    {
        private SqlConnection connection = new SqlConnection(Class1.ConnectionString);

        public Finformesventas()
        {
            InitializeComponent();
            txtncaja.Text = "todas";

            // Configurar el DataGridView como de solo lectura
            dinfoventas.ReadOnly = true;

            // Evitar que el usuario agregue nuevas filas
            dinfoventas.AllowUserToAddRows = false;

            // Evitar que el usuario elimine filas
            dinfoventas.AllowUserToDeleteRows = false;

            // Evitar que el usuario reordene columnas
            dinfoventas.AllowUserToOrderColumns = false;

            // Configurar el TextBox como de solo lectura
            txttotalinforme.ReadOnly = true;
        }

        private void BuscarCabVentas(int? idcaja = null)
        {
            try
            {
                ActualizarTotalVenta(); // Asegurarse que el totalventa esté actualizado

                connection.Open();
                string query = "SELECT idventa as Venta, idcliente as Cliente, idcaja as Caja, idusuario as Usuario, fechaventa as [Fecha de Venta], totalventa as [Total Ventas] FROM cab_venta WHERE fechaventa BETWEEN @fechaInicio AND @fechaFinal AND estado = 'activo'";

                // Si se ha seleccionado una caja, agregar la condición de filtrado por idcaja
                if (idcaja.HasValue)
                {
                    query += " AND idcaja = @idcaja";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DateTime fechaInicio = dateinicio.Value.Date;
                    DateTime fechaFinal = datefinal.Value.Date.AddDays(1).AddTicks(-1);

                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFinal", fechaFinal);

                    if (idcaja.HasValue)
                    {
                        command.Parameters.AddWithValue("@idcaja", idcaja.Value);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dinfoventas.DataSource = dataTable;

                    // Totalizar las ventas
                    int totalVentas = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        totalVentas += Convert.ToInt32(row["Total Ventas"]);
                    }

                    txttotalinforme.Text = totalVentas.ToString("C0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en cab_venta: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void bventag_Click(object sender, EventArgs e)
        {
            // Buscar datos en la tabla cab_venta
            BuscarCabVentas();
        }

        private void bventad_Click(object sender, EventArgs e)
        {
            // Buscar datos en la tabla det_venta
            BuscarDetVentas();
        }

        private void ActualizarTotalVenta()
        {
            try
            {
                connection.Open();
                string query = @"
                    UPDATE cab_venta
                    SET totalventa = (SELECT SUM(subtotal) FROM det_venta WHERE det_venta.idventa = cab_venta.idventa)
                    WHERE estado = 'activo'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar totalventa en cab_venta: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void BuscarCabVentas()
        {
            try
            {
                ActualizarTotalVenta(); // Asegurarse que el totalventa esté actualizado

                connection.Open();
                string query = "SELECT idventa as Venta, idcliente as Cliente, idcaja as Caja, idusuario as Usuario, fechaventa as [Fecha de Venta], totalventa as [Total Ventas] FROM cab_venta WHERE fechaventa BETWEEN @fechaInicio AND @fechaFinal AND estado = 'activo'";

                // Verificar si el valor de txtncajas es "todas" o si es un idcaja específico
                if (txtncaja.Text != "todas" && !string.IsNullOrEmpty(txtncaja.Text))
                {
                    query += " AND idcaja = @idcaja";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DateTime fechaInicio = dateinicio.Value.Date;
                    DateTime fechaFinal = datefinal.Value.Date.AddDays(1).AddTicks(-1);

                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFinal", fechaFinal);

                    // Si no es "todas", agregar el parámetro de idcaja
                    if (txtncaja.Text != "todas" && !string.IsNullOrEmpty(txtncaja.Text))
                    {
                        command.Parameters.AddWithValue("@idcaja", txtncaja.Text);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dinfoventas.DataSource = dataTable;

                    // Verificar si la columna "Total Ventas" existe y aplicar formato
                    if (dinfoventas.Columns.Contains("Total Ventas"))
                    {
                        dinfoventas.Columns["Total Ventas"].DefaultCellStyle.Format = "C0";  // Formato de moneda
                        dinfoventas.Columns["Total Ventas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Alinear a la derecha
                    }

                    // Totalizar las ventas
                    int totalVentas = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        totalVentas += Convert.ToInt32(row["Total Ventas"]);
                    }

                    txttotalinforme.Text = totalVentas.ToString("C0");  // Formatear total en moneda
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en cab_venta: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void BuscarDetVentas()
        {
            try
            {
                ActualizarTotalVenta(); // Asegurarse que el totalventa esté actualizado

                connection.Open();
                string query = @"
        SELECT
            cab.idventa as Venta,
            cab.idcaja as Caja,
            cab.idusuario as Usuario,
            cab.fechaventa as [Fecha de Venta],
            det.idproducto as [Codigo de Producto],
            prod.descripcion as [Descripcion Producto],
            det.cantidad,
            det.valorunidad as [valor Unitario],
            det.subtotal
        FROM 
            cab_venta cab
        INNER JOIN 
            det_venta det ON cab.idventa = det.idventa
        INNER JOIN 
            productos prod ON det.idproducto = prod.idproducto
        WHERE 
            cab.fechaventa BETWEEN @fechaInicio AND @fechaFinal AND cab.estado = 'activo'";

                if (txtncaja.Text != "todas" && !string.IsNullOrEmpty(txtncaja.Text))
                {
                    query += " AND cab.idcaja = @idcaja";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DateTime fechaInicio = dateinicio.Value.Date;
                    DateTime fechaFinal = datefinal.Value.Date.AddDays(1).AddTicks(-1);

                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFinal", fechaFinal);

                    if (txtncaja.Text != "todas" && !string.IsNullOrEmpty(txtncaja.Text))
                    {
                        command.Parameters.AddWithValue("@idcaja", txtncaja.Text);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dinfoventas.DataSource = dataTable;

                    // Formatear las columnas en DataGridView
                    if (dinfoventas.Columns["Valor Unitario"] != null)
                        dinfoventas.Columns["Valor Unitario"].DefaultCellStyle.Format = "C0";
                    if (dinfoventas.Columns["subtotal"] != null)
                        dinfoventas.Columns["subtotal"].DefaultCellStyle.Format = "C0";
                  

                    // Alinear a la derecha las columnas correspondientes
                    dinfoventas.Columns["Valor Unitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dinfoventas.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    
                    // Totalizar los subtotales
                    int totalSubtotal = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        totalSubtotal += Convert.ToInt32(row["subtotal"]);
                    }

                    txttotalinforme.Text = totalSubtotal.ToString("C0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en det_venta: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private (string, byte[]) ObtenerInformacionEmpresa()
        {
            string informacion = string.Empty;
            byte[] logo = null;

            try
            {
                connection.Open();
                string query = "SELECT nit, razonsocial, direccion, logo FROM empresa"; // Ajusta los campos según tu tabla empresa
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string nit = reader["nit"].ToString();
                        string razonSocial = reader["razonsocial"].ToString();
                        string direccion = reader["direccion"].ToString();
                        logo = reader["logo"] != DBNull.Value ? (byte[])reader["logo"] : null;

                        informacion = $"NIT: {nit}\nRazón Social: {razonSocial}\nDirección: {direccion}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener información de la empresa: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (informacion, logo);
        }

        private void ppdf_Click(object sender, EventArgs e)
        {
            ExportarAPDF();
        }
        private void ExportarAPDF()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Guardar archivo PDF",
                    FileName = "InformeVentas.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        Document doc = new Document(PageSize.A4.Rotate());
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        // Obtener información de la empresa
                        var (informacionEmpresa, logo) = ObtenerInformacionEmpresa();

                        if (logo != null)
                        {
                            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(logo);
                            image.ScaleToFit(100f, 100f);
                            doc.Add(image);
                        }

                        doc.Add(new Paragraph(informacionEmpresa));
                        doc.Add(new Paragraph(" "));
                        doc.Add(new Paragraph("Informe de Ventas"));
                        doc.Add(new Paragraph($"Desde: {dateinicio.Value.ToShortDateString()} Hasta: {datefinal.Value.ToShortDateString()}"));
                        doc.Add(new Paragraph(" "));

                        PdfPTable table = new PdfPTable(dinfoventas.Columns.Count)
                        {
                            WidthPercentage = 100
                        };

                        // Agregar encabezados de columnas
                        foreach (DataGridViewColumn column in dinfoventas.Columns)
                        {
                            PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText))
                            {
                                BackgroundColor = BaseColor.LIGHT_GRAY,
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5
                            };
                            table.AddCell(headerCell);
                        }

                        // Agregar filas de datos
                        foreach (DataGridViewRow row in dinfoventas.Rows)
                        {
                            if (row.IsNewRow) continue;
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                string cellValue = cell.Value?.ToString() ?? string.Empty;

                                // Formatear las celdas de las columnas Total Ventas, Valor Unitario y Subtotal
                                if (cell.OwningColumn.Name == "Total Ventas" || cell.OwningColumn.Name == "valorunidad" || cell.OwningColumn.Name == "subtotal")
                                {
                                    cellValue = Convert.ToDecimal(cell.Value).ToString("C0");
                                }

                                PdfPCell dataCell = new PdfPCell(new Phrase(cellValue))
                                {
                                    HorizontalAlignment = Element.ALIGN_RIGHT, // Alinear a la derecha
                                    Padding = 5,
                                    MinimumHeight = 20f,
                                    NoWrap = false
                                };
                                table.AddCell(dataCell);
                            }
                        }

                        doc.Add(table);

                        doc.Add(new Paragraph(" "));
                        doc.Add(new Paragraph("Total de Ventas: " + txttotalinforme.Text, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                        doc.Add(new Paragraph(" "));

                        doc.Close();
                    }

                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                    MessageBox.Show("PDF exportado con éxito.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a PDF: " + ex.Message);
            }
        }


        private void pecxel_Click(object sender, EventArgs e)
        {
            ExportarAExcel();
        }

        private void ExportarAExcel()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Guardar archivo Excel",
                    FileName = "InformeVentas.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new ExcelPackage(new FileInfo(saveFileDialog.FileName)))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Ventas");

                        // Agregar los encabezados
                        for (int i = 0; i < dinfoventas.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = dinfoventas.Columns[i].HeaderText;
                        }

                        // Agregar las filas
                        for (int rowIndex = 0; rowIndex < dinfoventas.Rows.Count; rowIndex++)
                        {
                            for (int colIndex = 0; colIndex < dinfoventas.Columns.Count; colIndex++)
                            {
                                worksheet.Cells[rowIndex + 2, colIndex + 1].Value = dinfoventas.Rows[rowIndex].Cells[colIndex].Value.ToString();
                            }
                        }

                        package.Save();
                    }

                    MessageBox.Show("El archivo Excel se ha generado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message);
            }
        }
    }
}

