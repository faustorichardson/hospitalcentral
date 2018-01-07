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
    public partial class frmAgregarUsuario : frmBase
    {
        string cModo;

        public frmAgregarUsuario()
        {
            InitializeComponent();
        }

        private void frmAgregarUsuario_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            this.cModo = "Inicio";
            this.Botones();
        }

        private void Limpiar()
        {
            this.txtID.Clear();
            this.txtUsuario.Clear();
            this.txtPassword.Clear();
            this.chkMantenimientos.Checked = false;
            this.chkMDoctores.Checked = false;
            this.chkMPacientes.Checked = false;
            this.chkMCategoriasProductos.Checked = false;
            this.chkMProductos.Checked = false;
            this.chkMUsuarios.Checked = false;
            this.chkMSuplidores.Checked = false;
            this.chkProcesos.Checked = false;
            this.chkPCitasMedicas.Checked = false;
            this.chkPEntradaInventario.Checked = false;
            this.chkPLicenciaMedica.Checked = false;
            this.chkReportes.Checked = false;
            this.chkRCitasMedicas.Checked = false;
            this.chkEstadisticas.Checked = false;
            this.chkECitasMedicas.Checked = false;
            this.chkPSalaEmergencia.Checked = false;
            this.chkPSalidaInventario.Checked = false;
            this.chkPLicenciaMedica.Checked = false;
            this.chkELicenciasMedicas.Checked = false;
            this.chkMTarifario.Checked = false;
            this.chkMTipoCobertura.Checked = false;
            this.chkPFacturacionServicio.Checked = false;
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
                    this.txtUsuario.Enabled = false;
                    this.txtPassword.Enabled = false;
                    this.statusA.Enabled = false;
                    this.statusB.Enabled = false;
                    this.chkMantenimientos.Enabled = false;
                    this.chkProcesos.Enabled = false;
                    this.chkReportes.Enabled = false;
                    this.chkEstadisticas.Enabled = false;
                    this.chkMDoctores.Enabled = false;
                    this.chkMPacientes.Enabled = false;
                    this.chkPEntradaInventario.Enabled = false;
                    this.chkMUsuarios.Enabled = false;                    
                    this.chkMProductos.Enabled = false;
                    this.chkMCategoriasProductos.Enabled = false;
                    this.chkMSuplidores.Enabled = false;
                    this.chkPCitasMedicas.Enabled = false;
                    this.chkPLicenciaMedica.Enabled = false;
                    this.chkRCitasMedicas.Enabled = false;
                    this.chkECitasMedicas.Enabled = false;
                    this.chkPSalidaInventario.Enabled = false;
                    this.chkPSalaEmergencia.Enabled = false;
                    this.chkPLicenciaMedica.Enabled = false;
                    this.chkELicenciasMedicas.Enabled = false;
                    this.chkMTarifario.Enabled = false;
                    this.chkMTipoCobertura.Enabled = false;
                    this.chkPFacturacionServicio.Enabled = false;
                    break;

                case "Nuevo":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    //
                    this.txtUsuario.Enabled = true;
                    this.txtPassword.Enabled = true;
                    this.statusA.Enabled = true;
                    this.statusB.Enabled = true;
                    this.chkMantenimientos.Enabled = true;
                    this.chkProcesos.Enabled = true;
                    this.chkReportes.Enabled = true;
                    this.chkEstadisticas.Enabled = true;
                    this.chkMDoctores.Enabled = true;
                    this.chkMPacientes.Enabled = true;                    
                    this.chkMUsuarios.Enabled = true;
                    this.chkMProductos.Enabled = true;
                    this.chkMCategoriasProductos.Enabled = true;
                    this.chkMSuplidores.Enabled = true;
                    this.chkPCitasMedicas.Enabled = true;
                    this.chkPEntradaInventario.Enabled = true;
                    this.chkPLicenciaMedica.Enabled = true;
                    this.chkRCitasMedicas.Enabled = true;
                    this.chkECitasMedicas.Enabled = true;
                    this.chkPSalidaInventario.Enabled = true;
                    this.chkPSalaEmergencia.Enabled = true;
                    this.chkPLicenciaMedica.Enabled = true;
                    this.chkELicenciasMedicas.Enabled = true;
                    this.chkMTarifario.Enabled = true;
                    this.chkMTipoCobertura.Enabled = true;
                    this.chkPFacturacionServicio.Enabled = true;
                    break;

                case "Grabar":
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnSalir.Enabled = true;
                    //
                    this.txtUsuario.Enabled = false;
                    this.txtPassword.Enabled = false;
                    this.statusA.Enabled = false;
                    this.statusB.Enabled = false;
                    this.chkMantenimientos.Enabled = false;
                    this.chkProcesos.Enabled = false;
                    this.chkReportes.Enabled = false;
                    this.chkEstadisticas.Enabled = false;
                    this.chkMDoctores.Enabled = false;
                    this.chkMPacientes.Enabled = false;
                    this.chkMUsuarios.Enabled = false;
                    this.chkMProductos.Enabled = false;
                    this.chkMCategoriasProductos.Enabled = false;
                    this.chkMSuplidores.Enabled = false;
                    this.chkPCitasMedicas.Enabled = false;
                    this.chkPEntradaInventario.Enabled = false;
                    this.chkPLicenciaMedica.Enabled = false;
                    this.chkRCitasMedicas.Enabled = false;
                    this.chkECitasMedicas.Enabled = false;
                    this.chkPSalidaInventario.Enabled = false;
                    this.chkPSalaEmergencia.Enabled = false;
                    this.chkPLicenciaMedica.Enabled = false;
                    this.chkELicenciasMedicas.Enabled = false;
                    this.chkMTarifario.Enabled = false;
                    this.chkMTipoCobertura.Enabled = false;
                    this.chkPFacturacionServicio.Enabled = false;
                    break;

                case "Editar":
                    this.btnNuevo.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnBuscar.Enabled = false;
                    this.btnImprimir.Enabled = true;
                    this.btnEliminar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnSalir.Enabled = true;
                    //
                    this.txtUsuario.Enabled = true;
                    this.txtPassword.Enabled = true;
                    this.statusA.Enabled = true;
                    this.statusB.Enabled = true;
                    this.chkMantenimientos.Enabled = true;
                    this.chkProcesos.Enabled = true;
                    this.chkReportes.Enabled = true;
                    this.chkEstadisticas.Enabled = true;
                    this.chkMDoctores.Enabled = true;
                    this.chkMPacientes.Enabled = true;
                    this.chkMUsuarios.Enabled = true;
                    this.chkMProductos.Enabled = true;
                    this.chkMCategoriasProductos.Enabled = true;
                    this.chkMSuplidores.Enabled = true;
                    this.chkPCitasMedicas.Enabled = true;
                    this.chkPEntradaInventario.Enabled = true;
                    this.chkPLicenciaMedica.Enabled = true;
                    this.chkRCitasMedicas.Enabled = true;
                    this.chkECitasMedicas.Enabled = true;
                    this.chkPSalidaInventario.Enabled = true;
                    this.chkPSalaEmergencia.Enabled = true;
                    this.chkPLicenciaMedica.Enabled = true;
                    this.chkELicenciasMedicas.Enabled = true;
                    this.chkMTarifario.Enabled = true;
                    this.chkMTipoCobertura.Enabled = true;
                    this.chkPFacturacionServicio.Enabled = true;
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
                    this.txtUsuario.Enabled = false;
                    this.txtPassword.Enabled = false;
                    this.statusA.Enabled = false;
                    this.statusB.Enabled = false;
                    this.chkMantenimientos.Enabled = false;
                    this.chkProcesos.Enabled = false;
                    this.chkReportes.Enabled = false;
                    this.chkEstadisticas.Enabled = false;
                    this.chkMDoctores.Enabled = false;
                    this.chkMPacientes.Enabled = false;
                    this.chkMUsuarios.Enabled = false;
                    this.chkMProductos.Enabled = false;
                    this.chkMCategoriasProductos.Enabled = false;
                    this.chkMSuplidores.Enabled = false;
                    this.chkPCitasMedicas.Enabled = false;
                    this.chkPEntradaInventario.Enabled = false;
                    this.chkPLicenciaMedica.Enabled = false;
                    this.chkRCitasMedicas.Enabled = false;
                    this.chkECitasMedicas.Enabled = false;
                    this.chkPSalidaInventario.Enabled = false;
                    this.chkPSalaEmergencia.Enabled = false;
                    this.chkPLicenciaMedica.Enabled = false;
                    this.chkELicenciasMedicas.Enabled = false;
                    this.chkMTarifario.Enabled = false;
                    this.chkMTipoCobertura.Enabled = false;
                    this.chkPFacturacionServicio.Enabled = false;
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
                    //
                    this.txtUsuario.Enabled = false;
                    this.txtPassword.Enabled = false;
                    this.statusA.Enabled = false;
                    this.statusB.Enabled = false;
                    this.chkMantenimientos.Enabled = false;
                    this.chkProcesos.Enabled = false;
                    this.chkReportes.Enabled = false;
                    this.chkEstadisticas.Enabled = false;
                    this.chkMDoctores.Enabled = false;
                    this.chkMPacientes.Enabled = false;
                    this.chkMUsuarios.Enabled = false;
                    this.chkMProductos.Enabled = false;
                    this.chkMCategoriasProductos.Enabled = false;
                    this.chkMSuplidores.Enabled = false;
                    this.chkPCitasMedicas.Enabled = false;
                    this.chkPEntradaInventario.Enabled = false;
                    this.chkPLicenciaMedica.Enabled = false;
                    this.chkRCitasMedicas.Enabled = false;
                    this.chkECitasMedicas.Enabled = false;
                    this.chkPSalidaInventario.Enabled = false;
                    this.chkPSalaEmergencia.Enabled = false;
                    this.chkPLicenciaMedica.Enabled = false;
                    this.chkELicenciasMedicas.Enabled = false;
                    this.chkMTarifario.Enabled = false;
                    this.chkMTipoCobertura.Enabled = false;
                    this.chkPFacturacionServicio.Enabled = false;
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
                MyCommand.CommandText = "SELECT count(*) FROM usuarios";

                // Step 4 - Open connection
                MyConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                txtID.Text = Convert.ToString(codigo);
                txtUsuario.Focus();

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
            this.Limpiar();
            this.cModo = "Nuevo";
            this.Botones();
            this.ProximoCodigo();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            if (txtUsuario.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtUsuario.Focus();
            }
            else if (txtPassword.Text == "") {
                MessageBox.Show("No se permiten campos vacios...");
                txtPassword.Focus();
            }
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
                        myCommand.CommandText = "INSERT INTO usuarios(usuario, clave, status, " +
                            // Permisos Mantenimientos
                            " permiso_mantenimiento," +
                            " permiso_mantenimiento_doctores,"+
                            " permiso_mantenimiento_pacientes,"+
                            " permiso_mantenimiento_usuario,"+
                            " permiso_mantenimiento_productos,"+
                            " permiso_mantenimiento_productoscategorias,"+
                            " permiso_mantenimiento_suplidores,"+
                            " permiso_mantenimiento_tarifas," +
                            " permiso_mantenimiento_tipocobertura," +
                            // Permisos Procesos
                            " permiso_proceso," +
                            " permiso_proceso_citasmedicas,"+
                            " permiso_proceso_entradainventario," +
                            " permiso_proceso_licenciasmedicas,"+
                            " permiso_proceso_salidainventario,"+
                            " permiso_proceso_salaemergencia,"+
                            " permiso_proceso_facturacionservicio," +
                            // Permisos Reportes
                            " permiso_reporte," +
                            " permiso_reporte_citasmedicas,"+
                            // Permisos Estadisticas
                            " permiso_estadistica,"+
                            " permiso_estadistica_citasmedicas,"+
                            " permiso_estadistica_licenciasmedicas"+
                            // VALORES DE LOS PERMISOS
                            ") values(@usuario, @clave, @status, " +
                            // Valores permisos mantenimientos
                            " @permiso_mantenimiento," +
                            " @permiso_mantenimiento_doctores,"+
                            " @permiso_mantenimiento_pacientes,"+
                            " @permiso_mantenimiento_usuario,"+
                            " @permiso_mantenimiento_productos,"+
                            " @permiso_mantenimiento_productoscategorias,"+
                            " @permiso_mantenimiento_suplidores,"+
                            " @permiso_mantenimiento_tarifas," +
                            " @permiso_mantenimiento_tipocobertura," +
                            // Valores permisos procesos
                            " @permiso_proceso,"+
                            " @permiso_proceso_citasmedicas,"+
                            " @permiso_proceso_entradainventario,"+
                            " @permiso_proceso_licenciasmedicas," +
                            " @permiso_proceso_salidainventario," +
                            " @permiso_proceso_salaemergencia," +
                            " @permiso_proceso_facturacionservicio," +
                            // Valores permisos reportes
                            " @permiso_reporte,"+
                            " @permiso_reporte_citasmedicas,"+
                            // Valores permisos estadisticas
                            " @permiso_estadistica,"+
                            " @permiso_estadistica_citasmedicas,"+
                            " @permiso_estadistica_licenciasmedicas"+
                            // Fin de los valores
                            ")";
                        myCommand.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                        myCommand.Parameters.AddWithValue("@clave", txtPassword.Text);
                        // Verificando el estatus del usuario
                        if(statusA.Checked == true){
                            myCommand.Parameters.AddWithValue("@status", 1);
                        } else{
                            myCommand.Parameters.AddWithValue("@status", 0);
                        }
                        // Verificando el estatus de los permisos MANTENIMIENTO
                        if (chkMantenimientos.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento", 0);
                        }

                        if (chkMDoctores.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_doctores", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_doctores", 0);
                        }

                        if (chkMPacientes.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_pacientes", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_pacientes", 0);
                        }

                        if (chkMUsuarios.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_usuario", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_usuario", 0);
                        }
                        if (chkMProductos.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_productos", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_productos", 0);
                        }
                        if (chkMCategoriasProductos.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_productoscategorias", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_productoscategorias", 0);
                        }
                        if (chkMSuplidores.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_suplidores", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_suplidores", 0);
                        }
                        if (chkMTarifario.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_tarifas", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_tarifas", 0);
                        }

                        if (chkMTipoCobertura.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_tipocobertura", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_tipocobertura", 0);
                        }

                        // Verificando el estatus de los permisos PROCESOS
                        if (chkProcesos.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso", 0);
                        }

                        if (chkPCitasMedicas.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_citasmedicas", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_citasmedicas", 0);
                        }

                        if (chkPEntradaInventario.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_entradainventario", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_entradainventario", 0);
                        }
                        if (chkPLicenciaMedica.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_licenciasmedicas", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_licenciasmedicas", 0);
                        }
                        if (chkPSalidaInventario.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_salidainventario", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_salidainventario", 0);
                        }
                        if (chkPSalaEmergencia.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_salaemergencia", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_salaemergencia", 0);
                        }
                        if (chkPFacturacionServicio.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_facturacionservicio", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_facturacionservicio", 0);
                        }

                        // Verificando el estatus de los permisos REPORTES
                        if (chkReportes.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_reporte", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_reporte", 0);
                        }

                        if (chkRCitasMedicas.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_reporte_citasmedicas", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_reporte_citasmedicas", 0);
                        }

                        // Verificando el estatus de los permisos ESTADISTICAS
                        if (chkEstadisticas.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_estadistica", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_estadistica", 0);
                        }

                        if (chkECitasMedicas.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_estadistica_citasmedicas", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_estadistica_citasmedicas", 0);
                        }

                        if (chkELicenciasMedicas.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_estadistica_licenciasmedicas", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_estadistica_licenciasmedicas", 0);
                        }

                        // Fin de los valores
                        
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
                        myCommand.CommandText = "UPDATE usuarios SET usuario = @usuario, clave = @clave, status = @status, "+
                            // Permisos Mantenimientos
                            " permiso_mantenimiento = @permiso_mantenimiento," +
                            " permiso_mantenimiento_doctores = @permiso_mantenimiento_doctores," +
                            " permiso_mantenimiento_pacientes = @permiso_mantenimiento_pacientes," +
                            " permiso_mantenimiento_usuario = @permiso_mantenimiento_usuario," +
                            " permiso_mantenimiento_productos = @permiso_mantenimiento_productos,"+
                            " permiso_mantenimiento_productoscategorias = @permiso_mantenimiento_productoscategorias,"+
                            " permiso_mantenimiento_suplidores = @permiso_mantenimiento_suplidores,"+
                            " permiso_mantenimiento_tarifas = @permiso_mantenimiento_tarifas,"+
                            " permiso_mantenimiento_tipocobertura = @permiso_mantenimiento_tipocobertura," +
                            // Permisos Procesos
                            " permiso_proceso = @permiso_proceso," +
                            " permiso_proceso_citasmedicas = @permiso_proceso_citasmedicas," +
                            " permiso_proceso_entradainventario = @permiso_proceso_entradainventario,"+
                            " permiso_proceso_salaemergencia = @permiso_proceso_salaemergencia,"+
                            " permiso_proceso_salidainventario = @permiso_proceso_salidainventario,"+
                            " permiso_proceso_licenciasmedicas = @permiso_proceso_licenciasmedicas,"+
                            " permiso_proceso_facturacionservicio = @permiso_proceso_facturacionservicio," +
                            // Permisos Reportes
                            " permiso_reporte = @permiso_reporte," +
                            " permiso_reporte_citasmedicas = @permiso_reporte_citasmedicas," +
                            // Permisos Estadisticas
                            " permiso_estadistica = @permiso_estadistica," +
                            " permiso_estadistica_citasmedicas = @permiso_estadistica_citasmedicas," +
                            " permiso_estadistica_licenciasmedicas = @permiso_estadistica_licenciasmedicas"+
                            // Condicion
                            " WHERE idusuarios = " + txtID.Text + "";

                        // VALORES
                        myCommand.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                        myCommand.Parameters.AddWithValue("@clave", txtPassword.Text);
                        
                        // Verificando el estatus del usuario
                        if (statusA.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@status", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@status", 0);
                        }
                        // Verificando el estatus de los permisos MANTENIMIENTO
                        if (chkMantenimientos.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento", 0);
                        }

                        if (chkMDoctores.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_doctores", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_doctores", 0);
                        }

                        if (chkMPacientes.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_pacientes", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_pacientes", 0);
                        }

                        if (chkMUsuarios.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_usuario", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_usuario", 0);
                        }
                        if (chkMProductos.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_productos", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_productos", 0);
                        }
                        if (chkMCategoriasProductos.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_productoscategorias", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_productoscategorias", 0);
                        }
                        if (chkMSuplidores.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_suplidores", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_suplidores", 0);
                        }
                        if (chkMTarifario.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_tarifas", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_tarifas", 0);
                        }
                        if (chkMTipoCobertura.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_tipocobertura", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_mantenimiento_tipocobertura", 0);
                        }

                        // Verificando el estatus de los permisos PROCESOS
                        if (chkProcesos.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso", 0);
                        }

                        if (chkPCitasMedicas.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_citasmedicas", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_citasmedicas", 0);
                        }

                        if (chkPEntradaInventario.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_entradainventario", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_entradainventario", 0);
                        }
                        if (chkPSalidaInventario.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_salidainventario", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_salidainventario", 0);
                        }
                        if (chkPSalaEmergencia.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_salaemergencia", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_salaemergencia", 0);
                        }
                        if (chkPLicenciaMedica.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_licenciasmedicas", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_licenciasmedicas", 0);
                        }
                        if (chkPFacturacionServicio.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_facturacionservicio", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_proceso_facturacionservicio", 0);
                        }

                        // Verificando el estatus de los permisos REPORTES
                        if (chkReportes.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_reporte", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_reporte", 0);
                        }

                        if (chkRCitasMedicas.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_reporte_citasmedicas", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_reporte_citasmedicas", 0);
                        }

                        // Verificando el estatus de los permisos ESTADISTICAS
                        if (chkEstadisticas.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_estadistica", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_estadistica", 0);
                        }

                        if (chkECitasMedicas.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_estadistica_citasmedicas", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_estadistica_citasmedicas", 0);
                        }

                        if (chkELicenciasMedicas.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@permiso_estadistica_licenciasmedicas", 1);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@permiso_estadistica_licenciasmedicas", 0);
                        }

                        // Fin de los valores

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
                cModo = "Inicio";
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
                    MyCommand.CommandText = "SELECT * " +
                        " FROM usuarios WHERE idusuarios = " + txtID.Text + "";

                    // Step 4 - connection open
                    MyConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            txtUsuario.Text = MyReader["usuario"].ToString();
                            txtPassword.Text = MyReader["clave"].ToString();
                            // El Status
                            if (MyReader["status"].ToString() == "1")
                            {
                                statusA.Checked = true;
                            }
                            else
                            {
                                statusB.Checked = true;
                            }
                            /////

                            // PERMISOS DE MANTENIMIENTOS
                            if (MyReader["permiso_mantenimiento"].ToString() == "1")
                            {
                                chkMantenimientos.Checked = true;
                            }
                            else
                            {
                                chkMantenimientos.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_mantenimiento_doctores"].ToString() == "1")
                            {
                                chkMDoctores.Checked = true;
                            }
                            else
                            {
                                chkMDoctores.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_mantenimiento_pacientes"].ToString() == "1")
                            {
                                chkMPacientes.Checked = true;
                            }
                            else
                            {
                                chkMPacientes.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_mantenimiento_usuario"].ToString() == "1")
                            {
                                chkMUsuarios.Checked = true;
                            }
                            else
                            {
                                chkMUsuarios.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_mantenimiento_productos"].ToString() == "1")
                            {
                                chkMProductos.Checked = true;
                            }
                            else
                            {
                                chkMProductos.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_mantenimiento_productoscategorias"].ToString() == "1")
                            {
                                chkMCategoriasProductos.Checked = true;
                            }
                            else
                            {
                                chkMCategoriasProductos.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_mantenimiento_suplidores"].ToString() == "1")
                            {
                                chkMSuplidores.Checked = true;
                            }
                            else
                            {
                                chkMSuplidores.Checked = false;
                            }
                            /////

                            // PERMISOS DE PROCESOS
                            if (MyReader["permiso_proceso"].ToString() == "1")
                            {
                                chkProcesos.Checked = true;
                            }
                            else
                            {
                                chkProcesos.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_proceso_citasmedicas"].ToString() == "1")
                            {
                                chkPCitasMedicas.Checked = true;
                            }
                            else
                            {
                                chkPCitasMedicas.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_proceso_entradainventario"].ToString() == "1")
                            {
                                chkPEntradaInventario.Checked = true;
                            }
                            else
                            {
                                chkPEntradaInventario.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_proceso_salidainventario"].ToString() == "1")
                            {
                                chkPSalidaInventario.Checked = true;
                            }
                            else
                            {
                                chkPSalidaInventario.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_proceso_salaemergencia"].ToString() == "1")
                            {
                                chkPSalaEmergencia.Checked = true;
                            }
                            else
                            {
                                chkPSalaEmergencia.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_proceso_licenciasmedicas"].ToString() == "1")
                            {
                                chkPLicenciaMedica.Checked = true;
                            }
                            else
                            {
                                chkPLicenciaMedica.Checked = false;
                            }
                            /////
                            
                            // PERMISOS REPORTES
                            if (MyReader["permiso_reporte"].ToString() == "1")
                            {
                                chkReportes.Checked = true;
                            }
                            else
                            {
                                chkReportes.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_reporte_citasmedicas"].ToString() == "1")
                            {
                                chkRCitasMedicas.Checked = true;
                            }
                            else
                            {
                                chkRCitasMedicas.Checked = false;
                            }
                            /////

                            // PERMISOS ESTADISTICAS
                            if (MyReader["permiso_estadistica"].ToString() == "1")
                            {
                                chkEstadisticas.Checked = true;
                            }
                            else
                            {
                                chkEstadisticas.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_estadistica_citasmedicas"].ToString() == "1")
                            {
                                chkECitasMedicas.Checked = true;
                            }
                            else
                            {
                                chkECitasMedicas.Checked = false;
                            }
                            /////
                            if (MyReader["permiso_estadistica_licenciasmedicas"].ToString() == "1")
                            {
                                chkELicenciasMedicas.Checked = true;
                            }
                            else
                            {
                                chkELicenciasMedicas.Checked = false;
                            }
                            /////
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
                //string varEspecialidad = (cmbEspecialidad.SelectedValue).ToString();
                //cWhere = cWhere + " AND fechacita >= " + "'" + fechadesde + "'" + " AND fechacita <= " + "'" + fechahasta + "'" + "";
                //cWhere = cWhere + " AND referimiento = " + varEspecialidad + "";
                sbQuery.Clear();
                sbQuery.Append("SELECT idusuarios, usuario, clave, status");
                sbQuery.Append(" FROM usuarios ");
                sbQuery.Append(cWhere);

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtUsuarios = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtUsuarios);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtUsuarios.Rows.Count;
                if (nRegistro == 0)
                {
                    MessageBox.Show("No Hay Datos Para Mostrar, Favor Verificar", "Sistema de Gestion de Combustibles", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    cTitulo = "LISTADO DE USUARIOS DEL SISTEMA";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptUsuarios orptUsuarios = new rptUsuarios();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;

                    orptUsuarios.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtUsuarios, orptUsuarios, cTitulo);

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
            if (txtUsuario.Text != "")
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

            this.Limpiar();
            this.cModo = "Inicio";
            this.Botones();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
