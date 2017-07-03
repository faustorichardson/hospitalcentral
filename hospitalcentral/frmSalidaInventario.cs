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
    public partial class frmSalidaInventario : frmBase
    {

        int gCodigo = 0;
        string cModo = "Inicio";
        decimal sumaTotal;
        decimal subTotal;
        decimal total;
        decimal monto;
        double itbi = 1.18;
        int selectedRow = 0;
        int countFilas = 0;
        //int addInventario;
        //int delInventario;
        int cantExistencia;


        public frmSalidaInventario()
        {
            InitializeComponent();
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            picBox.Image = Properties.Resources.Image_capture_128x128;
            this.Limpiar();
            this.LimpiarTxtGrid();
            this.cModo = "Inicio";
            this.Botones();
            this.fillCmbCategoria();
            this.chkHemograma.Checked = false;
            this.chkGlicemia.Checked = false;
            this.chkUrea.Checked = false;
            this.chkCreatinina.Checked = false;
            this.chkTgo.Checked = false;
            this.chkTg.Checked = false;
            this.chkVdrl.Checked = false;
            this.chkHiv.Checked = false;
            this.chkHbsAg.Checked = false;
            this.chkHcv.Checked = false;
            this.chkTipificacion.Checked = false;
            this.chkPsa.Checked = false;
            this.chkFalcemia.Checked = false;
            this.chkElectrolitos.Checked = false;
            this.chkProteinasTotales.Checked = false;
            this.chkAlbumina.Checked = false;
            this.chkPt.Checked = false;
            this.chkPtt.Checked = false;
            this.chkExOrina.Checked = false;
            this.chkColesterol.Checked = false;
            this.chkTrigliceridos.Checked = false;
            this.chkColesterolHdl.Checked = false;
            this.chkAcidoUrico.Checked = false;
            this.chkAmilasa.Checked = false;
            this.chkBilirrubina.Checked = false;
            this.chkChiamycia.Checked = false;
            this.chkSemen.Checked = false;
            this.chkSecresionUretral.Checked = false;
            this.chkUrocultivo.Checked = false;
            this.chkFalcalina.Checked = false;
            this.chkAso.Checked = false;
            this.chkPcr.Checked = false;
            this.chkFr.Checked = false;
            this.chkHcg.Checked = false;
            this.chkTestCoombDirect.Checked = false;
            this.chkTestCoombIndirect.Checked = false;
            this.chkVarianteDu.Checked = false;
            this.chkEritroSedimentacion.Checked = false;
        }

        private void fillCmbCategoria()
        {
            try
            {
                // Step 1 
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2
                MyConexion.Open();

                // Step 3
                MySqlCommand MyCommand = new MySqlCommand("SELECT idcategoria, categoria FROM categorias ORDER BY categoria ASC", MyConexion);

                // Step 4
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();

                // Step 5
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add("idcategoria", typeof(int));
                MyDataTable.Columns.Add("categoria", typeof(string));
                MyDataTable.Load(MyReader);

                // Step 6
                cmbCategoria.ValueMember = "idcategoria";
                cmbCategoria.DisplayMember = "categoria";
                cmbCategoria.DataSource = MyDataTable;

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
                MyCommand.CommandText = "SELECT count(*) FROM salida_inventario";

                // Step 4 - Open connection
                MyConexion.Open();

                // Step 5 - Execute the SQL Statement y Asigno el valor resultante a la variable "codigo"
                int codigo;
                codigo = Convert.ToInt32(MyCommand.ExecuteScalar());
                codigo = codigo + 1;
                txtID.Text = Convert.ToString(codigo);

                // Actualizo el Codigo Global
                gCodigo = codigo;

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
                    txtID.Enabled = false;
                    txtIDCliente.Enabled = false;
                    txtCliente.Enabled = false;
                    btnBuscar.Enabled = false;
                    dtFecha.Enabled = false;
                    btnBuscarProducto.Enabled = false;
                    btnBuscarSuplidor.Enabled = false;
                    btnAddGrid.Enabled = false;
                    btnDeleteGrid.Enabled = false;
                    //txtTipo.Enabled = false;
                    //txtPrecioProducto.Enabled = false;
                    txtCantidad.Enabled = false;
                    dtgEntradaInventario.Enabled = false;
                    rbAccionCivica.Enabled = false;
                    rbSenasa.Enabled = false;
                    // Examen Medico
                    this.chkHemograma.Enabled = false;
                    this.chkGlicemia.Enabled = false;
                    this.chkUrea.Enabled = false;
                    this.chkCreatinina.Enabled = false;
                    this.chkTgo.Enabled = false;
                    this.chkTg.Enabled = false;
                    this.chkVdrl.Enabled = false;
                    this.chkHiv.Enabled = false;
                    this.chkHbsAg.Enabled = false;
                    this.chkHcv.Enabled = false;
                    this.chkTipificacion.Enabled = false;
                    this.chkPsa.Enabled = false;
                    this.chkFalcemia.Enabled = false;
                    this.chkElectrolitos.Enabled = false;
                    this.chkProteinasTotales.Enabled = false;
                    this.chkAlbumina.Enabled = false;
                    this.chkPt.Enabled = false;
                    this.chkPtt.Enabled = false;
                    this.chkExOrina.Enabled = false;
                    this.chkColesterol.Enabled = false;
                    this.chkTrigliceridos.Enabled = false;
                    this.chkColesterolHdl.Enabled = false;
                    this.chkAcidoUrico.Enabled = false;
                    this.chkAmilasa.Enabled = false;
                    this.chkBilirrubina.Enabled = false;
                    this.chkChiamycia.Enabled = false;
                    this.chkSemen.Enabled = false;
                    this.chkSecresionUretral.Enabled = false;
                    this.chkUrocultivo.Enabled = false;
                    this.chkFalcalina.Enabled = false;
                    this.chkAso.Enabled = false;
                    this.chkPcr.Enabled = false;
                    this.chkFr.Enabled = false;
                    this.chkHcg.Enabled = false;
                    this.chkTestCoombDirect.Enabled = false;
                    this.chkTestCoombIndirect.Enabled = false;
                    this.chkVarianteDu.Enabled = false;
                    this.chkEritroSedimentacion.Enabled = false;
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
                    txtIDCliente.Enabled = false;
                    txtCliente.Enabled = false;
                    btnBuscar.Enabled = true;
                    dtFecha.Enabled = true;
                    btnBuscarProducto.Enabled = true;
                    btnBuscarSuplidor.Enabled = true;
                    btnAddGrid.Enabled = true;
                    btnDeleteGrid.Enabled = true;
                    //txtTipo.Enabled = true;
                    //txtPrecioProducto.Enabled = true;
                    txtCantidad.Enabled = true;
                    dtgEntradaInventario.Enabled = true;
                    rbAccionCivica.Enabled = true;
                    rbSenasa.Enabled = true;
                    // Examen Medico
                    this.chkHemograma.Enabled = true;
                    this.chkGlicemia.Enabled = true;
                    this.chkUrea.Enabled = true;
                    this.chkCreatinina.Enabled = true;
                    this.chkTgo.Enabled = true;
                    this.chkTg.Enabled = true;
                    this.chkVdrl.Enabled = true;
                    this.chkHiv.Enabled = true;
                    this.chkHbsAg.Enabled = true;
                    this.chkHcv.Enabled = true;
                    this.chkTipificacion.Enabled = true;
                    this.chkPsa.Enabled = true;
                    this.chkFalcemia.Enabled = true;
                    this.chkElectrolitos.Enabled = true;
                    this.chkProteinasTotales.Enabled = true;
                    this.chkAlbumina.Enabled = true;
                    this.chkPt.Enabled = true;
                    this.chkPtt.Enabled = true;
                    this.chkExOrina.Enabled = true;
                    this.chkColesterol.Enabled = true;
                    this.chkTrigliceridos.Enabled = true;
                    this.chkColesterolHdl.Enabled = true;
                    this.chkAcidoUrico.Enabled = true;
                    this.chkAmilasa.Enabled = true;
                    this.chkBilirrubina.Enabled = true;
                    this.chkChiamycia.Enabled = true;
                    this.chkSemen.Enabled = true;
                    this.chkSecresionUretral.Enabled = true;
                    this.chkUrocultivo.Enabled = true;
                    this.chkFalcalina.Enabled = true;
                    this.chkAso.Enabled = true;
                    this.chkPcr.Enabled = true;
                    this.chkFr.Enabled = true;
                    this.chkHcg.Enabled = true;
                    this.chkTestCoombDirect.Enabled = true;
                    this.chkTestCoombIndirect.Enabled = true;
                    this.chkVarianteDu.Enabled = true;
                    this.chkEritroSedimentacion.Enabled = true;                    
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
                    txtID.Enabled = false;
                    txtIDCliente.Enabled = false;
                    txtCliente.Enabled = false;
                    btnBuscar.Enabled = false;
                    dtFecha.Enabled = false;
                    btnBuscarProducto.Enabled = false;
                    btnBuscarSuplidor.Enabled = false;
                    btnAddGrid.Enabled = false;
                    btnDeleteGrid.Enabled = false;
                    //txtTipo.Enabled = false;
                    //txtPrecioProducto.Enabled = false;
                    txtCantidad.Enabled = false;
                    dtgEntradaInventario.Enabled = false;
                    rbAccionCivica.Enabled = false;
                    rbSenasa.Enabled = false;
                    // Examen Medico
                    this.chkHemograma.Enabled = false;
                    this.chkGlicemia.Enabled = false;
                    this.chkUrea.Enabled = false;
                    this.chkCreatinina.Enabled = false;
                    this.chkTgo.Enabled = false;
                    this.chkTg.Enabled = false;
                    this.chkVdrl.Enabled = false;
                    this.chkHiv.Enabled = false;
                    this.chkHbsAg.Enabled = false;
                    this.chkHcv.Enabled = false;
                    this.chkTipificacion.Enabled = false;
                    this.chkPsa.Enabled = false;
                    this.chkFalcemia.Enabled = false;
                    this.chkElectrolitos.Enabled = false;
                    this.chkProteinasTotales.Enabled = false;
                    this.chkAlbumina.Enabled = false;
                    this.chkPt.Enabled = false;
                    this.chkPtt.Enabled = false;
                    this.chkExOrina.Enabled = false;
                    this.chkColesterol.Enabled = false;
                    this.chkTrigliceridos.Enabled = false;
                    this.chkColesterolHdl.Enabled = false;
                    this.chkAcidoUrico.Enabled = false;
                    this.chkAmilasa.Enabled = false;
                    this.chkBilirrubina.Enabled = false;
                    this.chkChiamycia.Enabled = false;
                    this.chkSemen.Enabled = false;
                    this.chkSecresionUretral.Enabled = false;
                    this.chkUrocultivo.Enabled = false;
                    this.chkFalcalina.Enabled = false;
                    this.chkAso.Enabled = false;
                    this.chkPcr.Enabled = false;
                    this.chkFr.Enabled = false;
                    this.chkHcg.Enabled = false;
                    this.chkTestCoombDirect.Enabled = false;
                    this.chkTestCoombIndirect.Enabled = false;
                    this.chkVarianteDu.Enabled = false;
                    this.chkEritroSedimentacion.Enabled = false;                    
                    break;

                case "Editar":
                //this.btnNuevo.Enabled = false;
                //this.btnGrabar.Enabled = true;
                //this.btnEditar.Enabled = false;
                //this.btnBuscar.Enabled = false;
                //this.btnImprimir.Enabled = false;
                //this.btnEliminar.Enabled = true;
                //this.btnCancelar.Enabled = true;
                ////
                //txtID.Enabled = true;
                //txtIDSuplidor.Enabled = true;
                //txtSuplidor.Enabled = true;
                //btnBuscar.Enabled = true;
                //dtFecha.Enabled = true;
                //btnBuscarProducto.Enabled = true;
                //btnBuscarSuplidor.Enabled = true;
                //btnAddGrid.Enabled = true;
                //btnDeleteGrid.Enabled = true;
                //txtTipo.Enabled = true;
                //txtPrecioProducto.Enabled = true;
                //txtCantidad.Enabled = true;
                //dtgEntradaInventario.Enabled = true;
                //break;

                case "Buscar":
                //this.btnNuevo.Enabled = true;
                //this.btnGrabar.Enabled = false;
                //this.btnEditar.Enabled = true;
                //this.btnBuscar.Enabled = true;
                //this.btnImprimir.Enabled = true;
                //this.btnEliminar.Enabled = false;
                //this.btnCancelar.Enabled = false;
                //this.btnSalir.Enabled = true;
                ////
                //txtID.Enabled = false;
                //txtIDSuplidor.Enabled = false;
                //txtSuplidor.Enabled = false;
                //btnBuscar.Enabled = false;
                //dtFecha.Enabled = false;
                //btnBuscarProducto.Enabled = false;
                //btnAddGrid.Enabled = false;
                //btnDeleteGrid.Enabled = false;
                //txtTipo.Enabled = false;
                //txtPrecioProducto.Enabled = false;
                //txtCantidad.Enabled = false;
                //dtgEntradaInventario.Enabled = false;
                //break;

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

        private void Limpiar()
        {
            picBox.Image = Properties.Resources.Image_capture_128x128;
            txtID.Clear();
            txtIDCliente.Clear();
            txtCliente.Clear();
            dtgEntradaInventario.Rows.Clear();
            //lblSumaTotal.Text = "0.00";
            //lblTotal.Text = "0.00";
            cantExistencia = 0;
            sumaTotal = 0;
            subTotal = 0;
            monto = 0;
            countFilas = 0;
            this.txtOtros.Clear();
        }

        // Funcion que convierte un valor decimal a texto para graficarlo en un textbox
        public static string GetCurrencyFormat(decimal myValue)
        {
            return string.Format("{0:#,###0.00}", myValue);
        }

        // Funcion que convierte el decimal de un textbox para salvarlo a la base de datos
        public static decimal ParseCurrencyFormat(string myValue)
        {
            return decimal.Parse(myValue, System.Globalization.NumberStyles.Currency);
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.cModo = "Nuevo";
            this.Limpiar();
            this.LimpiarTxtGrid();
            this.Botones();
            this.ProximoCodigo();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtIDCliente.Text == "" || countFilas <= 0)
            {
                MessageBox.Show("No se permiten campos vacios...");
                txtCantidad.Focus();
            }
            else
            {
                if (countFilas > 0)
                {
                    if (cModo == "Nuevo")
                    {
                        // Verifico nuevamente el siguiente codigo antes de guardar
                        this.ProximoCodigo();

                        try
                        {
                            // Step 1 - Stablishing the connection
                            MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                            // Step 2 - Crear el comando de ejecucion
                            MySqlCommand myCommand = MyConexion.CreateCommand();

                            // Step 3 - Comando a ejecutar
                            myCommand.CommandText = "INSERT INTO salida_inventario(idpaciente, fecha, nss, tipoaccion, "+
                            " hemograma, glicemia, urea, creatinina, tgo, tg, vdrl, hiv, hbsag, hcv, tipificacion, psa, falcemia,"+
                            " electrolitos_sericos, proteinas_totales, albumina, pt, ptt, exorina, colesterol, trigliceridos, "+
                            " colesterolhdl, acidourico, amilasa, bilirrubina, chiamycia, cultivosemen, cultivosecrecionuretral, "+
                            " urocultivo, falcalina, aso, pcr, fr, hcg, coombdirect, coombindirect, variantedu, eritrosedimentacion, otros, fecharegistrada)" +
                                " values(@idpaciente, @fecha, @nss, @tipoaccion, "+
                            " @hemograma, @glicemia, @urea, @creatinina, @tgo, @tg, @vdrl, @hiv, @hbsag, @hcv, @tipificacion, @psa, @falcemia,"+
                            " @electrolitos_sericos, @proteinas_totales, @albumina, @pt, @ptt, @exorina, @colesterol, @trigliceridos, "+
                            " @colesterolhdl, @acidourico, @amilasa, @bilirrubina, @chiamycia, @cultivosemen, @cultivosecrecionuretral,"+
                            " @urocultivo, @falcalina, @aso, @pcr, @fr, @hcg, @coombdirect, @coombindirect, @variantedu, @eritrosedimentacion, @otros, NOW())";
                            
                            myCommand.Parameters.AddWithValue("@idpaciente", txtIDCliente.Text);
                            myCommand.Parameters.AddWithValue("@fecha", dtFecha.Value);
                            myCommand.Parameters.AddWithValue("@nss", txtNSS.Text);

                            if (rbSenasa.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@tipoaccion", "S");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@tipoaccion", "A");
                            }                            

                            if(chkHemograma.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@hemograma", "1");
                            } else{
                                myCommand.Parameters.AddWithValue("@hemograma", "0");
                            }

                            if (chkGlicemia.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@glicemia", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@glicemia", "0");
                            }

                            if (chkUrea.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@urea", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@urea", "0");
                            }

                            if (chkCreatinina.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@creatinina", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@creatinina", "0");
                            }

                            if (chkTgo.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@tgo", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@tgo", "0");
                            }

                            if (chkTg.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@tg", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@tg", "0");
                            }

                            if (chkVdrl.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@vdrl", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@vdrl", "0");
                            }

                            if (chkHiv.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@hiv", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@hiv", "0");
                            }

                            if (chkHbsAg.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@hbsag", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@hbsag", "0");
                            }

                            if (chkHcv.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@hcv", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@hcv", "0");
                            }

                            if (chkTipificacion.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@tipificacion", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@tipificacion", "0");
                            }

                            if (chkPsa.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@psa", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@psa", "0");
                            }

                            if (chkFalcemia.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@falcemia", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@falcemia", "0");
                            }

                            if (chkElectrolitos.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@electrolitos_sericos", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@electrolitos_sericos", "0");
                            }

                            if (chkProteinasTotales.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@proteinas_totales", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@proteinas_totales", "0");
                            }

                            if (chkAlbumina.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@albumina", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@albumina", "0");
                            }

                            if (chkPt.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@pt", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@pt", "0");
                            }

                            if (chkPtt.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@ptt", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@ptt", "0");
                            }

                            if (chkExOrina.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@exorina", "1");
                            }
                            else 
                            {
                                myCommand.Parameters.AddWithValue("@exorina", "0");
                            }

                            if (chkColesterol.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@colesterol", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@colesterol", "0");
                            }

                            if (chkTrigliceridos.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@trigliceridos", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@trigliceridos", "0");
                            }

                            if (chkColesterolHdl.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@colesterolhdl", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@colesterolhdl", "0");
                            }

                            if (chkAcidoUrico.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@acidourico", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@acidourico", "0");
                            }

                            if (chkAmilasa.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@amilasa", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@amilasa", "0");
                            }

                            if (chkBilirrubina.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@bilirrubina", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@bilirrubina", "0");
                            }

                            if (chkChiamycia.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@chiamycia", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@chiamycia", "0");
                            }

                            if (chkSemen.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@cultivosemen", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@cultivosemen", "0");
                            }

                            if (chkSecresionUretral.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@cultivosecrecionuretral", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@cultivosecrecionuretral", "0");
                            }

                            if (chkUrocultivo.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@urocultivo", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@urocultivo", "0");
                            }

                            if (chkFalcalina.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@falcalina", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@falcalina", "0");
                            }

                            if (chkAso.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@aso", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@aso", "0");
                            }

                            if (chkPcr.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@pcr", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@pcr", "0");
                            }

                            if (chkFr.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@fr", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@fr", "0");
                            }

                            if (chkHcg.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@hcg", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@hcg", "0");
                            }

                            if (chkTestCoombDirect.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@coombdirect", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@coombdirect", "0");
                            }

                            if (chkTestCoombIndirect.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@coombindirect", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@coombindirect", "0");
                            }

                            if (chkVarianteDu.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@variantedu", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@variantedu", "0");
                            }

                            if (chkEritroSedimentacion.Checked == true)
                            {
                                myCommand.Parameters.AddWithValue("@eritrosedimentacion", "1");
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@eritrosedimentacion", "0");
                            }

                            myCommand.Parameters.AddWithValue("@otros", txtOtros.Text);

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

                        // Llamo funcion que guarda data del grid
                        this.saveGrid();

                    }

                    // llamo la funcion para imprimir entrada.-
                    //this.ImprimeSolicitud();

                    // cuando termino de imprimir
                    this.Limpiar();
                    this.LimpiarTxtGrid();
                    this.cModo = "Inicio";
                    this.Botones();
                }
                else
                {
                    MessageBox.Show("No se puede grabar si no ha agregado algun producto...");
                    this.btnBuscarProducto.Focus();
                }
            }
        }

        private void ImprimeSolicitud()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("No se puede generar una impresion de facturacion de inventario sin el codigo...");
                this.txtID.Focus();
            }
            else
            {
                try
                {
                    // private void ImprimeSolicitud()
                    {
                        DialogResult Result =
                        MessageBox.Show("Imprima la Facturacion" + System.Environment.NewLine + "Desea Imprimir el despacho de materiales", "Sistema de Gestion Medica", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                        switch (Result)
                        {
                            case DialogResult.Yes:
                                GenerarReporte();
                                break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
        }

        private void GenerarReporte()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("No se permite generar el reporte sin su debida numeracion...");
                txtCantidad.Focus();
            }
            else
            {

                //clsConexion a la base de datos
                MySqlConnection myclsConexion = new MySqlConnection(clsConexion.ConectionString);
                // Creando el command que ejecutare
                MySqlCommand myCommand = new MySqlCommand();
                // Creando el Data Adapter
                MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                // Creando el String Builder
                StringBuilder sbQuery = new StringBuilder();
                // Otras variables del entorno
                string cWhere = " WHERE 1 = 1";
                string cUsuario = frmLogin.cUsuarioActual;
                string cTitulo = "";
                int cCodigo = Convert.ToInt32(txtID.Text);

                try
                {
                    // Abro clsConexion
                    myclsConexion.Open();
                    // Creo comando
                    myCommand = myclsConexion.CreateCommand();
                    // Adhiero el comando a la clsConexion
                    myCommand.Connection = myclsConexion;
                    // Filtros de la busqueda
                    //int cCodigoImprimir = Convert.ToInt32(txtIdLicencia.Text);
                    cWhere = cWhere + " AND facturacion.idfacturacion =" + cCodigo + "";
                    sbQuery.Clear();
                    sbQuery.Append("SELECT ");
                    sbQuery.Append(" salida_inventario.id, salida_inventario_detalle.idproducto,");
                    sbQuery.Append(" salida_inventario_detalle.producto, salida_inventario_detalle.tipo,");
                    sbQuery.Append(" salida_inventario_detalle.cantidad, salida_inventario.fecha, ");
                    sbQuery.Append(" pacientes.idpacientes, pacientes.nombre,");
                    sbQuery.Append(" pacientes.nss, pacientes.record, pacientes.cedula, pacientes.rango");
                    //sbQuery.Append(" ");
                    sbQuery.Append(" FROM salida_inventario");
                    sbQuery.Append(" INNER JOIN salida_inventario_detalle ON salida_inventario_detalle.id = salida_inventario.id");
                    sbQuery.Append(" INNER JOIN pacientes ON pacientes.idpacientes = salida_inventario.idpaciente");
                    //sbQuery.Append(" INNER JOIN provincias ON provincias.provincia_id = clientes.provincia");
                    sbQuery.Append(cWhere);

                    // Paso los valores de sbQuery al CommandText
                    myCommand.CommandText = sbQuery.ToString();
                    // Creo el objeto Data Adapter y ejecuto el command en el
                    myAdapter = new MySqlDataAdapter(myCommand);
                    // Creo el objeto Data Table
                    DataTable dtMovimientoInventario = new DataTable();
                    // Lleno el data adapter
                    myAdapter.Fill(dtMovimientoInventario);
                    // Cierro el objeto clsConexion
                    myclsConexion.Close();

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
                        cTitulo = "FACTURA DETALLE";

                        //6to Instanciamos nuestro REPORTE
                        //Reportes.ListadoDoctores oListado = new Reportes.ListadoDoctores();
                        rptFacturaDetalle orptFacturaDetalle = new rptFacturaDetalle();

                        //pasamos el nombre del TITULO del Listado
                        //SumaryInfo es un objeto que se utiliza para leer,crear y actualizar las propiedades del reporte
                        // oListado.SummaryInfo.ReportTitle = cTitulo;
                        orptFacturaDetalle.SummaryInfo.ReportTitle = cTitulo;

                        //7mo. instanciamos nuestro el FORMULARIO donde esta nuestro ReportViewer
                        frmPrinter ofrmPrinter = new frmPrinter(dtMovimientoInventario, orptFacturaDetalle, cTitulo);

                        //ParameterFieldInfo Obtiene o establece la colección de campos de parámetros.
                        ofrmPrinter.CrystalReportViewer1.ParameterFieldInfo = oParametrosCR;
                        ofrmPrinter.ShowDialog();
                    }
                }
                catch (Exception myEx)
                {
                    MessageBox.Show("Error : " + myEx.Message, "Mostrando Reporte", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    clsExceptionLog.LogError(myEx, false);
                    return;
                }
            }
        }

        private void saveGrid()
        {
            try
            {
                // Configuro la conexion
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Abro conexion
                MyConexion.Open();

                // Creo bucle de guardar informacion del grid
                for (int row = 0; row < countFilas; row++)
                {
                    MySqlCommand myCommand = new MySqlCommand("INSERT INTO salida_inventario_detalle(id, idproducto, producto, cantidad)" +
                        " values (@id, @idproducto, @producto, @cantidad)", MyConexion);
                    myCommand.Parameters.AddWithValue("@id", gCodigo);
                    myCommand.Parameters.AddWithValue("@idproducto", dtgEntradaInventario.Rows[row].Cells[0].Value);
                    myCommand.Parameters.AddWithValue("@producto", dtgEntradaInventario.Rows[row].Cells[1].Value);
                    myCommand.Parameters.AddWithValue("@cantidad", dtgEntradaInventario.Rows[row].Cells[2].Value);
                    //myCommand.Parameters.AddWithValue("@tipo", dtgEntradaInventario.Rows[row].Cells[2].Value);
                    //myCommand.Parameters.AddWithValue("@precio", dtgEntradaInventario.Rows[row].Cells[3].Value);
                    //myCommand.Parameters.AddWithValue("@cantidad", dtgEntradaInventario.Rows[row].Cells[4].Value);
                    //myCommand.Parameters.AddWithValue("@subtotal", dtgEntradaInventario.Rows[row].Cells[5].Value);

                    //// Cambio el valor del grid a decimal
                    //string myValue_precio = Convert.ToString(dtgEntradaInventario.Rows[row].Cells[3].Value);
                    //decimal myValueMonto_precio = clsFunctions.ParseCurrencyFormat(myValue_precio);
                    //myCommand.Parameters.AddWithValue("@precio", myValueMonto_precio);
                    ////myCommand.Parameters.AddWithValue("@precio", dtgEntradaInventario.Rows[row].Cells[3].Value);
                    //myCommand.Parameters.AddWithValue("@cantidad", dtgEntradaInventario.Rows[row].Cells[4].Value);

                    //string myValue_subtotal = Convert.ToString(dtgEntradaInventario.Rows[row].Cells[5].Value);
                    //decimal myValueMonto_subtotal = clsFunctions.ParseCurrencyFormat(myValue_subtotal);
                    //myCommand.Parameters.AddWithValue("@subtotal", myValueMonto_subtotal);
                    
                    // EJECUTO EL COMANDO
                    myCommand.ExecuteNonQuery();
                }

                dtgEntradaInventario.Rows.Clear();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
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
            frmPrintMaterialLaboratorio ofrmPrintMaterialLaboratorio = new frmPrintMaterialLaboratorio();
            ofrmPrintMaterialLaboratorio.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dtgEntradaInventario.Rows.Count > 0)
            {                
                MessageBox.Show("Debe eliminar primero los productos agregados...");             
            }
            else
            {
                this.cModo = "Inicio";
                this.Botones();
                this.Limpiar();
                this.LimpiarTxtGrid();
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (countFilas > 0)
            {
                MessageBox.Show("Debe eliminar primero los productos agregados...");
                //btnDeleteGrid.Focus();
            }
            else
            {
                this.Close();
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (txtIDCliente.Text == "" && txtNSS.Text == "" && txtCliente.Text == "")
            {
                MessageBox.Show("No se puede agregar material gastable de laboratorio sin antes buscar un paciente...");
                btnBuscarSuplidor.Focus();
            }
            else
            {
                //if (chkAcidoUrico.Checked == false || chkAlbumina.Checked == false || chkAmilasa.Checked == false ||
                //    chkAso.Checked == false || chkBilirrubina.Checked == false || chkChiamycia.Checked == false ||
                //    chkColesterol.Checked == false || chkColesterolHdl.Checked == false || chkCreatinina.Checked == false ||
                //    chkElectrolitos.Checked == false || chkEritroSedimentacion.Checked == false || chkExOrina.Checked == false ||
                //    chkFalcalina.Checked == false || chkFalcemia.Checked == false || chkFr.Checked == false || chkGlicemia.Checked == false ||
                //    chkHbsAg.Checked == false || chkHcg.Checked == false || chkHcv.Checked == false || chkHemograma.Checked == false ||
                //    chkHiv.Checked == false || chkPcr.Checked == false || chkProteinasTotales.Checked == false || chkPsa.Checked == false ||
                //    chkPt.Checked == false || chkPtt.Checked == false || chkSecresionUretral.Checked == false || chkSemen.Checked == false ||
                //    chkTestCoombDirect.Checked == false || chkTestCoombIndirect.Checked == false || chkTg.Checked == false ||
                //    chkTgo.Checked == false || chkTipificacion.Checked == false || chkTrigliceridos.Checked == false ||
                //    chkUrea.Checked == false || chkUrocultivo.Checked == false || chkVarianteDu.Checked == false ||
                //    chkVdrl.Checked == false)
                //{
                //    MessageBox.Show("No puede agregar un producto de laboratorio sin verificar el examen a realizar...");
                //    btnBuscarProducto.Focus();
                //}
                //else
                //{
                    frmBuscarProductos ofrmBuscarProductos = new frmBuscarProductos();
                    ofrmBuscarProductos.ShowDialog();
                    string cCodigo = ofrmBuscarProductos.cCodigo;

                    // Si selecciono un registro
                    if (cCodigo != "" && cCodigo != null)
                    {
                        // Mostrar el codigo                      
                        txtIDProducto.Text = Convert.ToString(cCodigo).Trim();
                        try
                        {
                            // Step 1 - clsConexion
                            MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                            // Step 2 - creating the command object
                            MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                            // Step 3 - creating the commandtext
                            //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;                                                
                            // verifico el tipo para filtrar en la base de datos
                            //if (txtTipoCliente.Text == "A")
                            //{
                            //    MyCommand.CommandText = "SELECT idproducto, producto, tipo, precio_a as precio, imagen from productos WHERE idproducto = '" + txtIDProducto.Text.Trim() + "'";
                            //}
                            //else
                            //{
                            //    MyCommand.CommandText = "SELECT idproducto, producto, tipo, precio_b as precio, imagen from productos WHERE idproducto = '" + txtIDProducto.Text.Trim() + "'";
                            //}
                            MyCommand.CommandText = "SELECT idproducto, producto, idcategoria, imagen from productos WHERE idproducto = '" + txtIDProducto.Text.Trim() + "'";

                            // Step 4 - connection open
                            MyclsConexion.Open();

                            // Step 5 - Creating the DataReader                    
                            MySqlDataReader MyReader = MyCommand.ExecuteReader();

                            // Step 6 - Verifying if Reader has rows
                            if (MyReader.HasRows)
                            {
                                while (MyReader.Read())
                                {
                                    txtIDProducto.Text = MyReader["idproducto"].ToString();
                                    txtProducto.Text = MyReader["producto"].ToString();
                                    cmbCategoria.SelectedValue = MyReader["idcategoria"].ToString();

                                    // Leyendo la imagen
                                    byte[] img = (byte[])(MyReader["imagen"]);

                                    if (img == null)
                                    {
                                        picBox.Image = null;
                                    }
                                    else
                                    {
                                        MemoryStream mstream = new MemoryStream(img);
                                        picBox.Image = System.Drawing.Image.FromStream(mstream);
                                    }
                                }
                                //this.cModo = "Buscar";
                                //this.Botones();
                                this.txtCantidad.Focus();
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron registros con este ID de Producto...", "Sistea de Gestion Medica", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //}
            }
        }

        private void btnAddGrid_Click(object sender, EventArgs e)
        {
            // VERIFICO QUE PRIMERO SE SELECCIONE UN SUPLIDOR
            if (txtIDCliente.Text == "" && txtNSS.Text == "")
            {
                MessageBox.Show("Antes de agregar productos debe de seleccionar el paciente...");
                this.btnBuscarSuplidor.Focus();
            }
            else if (txtIDProducto.Text == "")
            {
                MessageBox.Show("Antes de agregar productos debe de buscarlos...");
                this.btnBuscarProducto.Focus();
            }
            else
            {
                // BUSCAR INVENTARIO Y AGREGAR
                try
                {
                    // BUSCO INVENTARIO Y LO PASO A LA VARIABLE ADDINVENTARIO
                    this.searchExistencia();

                    // Verifico si la existencia es mayor o menos que la cantidad a facturar
                    if (cantExistencia > Convert.ToInt32(txtCantidad.Text))
                    {
                        // RESTO LA CANTIDAD LA CANTIDAD A LA VARIABLE ADDINVENTARIO
                        //this.addInventario = this.addInventario + Convert.ToInt32(txtCantidad.Text);
                        cantExistencia = cantExistencia - Convert.ToInt32(txtCantidad.Text);

                        // ACTUALIZO EL INVENTARIO
                        this.updateCantidad();


                        // ACTUALIZANDO LA VARIABLE Y EL LABEL DEL SUBTOTAL
                        try
                        {
                            // Creo la variable del tipo double "SUBTOTAL" para calcular el resultado de cantidad por precio
                            //subTotal = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecioProducto.Text);

                            // Registro la entrada al GRID
                            dtgEntradaInventario.Rows.Add(txtIDProducto.Text, txtProducto.Text, txtCantidad.Text);

                            // Realizo la operacion de sumar el subtotal mas la variable acumuladora sumatotal
                            //sumaTotal = sumaTotal + subTotal;

                            // Llamo la funcion para formatear el campo.-
                            //monto = Convert.ToDecimal(sumaTotal);
                            //lblSumaTotal.Text = clsFunctions.GetCurrencyFormat(monto);

                            // Agrego una fila al contador
                            countFilas = countFilas + 1;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            throw;
                        }

                        // ACTUALIZANDO LA VARIABLE Y EL LABEL DEL TOTAL + ITBIs
                        //if (chkITBI.Checked == true)
                        //{
                        //    total = sumaTotal;

                        //    lblTotal.Text = clsFunctions.GetCurrencyFormat(total);
                        //}
                        //else
                        //{
                        //    try
                        //    {
                        //        // Creo la variable del tipo double "TOTAL" para calcular el resultado de sumatotal por itbi
                        //        total = sumaTotal * Convert.ToDecimal(itbi);

                        //        // Formateo la variable TOTAL para llevarlo al label
                        //        lblTotal.Text = clsFunctions.GetCurrencyFormat(total);
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        MessageBox.Show(ex.Message);
                        //        throw;
                        //    }
                        //}

                        // DESPUES QUE AGREGO AL GRID Y ACTUALIZO EL INVENTARIO LIMPIO LOS CAMPOS
                        this.LimpiarTxtGrid();

                    }
                    else
                    {
                        MessageBox.Show("La cantidad a agregar es mayor que la cantidad en existencia...");
                        this.txtCantidad.Focus();
                    }                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }                

            }
            
        }

        private void btnDeleteGrid_Click(object sender, EventArgs e)
        {
            if (countFilas > 0)
            {
                if (txtIDProducto.Text != "" && txtCantidad.Text != "")
                {
                    // BUSCANDO Y ACTUALIZANDO LA EXISTENCIA EN LA TABLA INVENTARIO
                    try
                    {
                        // BUSCO INVENTARIO Y LO PASO A LA VARIABLE ADDINVENTARIO
                        this.searchExistencia();

                        // RESTO LA CANTIDAD A LA VARIABLE EXISTENCIA
                        cantExistencia = cantExistencia + Convert.ToInt32(txtCantidad.Text);

                        // ACTUALIZO EL INVENTARIO
                        this.updateCantidad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }

                    // RESTANDO EL SUBTOTAL A LA VARIABLE SUMATOTAL
                    try
                    {

                        //// Creo la variable del tipo double "SUBTOTAL" para calcular el resultado de cantidad por precio
                        //subTotal = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecioProducto.Text);

                        // selecciono el indice del registro en el grid
                        selectedRow = dtgEntradaInventario.CurrentCell.RowIndex;

                        // remuevo la linea que corresponde al indice
                        dtgEntradaInventario.Rows.RemoveAt(selectedRow);

                        // Actualizo la variable de las filas
                        countFilas = countFilas - 1;

                        //// Actualizo el monto
                        //sumaTotal = sumaTotal - subTotal;

                        //// Formateo la cifra
                        //lblSumaTotal.Text = clsFunctions.GetCurrencyFormat(sumaTotal);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }

                    // ACTUALIZANDO LA VARIABLE Y EL LABEL DEL SUBTOTAL + ITBIs
                    //if (chkITBI.Checked == true)
                    //{
                    //    total = sumaTotal;

                    //    lblTotal.Text = clsFunctions.GetCurrencyFormat(total);
                    //}
                    //else
                    //{
                    //    try
                    //    {
                    //        // Creo la variable del tipo double "TOTAL" para calcular el resultado de sumatotal por itbi
                    //        total = sumaTotal * Convert.ToDecimal(itbi);

                    //        // Formateo la variable TOTAL para llevarlo al label
                    //        lblTotal.Text = clsFunctions.GetCurrencyFormat(total);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        MessageBox.Show(ex.Message);
                    //        throw;
                    //    }
                    //}

                    // Limpiando los valores de los campos que llenan el grid
                    this.LimpiarTxtGrid();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el producto que desea remover...");
                    this.dtgEntradaInventario.Focus();
                }                
            }
            else
            {
                MessageBox.Show("No hay datos para eliminar o debe de seleccionar el producto...");
            }        
        }

        private void searchExistencia()
        {
            // Limpio variable existencia
            cantExistencia = 0;

            // BUSCO LA EXISTENCIA            
            try
            {
                // Step 1 - Conexion
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 
                MySqlCommand MyCommand = MyConexion.CreateCommand();

                // Step 3
                MyCommand.CommandText = "SELECT cantidad FROM inventario WHERE idproducto = " + txtIDProducto.Text + "";

                // Step 4
                MyConexion.Open();

                // Step 5
                //this.addInventario = Convert.ToInt32(MyCommand.ExecuteScalar());
                cantExistencia = Convert.ToInt32(MyCommand.ExecuteScalar());

                //if (myCantidad == 0)
                //{
                //    myCantidad = 0;
                //}
                // Step 6
                //this.txtDepartamento.Text = MyText;

                // Step 7
                MyConexion.Close();

            }
            catch (Exception MyEx)
            {
                MessageBox.Show(MyEx.Message);
            }
        }

        private void updateCantidad()
        {
            try
            {
                // Step 1 - Stablishing the connection
                MySqlConnection MyConexion = new MySqlConnection(clsConexion.ConectionString);

                // Step 2 - Crear el comando de ejecucion
                MySqlCommand myCommand = MyConexion.CreateCommand();

                // Step 3 - Comando a ejecutar
                myCommand.CommandText = "UPDATE inventario SET cantidad = @cantidad " +
                    " WHERE idproducto = " + txtIDProducto.Text + "";
                myCommand.Parameters.AddWithValue("@cantidad", cantExistencia);

                // Step 4 - Opening the connection
                MyConexion.Open();

                // Step 5 - Executing the query
                int nFilas = myCommand.ExecuteNonQuery();
                if (nFilas > 0)
                {
                    //MessageBox.Show("Existencia actualizada satisfactoriamente...");
                }
                else
                {
                    //MessageBox.Show("No fue actualizada la existencia...");
                }

                // Step 6 - Closing the connection
                MyConexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void LimpiarTxtGrid()
        {
            txtIDProducto.Clear();
            txtProducto.Clear();            
            txtCantidad.Clear();
        }

        private void btnBuscarSuplidor_Click(object sender, EventArgs e)
        {
            frmBuscarPacientes ofrmBuscarPacientes = new frmBuscarPacientes();
            ofrmBuscarPacientes.ShowDialog();            
            string cCodigo = ofrmBuscarPacientes.cCodigo;

            // Si selecciono un registro
            if (cCodigo != "" && cCodigo != null)
            {
                // Mostrar el codigo                      
                txtIDCliente.Text = Convert.ToString(cCodigo).Trim();
                try
                {
                    // Step 1 - clsConexion
                    MySqlConnection MyclsConexion = new MySqlConnection(clsConexion.ConectionString);

                    // Step 2 - creating the command object
                    MySqlCommand MyCommand = MyclsConexion.CreateCommand();

                    // Step 3 - creating the commandtext
                    //MyCommand.CommandText = "SELECT *  FROM paciente WHERE cedula = ' " + txtCedula.Text.Trim() + "'  " ;
                    MyCommand.CommandText = "SELECT nombre, nss from pacientes WHERE idpacientes = '" + txtIDCliente.Text + "'";

                    // Step 4 - connection open
                    MyclsConexion.Open();

                    // Step 5 - Creating the DataReader                    
                    MySqlDataReader MyReader = MyCommand.ExecuteReader();

                    // Step 6 - Verifying if Reader has rows
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {

                            txtCliente.Text = MyReader["nombre"].ToString();
                            txtNSS.Text = MyReader["nss"].ToString();
                            
                            // Verifica Forma de Facturacion
                            //this.verificaITBI();
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con este ID de Suplidor...", "Sistema de Gestion Medica", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //private void verificaITBI()
        //{
        //    if (txtID.Text != "" && txtIDCliente.Text != "")
        //    {
        //        DialogResult Result =
        //        MessageBox.Show("Tipo de facturacion..." + System.Environment.NewLine + "Desea Facturar con ITBIs incluido", "Sistema de Facturacion e Inventario", MessageBoxButtons.YesNo,
        //                MessageBoxIcon.Question);
        //        switch (Result)
        //        {
        //            case DialogResult.No:
        //                this.chkITBI.Checked = true;
        //                break;
        //        }
        //    }

        //}

        //private void txtPrecioProducto_Leave(object sender, EventArgs e)
        //{
        //    if (txtPrecioProducto.Text == "")
        //    {
        //        MessageBox.Show("No puede dejar la cantidad sin valor...");
        //        txtPrecioProducto.Focus();
        //    }
        //    else
        //    {
        //        // Llamo la funcion para formatear el campo.-
        //        decimal monto = Convert.ToDecimal(txtPrecioProducto.Text);
        //        txtPrecioProducto.Text = clsFunctions.GetCurrencyFormat(monto);
        //    }
        //}

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dtgEntradaInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                DataGridViewRow row = dtgEntradaInventario.Rows[selectedRow];
                // Lleno los campos
                txtIDProducto.Text = row.Cells[0].Value.ToString();
                txtProducto.Text = row.Cells[1].Value.ToString();
                //txtTipo.Text = row.Cells[2].Value.ToString();
                //txtPrecioProducto.Text = row.Cells[3].Value.ToString();
                txtCantidad.Text = row.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //private void chkITBI_Click(object sender, EventArgs e)
        //{
        //    if (chkITBI.Checked == true)
        //    {
        //        if (countFilas > 0)
        //        {
        //            MessageBox.Show("Para alterar la factura debe borrar los productos...");
        //        }
        //    }
        //    else
        //    {
        //        if (countFilas > 0)
        //        {
        //            MessageBox.Show("Para alterar la factura debe borrar los productos...");
        //            chkITBI.Checked = false;

        //        }
        //    }
        //}

    }
}
