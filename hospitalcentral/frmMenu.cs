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
        string permiso_mantenimiento = "0";        
        string permiso_mantenimiento_doctores = "0";
        string permiso_mantenimiento_pacientes = "0";
        string permiso_mantenimiento_usuarios = "0";
        string permiso_proceso = "0";
        string permiso_proceso_citasmedicas = "0";
        string permiso_reporte = "0";
        string permiso_reporte_citasmedicas = "0";
        string permiso_estadistica = "0";
        string permiso_estadistica_citasmedicas = "0";
        
        
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
                    " permiso_proceso, " +
                    " permiso_proceso_citasmedicas," +
                    " permiso_reporte, " +
                    " permiso_reporte_citasmedicas," +
                    " permiso_estadistica, " +
                    " permiso_estadistica_citasmedicas"+
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
                        permiso_mantenimiento = MyReader["permiso_mantenimiento"].ToString();
                        permiso_mantenimiento_doctores = MyReader["permiso_mantenimiento_doctores"].ToString();
                        permiso_mantenimiento_pacientes = MyReader["permiso_mantenimiento_pacientes"].ToString();
                        permiso_mantenimiento_usuarios = MyReader["permiso_mantenimiento_usuario"].ToString();
                        permiso_proceso = MyReader["permiso_proceso"].ToString();
                        permiso_proceso_citasmedicas = MyReader["permiso_proceso_citasmedicas"].ToString();
                        permiso_reporte = MyReader["permiso_reporte"].ToString();
                        permiso_reporte_citasmedicas = MyReader["permiso_reporte_citasmedicas"].ToString();
                        permiso_estadistica = MyReader["permiso_estadistica"].ToString();
                        permiso_estadistica_citasmedicas = MyReader["permiso_estadistica_citasmedicas"].ToString();
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
                this.btn_procesos_citasmedicas.Enabled = true;
            }
            else
            {
                this.btn_procesos_citasmedicas.Enabled = false;
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

       
        
    }
}
