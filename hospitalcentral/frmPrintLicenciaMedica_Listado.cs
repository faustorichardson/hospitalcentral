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
    public partial class frmPrintLicenciaMedica_Listado : frmBase
    {
        public frmPrintLicenciaMedica_Listado()
        {
            InitializeComponent();
        }

        private void frmPrintLicenciaMedica_Listado_Load(object sender, EventArgs e)
        {
            verificaSeleccion();
        }

        private void verificaSeleccion()
        {
            if (rbPorFecha.Checked == true)
            {
                this.dtDesde.Enabled = true;
                this.dtHasta.Enabled = true;
                this.txtCedula.Enabled = false;
            }
            else
            {
                this.dtDesde.Enabled = false;
                this.dtHasta.Enabled = false;
                this.txtCedula.Enabled = true;
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
            string cWhere = " WHERE 1 = 1 ";
            string cUsuario = "";
            string cTitulo = "";
            string fechadesde = dtDesde.Value.ToString("yyyy-MM-dd");
            string fechahasta = dtHasta.Value.ToString("yyyy-MM-dd");

            try
            {
                // Abro conexion
                myConexion.Open();
                // Creo comando
                myCommand = myConexion.CreateCommand();
                // Adhiero el comando a la conexion
                myCommand.Connection = myConexion;
                // Filtros de la busqueda
                
                if (rbPorFecha.Checked == true)
                {                    
                    cWhere = cWhere + " AND licenciamedica.fecha >= " + "'" + fechadesde + "'" + " AND licenciamedica.fecha <= " + "'" + fechahasta + "'" + "";                    
                }
                else if (rbPorPersona.Checked == true)
                {                    
                    cWhere = cWhere + " AND cedula = " + "'" + txtCedula.Text + "'" + "";
                    //MessageBox.Show(txtCedula.Text);
                }

                sbQuery.Clear();
                sbQuery.Append(" SELECT");
                sbQuery.Append(" licenciamedica.id, ");
                sbQuery.Append(" licenciamedica.cedula, ");
                sbQuery.Append(" licenciamedica.nombre, ");
                sbQuery.Append(" licenciamedica.apellido, ");
                //sbQuery.Append(" licenciamedica.rango, ");
                sbQuery.Append(" licenciamedica.tiempolicencia, ");
                sbQuery.Append(" licenciamedica.tiempotipo, ");
                sbQuery.Append(" licenciamedica.fecha, ");
                sbQuery.Append(" licenciamedica.diagnostico, ");
                sbQuery.Append(" organizacion.organizacion, ");
                sbQuery.Append(" rangosmilitares.rango as rango, ");
                sbQuery.Append(" rangosmilitares.orden ");
                sbQuery.Append(" FROM licenciamedica ");
                sbQuery.Append(" INNER JOIN organizacion ON organizacion.id = licenciamedica.organizacion ");
                sbQuery.Append(" INNER JOIN rangosmilitares ON rangosmilitares.idrango = licenciamedica.rango ");
                sbQuery.Append(cWhere);
                sbQuery.Append(" ORDER BY rangosmilitares.orden");                

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtLicenciasMedicas = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtLicenciasMedicas);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtLicenciasMedicas.Rows.Count;
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

                    //nombre del parametro en CR (Crystal Reports)
                    oParametrosCR[0].Name = "cUsuario";

                    //nombre del TITULO DEL INFORME
                    cTitulo = "LISTADO DE LICENCIAS MEDICAS";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptListadoLicenciasMedicas oRptListadoLicenciasMedicas = new rptListadoLicenciasMedicas();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;

                    oRptListadoLicenciasMedicas.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtLicenciasMedicas, oRptListadoLicenciasMedicas, cTitulo);

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

        private void rbPorFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPorFecha.Checked == true)
            {
                this.dtDesde.Enabled = true;
                this.dtHasta.Enabled = true;
                this.txtCedula.Enabled = false;
            }            
        }

        private void rbPorPersona_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPorPersona.Checked == true)
            {
                this.dtDesde.Enabled = false;
                this.dtHasta.Enabled = false;
                this.txtCedula.Enabled = true;
                this.txtCedula.Focus();
            }            
        }
    }
}
