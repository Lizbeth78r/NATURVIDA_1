using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_negocios;

namespace Capa_V
{
    public partial class frm_inicio_sesion : Form
    {
        public frm_inicio_sesion()
        {
            InitializeComponent();
        }
        
        public void Ingresar_login()
        {
            seguridad encripta = new seguridad();
            SqlConnection conexiones = new SqlConnection("Server=BUCDFPCSEFSD023;Database=NaturVida1;Integrated Security= True");
            Form2 Forms2= new Form2(); 
            conexiones.Open();
            SqlCommand comando = new SqlCommand("SELECT Usuario,Contraseña FROM Vendedores WHERE Usuario=@Usuario AND Contraseña=@Contraseña",conexiones);
            comando.Parameters.AddWithValue("@Usuario",TXT_usuario.Text);
            comando.Parameters.AddWithValue("@Contraseña", encripta.GetSHA256(TXT_contraseña.Text));
            SqlDataReader LEER= comando.ExecuteReader();
            if (LEER.Read())
            {
                conexiones.Close();
                this.Hide();
                Forms2.Show();
            }
            else
            {
                MessageBox.Show("Datos incorrectos","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void cleanIngreso()
        {
            TXT_usuario.Clear();
            TXT_contraseña.Clear();
        }
        private void BTN_ingresar_Click(object sender, EventArgs e)
        {
            Ingresar_login();
        }

        private void frm_inicio_sesion_Load(object sender, EventArgs e)
        {

        }
    }
}
