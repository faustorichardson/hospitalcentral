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
    public partial class frmPrintHistoriaClinica : frmBase
    {
        public frmPrintHistoriaClinica()
        {
            InitializeComponent();
        }

        private void frmPrintHistoriaClinica_Load(object sender, EventArgs e)
        {

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

            // FILTROS DE OPCIONES
            if (rbTodos.Checked == true)
            {
            }
            else if (rbSenasa.Checked == true)
            {
                cWhere = cWhere + " AND historiaclinica.tipoaccion = 'S'";
            }
            else if (rbAccionCivica.Checked == true)
            {
                cWhere = cWhere + " AND historiaclinica.tipoaccion = 'A'";
            }

            try
            {
                // Abro conexion
                myConexion.Open();
                // Creo comando
                myCommand = myConexion.CreateCommand();
                // Adhiero el comando a la conexion
                myCommand.Connection = myConexion;
                // Filtros de la busqueda
                string fechadesde = dtDesde.Value.ToString("yyyy-MM-dd");
                string fechahasta = dtHasta.Value.ToString("yyyy-MM-dd");
                cWhere = cWhere + " AND fecha >= " + "'" + fechadesde + "'" + " AND fecha <= " + "'" + fechahasta + "'" + "";
                sbQuery.Clear();
                sbQuery.Append("SELECT ");
                sbQuery.Append(" historiaclinica.id, historiaclinica.nss, historiaclinica.fecha, historiaclinica.hora,");
                sbQuery.Append(" historiaclinica.motivoconsulta, historiaclinica.antecedentespatologicos,");
                sbQuery.Append(" pacientes.nombre as nombrepaciente, pacientes.fecha_nacimiento,");
                sbQuery.Append(" (DATE_FORMAT(NOW(),'%Y-%m-%d') - DATE_FORMAT(pacientes.fecha_nacimiento,'%Y-%m-%d')) as edad");
                sbQuery.Append(" FROM historiaclinica ");
                sbQuery.Append(" INNER JOIN pacientes ON pacientes.nss = historiaclinica.nss");
                sbQuery.Append(cWhere);
                sbQuery.Append(" ORDER BY pacientes.nombre ASC");

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtHistoriaClinica = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtHistoriaClinica);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtHistoriaClinica.Rows.Count;
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
                    if (rbTodos.Checked == true)
                    {
                        cTitulo = "LISTADO DE ATENCIONES MEDICAS";
                    }
                    else if (rbSenasa.Checked == true)
                    {
                        cTitulo = "LISTADO DE ATENCIONES MEDICAS POR SENASA";
                    }
                    else if (rbAccionCivica.Checked == true)
                    {
                        cTitulo = "LISTADO DE ATENCIONES MEDICAS POR ACCIONES CIVICAS";
                    }


                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptListadoHistoriaClinica orptListadoHistoriaClinica = new rptListadoHistoriaClinica();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptListadoHistoriaClinica.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtHistoriaClinica, orptListadoHistoriaClinica, cTitulo);

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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
