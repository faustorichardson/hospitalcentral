﻿using System;
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
    public partial class frmPrintCitasMedicas : frmBase
    {
        public frmPrintCitasMedicas()
        {
            InitializeComponent();
        }

        private void frmPrintCitasMedicas_Load(object sender, EventArgs e)
        {
            this.fillCmbEspecialidad();
        }

        private void fillCmbEspecialidad()
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (chkPorRecord.Checked == true)
            {
                if (txtRecord.Text == "")
                {
                    MessageBox.Show("Para hacer una consulta debe introducir numero de record...");
                    txtRecord.Focus();
                }
                else
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
                        //string fechadesde = dtCitaMedicaDesde.Value.ToString("yyyy-MM-dd");
                        //string fechahasta = dtCitaMedicaHasta.Value.ToString("yyyy-MM-dd");
                        //cWhere = cWhere + " AND fechacita >= " + "'" + fechadesde + "'" + " AND fechacita <= " + "'" + fechahasta + "'" + "";
                        cWhere = cWhere + " AND citasmedicas.nss = " + txtRecord.Text + "";
                        sbQuery.Clear();
                        sbQuery.Append("SELECT ");
                        sbQuery.Append(" citasmedicas.idcitasmedicas, citasmedicas.fecha, citasmedicas.fecharegistro,");
                        sbQuery.Append(" pacientes.cedula, pacientes.record, pacientes.nombre, rango.rango,");
                        sbQuery.Append(" especialidad.especialidad, citasmedicas.nss");
                        sbQuery.Append(" FROM citasmedicas ");
                        sbQuery.Append(" INNER JOIN pacientes ON pacientes.record = citasmedicas.record");
                        sbQuery.Append(" INNER JOIN especialidad ON especialidad.idespecialidad = citasmedicas.especialidad");
                        sbQuery.Append(" INNER JOIN rango ON rango.idrango = pacientes.rango");
                        sbQuery.Append(cWhere);
                        sbQuery.Append(" ORDER BY fecha ASC");

                        // Paso los valores de sbQuery al CommandText
                        myCommand.CommandText = sbQuery.ToString();
                        // Creo el objeto Data Adapter y ejecuto el command en el
                        myAdapter = new MySqlDataAdapter(myCommand);
                        // Creo el objeto Data Table
                        DataTable dtCitasMedicas = new DataTable();
                        // Lleno el data adapter
                        myAdapter.Fill(dtCitasMedicas);
                        // Cierro el objeto conexion
                        myConexion.Close();

                        // Verifico cantidad de datos encontrados
                        int nRegistro = dtCitasMedicas.Rows.Count;
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
                            cTitulo = "LISTADO DE CITAS MEDICAS POR RECORD MEDICO";

                            //6to Instanciamos nuestro REPORTE
                            //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                            rptCitasMedicasPorRecord orptCitasMedicasPorRecord = new rptCitasMedicasPorRecord();

                            //pasamos el nombre del TITULO del Listado
                            //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                            // oListado.SummaryInfo.ReportTitle = cTitulo;
                            orptCitasMedicasPorRecord.SummaryInfo.ReportTitle = cTitulo;

                            //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                            frmPrinter ofrmPrinter = new frmPrinter(dtCitasMedicas, orptCitasMedicasPorRecord, cTitulo);

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
            }
            else if (chkPorEspecialidad.Checked == true)
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
                    string fechadesde = dtCitaMedicaDesde.Value.ToString("yyyy-MM-dd");
                    string fechahasta = dtCitaMedicaHasta.Value.ToString("yyyy-MM-dd");
                    cWhere = cWhere + " AND citasmedicas.fecha >= " + "'" + fechadesde + "'" + " AND citasmedicas.fecha <= " + "'" + fechahasta + "'" + "";
                    //cWhere = cWhere + " AND citasmedicas.fecha = "+ "'" + fecha + "'" + "";
                    cWhere = cWhere + " AND citasmedicas.especialidad = " + cmbEspecialidad.SelectedValue +"";
                    //cWhere = cWhere + " AND citasmedicas.record = " + txtRecord.Text + "";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT ");
                    sbQuery.Append(" citasmedicas.idcitasmedicas, citasmedicas.fecha, citasmedicas.fecharegistro,");
                    sbQuery.Append(" pacientes.cedula, pacientes.record, pacientes.nombre, rango.rango,");
                    sbQuery.Append(" especialidad.especialidad, citasmedicas.record, citasmedicas.nss ");
                    sbQuery.Append(" FROM citasmedicas ");
                    sbQuery.Append(" INNER JOIN pacientes ON pacientes.record = citasmedicas.record");
                    sbQuery.Append(" INNER JOIN especialidad ON especialidad.idespecialidad = citasmedicas.especialidad");
                    sbQuery.Append(" INNER JOIN rango ON rango.idrango = pacientes.rango");
                    sbQuery.Append(cWhere);
                    //sbQuery.Append(" ORDER BY fecha ASC");

                    // Paso los valores de sbQuery al CommandText
                    myCommand.CommandText = sbQuery.ToString();
                    // Creo el objeto Data Adapter y ejecuto el command en el
                    myAdapter = new MySqlDataAdapter(myCommand);
                    // Creo el objeto Data Table
                    DataTable dtCitasMedicas = new DataTable();
                    // Lleno el data adapter
                    myAdapter.Fill(dtCitasMedicas);
                    // Cierro el objeto conexion
                    myConexion.Close();

                    // Verifico cantidad de datos encontrados
                    int nRegistro = dtCitasMedicas.Rows.Count;
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
                        ParameterField oFechaInicial = new ParameterField();
                        ParameterField oFechaFinal = new ParameterField();
                        //parametervaluetype especifica el TIPO de valor de parametro
                        //ParameterValueKind especifica el tipo de valor de parametro en la PARAMETERVALUETYPE de la Clase PARAMETERFIELD
                        oUsuario.ParameterValueType = ParameterValueKind.StringParameter;
                        oFechaInicial.ParameterValueType = ParameterValueKind.DateTimeParameter;
                        oFechaFinal.ParameterValueType = ParameterValueKind.DateTimeParameter;

                        //3ero.VALORES PARA LOS PARAMETROS
                        //ParameterDiscreteValue proporciona propiedades para la recuperacion y configuracion de 
                        //parametros de valores discretos
                        ParameterDiscreteValue oUsuarioDValue = new ParameterDiscreteValue();
                        oUsuarioDValue.Value = cUsuario;
                        ParameterDiscreteValue oFechaDValue = new ParameterDiscreteValue();
                        oFechaDValue.Value = fechadesde;
                        ParameterDiscreteValue oFechaFinDValue = new ParameterDiscreteValue();
                        oFechaFinDValue.Value = fechahasta;

                        //4to. AGREGAMOS LOS VALORES A LOS PARAMETROS
                        oUsuario.CurrentValues.Add(oUsuarioDValue);
                        oFechaInicial.CurrentValues.Add(oFechaDValue);
                        oFechaFinal.CurrentValues.Add(oFechaFinDValue);

                        //5to. AGREGAMOS LOS PARAMETROS A LA COLECCION 
                        oParametrosCR.Add(oUsuario);
                        oParametrosCR.Add(oFechaInicial);
                        oParametrosCR.Add(oFechaFinal);
                        //nombre del parametro en CR (Crystal Reports)
                        oParametrosCR[0].Name = "cUsuario";
                        oParametrosCR[1].Name = "cFechaDesde";
                        oParametrosCR[2].Name = "cFechaHasta";


                        //nombre del TITULO DEL INFORME
                        cTitulo = "LISTADO DE CITAS MEDICAS POR ESPECIALIDAD";

                        //6to Instanciamos nuestro REPORTE
                        //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                        rptCitasMedicasPorEspecialidad orptCitasMedicasPorEspecialidad = new rptCitasMedicasPorEspecialidad();

                        //pasamos el nombre del TITULO del Listado
                        //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                        // oListado.SummaryInfo.ReportTitle = cTitulo;
                        orptCitasMedicasPorEspecialidad.SummaryInfo.ReportTitle = cTitulo;

                        //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                        frmPrinter ofrmPrinter = new frmPrinter(dtCitasMedicas, orptCitasMedicasPorEspecialidad, cTitulo);

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
            else if (chkTodos.Checked == true)
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
                    string fechadesde = dtCitaMedicaDesde.Value.ToString("yyyy-MM-dd");
                    string fechahasta = dtCitaMedicaHasta.Value.ToString("yyyy-MM-dd");
                    //string fechahasta = fechaHasta.Value.ToString("yyyy-MM-dd");
                    cWhere = cWhere + " AND fecha >= " + "'" + fechadesde + "'" + " AND fecha <= " + "'" + fechahasta + "'" + "";
                    //cWhere = cWhere + " AND citasmedicas.fecha = " + "'" + fecha + "'" + "";
                    //cWhere = cWhere + " AND citasmedicas.especialidad = " + cmbEspecialidad.SelectedValue + "";
                    //cWhere = cWhere + " AND citasmedicas.record = " + txtRecord.Text + "";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT ");
                    sbQuery.Append(" citasmedicas.idcitasmedicas, citasmedicas.fecha, citasmedicas.fecharegistro,");
                    sbQuery.Append(" pacientes.cedula, pacientes.record, pacientes.nombre, rango.rango,");
                    sbQuery.Append(" especialidad.especialidad, citasmedicas.nss");
                    sbQuery.Append(" FROM citasmedicas ");
                    sbQuery.Append(" INNER JOIN pacientes ON pacientes.record = citasmedicas.record");
                    sbQuery.Append(" INNER JOIN especialidad ON especialidad.idespecialidad = citasmedicas.especialidad");
                    sbQuery.Append(" INNER JOIN rango ON rango.idrango = pacientes.rango");
                    sbQuery.Append(cWhere);
                    //sbQuery.Append(" ORDER BY fecha ASC");

                    // Paso los valores de sbQuery al CommandText
                    myCommand.CommandText = sbQuery.ToString();
                    // Creo el objeto Data Adapter y ejecuto el command en el
                    myAdapter = new MySqlDataAdapter(myCommand);
                    // Creo el objeto Data Table
                    DataTable dtCitasMedicas = new DataTable();
                    // Lleno el data adapter
                    myAdapter.Fill(dtCitasMedicas);
                    // Cierro el objeto conexion
                    myConexion.Close();

                    // Verifico cantidad de datos encontrados
                    int nRegistro = dtCitasMedicas.Rows.Count;
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
                        ParameterField oFechaInicial = new ParameterField();
                        ParameterField oFechaFinal = new ParameterField();
                        //parametervaluetype especifica el TIPO de valor de parametro
                        //ParameterValueKind especifica el tipo de valor de parametro en la PARAMETERVALUETYPE de la Clase PARAMETERFIELD
                        oUsuario.ParameterValueType = ParameterValueKind.StringParameter;
                        oFechaInicial.ParameterValueType = ParameterValueKind.DateTimeParameter;
                        oFechaFinal.ParameterValueType = ParameterValueKind.DateTimeParameter;

                        //3ero.VALORES PARA LOS PARAMETROS
                        //ParameterDiscreteValue proporciona propiedades para la recuperacion y configuracion de 
                        //parametros de valores discretos
                        ParameterDiscreteValue oUsuarioDValue = new ParameterDiscreteValue();
                        oUsuarioDValue.Value = cUsuario;
                        ParameterDiscreteValue oFechaDValue = new ParameterDiscreteValue();
                        oFechaDValue.Value = fechadesde;
                        ParameterDiscreteValue oFechaFinDValue = new ParameterDiscreteValue();
                        oFechaFinDValue.Value = fechahasta;

                        //4to. AGREGAMOS LOS VALORES A LOS PARAMETROS
                        oUsuario.CurrentValues.Add(oUsuarioDValue);
                        oFechaInicial.CurrentValues.Add(oFechaDValue);
                        oFechaFinal.CurrentValues.Add(oFechaFinDValue);

                        //5to. AGREGAMOS LOS PARAMETROS A LA COLECCION 
                        oParametrosCR.Add(oUsuario);
                        oParametrosCR.Add(oFechaInicial);
                        oParametrosCR.Add(oFechaFinal);
                        //nombre del parametro en CR (Crystal Reports)
                        oParametrosCR[0].Name = "cUsuario";
                        oParametrosCR[1].Name = "cFechaInicial";
                        oParametrosCR[2].Name = "cFechaFinal";


                        //nombre del TITULO DEL INFORME
                        cTitulo = "LISTADO GENERAL DE CITAS MEDICAS";

                        //6to Instanciamos nuestro REPORTE
                        //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                        rptCitasMedicasTodas orptCitasMedicasTodas = new rptCitasMedicasTodas();

                        //pasamos el nombre del TITULO del Listado
                        //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                        // oListado.SummaryInfo.ReportTitle = cTitulo;
                        orptCitasMedicasTodas.SummaryInfo.ReportTitle = cTitulo;

                        //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                        frmPrinter ofrmPrinter = new frmPrinter(dtCitasMedicas, orptCitasMedicasTodas, cTitulo);

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
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
