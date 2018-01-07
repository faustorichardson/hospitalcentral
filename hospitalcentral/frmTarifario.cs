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
    public partial class frmTarifario : frmBase
    {
        // Declarando la variable
        string cModo = "Inicio";

        public frmTarifario()
        {
            InitializeComponent();
        }

        private void frmTarifario_Load(object sender, EventArgs e)
        {
            this.cModo = "Inicio";
            this.Limpiar();
            this.Botones();
            this.fillCmbTipoCobertura();
        }

        private void fillCmbTipoCobertura()
        {
            try
            {
                // Step 1 
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT id, tipocobertura from tarifas_tipocobertura order by tipocobertura ASC", MyConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("id", typeof(int));
                MyDataTable.Columns.Add("tipocobertura", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6
                cmbTipoCobertura.ValueMember = "id";
                cmbTipoCobertura.DisplayMember = "tipocobertura";
                cmbTipoCobertura.DataSource = MyDataTable;
                
                // Step 7
                MyConexion.Close();
            }
            catch (Exception)
            {
                
                throw;
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
                MyCommand.CommandText = "SELECT count(*) FROM tarifas";

                // Step 4 - Open connection
                MyConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                txtID.Text = Convert.ToString(codigo);

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

        private void Limpiar()
        {
            this.txtID.Clear();
            this.cmbTipoCobertura.Refresh();
            this.txtSimon.Clear();
            this.txtCups.Clear();
            this.txtDescripcionServicio.Clear();
            this.txtMontoContributivo.Clear();
            this.txtMontoSubsidiado.Clear();
            this.dtFecha.Refresh();
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
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //
                    this.txtID.Enabled = true;
                    this.cmbTipoCobertura.Enabled = false;
                    this.txtSimon.Enabled = false;
                    this.txtCups.Enabled = false;
                    this.txtDescripcionServicio.Enabled = false;
                    this.txtMontoContributivo.Enabled = false;
                    this.txtMontoSubsidiado.Enabled = false;
                    this.dtFecha.Enabled = false;
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
                    this.txtID.Enabled = false;
                    this.cmbTipoCobertura.Enabled = true;
                    this.txtSimon.Enabled = true;
                    this.txtCups.Enabled = true;
                    this.txtDescripcionServicio.Enabled = true;
                    this.txtMontoContributivo.Enabled = true;
                    this.txtMontoSubsidiado.Enabled = true;
                    this.dtFecha.Enabled = true;
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
                    this.txtID.Enabled = true;
                    this.cmbTipoCobertura.Enabled = false;
                    this.txtSimon.Enabled = false;
                    this.txtCups.Enabled = false;
                    this.txtDescripcionServicio.Enabled = false;
                    this.txtMontoContributivo.Enabled = false;
                    this.txtMontoSubsidiado.Enabled = false;
                    this.dtFecha.Enabled = false;
                    break;

                case "Editar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    //
                    this.txtID.Enabled = false;
                    this.cmbTipoCobertura.Enabled = true;
                    this.txtSimon.Enabled = true;
                    this.txtCups.Enabled = true;
                    this.txtDescripcionServicio.Enabled = true;
                    this.txtMontoContributivo.Enabled = true;
                    this.txtMontoSubsidiado.Enabled = true;
                    this.dtFecha.Enabled = true;
                    break;

                case "Buscar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //
                    this.txtID.Enabled = true;
                    this.cmbTipoCobertura.Enabled = false;
                    this.txtSimon.Enabled = false;
                    this.txtCups.Enabled = false;
                    this.txtDescripcionServicio.Enabled = false;
                    this.txtMontoContributivo.Enabled = false;
                    this.txtMontoSubsidiado.Enabled = false;
                    this.dtFecha.Enabled = false;
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
                    this.txtID.Enabled = true;
                    this.cmbTipoCobertura.Enabled = false;
                    this.txtSimon.Enabled = false;
                    this.txtCups.Enabled = false;
                    this.txtDescripcionServicio.Enabled = false;
                    this.txtMontoContributivo.Enabled = false;
                    this.txtMontoSubsidiado.Enabled = false;
                    this.dtFecha.Enabled = false;
                    break;

                default:
                    break;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.cModo = "Nuevo";
            this.Limpiar();
            this.Botones();
            this.ProximoCodigo();
            this.cmbTipoCobertura.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtDescripcionServicio.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtDescripcionServicio.Focus();
            }
            else
            {
                if (cModo == "Nuevo")
                {
                    try
                    {
                        // Step 1 - Stablishing the connection
                        MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - Crear el comando de ejecucion
                        MySqlCommand myCommand = MyConexion.CreateCommand();

                        // Step 3 - Comando a ejecutar
                        myCommand.CommandText = "INSERT INTO tarifas(tipocobertura, simon, cups, descripcionservicio, "+
                        " fecha_vigencia, monto_subsidiado, monto_contributivo)" +
                            " values(@tipocobertura, @simon, @cups, @descripcionservicio, @fecha_vigencia, "+
                        " @monto_subsidiado, @monto_contributivo)";
                        myCommand.Parameters.AddWithValue("@tipocobertura", cmbTipoCobertura.SelectedValue);
                        myCommand.Parameters.AddWithValue("@simon", txtSimon.Text);
                        myCommand.Parameters.AddWithValue("@cups", txtCups.Text);
                        myCommand.Parameters.AddWithValue("@descripcionservicio", txtDescripcionServicio.Text);
                        myCommand.Parameters.AddWithValue("@fecha_vigencia", dtFecha.Value);
                        // CONVIRTIENDO LOS VALORES DECIMALES DE LOS MONTOS
                        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-* //
                        // Convierto el campo monto en texto
                        txtMontoSubsidiado.Text = Convert.ToString(txtMontoSubsidiado.Text);
                        // Cambio el valor del textbox a decimal
                        string myValueSubsidiado = Convert.ToString(txtMontoSubsidiado.Text);
                        decimal myValueMontoSubsidiado = clsFunctions.ParseCurrencyFormat(myValueSubsidiado);                        
                        myCommand.Parameters.AddWithValue("@monto_subsidiado", myValueMontoSubsidiado);
                        // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-* //
                        // Convierto el campo monto en texto
                        txtMontoContributivo.Text = Convert.ToString(txtMontoContributivo.Text);
                        // Cambio el valor del textbox a decimal
                        string myValueContributivo = Convert.ToString(txtMontoContributivo.Text);
                        decimal myValueMontoContributivo = clsFunctions.ParseCurrencyFormat(myValueContributivo);
                        //
                        myCommand.Parameters.AddWithValue("@monto_contributivo", myValueMontoContributivo);

                        // Step 4 - Opening the connection
                        MyConexion.Open();

                        // Step 5 - Executing the query
                        myCommand.ExecuteNonQuery();

                        // Step 6 - Closing the connection
                        MyConexion.Close();

                        MessageBox.Show("Informacion guardada satisfactoriamente...");
                    }
                    catch (Exception MyEx)
                    {
                        MessageBox.Show(MyEx.Message);
                    }

                }
                else
                {
                    try
                    {
                        //// Step 1 - Stablishing the connection
                        //MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                        //// Step 2 - Crear el comando de ejecucion
                        //MySqlCommand myCommand = MyConexion.CreateCommand();

                        //// Step 3 - Comando a ejecutar
                        //myCommand.CommandText = "UPDATE tarifa_tipocobertura SET tipocobertura = @tipocobertura " +
                        //    " WHERE id = " + txtID.Text + "";
                        //myCommand.Parameters.AddWithValue("@tipocobertura", txtTipoCobertura.Text);

                        //// Step 4 - Opening the connection
                        //MyConexion.Open();

                        //// Step 5 - Executing the query
                        //myCommand.ExecuteNonQuery();

                        //// Step 6 - Closing the connection
                        //MyConexion.Close();

                        //MessageBox.Show("Informacion actualizada satisfactoriamente...");
                    }
                    catch (Exception MyEx)
                    {
                        MessageBox.Show(MyEx.Message);
                    }

                }

                this.Limpiar();
                this.cModo = "Inicio";
                this.Botones();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.cModo = "Editar";
            this.Botones();
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
            if (txtDescripcionServicio.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema Gestion de Hospital v1.0", MessageBoxButtons.YesNo,
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

        private void txtMontoSubsidiado_Leave(object sender, EventArgs e)
        {
            if (txtMontoSubsidiado.Text == "")
            {
                MessageBox.Show("No puede dejar la cantidad sin valor...");
                txtMontoSubsidiado.Focus();
            }
            else
            {
                // Llamo la funcion para formatear el campo.-
                decimal monto = Convert.ToDecimal(txtMontoSubsidiado.Text);
                txtMontoSubsidiado.Text = clsFunctions.GetCurrencyFormat(monto);
            }

        }

        private void txtMontoContributivo_Leave(object sender, EventArgs e)
        {
            if (txtMontoContributivo.Text == "")
            {
                MessageBox.Show("No puede dejar la cantidad sin valor...");
                txtMontoContributivo.Focus();
            }
            else
            {
                // Llamo la funcion para formatear el campo.-
                decimal monto = Convert.ToDecimal(txtMontoContributivo.Text);
                txtMontoContributivo.Text = clsFunctions.GetCurrencyFormat(monto);
            }

        }
    }
}
