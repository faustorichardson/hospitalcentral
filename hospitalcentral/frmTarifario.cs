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
                    this.btnImprimir.Enabled = true;
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
                    this.btnImprimir.Enabled = true;
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
                        // Step 1 - Stablishing the connection
                        MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                        // Step 2 - Crear el comando de ejecucion
                        MySqlCommand myCommand = MyConexion.CreateCommand();

                        // Step 3 - Comando a ejecutar
                        myCommand.CommandText = "UPDATE tarifas SET tipocobertura = @tipocobertura, "+
                            " simon = @simon, cups = @cups, descripcionservicio = @descripcionservicio, "+ 
                            " fecha_vigencia = @fecha_vigencia, monto_subsidiado = @monto_subsidiado, "+
                            " monto_contributivo = @monto_contributivo " +
                            " WHERE id = " + txtID.Text + "";
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

                        MessageBox.Show("Informacion actualizada satisfactoriamente...");
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
            if (txtID.Text == "")
            {
                MessageBox.Show("No se permiten busquedas sin argumentos...");
                txtID.Focus();
            }
            else
            {
                try
                {
                    // Step 1 - Conexion
                    MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    MyCommand.CommandText = "SELECT tipocobertura, simon, cups, descripcionservicio, fecha_vigencia, "+
                        " monto_subsidiado, monto_contributivo " +
                        " FROM tarifas WHERE id = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            cmbTipoCobertura.SelectedValue = MyReader["tipocobertura"].ToString();
                            txtSimon.Text = MyReader["simon"].ToString();
                            txtCups.Text = MyReader["cups"].ToString();
                            txtDescripcionServicio.Text = MyReader["descripcionservicio"].ToString();
                            //
                            // Llamo la funcion para formatear el campo MONTO SUBSIDIADO.-
                            txtMontoSubsidiado.Text = MyReader["monto_subsidiado"].ToString();
                            decimal montoSubsidiado = Convert.ToDecimal(txtMontoSubsidiado.Text);
                            txtMontoSubsidiado.Text = clsFunctions.GetCurrencyFormat(montoSubsidiado);
                            //
                            // Llamo la funcion para formatear el campo MONTO CONTRIBUTIVO.-
                            txtMontoContributivo.Text = MyReader["monto_contributivo"].ToString();
                            decimal montoContributivo = Convert.ToDecimal(txtMontoContributivo.Text);
                            txtMontoContributivo.Text = clsFunctions.GetCurrencyFormat(montoContributivo);
                            //
                            dtFecha.Value = Convert.ToDateTime(MyReader["fecha_vigencia"].ToString());
                            
                        }

                        this.cModo = "Buscar";
                        this.Botones();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros...");
                        this.cModo = "Inicio";
                        this.Botones();
                        this.Limpiar();
                        txtID.Focus();
                    }

                    // Step 6 - Closing all
                    MyReader.Close();
                    MyCommand.Dispose();
                    MyConexion.Close();

                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }



            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Conexion a la base de datos
            MySqlConnection myConexion = new MySqlConnection(clsConexion.ConectionString);
            // Creando el command que ejecutare
            MySqlCommand myCommand = new MySqlCommand();
            // Creando el Data Adapter
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            // Creando el String Builder
            StringBuilder sbQuery = new StringBuilder();
            // Otras variables del entorno
            string cWhere = " WHERE 1 = 1";
            string cUsuario = "";
            string cTitulo = "";

            try
            {
                // Abro conexion
                myConexion.Open();
                // Creo comando
                myCommand = myConexion.CreateCommand();
                // Adhiero el comando a la conexion
                myCommand.Connection = myConexion;
                // Filtros de la busqueda
                //string fechadesde = fechaDesde.Value.ToString("yyyy-MM-dd");
                //string fechahasta = fechaHasta.Value.ToString("yyyy-MM-dd");
                //cWhere = cWhere + " AND fechacita >= " + "'" + fechadesde + "'" + " AND fechacita <= " + "'" + fechahasta + "'" + "";
                sbQuery.Clear();
                sbQuery.Append("SELECT ");
                sbQuery.Append(" tarifas.id, tarifas.simon, tarifas.cups, tarifas.descripcionservicio,");
                sbQuery.Append(" tarifas.fecha_vigencia, tarifas.monto_contributivo, tarifas.monto_subsidiado,");
                sbQuery.Append(" tarifas_tipocobertura.tipocobertura");                
                sbQuery.Append(" FROM tarifas ");
                sbQuery.Append(" INNER JOIN tarifas_tipocobertura ON tarifas_tipocobertura.id = tarifas.tipocobertura");
                sbQuery.Append(cWhere);
                sbQuery.Append(" ORDER BY tarifas.descripcionservicio ASC");

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtTarifas = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtTarifas);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtTarifas.Rows.Count;
                if (nRegistro == 0)
                {
                    MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema de Gestion de Hospital", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    //1ero.HACEMOS LA COLECCION DE PARAMETROS
                    //los campos de parametros contiene un objeto para cada campo de parametro en el informe
                    ParameterFields oParametrosCR = new ParameterFields();
                    //Proporciona propiedades para la recuperacion y configuracion del tipo de los parametros
                    ParameterValues oParametrosValuesCR = new ParameterValues();

                    //2do.CREAMOS LOS PARAMETROS
                    ParameterField oUsuario = new ParameterField();
                    //parametervaluetype especifica el TIPO de valor de parametro
                    //ParameterValueKind especifica el tipo de valor de parametro en la PARAMETERVALUETYPE de la Clase PARAMETERFIELD
                    oUsuario.ParameterValueType = ParameterValueKind.StringParameter;

                    //3ero.VALORES PARA LOS PARAMETROS
                    //ParameterDiscreteValue proporciona propiedades para la recuperacion y configuracion de 
                    //parametros de valores discretos
                    ParameterDiscreteValue oUsuarioDValue = new ParameterDiscreteValue();
                    oUsuarioDValue.Value = cUsuario;

                    //4to. AGREGAMOS LOS VALORES A LOS PARAMETROS
                    oUsuario.CurrentValues.Add(oUsuarioDValue);


                    //5to. AGREGAMOS LOS PARAMETROS A LA COLECCION 
                    oParametrosCR.Add(oUsuario);

                    //nombre del parametro en CR (Crystal Reports)
                    oParametrosCR[0].Name = "cUsuario";

                    //nombre del TITULO DEL INFORME
                    cTitulo = "ACUERDO DE TARIFAS ENTRE SEGURIDAD NACIONAL DE SALUD (SENASA)";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptTarifasServicios orptTarifasServicios = new rptTarifasServicios();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptTarifasServicios.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtTarifas, orptTarifasServicios, cTitulo);

                    //ParameterFieldInfo Obtiene o establece la colección de campos de parámetros.
                    ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                    ofrmPrinter.ShowDialog();
                }


            }
            catch (Exception myEx)
            {
                MessageBox.Show("Error : " + myEx.Message, "Mostrando Reporte", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                //ExceptionLog.LogError(myEx, false);
                return;
            }
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
