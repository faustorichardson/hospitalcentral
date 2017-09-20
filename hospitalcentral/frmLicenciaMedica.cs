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
    public partial class frmLicenciaMedica : frmBase
    {
        // Variable de los modos de los botones
        string cModo = "Inicio";
        public frmLicenciaMedica()
        {
            InitializeComponent();
        }

        private void frmLicenciaMedica_Load(object sender, EventArgs e)
        {
            this.cModo = "Inicio";
            this.Botones();
            this.Limpiar();
            this.fillCmbRango();
            this.fillCmbDepartamento();
            this.fillCmbOrganizacion();
        }

        private void fillCmbOrganizacion()
        {
            try
            {
                // Step 1 
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT id, organizacion FROM organizacion ORDER BY organizacion ASC", MyConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("id", typeof(int));
                MyDataTable.Columns.Add("organizacion", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6
                cmbOrganizacion.ValueMember = "id";
                cmbOrganizacion.DisplayMember = "organizacion";
                cmbOrganizacion.DataSource = MyDataTable;

                // Step 7
                MyConexion.Close();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
                throw;
            }
        }

        private void fillCmbDepartamento()
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
                cmbDepartamento.ValueMember = "idespecialidad";
                cmbDepartamento.DisplayMember = "especialidad";
                cmbDepartamento.DataSource = MyDataTable;

                // Step 7
                MyConexion.Close();
            }
            catch (Exception myEx)
            {
                MessageBox.Show(myEx.Message);
                //throw;
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
                MySqlCommand MyCommand = new MySqlCommand("SELECT idrango, rango FROM rangosmilitares ORDER BY rango ASC", MyConexion);

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

        private void ProximoCodigo()
        {
            try
            {
                // Step 1 - Connection stablished
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - Create command
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // Step 3 - Set the commanndtext property
                MyCommand.CommandText = "SELECT count(*) FROM licenciamedica";

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
                throw;
            }
        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.txtNombres.Clear();
            this.txtApellidos.Clear();
            this.txtCedula.Clear();
            this.txtCarnetMilitar.Clear();
            this.txtTelContacto.Clear();
            this.txtCia.Clear();
            this.txtCantidad.Clear();
            this.txtLugar.Clear();
            this.txtDiagnostico.Clear();
            this.txtRecord.Clear();
            this.txtDoctor.Clear();
            this.txtExequatur.Clear();
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
                    this.txtCedula.Enabled = false;
                    this.txtCarnetMilitar.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.txtNombres.Enabled = false;
                    this.txtApellidos.Enabled = false;
                    this.cmbOrganizacion.Enabled = false;
                    this.cmbRango.Enabled = false;
                    this.txtTelContacto.Enabled = false;
                    this.txtCia.Enabled = false;
                    this.txtCantidad.Enabled = false;
                    this.rbDias.Enabled = false;
                    this.rbMes.Enabled = false;
                    this.txtLugar.Enabled = false;
                    this.txtDiagnostico.Enabled = false;
                    this.cmbDepartamento.Enabled = false;
                    this.txtRecord.Enabled = false;
                    this.txtDoctor.Enabled = false;
                    this.txtExequatur.Enabled = false;
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
                    this.txtCedula.Enabled = true;
                    this.txtCarnetMilitar.Enabled = true;
                    this.dtFecha.Enabled = true;
                    this.txtNombres.Enabled = true;
                    this.txtApellidos.Enabled = true;
                    this.cmbOrganizacion.Enabled = true;
                    this.cmbRango.Enabled = true;
                    this.txtTelContacto.Enabled = true;
                    this.txtCia.Enabled = true;
                    this.txtCantidad.Enabled = true;
                    this.rbDias.Enabled = true;
                    this.rbMes.Enabled = true;
                    this.txtLugar.Enabled = true;
                    this.txtDiagnostico.Enabled = true;
                    this.cmbDepartamento.Enabled = true;
                    this.txtRecord.Enabled = true;
                    this.txtDoctor.Enabled = true;
                    this.txtExequatur.Enabled = true;
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
                    this.txtCedula.Enabled = false;
                    this.txtCarnetMilitar.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.txtNombres.Enabled = false;
                    this.txtApellidos.Enabled = false;
                    this.cmbOrganizacion.Enabled = false;
                    this.cmbRango.Enabled = false;
                    this.txtTelContacto.Enabled = false;
                    this.txtCia.Enabled = false;
                    this.txtCantidad.Enabled = false;
                    this.rbDias.Enabled = false;
                    this.rbMes.Enabled = false;
                    this.txtLugar.Enabled = false;
                    this.txtDiagnostico.Enabled = false;
                    this.cmbDepartamento.Enabled = false;
                    this.txtRecord.Enabled = false;
                    this.txtDoctor.Enabled = false;
                    this.txtExequatur.Enabled = false;
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
                    this.txtCedula.Enabled = true;
                    this.txtCarnetMilitar.Enabled = true;
                    this.dtFecha.Enabled = true;
                    this.txtNombres.Enabled = true;
                    this.txtApellidos.Enabled = true;
                    this.cmbOrganizacion.Enabled = true;
                    this.cmbRango.Enabled = true;
                    this.txtTelContacto.Enabled = true;
                    this.txtCia.Enabled = true;
                    this.txtCantidad.Enabled = true;
                    this.rbDias.Enabled = true;
                    this.rbMes.Enabled = true;
                    this.txtLugar.Enabled = true;
                    this.txtDiagnostico.Enabled = true;
                    this.cmbDepartamento.Enabled = true;
                    this.txtRecord.Enabled = true;
                    this.txtDoctor.Enabled = true;
                    this.txtExequatur.Enabled = true;
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
                    this.txtCedula.Enabled = false;
                    this.txtCarnetMilitar.Enabled = false;
                    this.dtFecha.Enabled = false;
                    this.txtNombres.Enabled = false;
                    this.txtApellidos.Enabled = false;
                    this.cmbOrganizacion.Enabled = false;
                    this.cmbRango.Enabled = false;
                    this.txtTelContacto.Enabled = false;
                    this.txtCia.Enabled = false;
                    this.txtCantidad.Enabled = false;
                    this.rbDias.Enabled = false;
                    this.rbMes.Enabled = false;
                    this.txtLugar.Enabled = false;
                    this.txtDiagnostico.Enabled = false;
                    this.cmbDepartamento.Enabled = false;
                    this.txtRecord.Enabled = false;
                    this.txtDoctor.Enabled = false;
                    this.txtExequatur.Enabled = false;
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
            this.Limpiar();
            this.cModo = "Nuevo";            
            this.Botones();
            this.ProximoCodigo();
            this.txtID.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtCedula.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtCedula.Focus();
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
                        myCommand.CommandText = "INSERT INTO licenciamedica(cedula, carnet, nombre, apellido, organizacion,"+
                        "rango, telcontacto, compania, tiempolicencia, tiempotipo, lugardescanso, diagnostico, departamento,"+
                        "record, doctor, exequatur, fecha)" +
                            " values(@cedula, @carnet, @nombre, @apellido, @organizacion, "+
                        " @rango, @telcontacto, @compania, @tiempolicencia, @tiempotipo, @lugardescanso, @diagnostico, @departamento, "+
                        " @record, @doctor, @exequatur, @fecha)";
                        myCommand.Parameters.AddWithValue("@cedula", txtCedula.Text);
                        myCommand.Parameters.AddWithValue("@carnet", txtCarnetMilitar.Text);
                        myCommand.Parameters.AddWithValue("@nombre", txtNombres.Text);
                        myCommand.Parameters.AddWithValue("@apellido", txtApellidos.Text);
                        myCommand.Parameters.AddWithValue("@organizacion", cmbOrganizacion.SelectedValue);
                        myCommand.Parameters.AddWithValue("@rango", cmbRango.SelectedValue);
                        myCommand.Parameters.AddWithValue("@telcontacto", txtTelContacto.Text);
                        myCommand.Parameters.AddWithValue("@compania", txtCia.Text);
                        myCommand.Parameters.AddWithValue("@tiempolicencia", txtCantidad.Text);
                        // Para poner si la cantidad de la licencia es en dias o mes
                        if (rbDias.Checked == true){
                            myCommand.Parameters.AddWithValue("@tiempotipo", "D");
                        } else{
                            myCommand.Parameters.AddWithValue("@tiempotipo", "M");
                        }
                        myCommand.Parameters.AddWithValue("@lugardescanso", txtLugar.Text);
                        myCommand.Parameters.AddWithValue("@diagnostico", txtDiagnostico.Text);
                        myCommand.Parameters.AddWithValue("@departamento", cmbDepartamento.SelectedValue);
                        myCommand.Parameters.AddWithValue("@record", txtRecord.Text);
                        myCommand.Parameters.AddWithValue("@doctor", txtDoctor.Text);
                        myCommand.Parameters.AddWithValue("@exequatur", txtExequatur.Text);
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);

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
                        myCommand.CommandText = "UPDATE licenciamedica SET cedula = @cedula, carnet = @carnet, "+
                            "nombre = @nombre, apellido = @apellido, organizacion = @organizacion, rango = @rango, "+
                            "telcontacto = @telcontacto, compania = @compania, tiempolicencia = @tiempolicencia, "+
                            "tiempotipo = @tiempotipo, lugardescanso = @lugardescanso, diagnostico = @diagnostico, "+
                            "departamento = @departamento, record = @record, doctor = @doctor, "+
                            "exequatur = @exequatur, fecha = @fecha " +
                            " WHERE id = " + txtID.Text + "";
                        myCommand.Parameters.AddWithValue("@cedula", txtCedula.Text);
                        myCommand.Parameters.AddWithValue("@carnet", txtCarnetMilitar.Text);
                        myCommand.Parameters.AddWithValue("@nombre", txtNombres.Text);
                        myCommand.Parameters.AddWithValue("@apellido", txtApellidos.Text);
                        myCommand.Parameters.AddWithValue("@organizacion", cmbOrganizacion.SelectedValue);
                        myCommand.Parameters.AddWithValue("@rango", cmbRango.SelectedValue);
                        myCommand.Parameters.AddWithValue("@telcontacto", txtTelContacto.Text);
                        myCommand.Parameters.AddWithValue("@compania", txtCia.Text);
                        myCommand.Parameters.AddWithValue("@tiempolicencia", txtCantidad.Text);
                        // Para poner si la cantidad de la licencia es en dias o mes
                        if (rbDias.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@tiempotipo", "D");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@tiempotipo", "M");
                        }
                        myCommand.Parameters.AddWithValue("@lugardescanso", txtLugar.Text);
                        myCommand.Parameters.AddWithValue("@diagnostico", txtDiagnostico.Text);
                        myCommand.Parameters.AddWithValue("@departamento", cmbDepartamento.SelectedValue);
                        myCommand.Parameters.AddWithValue("@record", txtRecord.Text);
                        myCommand.Parameters.AddWithValue("@doctor", txtDoctor.Text);
                        myCommand.Parameters.AddWithValue("@exequatur", txtExequatur.Text);
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);

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
                    MyCommand.CommandText = "SELECT cedula, carnet, nombre, apellido, organizacion," +
                        "rango, telcontacto, compania, tiempolicencia, tiempotipo, lugardescanso, "+
                        " diagnostico, departamento, record, doctor, exequatur, fecha " +
                        "FROM licenciamedica WHERE id = " + txtID.Text + "";

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
                            txtCarnetMilitar.Text = MyReader["carnet"].ToString();
                            txtNombres.Text = MyReader["nombre"].ToString();
                            txtApellidos.Text = MyReader["apellido"].ToString();
                            cmbOrganizacion.SelectedValue = MyReader["organizacion"].ToString();
                            cmbRango.SelectedValue = MyReader["rango"].ToString();
                            txtTelContacto.Text = MyReader["telcontacto"].ToString();
                            txtCia.Text = MyReader["compania"].ToString();
                            txtCantidad.Text = MyReader["tiempolicencia"].ToString();
                            if (MyReader["tiempotipo"].ToString() == "D")
                            {
                                rbDias.Checked = true;
                            }
                            else
                            {
                                rbMes.Checked = true;
                            }
                            txtLugar.Text = MyReader["lugardescanso"].ToString();
                            txtDiagnostico.Text = MyReader["diagnostico"].ToString();
                            cmbDepartamento.SelectedValue = MyReader["departamento"].ToString();
                            txtRecord.Text = MyReader["record"].ToString();
                            txtDoctor.Text = MyReader["doctor"].ToString();
                            txtExequatur.Text = MyReader["exequatur"].ToString();
                            dtFecha.Value = Convert.ToDateTime(MyReader["fecha"].ToString());
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmPrintLicenciaMedica_Listado ofrmPrintLicenciaMedica_Listado = new frmPrintLicenciaMedica_Listado();
            ofrmPrintLicenciaMedica_Listado.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                DialogResult Result =
                MessageBox.Show("Se perderan Los cambios Realizados" + System.Environment.NewLine + "Desea Guardar los Cambios", "Sistema de Gestion de Hospital", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                switch (Result)
                {
                    case DialogResult.Yes:
                        cModo = "Actualiza";
                        btnGrabar_Click(sender, e);
                        break;                    
                }

                // Limpio los campos
                this.cModo = "Inicio";
                this.Botones();
                this.Limpiar();
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

            // LEAVE //

            //if (txtCantidad.Text == "")
            //{
            //    MessageBox.Show("No puede dejar la cantidad sin valor...");
            //    txtCantidad.Focus();
            //}            
        }
    }
}
