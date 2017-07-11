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
    public partial class frmPacientes : frmBase
    {
        string cModo = "Inicio";

        public frmPacientes()
        {
            InitializeComponent();
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            this.cModo = "Inicio";
            this.Botones();
            this.fillCmbRango();
        }

        private void fillCmbRango()
        {
            try
            {
                // Step 1 
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT idrango, rango FROM rango ORDER BY rango ASC", MyConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("idrango", typeof(int));
                MyDataTable.Columns.Add("rango", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6
                cmbRango.ValueMember = "idrango";
                cmbRango.DisplayMember = "rango";
                cmbRango.DataSource = MyDataTable;

                // Step 7
                MyConexion.Close();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
                throw;
            }
        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.txtRecord.Clear();
            this.txtCedula.Clear();
            this.txtNombre.Clear();
            this.txtNSS.Clear();
            this.txtAntecedentes.Clear();
            this.cmbRango.Refresh();
            this.rbHombre.Checked = true;
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
                    this.txtID.Enabled = false;
                    this.txtRecord.Enabled = false;
                    this.txtCedula.Enabled = false;
                    this.txtNombre.Enabled = false;
                    this.cmbRango.Enabled = false;
                    this.txtNSS.Enabled = false;
                    this.txtAntecedentes.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.rbHombre.Enabled = false;
                    this.rbMujer.Enabled = false;
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
                    this.txtRecord.Enabled = true;
                    this.txtCedula.Enabled = true;
                    this.txtNombre.Enabled = true;
                    this.cmbRango.Enabled = true;
                    this.txtNSS.Enabled = true;
                    this.txtAntecedentes.Enabled = true;
                    this.dtFecha.Enabled = true;
                    this.rbHombre.Enabled = true;
                    this.rbMujer.Enabled = true;
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
                    this.txtID.Enabled = false;
                    this.txtRecord.Enabled = false;
                    this.txtCedula.Enabled = false;
                    this.txtNombre.Enabled = false;
                    this.cmbRango.Enabled = false;
                    this.txtNSS.Enabled = false;
                    this.txtAntecedentes.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.rbHombre.Enabled = false;
                    this.rbMujer.Enabled = false;
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
                    this.txtRecord.Enabled = true;
                    this.txtCedula.Enabled = true;
                    this.txtNombre.Enabled = true;
                    this.cmbRango.Enabled = true;
                    this.txtNSS.Enabled = true;
                    this.txtAntecedentes.Enabled = true;
                    this.dtFecha.Enabled = true;
                    this.rbHombre.Enabled = true;
                    this.rbMujer.Enabled = true;
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
                    this.txtID.Enabled = false;
                    this.txtRecord.Enabled = false;
                    this.txtCedula.Enabled = false;
                    this.txtNombre.Enabled = false;
                    this.cmbRango.Enabled = false;
                    this.txtNSS.Enabled = false;
                    this.txtAntecedentes.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.rbHombre.Enabled = false;
                    this.rbMujer.Enabled = false;
                    break;

                case "Eliminar":
                    break;

                case "Cancelar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
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
                MyCommand.CommandText = "SELECT count(*) FROM pacientes";

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.cModo = "Nuevo";
            this.Limpiar();
            this.Botones();
            this.ProximoCodigo();
            this.txtRecord.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtRecord.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtRecord.Focus();
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
                        myCommand.CommandText = "INSERT INTO pacientes(record, cedula, nombre, rango, nss, antecedentes, fecha_nacimiento, sexo)" +
                            " values(@record, @cedula, @nombre, @rango, @nss, @antecedentes, @fecha, @sexo)";
                        myCommand.Parameters.AddWithValue("@record", txtRecord.Text);
                        myCommand.Parameters.AddWithValue("@cedula", txtCedula.Text);
                        myCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        myCommand.Parameters.AddWithValue("@rango", cmbRango.SelectedValue);
                        myCommand.Parameters.AddWithValue("@nss", txtNSS.Text);
                        myCommand.Parameters.AddWithValue("@antecedentes", txtAntecedentes.Text);
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        if (rbHombre.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@sexo", "M");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@sexo", "F");
                        }

                        // Step 4 - Opening the connection
                        MyConexion.Open();

                        // Step 5 - Executing the query
                        int nFilas = myCommand.ExecuteNonQuery();
                        if (nFilas > 0)
                        {
                            MessageBox.Show("Informacion guardada satisfactoriamente...");
                        }
                        else
                        {
                            MessageBox.Show("No fueron guardadas las informaciones...");
                        }

                        // Step 6 - Closing the connection
                        MyConexion.Close();
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
                        myCommand.CommandText = "UPDATE pacientes SET record = @record, cedula = @cedula, " +
                            "nombre = @nombre, rango = @rango, nss = @nss, antecedentes = @antecedentes, fecha = @fecha, " +
                            " sexo = @sexo "+
                            " WHERE idpacientes = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@record", txtRecord.Text);
                        myCommand.Parameters.AddWithValue("@cedula", txtCedula.Text);
                        myCommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        myCommand.Parameters.AddWithValue("@rango", cmbRango.SelectedValue);
                        myCommand.Parameters.AddWithValue("@nss", txtNSS.Text);
                        myCommand.Parameters.AddWithValue("@antecedentes", txtAntecedentes.Text);
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        if (rbHombre.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@sexo", "M");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@sexo", "F");
                        }
                        // Step 4 - Opening the connection
                        MyConexion.Open();

                        // Step 5 - Executing the query
                        int nFilas = myCommand.ExecuteNonQuery();
                        if (nFilas > 0)
                        {
                            MessageBox.Show("Informacion actualiada satisfactoriamente...");
                        }
                        else
                        {
                            MessageBox.Show("No fueron actualizadas las informaciones...");
                        }

                        // Step 6 - Closing the connection
                        MyConexion.Close();

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
            frmBuscarPacientes ofrmBuscarPacientes = new frmBuscarPacientes();
            ofrmBuscarPacientes.ShowDialog();
            string cCodigo = ofrmBuscarPacientes.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtID.Text = Convert.ToString(cCodigo).Trim();
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;
                    MyCommand.CommandText = "SELECT * from pacientes WHERE idpacientes = '" + txtID.Text.Trim() + "'";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtID.Text = MyReader["idpacientes"].ToString();
                            txtCedula.Text = MyReader["cedula"].ToString();
                            txtNombre.Text = MyReader["nombre"].ToString();
                            cmbRango.SelectedValue = MyReader["rango"].ToString();
                            txtRecord.Text = MyReader["record"].ToString();
                            txtNSS.Text = MyReader["nss"].ToString();
                            txtAntecedentes.Text = MyReader["antecedentes"].ToString();
                            dtFecha.Value = Convert.ToDateTime(MyReader["fecha_nacimiento"].ToString());
                            string sexo = MyReader["sexo"].ToString();
                            if (sexo == "M")
                            {
                                rbHombre.Checked = true;
                            }
                            else
                            {
                                rbHombre.Checked = true;
                            }
                        }
                        this.cModo = "Buscar";
                        this.Botones();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros ...", "Sistema de Gestion Medica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.txtCedula.Focus();
                        //this.cModo = "Inicio";
                        //this.Botones();
                        //this.Limpiar();
                        //this.txtID.Focus();
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
                sbQuery.Append(" pacientes.idpacientes, pacientes.record, pacientes.cedula,");
                sbQuery.Append(" pacientes.nombre, rango.rango, pacientes.nss, pacientes.antecedentes, pacientes.fecha_nacimiento ");
                sbQuery.Append(" FROM pacientes ");
                sbQuery.Append(" INNER JOIN rango ON rango.idrango = pacientes.rango");
                sbQuery.Append(cWhere);
                sbQuery.Append(" ORDER BY pacientes.nombre ASC");

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtPacientes = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtPacientes);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtPacientes.Rows.Count;
                if (nRegistro == 0)
                {
                    MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema de Gestion Medica", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    cTitulo = "LISTADO DE PACIENTES";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptPacientes orptPacientes = new rptPacientes();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptPacientes.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtPacientes, orptPacientes, cTitulo);

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
            if (txtID.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema de Gestion Medica", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                switch (Result)
                {
                    case DialogResult.Yes:
                        cModo = "Actualiza";
                        btnGrabar_Click(sender, e);
                        break;
                }
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRecord_KeyPress(object sender, KeyPressEventArgs e)
        {

            // keypress//

            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }            
        }
    }
}
