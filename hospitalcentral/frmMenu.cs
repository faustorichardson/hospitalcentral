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
        string permiso_proceso = "0";
        string permiso_reporte = "0";
        string permiso_estadistica = "0";
        
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
                MyCommand.CommandText = "SELECT permiso_mantenimiento,  " +
                    " permiso_proceso, " +
                    " permiso_reporte, " +
                    " permiso_estadistica " +
                    "FROM usuarios WHERE usuario = '" + UsuarioActual + "'";

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
                        permiso_proceso = MyReader["permiso_proceso"].ToString();
                        permiso_reporte = MyReader["permiso_reporte"].ToString();
                        permiso_estadistica = MyReader["permiso_estadistica"].ToString();
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

            // VERIFICANDO LOS PERMISOS DE PROCESOS
            if (permiso_proceso == "1")
            {
                this.menu_procesos.Enabled = true;
            }
            else
            {
                this.menu_procesos.Enabled = false;
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


            // VERIFICANDO LOS PERMISOS DE ESTADISTICAS
            if (permiso_estadistica == "1")
            {
                this.menu_estadisticas.Enabled = true;
            }
            else
            {
                this.menu_estadisticas.Enabled = false;
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

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {

        }

       
        
    }
}
