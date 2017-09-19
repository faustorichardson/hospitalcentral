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
    public partial class frmMenu : Form
    {
        public string UsuarioActual;        
        //public string cUsuarioActual = frmLogin.cUsuarioActual;        
        // PERMISO DE MANTENIMIENTOS
        string permiso_mantenimiento = "0";        
        string permiso_mantenimiento_doctores = "0";
        string permiso_mantenimiento_pacientes = "0";
        string permiso_mantenimiento_productos = "0";
        string permiso_mantenimiento_productoscategorias = "0";
        string permiso_mantenimiento_usuarios = "0";
        string permiso_mantenimiento_suplidores = "0";
        // PERMISO DE PROCESOS
        string permiso_proceso = "0";
        string permiso_proceso_citasmedicas = "0";
        string permiso_proceso_entradainventario = "0";
        string permiso_proceso_salidainventario = "0";
        string permiso_proceso_salaemergencia = "0";
        string permiso_proceso_licenciasmedicas = "0";
        // PERMISO DE REPORTES
        string permiso_reporte = "0";
        string permiso_reporte_citasmedicas = "0";
        string permiso_reportes_existencialaboratorio = "0";
        string permiso_reportes_materiallaboratorio = "0";
        string permiso_reportes_examenesmedicos = "0";
        string permiso_reportes_historialclinico = "0";
        // PERMISO DE ESTADISTICAS
        string permiso_estadistica = "0";
        string permiso_estadistica_citasmedicas = "0";
        string permiso_estadisticas_materiallaboratorio = "0";
        string permiso_estadisticas_historialclinico = "0";
        
        
        public frmMenu(string cUsuarioActual)
        {
            UsuarioActual = frmLogin.cUsuarioActual;
            InitializeComponent();
        }


        private void frmMenu_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(UsuarioActual);
            //this.accesos();
            this.verificapermisos();
            // Obtiene las informaciones de la empresa
            this.getEmpresa();
        }

        private void getEmpresa()
        {
        }

        private void verificapermisos()
        {
            try
            {
                // Step 1 - Conexion
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - creating the command object
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // Step 3 - creating the commandtext
                MyCommand.CommandText = "SELECT " +
                    " permiso_mantenimiento," +
                    " permiso_mantenimiento_doctores," +
                    " permiso_mantenimiento_pacientes," +
                    " permiso_mantenimiento_usuario," +
                    " permiso_mantenimiento_productos,"+
                    " permiso_mantenimiento_productoscategorias,"+
                    " permiso_mantenimiento_suplidores,"+
                    " permiso_proceso, " +
                    " permiso_proceso_citasmedicas," +
                    " permiso_proceso_salidainventario," +
                    " permiso_proceso_salaemergencia," +
                    " permiso_proceso_entradainventario,"+
                    " permiso_proceso_licenciasmedicas,"+
                    " permiso_reporte, " +
                    " permiso_reporte_citasmedicas," +
                    " permiso_reportes_existencialaboratorio,"+
                    " permiso_reportes_materiallaboratorio,"+
                    " permiso_reportes_examenesmedicos,"+
                    " permiso_reportes_historialclinico,"+
                    " permiso_estadistica, " +
                    " permiso_estadistica_citasmedicas,"+
                    " permiso_estadistica_materiallaboratorio,"+
                    " permiso_estadistica_historialclinico"+
                    " FROM usuarios WHERE usuario = '" + UsuarioActual + "'";

                // Step 4 - connection open
                MyConexion.Open();

                // Step 5 - Creating the DataReader                    
                MySqlDataReader MyReader = MyCommand.ExecuteReader();

                // Step 6 - Verifying if Reader has rows
                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {                                            
                        // MANTENIMIENTOS
                        permiso_mantenimiento = MyReader["permiso_mantenimiento"].ToString();
                        permiso_mantenimiento_doctores = MyReader["permiso_mantenimiento_doctores"].ToString();
                        permiso_mantenimiento_pacientes = MyReader["permiso_mantenimiento_pacientes"].ToString();
                        permiso_mantenimiento_productos = MyReader["permiso_mantenimiento_productos"].ToString();
                        permiso_mantenimiento_productoscategorias = MyReader["permiso_mantenimiento_productoscategorias"].ToString();
                        permiso_mantenimiento_usuarios = MyReader["permiso_mantenimiento_usuario"].ToString();
                        permiso_mantenimiento_suplidores = MyReader["permiso_mantenimiento_suplidores"].ToString();
                        // PROCESOS
                        permiso_proceso = MyReader["permiso_proceso"].ToString();
                        permiso_proceso_citasmedicas = MyReader["permiso_proceso_citasmedicas"].ToString();
                        permiso_proceso_entradainventario = MyReader["permiso_proceso_entradainventario"].ToString();
                        permiso_proceso_salidainventario = MyReader["permiso_proceso_salidainventario"].ToString();
                        permiso_proceso_salaemergencia = MyReader["permiso_proceso_salaemergencia"].ToString();
                        permiso_proceso_licenciasmedicas = MyReader["permiso_proceso_licenciasmedicas"].ToString();
                        // REPORTES
                        permiso_reporte = MyReader["permiso_reporte"].ToString();
                        permiso_reporte_citasmedicas = MyReader["permiso_reporte_citasmedicas"].ToString();
                        permiso_reportes_existencialaboratorio = MyReader["permiso_reportes_existencialaboratorio"].ToString();
                        permiso_reportes_examenesmedicos = MyReader["permiso_reportes_examenesmedicos"].ToString();
                        permiso_reportes_historialclinico = MyReader["permiso_reportes_historialclinico"].ToString();
                        // ESTADISTICAS
                        permiso_estadistica = MyReader["permiso_estadistica"].ToString();
                        permiso_estadistica_citasmedicas = MyReader["permiso_estadistica_citasmedicas"].ToString();
                        permiso_estadisticas_materiallaboratorio = MyReader["permiso_estadistica_materiallaboratorio"].ToString();
                        permiso_estadisticas_historialclinico = MyReader["permiso_estadistica_historialclinico"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permisos asignados...");
                    //nivel = 0;
                }

                // Step 6 - Closing all
                MyReader.Close();
                MyCommand.Dispose();
                MyConexion.Close();

                // Llama la funcion que habilita permisos
                this.aplicapermisos();

            }
            catch (Exception MyEx)
            {
                MessageBox.Show(MyEx.Message);
             //   nivel = 0;
            }

            
        }

        private void aplicapermisos()
        {
            // VERIFICANDO LOS PERMISOS DE MANTENIMIENTOS
            if (permiso_mantenimiento == "1")
            {
                this.menu_mantenimientos.Enabled = true;
            }
            else
            {
                this.menu_mantenimientos.Enabled = false;
            }
            /////
            if (permiso_mantenimiento_doctores == "1")
            {
                this.btn_mantenimiento_doctores.Enabled = true;
            }
            else
            {
                this.btn_mantenimiento_doctores.Enabled = false;
            }
            /////
            if (permiso_mantenimiento_pacientes == "1")
            {
                this.btn_mantenimiento_pacientes.Enabled = true;
            }
            else
            {
                this.btn_mantenimiento_pacientes.Enabled = false;
            }
            /////
            if (permiso_mantenimiento_usuarios == "1")
            {
                this.btn_mantenimiento_usuarios.Enabled = true;
            }
            else
            {
                this.btn_mantenimiento_usuarios.Enabled = false;
            }
            /////
            if (permiso_mantenimiento_productos == "1")
            {
                this.btn_mantenimiento_productos.Enabled = true;
            }
            else
            {
                this.btn_mantenimiento_productos.Enabled = false;
            }
            /////
            if (permiso_mantenimiento_productoscategorias == "1")
            {
                this.btn_mantenimiento_productoscategorias.Enabled = true;
            }
            else
            {
                this.btn_mantenimiento_productoscategorias.Enabled = false;
            }
            if (permiso_mantenimiento_suplidores == "1")
            {
                this.btn_mantenimiento_suplidores.Enabled = true;
            }
            else
            {
                this.btn_mantenimiento_suplidores.Enabled = false;
            }
            /////

            // VERIFICANDO LOS PERMISOS DE PROCESOS
            if (permiso_proceso == "1")
            {
                this.menu_procesos.Enabled = true;
            }
            else
            {
                this.menu_procesos.Enabled = false;
            }
            /////
            if (permiso_proceso_citasmedicas == "1")
            {
                this.btn_procesos_citamedica.Enabled = true;
            }
            else
            {
                this.btn_procesos_citamedica.Enabled = false;
            }
            /////
            if (permiso_proceso_entradainventario == "1")
            {
                this.btn_proceso_entradainventario.Enabled = true;
            }
            else
            {
                this.btn_proceso_entradainventario.Enabled = false;
            }
            /////
            if (permiso_proceso_licenciasmedicas == "1")
            {
                this.btn_proceso_licenciasmedicas.Enabled = true;
            }
            else
            {
                this.btn_proceso_licenciasmedicas.Enabled = false;
            }
            /////
            if (permiso_proceso_salidainventario == "1")
            {
                this.btn_proceso_salidainventario.Enabled = true;
            }
            else
            {
                this.btn_proceso_salidainventario.Enabled = true;
            }
            /////
            if (permiso_proceso_salaemergencia == "1")
            {
                this.btn_proceso_salaemergencias.Enabled = true;
            }
            else
            {
                this.btn_proceso_salaemergencias.Enabled = false;
            }

            // VERIFICANDO LOS PERMISOS DE REPORTES
            if (permiso_reporte == "1")
            {
                this.menu_reportes.Enabled = true;
            }
            else
            {
                this.menu_reportes.Enabled = false;
            }
            /////
            if (permiso_reporte_citasmedicas == "1")
            {
                this.btn_reportes_citasmedicas.Enabled = true;
            }
            else
            {
                this.btn_reportes_citasmedicas.Enabled = false;
            }
            /////
            if (permiso_reportes_existencialaboratorio == "1")
            {
                this.btn_reportes_existencialaboratorio.Enabled = true;
            }
            else
            {
                this.btn_reportes_existencialaboratorio.Enabled = false;
            }
            /////
            if (permiso_reportes_materiallaboratorio == "1")
            {
                this.btn_reportes_materiallaboratorio.Enabled = true;
            }
            else
            {
                this.btn_reportes_materiallaboratorio.Enabled = false;
            }
            /////
            if (permiso_reportes_examenesmedicos == "1")
            {
                this.btn_reportes_examenesmedicos.Enabled = true;
            }
            else
            {
                this.btn_reportes_examenesmedicos.Enabled = false;
            }
            /////
            if (permiso_reportes_historialclinico == "1")
            {
                this.btn_reportes_historialclinico.Enabled = true;
            }
            else
            {
                this.btn_reportes_historialclinico.Enabled = false;
            }

            // VERIFICANDO LOS PERMISOS DE ESTADISTICAS
            if (permiso_estadistica == "1")
            {
                this.menu_estadisticas.Enabled = true;
            }
            else
            {
                this.menu_estadisticas.Enabled = false;
            }
            /////
            if (permiso_estadistica_citasmedicas == "1")
            {
                this.btn_estadisticas_citasmedicas.Enabled = true;
            }
            else
            {
                this.btn_estadisticas_citasmedicas.Enabled = false;
            }
            /////
            if (permiso_estadisticas_historialclinico == "1")
            {
                this.btn_estadisticas_historialclinico.Enabled = true;
            }
            else
            {
                this.btn_estadisticas_historialclinico.Enabled = false;
            }
            /////
            if (permiso_estadisticas_materiallaboratorio == "1")
            {
                this.btn_estadisticas_materiallaboratorio.Enabled = true;
            }
            else
            {
                this.btn_estadisticas_materiallaboratorio.Enabled = false;
            }

        }


        private void buttonItem7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void buttonItem10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            frmAbout ofrmAbout = new frmAbout();
            ofrmAbout.ShowDialog();
        }

       
        private void buttonItem25_Click(object sender, EventArgs e)
        {

            
        }

       
        private void ribbonTabItem2_Click(object sender, EventArgs e)
        {

        }

       
        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem39_Click(object sender, EventArgs e)
        {
            frmAgregarUsuario ofrmAgregarUsuario = new frmAgregarUsuario();
            ofrmAgregarUsuario.ShowDialog();
        }

       
        private void buttonItem39_Click_1(object sender, EventArgs e)
        {
            frmAgregarUsuario ofrmAgregarUsuario = new frmAgregarUsuario();
            ofrmAgregarUsuario.ShowDialog();
        }

       
        private void buttonItem12_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            frmDoctores ofrmDoctores = new frmDoctores();
            ofrmDoctores.ShowDialog();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            frmPacientes ofrmPacientes = new frmPacientes();
            ofrmPacientes.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            frmcitasmedicas ofrmCitasMedicas = new frmcitasmedicas();
            ofrmCitasMedicas.ShowDialog();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            frmPrintCitasMedicas ofrmPrintCitasMedicas = new frmPrintCitasMedicas();
            ofrmPrintCitasMedicas.ShowDialog();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            frmEstadisticasCitasMedicas ofrmEstadisticasCitasMedicas = new frmEstadisticasCitasMedicas();
            ofrmEstadisticasCitasMedicas.ShowDialog();
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            frmcitasmedicas ofrmCitasMedicas = new frmcitasmedicas();
            ofrmCitasMedicas.ShowDialog();
        }

        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            frmProductos ofrmProductos = new frmProductos();
            ofrmProductos.ShowDialog();
        }

        private void buttonItem3_Click_1(object sender, EventArgs e)
        {
            frmCategorias ofrmCategorias = new frmCategorias();
            ofrmCategorias.ShowDialog();
        }

        private void buttonItem2_Click_2(object sender, EventArgs e)
        {
            frmEntradaInventario ofrmEntradaInventario = new frmEntradaInventario();
            ofrmEntradaInventario.ShowDialog();
        }

        private void buttonItem3_Click_2(object sender, EventArgs e)
        {
            frmSalidaInventario ofrmSalidaInventario = new frmSalidaInventario();
            ofrmSalidaInventario.ShowDialog();
        }

        private void buttonItem4_Click_1(object sender, EventArgs e)
        {
            frmSuplidores ofrmSuplidores = new frmSuplidores();
            ofrmSuplidores.ShowDialog();
        }

        private void ribbonBar2_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonItem4_Click_2(object sender, EventArgs e)
        {
            frmPrintInventarioEstadisticas ofrmPrintInventarioEstadisticas = new frmPrintInventarioEstadisticas();
            ofrmPrintInventarioEstadisticas.ShowDialog();
        }

        private void buttonItem1_Click_2(object sender, EventArgs e)
        {
            frmPrintMaterialLaboratorio ofrmPrintMaterialLaboratorio = new frmPrintMaterialLaboratorio();
            ofrmPrintMaterialLaboratorio.ShowDialog();
        }

        private void buttonItem2_Click_3(object sender, EventArgs e)
        {

        }

        private void buttonItem5_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click_4(object sender, EventArgs e)
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
                sbQuery.Append(" productos.idproducto, productos.producto, productos.referencia,");
                sbQuery.Append(" productos.descripcion, ");
                sbQuery.Append(" productos.reorden, categorias.categoria, inventario.cantidad");
                sbQuery.Append(" FROM productos ");
                sbQuery.Append(" INNER JOIN categorias ON categorias.idcategoria = productos.idcategoria ");
                sbQuery.Append(" INNER JOIN inventario ON inventario.idproducto = productos.idproducto ");
                sbQuery.Append(cWhere);
                sbQuery.Append(" ORDER BY productos.producto ASC ");

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtProductos = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtProductos);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtProductos.Rows.Count;
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
                    cTitulo = "LISTADO DE EXISTENCIA DE PRODUCTOS LABORATORIO";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptProductos orptProductos = new rptProductos();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptProductos.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtProductos, orptProductos, cTitulo);

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

        private void buttonItem5_Click_2(object sender, EventArgs e)
        {
            frmPrintExamenesMedicos ofrmPrintExamenesMedicos = new frmPrintExamenesMedicos();
            ofrmPrintExamenesMedicos.ShowDialog();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            frmHistoriaClinica ofrmHistoriaClinica = new frmHistoriaClinica();
            ofrmHistoriaClinica.ShowDialog();
        }

        private void buttonItem11_Click_1(object sender, EventArgs e)
        {
            frmPrintHistoriaClinica ofrmPrintHistoriaClinica = new frmPrintHistoriaClinica();
            ofrmPrintHistoriaClinica.ShowDialog();
        }

        private void buttonItem12_Click_1(object sender, EventArgs e)
        {
            frmPrintHistoriaClinicaEstadisticas ofrmPrintHistoriaClinicaEstadisticas = new frmPrintHistoriaClinicaEstadisticas();
            ofrmPrintHistoriaClinicaEstadisticas.ShowDialog();
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            frmLicenciaMedica ofrmLicenciaMedica = new frmLicenciaMedica();
            ofrmLicenciaMedica.ShowDialog();
        }

        private void ribbonPanel1_Click(object sender, EventArgs e)
        {

        }

       
        
    }
}
