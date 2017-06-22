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
    public partial class frmcitasmedicas : frmBase
    {
        string cModo = "Inicio";

        public frmcitasmedicas()
        {
            InitializeComponent();
        }

        private void frmcitasmedicas_Load(object sender, EventArgs e)
        {
            this.cModo = "Inicio";
            this.Botones();
            this.Limpiar();
            this.fillCmbEspecialidades();
            this.fillCmbRango();
        }

        private void fillCmbEspecialidades()
        {
            try
            {
                // Step 1 
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT idespecialidad, especialidad FROM especialidad ORDER BY especialidad ASC", MyConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("idespecialidad", typeof(int));
                MyDataTable.Columns.Add("especialidad", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6
                cmbEspecialidad.ValueMember = "idespecialidad";
                cmbEspecialidad.DisplayMember = "especialidad";
                cmbEspecialidad.DataSource = MyDataTable;

                // Step 7
                MyConexion.Close();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
                throw;
            }
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
            this.txtCedula.Clear();
            this.txtID.Clear();
            this.txtNombre.Clear();
            this.txtRecord.Clear();
            this.txtNSS.Clear();
            this.rbSenasa.Checked = true;
            this.dtCitaMedica.Refresh();
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
                MyCommand.CommandText = "SELECT count(*) FROM citasmedicas";

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
                    this.dtCitaMedica.Enabled = false;
                    this.cmbEspecialidad.Enabled = false;
                    this.txtRecord.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    this.txtNSS.Enabled = false;
                    this.rbAccionCivica.Enabled = false;
                    this.rbSenasa.Enabled = false;
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
                    this.dtCitaMedica.Enabled = true;
                    this.cmbEspecialidad.Enabled = true;
                    this.txtRecord.Enabled = false;
                    this.btnBuscarPaciente.Enabled = true;
                    this.txtNSS.Enabled = true;
                    this.rbAccionCivica.Enabled = true;
                    this.rbSenasa.Enabled = true;
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
                    this.dtCitaMedica.Enabled = false;
                    this.cmbEspecialidad.Enabled = false;
                    this.txtRecord.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    this.txtNSS.Enabled = false;
                    this.rbAccionCivica.Enabled = false;
                    this.rbSenasa.Enabled = false;
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
                    this.dtCitaMedica.Enabled = true;
                    this.cmbEspecialidad.Enabled = true;
                    this.txtRecord.Enabled = false;
                    this.btnBuscarPaciente.Enabled = true;
                    this.txtNSS.Enabled = true;
                    this.rbAccionCivica.Enabled = true;
                    this.rbSenasa.Enabled = true;
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
                    this.dtCitaMedica.Enabled = false;
                    this.cmbEspecialidad.Enabled = false;
                    this.txtRecord.Enabled = false;
                    this.btnBuscarPaciente.Enabled = false;
                    this.txtNSS.Enabled = false;
                    this.rbAccionCivica.Enabled = false;
                    this.rbSenasa.Enabled = false;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.cModo = "Nuevo";
            this.Limpiar();
            this.Botones();
            this.ProximoCodigo();
            this.dtCitaMedica.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtNSS.Text == "" || txtNombre.Text == "")
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
                        myCommand.CommandText = "INSERT INTO citasmedicas(fecha, record, especialidad, fecharegistro, nss, tipoaccion)" +
                            " values(@fecha, @record, @especialidad, NOW(), @nss, @tipoaccion)";
                        myCommand.Parameters.AddWithValue("@fecha", dtCitaMedica.Value);
                        myCommand.Parameters.AddWithValue("@record", txtRecord.Text);
                        myCommand.Parameters.AddWithValue("@especialidad", cmbEspecialidad.SelectedValue);
                        myCommand.Parameters.AddWithValue("@nss", txtNSS.Text);
                        if (rbSenasa.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@tipoaccion", "S");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@tipoaccion", "A");
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
                        myCommand.CommandText = "UPDATE citasmedicas SET fecha = @fecha, record = @record, nss = @nss, tipoaccion = @tipoaccion," +
                            "especialidad = @especialidad, fecharegistro = NOW() WHERE idcitasmedicas = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@fecha", dtCitaMedica.Value);
                        myCommand.Parameters.AddWithValue("@record", txtRecord.Text);
                        myCommand.Parameters.AddWithValue("@especialidad", cmbEspecialidad.SelectedValue);
                        myCommand.Parameters.AddWithValue("@nss", txtNSS.Text);
                        if (rbSenasa.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@tipoaccion", "S");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@tipoaccion", "A");
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

            if (txtID.Text == "")
            {
                MessageBox.Show("No se permiten busquedas vacias...");
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
                    MyCommand.CommandText = "SELECT fecha, record, especialidad, nss, tipoaccion " +
                        "FROM citasmedicas WHERE idcitasmedicas = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            dtCitaMedica.Value = Convert.ToDateTime(MyReader["fecha"].ToString());
                            cmbEspecialidad.SelectedValue = MyReader["especialidad"].ToString();
                            txtRecord.Text = MyReader["record"].ToString();
                            txtNSS.Text = MyReader["nss"].ToString();
                            if (MyReader["tipoaccion"].ToString() == "S")
                            {
                                rbSenasa.Checked = true;
                            }
                            else
                            {
                                rbAccionCivica.Checked = true;
                            }
                        }

                        // LLamo funcion que me busca los valores del paciente
                        this.buscaPaciente();

                        // Funcion de los botones
                        this.cModo = "Buscar";
                        this.Botones();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros...");
                        this.cModo = "Inicio";
                        this.Botones();
                        this.Limpiar();
                        this.txtID.Focus();
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

        private void buscaPaciente()
        {
            if (txtNSS.Text == "")
            {
                MessageBox.Show("Sin un numero de seguro social no se permite busqueda...");                
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
                    MyCommand.CommandText = "SELECT cedula, nombre, rango, record " +
                        "FROM pacientes WHERE nss = " + txtNSS.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtCedula.Text = MyReader["cedula"].ToString();
                            txtNombre.Text = MyReader["nombre"].ToString();
                            txtRecord.Text = MyReader["record"].ToString();
                            cmbRango.SelectedValue = MyReader["rango"].ToString();                            
                        }

                        //this.cModo = "Buscar";
                        //this.Botones();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros...");
                        //this.cModo = "Inicio";
                        //this.Botones();
                        //this.Limpiar();
                        //this.txtID.Focus();
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
            frmPrintCitasMedicas ofrmPrintCitasMedicas = new frmPrintCitasMedicas();
            ofrmPrintCitasMedicas.ShowDialog();
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

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            this.buscaPaciente();
        }
    }
}
