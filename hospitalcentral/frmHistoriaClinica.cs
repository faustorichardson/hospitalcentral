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
    public partial class frmHistoriaClinica : frmBase
    {
        string cModo = "Inicio";

        public frmHistoriaClinica()
        {
            InitializeComponent();
        }

        private void frmHistoriaClinica_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            this.cModo = "Inicio";
            this.Botones();                        
        }

        private void Limpiar()
        {
            dtFecha.Refresh();
            txtID.Clear();
            txtHora.Clear();
            rbSenasa.Checked = true;
            rbAccionCivica.Checked = false;
            rbHombre.Checked = false;
            rbMujer.Checked = false;
            txtNSS.Clear();
            txtAntecedentesPatologicos.Clear();
            txtMotivoConsulta.Clear();
            rbAtencionesPreviasNo.Checked = true;
            rbAtencionesPreviasSi.Checked = false;
            txtAtencionesPrevias.Clear();
            rbAlergiasNo.Checked = false;
            rbAlergiasSi.Checked = true;
            txtAlergias.Clear();
            txtSignosVitales_TA.Clear();
            txtSignosVitales_FC.Clear();
            txtSignosVitales_FR.Clear();
            txtSignosVitales_Pulso.Clear();
            txtSignosVitales_Temperatura.Clear();
            txtHallazgosDescripcion.Clear();
            chkPruebasHemograma.Checked = false;
            chkPruebasOrina.Checked = false;
            chkPruebasGlicemia.Checked = false;
            chkPruebasEmbarazo.Checked = false;
            chkPruebasOtros.Checked = false;
            txtPruebasOtrosDescripcion.Clear();
            txtHallazgosPruebas.Clear();
            chkPruebasRadiografias.Checked = false;
            txtPruebasRadiografias.Clear();
            chkPruebasSonografias.Checked = false;
            txtPruebasSonografias.Clear();
            chkPruebasEkg.Checked = false;
            txtPruebasEkg.Clear();
            txtDiagnostico.Clear();
            txtEdad.Clear();
            txtNombrePaciente.Clear();
            chkEmergenciaInmovilizacion.Checked = false;
            chkEmergenciaNebulizaciones.Checked = false;
            chkEmergenciaOtros.Checked = false;
            chkEmergenciaReanimacion.Checked = false;
            chkEmergenciaSutura.Checked = false;
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
                MyCommand.CommandText = "SELECT count(*) FROM historiaclinica";

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
                    txtID.Enabled = true;
                    dtFecha.Enabled = false;
                    txtHora.Enabled = false;
                    rbSenasa.Enabled = false;
                    rbAccionCivica.Enabled = false;
                    rbHombre.Enabled = false;
                    rbMujer.Enabled = false;
                    txtNSS.Enabled = false;
                    txtAntecedentesPatologicos.Enabled = false;
                    txtMotivoConsulta.Enabled = false;
                    rbAtencionesPreviasNo.Enabled = false;
                    rbAtencionesPreviasSi.Enabled = false;
                    txtAtencionesPrevias.Enabled = false;
                    rbAlergiasNo.Enabled = false;
                    rbAlergiasSi.Enabled = false;
                    txtAlergias.Enabled = false;
                    txtSignosVitales_TA.Enabled = false;
                    txtSignosVitales_FC.Enabled = false;
                    txtSignosVitales_FR.Enabled = false;
                    txtSignosVitales_Pulso.Enabled = false;
                    txtSignosVitales_Temperatura.Enabled = false;
                    txtHallazgosDescripcion.Enabled = false;
                    chkPruebasHemograma.Enabled = false;
                    chkPruebasOrina.Enabled = false;
                    chkPruebasGlicemia.Enabled = false;
                    chkPruebasEmbarazo.Enabled = false;
                    chkPruebasOtros.Enabled = false;
                    txtPruebasOtrosDescripcion.Enabled = false;
                    txtHallazgosPruebas.Enabled = false;
                    chkPruebasRadiografias.Enabled = false;
                    txtPruebasRadiografias.Enabled = false;
                    chkPruebasSonografias.Enabled = false;
                    txtPruebasSonografias.Enabled = false;
                    chkPruebasEkg.Enabled = false;
                    txtPruebasEkg.Enabled = false;
                    txtDiagnostico.Enabled = false;
                    chkEmergenciaSutura.Enabled = false;
                    chkEmergenciaInmovilizacion.Enabled = false;
                    chkEmergenciaReanimacion.Enabled = false;
                    chkEmergenciaNebulizaciones.Enabled = false;
                    chkEmergenciaOtros.Enabled = false;
                    txtEmergenciaOtros.Enabled = false;
                    rbEstatusDDA.Enabled = false;
                    rbEstatusAAP.Enabled = false;
                    rbEstatusADM.Enabled = false;
                    rbEstatusREF.Enabled = false;
                    rbEstatusDEP.Enabled = false;                    
                    rbOrigenEnfGral.Enabled = false;
                    rbOrigenMaternidad.Enabled = false;
                    rbOrigenAccidenteTrabajo.Enabled = false;
                    rbOrigenAccidenteTransito.Enabled = false;
                    rbOrigenOtros.Enabled = false;
                    txtOrigenOtros.Enabled = false;
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
                    txtID.Enabled = false;                    
                    dtFecha.Enabled = true;
                    txtHora.Enabled = true;
                    rbSenasa.Enabled = true;
                    rbAccionCivica.Enabled = true;
                    rbHombre.Enabled = false;
                    rbMujer.Enabled = false;
                    txtNSS.Enabled = true;
                    txtAntecedentesPatologicos.Enabled = true;
                    txtMotivoConsulta.Enabled = true;
                    rbAtencionesPreviasNo.Enabled = true;
                    rbAtencionesPreviasSi.Enabled = true;
                    txtAtencionesPrevias.Enabled = true;
                     rbAlergiasNo.Enabled = true;
                    rbAlergiasSi.Enabled = true;
                    txtAlergias.Enabled = true;
                    txtSignosVitales_TA.Enabled = true;
                    txtSignosVitales_FC.Enabled = true;
                    txtSignosVitales_FR.Enabled = true;
                    txtSignosVitales_Pulso.Enabled = true;
                    txtSignosVitales_Temperatura.Enabled = true;
                    txtHallazgosDescripcion.Enabled = true;
                    chkPruebasHemograma.Enabled = true;
                    chkPruebasOrina.Enabled = true;
                    chkPruebasGlicemia.Enabled = true;
                    chkPruebasEmbarazo.Enabled = true;
                    chkPruebasOtros.Enabled = true;
                    txtPruebasOtrosDescripcion.Enabled = true;
                    txtHallazgosPruebas.Enabled = true;
                    chkPruebasRadiografias.Enabled = true;
                    txtPruebasRadiografias.Enabled = true;
                    chkPruebasSonografias.Enabled = true;
                    txtPruebasSonografias.Enabled = true;
                    chkPruebasEkg.Enabled = true;
                    txtPruebasEkg.Enabled = true;
                    txtDiagnostico.Enabled = true;
                    chkEmergenciaSutura.Enabled = true;
                    chkEmergenciaInmovilizacion.Enabled = true;
                    chkEmergenciaReanimacion.Enabled = true;
                    chkEmergenciaNebulizaciones.Enabled = true;
                    chkEmergenciaOtros.Enabled = true;
                    txtEmergenciaOtros.Enabled = true;
                    rbEstatusDDA.Enabled = true;
                    rbEstatusAAP.Enabled = true;
                    rbEstatusADM.Enabled = true;
                    rbEstatusREF.Enabled = true;
                    rbEstatusDEP.Enabled = true;                    
                    rbOrigenEnfGral.Enabled = true;
                    rbOrigenMaternidad.Enabled = true;
                    rbOrigenAccidenteTrabajo.Enabled = true;
                    rbOrigenAccidenteTransito.Enabled = true;
                    rbOrigenOtros.Enabled = true;
                    txtOrigenOtros.Enabled = true;
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
                    txtID.Enabled = true;
                    dtFecha.Enabled = false;
                    txtHora.Enabled = false;
                    rbSenasa.Enabled = false;
                    rbAccionCivica.Enabled = false;
                    rbHombre.Enabled = false;
                    rbMujer.Enabled = false;
                    txtNSS.Enabled = false;
                    txtAntecedentesPatologicos.Enabled = false;
                    txtMotivoConsulta.Enabled = false;
                    rbAtencionesPreviasNo.Enabled = false;
                    rbAtencionesPreviasSi.Enabled = false;
                    txtAtencionesPrevias.Enabled = false;
                    rbAlergiasNo.Enabled = false;
                    rbAlergiasSi.Enabled = false;
                    txtAlergias.Enabled = false;
                    txtSignosVitales_TA.Enabled = false;
                    txtSignosVitales_FC.Enabled = false;
                    txtSignosVitales_FR.Enabled = false;
                    txtSignosVitales_Pulso.Enabled = false;
                    txtSignosVitales_Temperatura.Enabled = false;
                    txtHallazgosDescripcion.Enabled = false;
                    chkPruebasHemograma.Enabled = false;
                    chkPruebasOrina.Enabled = false;
                    chkPruebasGlicemia.Enabled = false;
                    chkPruebasEmbarazo.Enabled = false;
                    chkPruebasOtros.Enabled = false;
                    txtPruebasOtrosDescripcion.Enabled = false;
                    txtHallazgosPruebas.Enabled = false;
                    chkPruebasRadiografias.Enabled = false;
                    txtPruebasRadiografias.Enabled = false;
                    chkPruebasSonografias.Enabled = false;
                    txtPruebasSonografias.Enabled = false;
                    chkPruebasEkg.Enabled = false;
                    txtPruebasEkg.Enabled = false;
                    txtDiagnostico.Enabled = false;
                    chkEmergenciaSutura.Enabled = false;
                    chkEmergenciaInmovilizacion.Enabled = false;
                    chkEmergenciaReanimacion.Enabled = false;
                    chkEmergenciaNebulizaciones.Enabled = false;
                    chkEmergenciaOtros.Enabled = false;
                    txtEmergenciaOtros.Enabled = false;
                    rbEstatusDDA.Enabled = false;
                    rbEstatusAAP.Enabled = false;
                    rbEstatusADM.Enabled = false;
                    rbEstatusREF.Enabled = false;
                    rbEstatusDEP.Enabled = false;                    
                    rbOrigenEnfGral.Enabled = false;
                    rbOrigenMaternidad.Enabled = false;
                    rbOrigenAccidenteTrabajo.Enabled = false;
                    rbOrigenAccidenteTransito.Enabled = false;
                    rbOrigenOtros.Enabled = false;
                    txtOrigenOtros.Enabled = false;
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
                    txtID.Enabled = false;                    
                    dtFecha.Enabled = true;
                    txtHora.Enabled = true;
                    rbSenasa.Enabled = true;
                    rbAccionCivica.Enabled = true;
                    rbHombre.Enabled = false;
                    rbMujer.Enabled = false;
                    txtNSS.Enabled = true;
                    txtAntecedentesPatologicos.Enabled = true;
                    txtMotivoConsulta.Enabled = true;
                    rbAtencionesPreviasNo.Enabled = true;
                    rbAtencionesPreviasSi.Enabled = true;
                    txtAtencionesPrevias.Enabled = true;
                     rbAlergiasNo.Enabled = true;
                    rbAlergiasSi.Enabled = true;
                    txtAlergias.Enabled = true;
                    txtSignosVitales_TA.Enabled = true;
                    txtSignosVitales_FC.Enabled = true;
                    txtSignosVitales_FR.Enabled = true;
                    txtSignosVitales_Pulso.Enabled = true;
                    txtSignosVitales_Temperatura.Enabled = true;
                    txtHallazgosDescripcion.Enabled = true;
                    chkPruebasHemograma.Enabled = true;
                    chkPruebasOrina.Enabled = true;
                    chkPruebasGlicemia.Enabled = true;
                    chkPruebasEmbarazo.Enabled = true;
                    chkPruebasOtros.Enabled = true;
                    txtPruebasOtrosDescripcion.Enabled = true;
                    txtHallazgosPruebas.Enabled = true;
                    chkPruebasRadiografias.Enabled = true;
                    txtPruebasRadiografias.Enabled = true;
                    chkPruebasSonografias.Enabled = true;
                    txtPruebasSonografias.Enabled = true;
                    chkPruebasEkg.Enabled = true;
                    txtPruebasEkg.Enabled = true;
                    txtDiagnostico.Enabled = true;
                    chkEmergenciaSutura.Enabled = true;
                    chkEmergenciaInmovilizacion.Enabled = true;
                    chkEmergenciaReanimacion.Enabled = true;
                    chkEmergenciaNebulizaciones.Enabled = true;
                    chkEmergenciaOtros.Enabled = true;
                    txtEmergenciaOtros.Enabled = true;
                    rbEstatusDDA.Enabled = true;
                    rbEstatusAAP.Enabled = true;
                    rbEstatusADM.Enabled = true;
                    rbEstatusREF.Enabled = true;
                    rbEstatusDEP.Enabled = true;                    
                    rbOrigenEnfGral.Enabled = true;
                    rbOrigenMaternidad.Enabled = true;
                    rbOrigenAccidenteTrabajo.Enabled = true;
                    rbOrigenAccidenteTransito.Enabled = true;
                    rbOrigenOtros.Enabled = true;
                    txtOrigenOtros.Enabled = true;
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
                    txtID.Enabled = true;
                    dtFecha.Enabled = false;
                    txtHora.Enabled = false;
                    rbSenasa.Enabled = false;
                    rbAccionCivica.Enabled = false;
                    rbHombre.Enabled = false;
                    rbMujer.Enabled = false;
                    txtNSS.Enabled = false;
                    txtAntecedentesPatologicos.Enabled = false;
                    txtMotivoConsulta.Enabled = false;
                    rbAtencionesPreviasNo.Enabled = false;
                    rbAtencionesPreviasSi.Enabled = false;
                    txtAtencionesPrevias.Enabled = false;
                    rbAlergiasNo.Enabled = false;
                    rbAlergiasSi.Enabled = false;
                    txtAlergias.Enabled = false;
                    txtSignosVitales_TA.Enabled = false;
                    txtSignosVitales_FC.Enabled = false;
                    txtSignosVitales_FR.Enabled = false;
                    txtSignosVitales_Pulso.Enabled = false;
                    txtSignosVitales_Temperatura.Enabled = false;
                    txtHallazgosDescripcion.Enabled = false;
                    chkPruebasHemograma.Enabled = false;
                    chkPruebasOrina.Enabled = false;
                    chkPruebasGlicemia.Enabled = false;
                    chkPruebasEmbarazo.Enabled = false;
                    chkPruebasOtros.Enabled = false;
                    txtPruebasOtrosDescripcion.Enabled = false;
                    txtHallazgosPruebas.Enabled = false;
                    chkPruebasRadiografias.Enabled = false;
                    txtPruebasRadiografias.Enabled = false;
                    chkPruebasSonografias.Enabled = false;
                    txtPruebasSonografias.Enabled = false;
                    chkPruebasEkg.Enabled = false;
                    txtPruebasEkg.Enabled = false;
                    txtDiagnostico.Enabled = false;
                    chkEmergenciaSutura.Enabled = false;
                    chkEmergenciaInmovilizacion.Enabled = false;
                    chkEmergenciaReanimacion.Enabled = false;
                    chkEmergenciaNebulizaciones.Enabled = false;
                    chkEmergenciaOtros.Enabled = false;
                    txtEmergenciaOtros.Enabled = false;
                    rbEstatusDDA.Enabled = false;
                    rbEstatusAAP.Enabled = false;
                    rbEstatusADM.Enabled = false;
                    rbEstatusREF.Enabled = false;
                    rbEstatusDEP.Enabled = false;                    
                    rbOrigenEnfGral.Enabled = false;
                    rbOrigenMaternidad.Enabled = false;
                    rbOrigenAccidenteTrabajo.Enabled = false;
                    rbOrigenAccidenteTransito.Enabled = false;
                    rbOrigenOtros.Enabled = false;
                    txtOrigenOtros.Enabled = false;
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
            this.txtNSS.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtNSS.Text == "" || txtNombrePaciente.Text == "" || txtHora.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtNSS.Focus();
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
                        myCommand.CommandText = "INSERT INTO historiaclinica("+
                            "nss, "+
                            "fecha, "+
                            "hora, "+
                            "tipoaccion," +
                            "motivoconsulta, "+
                            "antecedentespatologicos, "+
                            "atencionesprevias, "+
                            "atencionesprevias_descripcion, " +
                            " alergias, "+
                            "alergias_descripcion, "+
                            "signosvitales_ta, "+
                            "signosvitales_fr, "+
                            "signosvitales_fc," +
                            " signosvitales_pulso, "+
                            "signosvitales_temp, "+
                            "examenfisico, "+
                            "pruebas_hemograma, "+
                            "pruebas_orina," +
                            " pruebas_glicemia, "+
                            "pruebas_embarazo, "+
                            "pruebas_otras, "+
                            "pruebas_otras_descripcion, "+
                            "hallazgos_pruebas_positivas," +
                            " pruebas_radiografias, "+
                            "pruebas_radiografias_descripcion, "+
                            "pruebas_sonografias, "+
                            "pruebas_sonografias_descripcion," +
                            " pruebas_ekg, "+
                            "pruebas_ekg_descripcion, "+
                            "diagnostico, "+
                            "emergencia_sutura, "+
                            "emergencia_inmovilizacion," +
                            " emergencia_reanimacioncardiopulmonar, "+
                            "emergencia_nebulizaciones, "+
                            "emergencia_otros," +
                            " emergencia_otros_descripcion, "+
                            "estatus, "+
                            "estatus_descripcion, "+
                            "origen_enfermedad, "+
                            "origen_enfermedad_descripcion, " +
                            "origen_enfermedad_especifique"+                            
                            ")" +
                            " values("+
                            "@nss, "+
                            "@fecha, "+
                            "@hora, "+
                            "@tipoaccion," +
                            " @motivoconsulta, "+
                            "@antecedentespatologicos, "+
                            "@atencionesprevias, "+
                            "@atencionesprevias_descripcion," +
                            " @alergias, "+
                            "@alergias_descripcion, "+
                            "@signosvitales_ta, "+
                            "@signosvitales_fr, "+
                            "@signosvitales_fc," +
                            " @signosvitales_pulso, "+
                            "@signosvitales_temp, "+
                            "@examenfisico, "+
                            "@pruebas_hemograma, "+
                            "@pruebas_orina," +
                            " @pruebas_glicemia, "+
                            "@pruebas_embarazo, "+
                            "@pruebas_otras, "+
                            "@pruebas_otras_descripcion, "+
                            "@hallazgos_pruebas_positivas," +
                            " @pruebas_radiografias, "+
                            "@pruebas_radiografias_descripcion, "+
                            "@pruebas_sonografias, "+
                            "@pruebas_sonografias_descripcion," +
                            " @pruebas_ekg, "+
                            "@pruebas_ekg_descripcion, "+
                            "@diagnostico, "+
                            "@emergencia_sutura, "+
                            "@emergencia_inmovilizacion,"+
                            " @emergencia_reanimacioncardiopulmonar, "+
                            "@emergencia_nebulizaciones, "+
                            "@emergencia_otros,"+
                            " @emergencia_otros_descripcion, "+
                            "@estatus, "+
                            "@estatus_descripcion, "+
                            "@origen_enfermedad, "+
                            "@origen_enfermedad_descripcion, "+
                            "@origen_enfermedad_especifique"+
                        ")";

                        myCommand.Parameters.AddWithValue("@nss", txtNSS.Text);
                        myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                        myCommand.Parameters.AddWithValue("@hora", txtHora.Text);
                        
                        // TIPO ACCION = SENASA / ACCION CIVICA
                        if(rbSenasa.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@tipoaccion", "S");
                        } else {
                            myCommand.Parameters.AddWithValue("@tipoaccion", "A");
                        }
                        myCommand.Parameters.AddWithValue("@motivoconsulta", txtMotivoConsulta.Text);
                        myCommand.Parameters.AddWithValue("@antecedentespatologicos", txtAntecedentesPatologicos.Text);
                        
                        // ATENCIONES PREVIAS = SI / NO
                        if(rbAtencionesPreviasNo.Checked == true){
                            myCommand.Parameters.AddWithValue("@atencionesprevias", "NO");
                        } else{
                            myCommand.Parameters.AddWithValue("@atencionesprevias", "SI");
                        }
                        myCommand.Parameters.AddWithValue("@atencionesprevias_descripcion", txtAtencionesPrevias.Text);

                        // ALERGIAS = SI / NO
                        if(rbAlergiasNo.Checked == true){
                            myCommand.Parameters.AddWithValue("@alergias", "SI");
                        } else{
                            myCommand.Parameters.AddWithValue("@alergias", "NO");
                        }

                        myCommand.Parameters.AddWithValue("@alergias_descripcion", txtAlergias.Text);
                        myCommand.Parameters.AddWithValue("@signosvitales_ta", txtSignosVitales_TA.Text);
                        myCommand.Parameters.AddWithValue("@signosvitales_fr", txtSignosVitales_FR.Text);
                        myCommand.Parameters.AddWithValue("@signosvitales_fc", txtSignosVitales_FC.Text);
                        myCommand.Parameters.AddWithValue("@signosvitales_pulso", txtSignosVitales_Pulso.Text);
                        myCommand.Parameters.AddWithValue("@signosvitales_temp", txtSignosVitales_Temperatura.Text);
                        myCommand.Parameters.AddWithValue("@examenfisico", txtHallazgosDescripcion.Text);
                        
                        // Pruebas Hemograma
                        if(chkPruebasHemograma.Checked == true){
                            myCommand.Parameters.AddWithValue("@pruebas_hemograma", "SI");
                        } else{
                            myCommand.Parameters.AddWithValue("@pruebas_hemograma", "NO");
                        }

                        // Pruebas Orina
                        if(chkPruebasOrina.Checked == true){
                            myCommand.Parameters.AddWithValue("@pruebas_orina", "SI");
                        } else{
                            myCommand.Parameters.AddWithValue("@pruebas_orina", "NO");
                        }

                        // Pruebas Glicemia
                        if(chkPruebasHemograma.Checked == true){
                            myCommand.Parameters.AddWithValue("@pruebas_glicemia", "SI");
                        } else{
                            myCommand.Parameters.AddWithValue("@pruebas_glicemia", "NO");
                        }

                        // Pruebas Embarazo
                        if(chkPruebasEmbarazo.Checked == true){
                            myCommand.Parameters.AddWithValue("@pruebas_embarazo", "SI");
                        } else{
                            myCommand.Parameters.AddWithValue("@pruebas_embarazo", "NO");
                        }

                        // Pruebas Otras
                        if(chkPruebasOtros.Checked == true){
                            myCommand.Parameters.AddWithValue("@pruebas_otras", "SI");
                        } else{
                            myCommand.Parameters.AddWithValue("@pruebas_otras", "NO");
                        }

                        myCommand.Parameters.AddWithValue("@pruebas_otras_descripcion", txtPruebasOtrosDescripcion.Text);
                        myCommand.Parameters.AddWithValue("@hallazgos_pruebas_positivas", txtHallazgosPruebas.Text);

                        // PRUEBAS RADIOGRAFIAS = SI / NO
                        if(chkPruebasRadiografias.Checked == true){
                            myCommand.Parameters.AddWithValue("@pruebas_radiografias", "SI");
                        } else{
                            myCommand.Parameters.AddWithValue("@pruebas_radiografias", "NO");
                        }
                        myCommand.Parameters.AddWithValue("@pruebas_radiografias_descripcion", txtPruebasRadiografias.Text);

                        // PRUEAS SONOGRAFIAS = SI / NO
                        if(chkPruebasSonografias.Checked == true){
                            myCommand.Parameters.AddWithValue("@pruebas_sonografias", "SI");
                        } else{
                            myCommand.Parameters.AddWithValue("@pruebas_sonografias", "NO");
                        }
                        myCommand.Parameters.AddWithValue("@pruebas_sonografias_descripcion", txtPruebasSonografias.Text);

                        // PRUEBAS EKG = SI / NO
                        if(chkPruebasEkg.Checked == true){
                            myCommand.Parameters.AddWithValue("@pruebas_ekg", "SI");
                        } else{
                            myCommand.Parameters.AddWithValue("@pruebas_ekg", "NO");
                        }
                        myCommand.Parameters.AddWithValue("@pruebas_ekg_descripcion", txtPruebasEkg.Text);

                        myCommand.Parameters.AddWithValue("@diagnostico", txtDiagnostico.Text);

                        // EMERGENCIAS SUTURA = SI / NO
                        if (chkEmergenciaSutura.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@emergencia_sutura", "SI");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@emergencia_sutura", "NO");
                        }

                        // EMERGENCIAS INMOVILIZACION = SI / NO
                        if (chkEmergenciaInmovilizacion.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@emergencia_inmovilizacion", "SI");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@emergencia_inmovilizacion", "NO");
                        }

                        // EMERGENCIAS REANIMACION CARDIOPULMONAR = SI / NO
                        if (chkEmergenciaReanimacion.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@emergencia_reanimacioncardiopulmonar", "SI");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@emergencia_reanimacioncardiopulmonar", "NO");
                        }

                        // EMERGENCIAS NEBULIZACIONES = SI / NO
                        if (chkEmergenciaNebulizaciones.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@emergencia_nebulizaciones", "SI");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@emergencia_nebulizaciones", "NO");
                        }

                        // EMERGENCIAS OTROS = SI / NO
                        if (chkEmergenciaOtros.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@emergencia_otros", "SI");
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@emergencia_otros", "NO");
                        }
                        myCommand.Parameters.AddWithValue("@emergencia_otros_descripcion", txtEmergenciaOtros.Text);

                        if (rbEstatusDDA.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@estatus", "DDA");
                            myCommand.Parameters.AddWithValue("@estatus_descripcion", "Dado de Alta");
                        }
                        else if (rbEstatusAAP.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@estatus", "AAP");
                            myCommand.Parameters.AddWithValue("@estatus_descripcion", "Alta a Peticion");
                        }
                        else if (rbEstatusADM.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@estatus", "ADM");
                            myCommand.Parameters.AddWithValue("@estatus_descripcion", "Admitido");
                        }
                        else if (rbEstatusREF.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@estatus", "REF");
                            myCommand.Parameters.AddWithValue("@estatus_descripcion", "Referido");
                        }
                        else if (rbEstatusDEP.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@estatus", "EPD");
                            myCommand.Parameters.AddWithValue("@estatus_descripcion", "Fallecido");
                        }

                        // ORIGEN DE LA ENFERMEDAD
                        if (rbOrigenEnfGral.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@origen_enfermedad", "EG");
                            myCommand.Parameters.AddWithValue("@origen_enfermedad_descripcion", "Enfermedad General");
                        }
                        else if (rbOrigenMaternidad.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@origen_enfermedad", "MA");
                            myCommand.Parameters.AddWithValue("@origen_enfermedad_descripcion", "Maternidad");
                        }
                        else if (rbOrigenAccidenteTrabajo.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@origen_enfermedad", "AP");
                            myCommand.Parameters.AddWithValue("@origen_enfermedad_descripcion", "Accidente de Trabajo");
                        }
                        else if (rbOrigenAccidenteTransito.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@origen_enfermedad", "AT");
                            myCommand.Parameters.AddWithValue("@origen_enfermedad_descripcion", "Accidente de Transito");
                        }
                        else if (rbOrigenOtros.Checked == true)
                        {
                            myCommand.Parameters.AddWithValue("@origen_enfermedad", "OT");
                            myCommand.Parameters.AddWithValue("@origen_enfermedad_descripcion", "Otros");
                        }
                        myCommand.Parameters.AddWithValue("@origen_enfermedad_especifique", txtOrigenOtros.Text);

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
                //    try
                //    {
                //        // Step 1 - Stablishing the connection
                //        MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                //        // Step 2 - Crear el comando de ejecucion
                //        MySqlCommand myCommand = MyConexion.CreateCommand();

                //        // Step 3 - Comando a ejecutar
                //        myCommand.CommandText = "UPDATE entrada SET fecha = @fecha, unidadnaval = @unidadnaval, " +
                //            "tipo_comb = @tipocombustible, cantidad = @cantidad WHERE id = " + txtID.Text + "";
                //        myCommand.Parameters.AddWithValue("@fecha", dtFechaRecibido.Value);
                //        myCommand.Parameters.AddWithValue("@unidadnaval", cmbUnidadNaval.SelectedValue);
                //        myCommand.Parameters.AddWithValue("@tipocombustible", cmbCombustible.SelectedValue);
                //        myCommand.Parameters.AddWithValue("@cantidad", txtCantidad.Text);

                //        // Step 4 - Opening the connection
                //        MyConexion.Open();

                //        // Step 5 - Executing the query
                //        int nFilas = myCommand.ExecuteNonQuery();
                //        if (nFilas > 0)
                //        {
                //            MessageBox.Show("Informacion actualiada satisfactoriamente...");
                //        }
                //        else
                //        {
                //            MessageBox.Show("No fueron actualizadas las informaciones...");
                //        }

                //        // Step 6 - Closing the connection
                //        MyConexion.Close();

                //    }
                //    catch (Exception MyEx)
                //    {
                //        MessageBox.Show(MyEx.Message);
                //    }

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

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" || txtNSS.Text != "" || txtNombrePaciente.Text != "")
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

        // FUNCION QUE BUSCA LAS INFORMACIONES DEL PACIENTE
        private void BuscarNSS()
        {
            MessageBox.Show("Prueba");
        }

        private void txtNSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnBuscarNSS_Click(object sender, EventArgs e)
        {
            if (txtNSS.Text == "")
            {
                MessageBox.Show("Debe introducir un Numero de Seguro Social...");
                txtNSS.Focus();
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
                    MyCommand.CommandText = "SELECT nombre, sexo, fecha_nacimiento, antecedentes " +
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
                            // NOMBRE PACIENTE
                            txtNombrePaciente.Text = MyReader["nombre"].ToString();
                            
                            // GENERO
                            string genero = MyReader["sexo"].ToString();
                            if (genero == "M")
                            {
                                rbHombre.Checked = true;
                            }
                            else
                            {
                                rbMujer.Checked = true;
                            }
                            
                            // CALCULO DE LA EDAD DEL PACIENTE
                            DateTime fechaNacimiento = Convert.ToDateTime(MyReader["fecha_nacimiento"].ToString());
                            DateTime fechaHoy = DateTime.Today;
                            int EdadPaciente = fechaHoy.Year - fechaNacimiento.Year;
                            // Pongo el valor en el campo texto de la edad
                            txtEdad.Text = Convert.ToString(EdadPaciente);
                            
                            // ANTECEDENTES DEL PACIENTE
                            txtAntecedentesPatologicos.Text = MyReader["antecedentes"].ToString();
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
                        this.txtNSS.Focus();
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
    }
}
