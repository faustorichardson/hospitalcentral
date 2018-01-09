using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Web;
using CrystalDecisions.Windows;
using System.Drawing.Imaging;
using System.IO;

namespace hospitalcentral
{
    public partial class frmFacturacionServicio : frmBase
    {
        // Declarando variable global de los modos de los botones
        string cModo = "Inicio";
        // codigo global
        int gCodigo = 0;
        decimal sumaTotal;
        decimal subTotal;
        decimal total;
        decimal monto;        
        int selectedRow = 0;
        int countFilas = 0;

        public frmFacturacionServicio()
        {
            InitializeComponent();
        }

        private void frmFacturacionServicio_Load(object sender, EventArgs e)
        {
            this.cModo = "Inicio";
            this.Botones();
        }

        private void Limpiar()
        {
            this.dtgFacturacionServicios.Rows.Clear();
            this.txtID.Clear();
            this.txtIDCliente.Clear();
            this.txtCliente.Clear();
            this.txtNSS.Clear();
            this.LimpiarTxtGrid();
        }

        private void LimpiarTxtGrid()
        {
            txtIDServicio.Clear();
            txtSimon.Clear();
            txtServicio.Clear();
            txtMonto.Clear();
        }

        private void Botones()
        {
            switch (cModo)
            {
                case "Inicio":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //
                    this.btnBuscarProducto.Enabled = false;
                    this.btnAddGrid.Enabled = false;
                    this.btnDeleteGrid.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    break;

                case "Nuevo":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    //
                    this.btnBuscarProducto.Enabled = true;
                    this.btnAddGrid.Enabled = true;
                    this.btnDeleteGrid.Enabled = true;
                    this.btnBuscarPaciente.Enabled = true;
                    break;

                case "Grabar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //
                    this.btnBuscarProducto.Enabled = false;
                    this.btnAddGrid.Enabled = false;
                    this.btnDeleteGrid.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    break;

                case "Editar":
                    /*this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    //
                    this.btnBuscarProducto.Enabled = false;
                    this.btnAddGrid.Enabled = false;
                    this.btnDeleteGrid.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    */
                    break;
                    
                case "Buscar":
                    /*this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    */
                    break;

                case "Eliminar":
                    break;

                case "Cancelar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //
                    this.btnBuscarProducto.Enabled = false;
                    this.btnAddGrid.Enabled = false;
                    this.btnDeleteGrid.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    break;

                default:
                    break;
            }

        }

        private void ProximoCodigo()
        {
            try
            {
                // Step 1 - Connection stablished
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - Create command
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // Step 3 - Set the commanndtext property
                MyCommand.CommandText = "SELECT count(*) FROM facturacionservicio";

                // Step 4 - Open connection
                MyConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                txtID.Text = Convert.ToString(codigo);

                // Actualizo el Codigo Global
                gCodigo = codigo;

                // Step 5 - Close the connection
                MyConexion.Close();
            }
            catch (MySqlException MyEx)
            {
                MessageBox.Show(MyEx.Message);
            }
        }

        // Funcion que convierte un valor decimal a texto para graficarlo en un textbox
        public static string GetCurrencyFormat(decimal myValue)
        {
            return string.Format("{0:#,###0.00}", myValue);
        }

        // Funcion que convierte el decimal de un textbox para salvarlo a la base de datos
        public static decimal ParseCurrencyFormat(string myValue)
        {
            return decimal.Parse(myValue, System.Globalization.NumberStyles.Currency);
        }



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.cModo = "Nuevo";
            this.Limpiar();
            this.LimpiarTxtGrid();
            this.Botones();
            this.ProximoCodigo();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema de Gestion de Hospital v1.0", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                switch (Result)
                {
                    case DialogResult.Yes:
                        cModo = "Actualiza";
                        btnGrabar_Click(sender, e);
                        break;
                }
            }

            this.Limpiar();
            this.cModo = "Inicio";
            this.Botones();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (txtIDCliente.Text == "" && txtNSS.Text == "" && txtCliente.Text == "")
            {
                MessageBox.Show("No se puede facturar servicio sin antes buscar un paciente...");
                btnBuscarPaciente.Focus();
            }
            else
            {
               
                frmBuscarServicio ofrmBuscarServicio = new frmBuscarServicio();
                ofrmBuscarServicio.ShowDialog();
                string cCodigo = ofrmBuscarServicio.cCodigo;

                // Si selecciono un registro
                if (cCodigo != "" && cCodigo != null)
                {
                    // Mostrar el codigo                      
                    txtIDServicio.Text = Convert.ToString(cCodigo).Trim();
                    try
                    {
                        // Step 1 - clsConexion
                        MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - creating the command object
                        MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                        // Step 3 - creating the commandtext
                        //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;                                                
                        // verifico el tipo para filtrar en la base de datos
                        //if (txtTipoCliente.Text == "A")
                        //{
                        //    MyCommand.CommandText = "SELECT idproducto, producto, tipo, precio_a as precio, imagen from productos WHERE idproducto = '" + txtIDProducto.Text.Trim() + "'";
                        //}
                        //else
                        //{
                        //    MyCommand.CommandText = "SELECT idproducto, producto, tipo, precio_b as precio, imagen from productos WHERE idproducto = '" + txtIDProducto.Text.Trim() + "'";
                        //}
                        if (rbSubsidiado.Checked == true)
                        {
                            MyCommand.CommandText = "SELECT id, simon, descripcionservicio, monto_subsidiado as monto from tarifas WHERE id = '" + txtIDServicio.Text.Trim() + "'";
                        }
                        else
                        {
                            MyCommand.CommandText = "SELECT id, simon, descripcionservicio, monto_contributivo as monto from tarifas WHERE id = '" + txtIDServicio.Text.Trim() + "'";
                        }

                        // Step 4 - connection open
                        MyclsConexion.Open();

                        // Step 5 - Creating the DataReader                    
                        MySqlDataReader MyReader = MyCommand.ExecuteReader();

                        // Step 6 - Verifying if Reader has rows
                        if (MyReader.HasRows)
                        {
                            while (MyReader.Read())
                            {
                                txtIDServicio.Text = MyReader["id"].ToString();
                                txtSimon.Text = MyReader["simon"].ToString();
                                txtServicio.Text = MyReader["descripcionservicio"].ToString();
                                txtMonto.Text = MyReader["monto"].ToString();
                                decimal monto = Convert.ToDecimal(txtMonto.Text);
                                txtMonto.Text = clsFunctions.GetCurrencyFormat(monto);                                  
                            }
                            //this.cModo = "Buscar";
                            //this.Botones();
                            //this.txtCantidad.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron registros con este ID de Producto...", "Sistea de Gestion Medica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        // Step 6 - Closing all
                        MyReader.Close();
                        MyCommand.Dispose();
                        MyclsConexion.Close();
                    }
                    catch (Exception MyEx)
                    {
                        MessageBox.Show(MyEx.Message);
                    }
                }
                //}
            }
        }

        private void btnAddGrid_Click(object sender, EventArgs e)
        {
            // VERIFICO QUE PRIMERO SE SELECCIONE UN SUPLIDOR
            if (txtIDCliente.Text == "" || txtCliente.Text == "" || txtNSS.Text == "")
            {
                MessageBox.Show("Antes de agregar servicios debe de seleccionar el paciente...");
                this.btnBuscarPaciente.Focus();
            }
            else if (txtIDServicio.Text == "" || txtServicio.Text == "" || txtMonto.Text == "")
            {
                MessageBox.Show("Antes de agregar servicios debe de buscarlos...");
                this.btnBuscarProducto.Focus();
            }
            else
            {
                // BUSCAR INVENTARIO Y AGREGAR
                try
                {                    
                    // Creo la variable del tipo double "SUBTOTAL" para calcular el resultado de cantidad por precio
                    subTotal = Convert.ToDecimal(txtMonto.Text);

                    // Registro la entrada al GRID
                    dtgFacturacionServicios.Rows.Add(txtIDServicio.Text, txtSimon.Text, txtServicio.Text, subTotal);
                    //dtgEntradaInventario.Rows.Add(txtIDProducto.Text, txtProducto.Text, txtTipo.Text, txtPrecioProducto.Text, txtCantidad.Text, subTotal);

                    // Realizo la operacion de sumar el subtotal mas la variable acumuladora sumatotal
                    sumaTotal = sumaTotal + subTotal;

                    // Llamo la funcion para formatear el campo.-
                    monto = Convert.ToDecimal(sumaTotal);
                    lblMontoFacturado.Text = clsFunctions.GetCurrencyFormat(monto);

                    // Agrego una fila al contador
                    countFilas = countFilas + 1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }

                this.LimpiarTxtGrid();
            }
        }

        private void btnDeleteGrid_Click(object sender, EventArgs e)
        {
            if (countFilas > 0)
            {
                if (txtServicio.Text != "" && txtMonto.Text != "")
                {                    

                    // RESTANDO EL SUBTOTAL A LA VARIABLE SUMATOTAL
                    try
                    {

                        // Creo la variable del tipo double "SUBTOTAL" para calcular el resultado de cantidad por precio
                        subTotal = Convert.ToDecimal(txtMonto.Text);

                        // selecciono el indice del registro en el grid
                        selectedRow = dtgFacturacionServicios.CurrentCell.RowIndex;

                        // remuevo la linea que corresponde al indice
                        dtgFacturacionServicios.Rows.RemoveAt(selectedRow);

                        // Actualizo la variable de las filas
                        countFilas = countFilas - 1;

                        // Actualizo el monto
                        sumaTotal = sumaTotal - subTotal;

                        // Formateo la cifra
                        lblMontoFacturado.Text = clsFunctions.GetCurrencyFormat(sumaTotal);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }                    

                    // Limpiando los campos de los valores de servicio
                    this.LimpiarTxtGrid();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el servicio que desea remover...");
                    this.dtgFacturacionServicios.Focus();
                }
            }
            else
            {
                MessageBox.Show("No hay datos para eliminar o debe de seleccionar el servicio...");
            }
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            frmBuscarPacientes ofrmBuscarPacientes = new frmBuscarPacientes();
            ofrmBuscarPacientes.ShowDialog();
            string cCodigo = ofrmBuscarPacientes.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtIDCliente.Text = Convert.ToString(cCodigo).Trim();
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;
                    MyCommand.CommandText = "SELECT idpacientes, nombre, nss, regimen from pacientes WHERE idpacientes = '" + txtIDCliente.Text + "'";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {

                            txtCliente.Text = MyReader["nombre"].ToString();
                            txtNSS.Text = MyReader["nss"].ToString();
                            string regimen = MyReader["regimen"].ToString();
                            if (regimen == "S")
                            {
                                this.rbSubsidiado.Checked = true;
                            }
                            else
                            {
                                this.rbContributivo.Checked = true;
                            }
                            // Verifica Forma de Facturacion
                            //this.verificaITBI();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con este ID...", "Sistema de Gestion Medica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    // Step 6 - Closing all
                    MyReader.Close();
                    MyCommand.Dispose();
                    MyclsConexion.Close();
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }
            }
        }

        private void dtgFacturacionServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                DataGridViewRow row = dtgFacturacionServicios.Rows[selectedRow];
                // Lleno los campos
                txtIDServicio.Text = row.Cells[0].Value.ToString();
                txtSimon.Text = row.Cells[1].Value.ToString();
                txtServicio.Text = row.Cells[2].Value.ToString();
                txtMonto.Text = row.Cells[3].Value.ToString();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

      

    }
}
