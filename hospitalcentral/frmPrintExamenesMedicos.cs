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
    public partial class frmPrintExamenesMedicos : frmBase
    {
        public frmPrintExamenesMedicos()
        {
            InitializeComponent();
        }

        private void frmPrintExamenesMedicos_Load(object sender, EventArgs e)
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
                cWhere = cWhere + " AND salida_inventario.fecha >= " + "'" + fechadesde + "'" + " AND salida_inventario.fecha <= " + "'" + fechahasta + "'" + "";
                sbQuery.Clear();
                sbQuery.Append("SELECT ");
                sbQuery.Append(" salida_inventario.idpaciente, SUM(salida_inventario.acidourico) as acidourico, SUM(salida_inventario.albumina) as albumina,");
                sbQuery.Append(" SUM(salida_inventario.amilasa) as amilasa, SUM(salida_inventario.aso) as aso, SUM(salida_inventario.bilirrubina) as bilirrubina,");
                sbQuery.Append(" SUM(salida_inventario.chiamycia) as chiamycia, SUM(salida_inventario.colesterol) as colesterol, SUM(salida_inventario.colesterolhdl) as colesterolhdl,");
                sbQuery.Append(" SUM(salida_inventario.coombdirect) as coombdirect, SUM(salida_inventario.coombindirect) as coomindirect, SUM(salida_inventario.creatinina) as creatinina,");
                sbQuery.Append(" SUM(salida_inventario.cultivosecrecionuretral) as cultivosecrecionuretral, SUM(salida_inventario.cultivosemen) as cultivosemen, SUM(salida_inventario.electrolitos_sericos) as electrolitos_sericos,");
                sbQuery.Append(" SUM(salida_inventario.eritrosedimentacion) as eritrosedimentacion, SUM(salida_inventario.exorina) as exorina, SUM(salida_inventario.falcalina) as falcalina,");
                sbQuery.Append(" SUM(salida_inventario.falcemia) as falcemia, SUM(salida_inventario.fr) as fr, SUM(salida_inventario.glicemia) as glicemia, SUM(salida_inventario.hbsag) as hbsag,");
                sbQuery.Append(" SUM(salida_inventario.hcg) as hcg, SUM(salida_inventario.hcv) as hcv, SUM(salida_inventario.hemograma) as hemograma, SUM(salida_inventario.hiv) as hiv,");
                sbQuery.Append(" SUM(salida_inventario.pcr) as pcr, SUM(salida_inventario.proteinas_totales) as proteinas_totales, SUM(salida_inventario.psa) as psa, SUM(salida_inventario.pt) as pt,");
                sbQuery.Append(" SUM(salida_inventario.ptt) as ptt, SUM(salida_inventario.tg) as tg, SUM(salida_inventario.tgo) as tgo, SUM(salida_inventario.tipificacion) as tipificacion,");
                sbQuery.Append(" SUM(salida_inventario.trigliceridos) as trigliceridos, SUM(salida_inventario.urea) as urea, SUM(salida_inventario.urocultivo) as urocultivo, ");
                sbQuery.Append(" SUM(salida_inventario.variantedu) as variantedu, SUM(salida_inventario.vdrl) as vdrl, pacientes.nombre as nombrepaciente, pacientes.nss, pacientes.record, ");
                sbQuery.Append(" SUM(salida_inventario.otros) as otros");
                sbQuery.Append(" FROM salida_inventario ");
                sbQuery.Append(" INNER JOIN pacientes ON pacientes.idpacientes = salida_inventario.idpaciente");
                sbQuery.Append(cWhere);
                sbQuery.Append(" GROUP BY salida_inventario.idpaciente");

                // Paso los valores de sbQuery al CommandText
                myCommand.CommandText = sbQuery.ToString();
                // Creo el objeto Data Adapter y ejecuto el command en el
                myAdapter = new MySqlDataAdapter(myCommand);
                // Creo el objeto Data Table
                DataTable dtMovimientoInventario = new DataTable();
                // Lleno el data adapter
                myAdapter.Fill(dtMovimientoInventario);
                // Cierro el objeto conexion
                myConexion.Close();

                // Verifico cantidad de datos encontrados
                int nRegistro = dtMovimientoInventario.Rows.Count;
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
                    cTitulo = "ESTADISTICAS DE EXAMENES MEDICOS POR FECHA";

                    //6to Instanciamos nuestro REPORTE
                    //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                    rptExamenesMedicos orptExamenesMedicos = new rptExamenesMedicos();

                    //pasamos el nombre del TITULO del Listado
                    //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                    // oListado.SummaryInfo.ReportTitle = cTitulo;
                    orptExamenesMedicos.SummaryInfo.ReportTitle = cTitulo;

                    //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                    frmPrinter ofrmPrinter = new frmPrinter(dtMovimientoInventario, orptExamenesMedicos, cTitulo);

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
