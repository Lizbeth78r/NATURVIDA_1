using Capa_Entidades;
using Capa_negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Capa_V
{
    public partial class Form2 : Form
    {
        CN_productos oCN_productos = new CN_productos();
        CN_productos oCN_productos2 = new CN_productos();//se instancian dos objetos de la misma capa uno para solo mostrar el combobox y otro para las selecciones
        CE_productos prod = new CE_productos();
        CN_clientes Ocn_CLIENTES  = new CN_clientes();
        CN_clientes Ocn_CLIENTES2 = new CN_clientes();
        CE_clientes cliente = new CE_clientes();
        Validaciones oCN_validacionCorreo = new Validaciones();
        List<int> lista = new List<int>();
        CE_factura oCE_factura = new CE_factura();
        CN_factura oCN_factura = new CN_factura();
        CE_detallefactura oCE_detallefactura = new CE_detallefactura();
        CN_factura_detalle oCN_factura_detalle = new CN_factura_detalle();
        CE_vendedores OCE_Vendedores = new CE_vendedores();
        CN_vendedores oCNvendedores = new CN_vendedores();
        Validaciones ovalidaciones= new Validaciones();

        DataTable tab = new DataTable();
        string id;
        int Codigo;
        string consulta = "EXEC MostrarProducto"; // en esta propiedad se pone en string para llamar el metodo del procedimiento almacenado
        string consulta_2 = "EXEC MostrarClientes";
        DataTable cargar= new DataTable();


        public Form2()
        {
            InitializeComponent();
            mostrarCOMBO(CMB_consult_prod);
            MostrarCombo_Cliente(CMB_clientes);
            MostrarFactura();
            mostrarData_Editarclient();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            mostrarData_EDITAR();
            mostrarData_Editarclient();
            MostrarNombresClientes();
            MostrarFactura();
            mostrarData_Editarclient();
            tab.Columns.Add("#Factura");
            tab.Columns.Add("Fecha");
            tab.Columns.Add("Clientes");
            tab.Columns.Add("Productos");
            tab.Columns.Add("Valor");
            tab.Columns.Add("Cantidad");
            tab.Columns.Add("Subtotal");
            dgv_factura.DataSource = tab;
            mostrartodoseditarvendedores();
            LimpiarIngresar();
            mostrarnombrevendedor();
            Editarmostrarnombrevendedor();
            eliminarmostrarnombrevendedor();
        }
        #region.PRODUCTOS   
        public void limpiar()
        {
            TXT_codigo.Clear();
            TXT_descripcion.Clear();  //limpiar campos
            TXT_valor.Clear();
            TXT_cantidad.Clear();
        }
        #region.VALIDACION DE CAJAS
        private void TXT_codigo_KeyPress(object sender, KeyPressEventArgs P)
        {
            Validaciones validar = new Validaciones();//solo numeros
            validar.SoloNum(P);
        }
        #endregion
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            CE_productos prod = new CE_productos();
            prod.Codigo = Convert.ToInt32(TXT_codigo.Text);
            prod.Descripción = TXT_descripcion.Text;   // guardar
            prod.Valor_Unidad = Convert.ToInt32(TXT_valor.Text);
            prod.Cantidad = Convert.ToInt32(TXT_cantidad.Text);
            oCN_productos.N_insertarPROD(prod);
            limpiar();
        }
        public void mostrar()
        {
            DGV_consultar.DataSource = oCN_productos.N_MostrarPROD(consulta);
        }
        private void BTN_mostrar_todo_Click(object sender, EventArgs e)
        {
            mostrar();
        }
        private void tab_consulta_Click(object sender, EventArgs e)
        {
            mostrar();
        }
        public void mostrarCOMBO(ComboBox b) //esto es para usar el mismo metodo con muchos combos ce manera q hacemos un objeto de combobox para cuando ivoquemos al metodo podamos usar culaquier combo como parametro
        {
            b.DataSource = oCN_productos2.N_MostrarPROD(consulta);    //usa el codigo para mostrar el combobox con el otro objeto 
            b.ValueMember = "Codigo";
            b.DisplayMember = "Descripción";
        }
        public void MostrarNombresProductos()
        {
            id = CMB_consult_prod.SelectedValue.ToString();  //con el selected vale inicializamos un parametro de id para buscar su id
            consulta = "Select * From productos where codigo=" + id;  // codigo= al parametro de id
            DGV_consultar.DataSource = oCN_productos.N_MostrarPROD(consulta);// y para la seleccion usa el otro con este codigo
            consulta = "EXEC MostrarProducto";
        }
        private void BTN_consultar_Click(object sender, EventArgs e)
        {
            MostrarNombresProductos();  
        }
        private void tab_editar_Enter(object sender, EventArgs e)
        {
            mostrarCOMBO(CMB_modificar); //para mostrar al combo vamos al evento de la page del tancontrol y al evento Enter luego  mostramos 
        }
        private void tab_consulta_Enter(object sender, EventArgs e)
        {
            mostrarCOMBO(CMB_consult_prod);
        }
        //--------------------------------------SELECCIONAR EN MODIFICAR------------------------------------------------------------------------------------------
        private void btn_consul_M_Click(object sender, EventArgs e)
        {
            MostrarNombresProductos();
            if (CMB_modificar.SelectedIndex >= 0)
            {
                txtCodigo.Text = dgv_editar.CurrentRow.Cells["Codigo"].Value.ToString();
                TXT_descrip_m.Text = dgv_editar.CurrentRow.Cells["Descripción"].Value.ToString();
                TXT_Valor_M.Text = dgv_editar.CurrentRow.Cells["Valor_Unidad"].Value.ToString();
                TXT_cantidad_M.Text = dgv_editar.CurrentRow.Cells["Cantidad"].Value.ToString();
            }
        }
        private void BTN_guardar_M_Click(object sender, EventArgs e)
        {
            prod.Codigo = Convert.ToInt32(txtCodigo.Text);
            prod.Descripción = (TXT_descrip_m.Text).ToString(); 
            prod.Valor_Unidad = Convert.ToInt32(TXT_Valor_M.Text);
            prod.Cantidad = Convert.ToInt32(TXT_cantidad_M.Text);
            oCN_productos.N_EditarPROD(prod);
            MessageBox.Show("actualizado");
            limpiar_EDIT();
        }
        public void limpiar_EDIT()
        {
            txtCodigo.Clear();
            TXT_descrip_m.Clear();
            TXT_Valor_M.Clear();
            TXT_cantidad_M.Clear(); 
        }
        private void tab_Eliminar_Enter(object sender, EventArgs e)
        {
            mostrarCOMBO(CMB_eliminar);
        }
        private void btn_Eliminar_E_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Estas seguro de Eliminar?","ADVERTENCIA",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                prod.Codigo = (Convert.ToInt32(CMB_eliminar.SelectedValue));
                oCN_productos.N_EliminarPROD(prod);
                mostrarCOMBO(CMB_eliminar);
                MessageBox.Show("se elimino");
            }
            else
            {
            }
        }
        public void mostrarData_EDITAR()
        {
            dgv_editar.DataSource = oCN_productos.N_MostrarPROD(consulta);
            dgv_editar.Visible=false;
        }

#endregion
        
        #region.CLIENTES


        public void MostrarCliente()
        {
            dgv_clientes.DataSource= Ocn_CLIENTES.N_Mostrar_Clientes();

        }
        public void MostrarNombresClientes()
        {
            CMB_clientes.DataSource = Ocn_CLIENTES.N_Mostrar_Clientes();
            CMB_clientes.ValueMember = "Documento";
            CMB_clientes.DisplayMember = "Nombre";
        }
        public void MostrarCombo_Cliente(ComboBox client)
        {
            client.DataSource = Ocn_CLIENTES.N_Mostrar_Clientes();
            client.ValueMember = "Documento";
            client.DisplayMember = "Nombre";
            cmb_editar_cliente.SelectedIndex = -1;
            

        }
        public void MostrarCombo_Cliente1()
        {
            CMB_clientes.DataSource = Ocn_CLIENTES.N_Mostrar_Clientes();
            CMB_clientes.ValueMember = "Documento";
            CMB_clientes.DisplayMember = "Nombre";
        }


        private void btn_cliente_mostrar_Click(object sender, EventArgs e)
        {
            MostrarCliente();

        }

        private void tab_consultar_clientes_Enter(object sender, EventArgs e)
        {
            MostrarCombo_Cliente(CMB_clientes);

        }



        private void btn_cliente_Consultar_Click(object sender, EventArgs e)
        {
            int cod;
            cod =Convert.ToInt32(CMB_clientes.SelectedValue.ToString());
            cliente.Documento =cod;
            dgv_clientes.DataSource = Ocn_CLIENTES.N_bbUSCAR_cliente(cliente);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------
        private void btn_cliente_guardar_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrEmpty(TXT_documento.Text) ||
                string.IsNullOrEmpty(TXT_nombre.Text) ||
                string.IsNullOrEmpty(TXT_direccion.Text) ||
                string.IsNullOrEmpty(TXT_telefono.Text) ||
                string.IsNullOrEmpty(TXT_correo.Text))
            {
                MessageBox.Show("Debe ingresar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else

            {
                cliente.Documento = Convert.ToInt32(TXT_documento.Text);
                cliente.Nombre = TXT_nombre.Text;
                cliente.Direccion = TXT_direccion.Text;
                cliente.Telefono = TXT_telefono.Text;
                cliente.Correo = TXT_correo.Text;
                Ocn_CLIENTES.N_Insertar_Client(cliente);
                MessageBox.Show("Ingreso Correctamente");
                Limpiar_CLIENTES();
            }
           
            
        }
        private void TXT_correo_Validating(object sender, CancelEventArgs e)
        {
            
        }
        


        public void Limpiar_CLIENTES()
        {
            TXT_documento.Clear();
            TXT_nombre.Clear();
            TXT_direccion.Clear();
            TXT_telefono.Clear();
            TXT_correo.Clear();
        }



        //--------------------------------------------------------------------------------------------------------------------------------------------------------

        public void mostrarData_Editarclient()
        {

            dgveditarcliente.DataSource = Ocn_CLIENTES.N_Mostrar_Clientes();
            dgveditarcliente.Visible = false;
        }
        private void btn_consultar_clienteE_Click(object sender, EventArgs e)
        {
  //if(txt_doc_ClientE.Text.Trim()==string.Empty || txt_NomCLIENTEDIT.Text.Trim()==string.Empty)//no vacios

            if (cmb_editar_cliente.SelectedIndex >= 0)
            {              
                    txt_doc_ClientE.Text = dgveditarcliente.CurrentRow.Cells[0].Value.ToString();
                    txt_NomCLIENTEDIT.Text = dgveditarcliente.CurrentRow.Cells[1].Value.ToString();
                    txt_direccEDIT.Text = dgveditarcliente.CurrentRow.Cells[2].Value.ToString();
                    txt_TeldClientEDIT.Text = dgveditarcliente.CurrentRow.Cells[3].Value.ToString();
                    txt_corrClientEDIT.Text = dgveditarcliente.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void tab_editar_clientes_Enter(object sender, EventArgs e)
        {
            MostrarCombo_Cliente(cmb_editar_cliente);
        }

        public void Limpiar_CLIENTES_2()
        {
            txt_doc_ClientE.Clear();
            txt_NomCLIENTEDIT.Clear();
            txt_direccEDIT.Clear();
            txt_TeldClientEDIT.Clear();
            txt_corrClientEDIT.Clear();
        }

        private void btn_editar_cliente_Click(object sender, EventArgs e)
        {
                txt_doc_ClientE.ReadOnly = true;//para solo lectura de la caja de texto
                cliente.Documento = Convert.ToInt32(txt_doc_ClientE.Text);
                cliente.Nombre = txt_NomCLIENTEDIT.Text;
                cliente.Direccion = txt_direccEDIT.Text;
                cliente.Telefono = txt_TeldClientEDIT.Text;
                cliente.Correo = txt_corrClientEDIT.Text;
                Ocn_CLIENTES.N_Editar_Cliente(cliente);
                MessageBox.Show("Ingreso correctamente");
                MostrarCombo_Cliente(CMB_clientes);
                
                Limpiar_CLIENTES_2();
            
        }
        

        private void btn_limpiar_cliente_Click(object sender, EventArgs e)
        {
            Limpiar_CLIENTES();
        }
        private void tab_eliminar_clientes_Enter(object sender, EventArgs e)
        {
            MostrarCombo_Cliente(cmb_Eliminar_cliente);
            
        }

        private void btn_eliminar_cliente_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro de Eliminar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cliente.Documento = (Convert.ToInt32(cmb_Eliminar_cliente.SelectedValue));
                Ocn_CLIENTES.N_Eliminar_Cliente(cliente);
                MostrarCombo_Cliente(cmb_Eliminar_cliente);
                MessageBox.Show("se elimino");
            }
            else
            {
            }

        }
        #endregion

        #region.Factura

        private void TAB_factura_Enter(object sender, EventArgs e)
        {
            mostrarCOMBO(cmb_productos_factura);

            MostrarCombo_Cliente(cmb_cliente_factura);

        }

        private void MostrarDetalleFactura()
        {
            //if (oCN_productos.N_MostrarPROD()){;
        }
        private void MostrarFactura()
        {

            if (oCN_factura.MostrarFactura() != " ")
            {
                int Factura = Convert.ToInt32(oCN_factura.MostrarFactura()) + 1;
                txt_numero_factura.Text = Factura.ToString();

            }
            else
                txt_numero_factura.Text = 1.ToString();

        }

        private void TotalFactura()
        {
            int Valor_Unidad = 0;
            foreach (DataRow filas in tab.Rows)
            {
                Valor_Unidad += Convert.ToInt32(filas["Subtotal"]);

            }
            int Valor = Valor_Unidad;
            txt_valor_total_factura.Text = Valor_Unidad.ToString();
        }
        private void btn_agg_prod_Click(object sender, EventArgs e)
        {
            string clien = cmb_cliente_factura.SelectedValue.ToString();
            string Proc = cmb_productos_factura.SelectedValue.ToString();

            prod.Codigo = Convert.ToInt32(cmb_productos_factura.SelectedValue);
            DataTable dtProducto = oCN_productos.BuscarProductos(prod);
            int Precio = Convert.ToInt32(dtProducto.Rows[0]["Valor_Unidad"].ToString());

            DataRow Fila = tab.NewRow();
            Fila["#Factura"] = txt_numero_factura.Text;
            Fila["Fecha"] = dtpFecha.Text;
            Fila["Clientes"] = clien;
            Fila["Productos"] = Proc;
            Fila["Valor"] = (Precio).ToString();
            Fila["Cantidad"] = txt_cantidad_factura.Text;
            Fila["Subtotal"] = (Precio) * (Convert.ToInt32(txt_cantidad_factura.Text));
            tab.Rows.Add(Fila);
            //TxtTotalFactura.Text = TotalFactura().ToString();
            TotalFactura();
            MostrarNombresProductos();
        }
        private void btn_terminar_factura_Click(object sender, EventArgs e)
        {
            GuardarFactura();
            GuardarDetalleFactura();
            LimpiarFactura();
            MostrarFactura();
        }

        public void GuardarFactura()
        {
            int Vendedor = 1212;

            oCE_factura.Fecha1 = Convert.ToDateTime(dtpFecha.Value);
            oCE_factura.Documento_Cliente1 = Convert.ToInt32(cmb_cliente_factura.SelectedValue);
            oCE_factura.Codigo_Vendedor1 = Vendedor;
            oCN_factura.InsetarFactura(oCE_factura);
        }

        public void GuardarDetalleFactura()
        {
            foreach (DataRow Datarow in tab.Rows)
            {
                oCE_detallefactura.Idfact1 = Convert.ToInt32(Datarow["#Factura"]);
                oCE_detallefactura.Codigo_Productos1 = Convert.ToInt32(Datarow["Productos"]);
                oCE_detallefactura.Cantidad1 = Convert.ToInt32(Datarow["Cantidad"]);
                oCE_detallefactura.Valor_Unidad1 = Convert.ToInt32(Datarow["Valor"]);
                oCN_factura_detalle.InsetarFacturaDetalle(oCE_detallefactura);
            }

        }
        public void LimpiarFactura()
        {
            txt_cantidad_factura.Clear();
            txt_valor_total_factura.Clear();
            tab.Rows.Clear();
        }
        #endregion

        #region.VENDEDORES  
        private void LimpiarIngresar() 
        {
            txtcodigoinservend.Clear();
            txtusuarioinserven.Clear();
            txtContraseñainservende.Clear();
            txtnombreinservend.Clear();
        }

        private void LimpiarEditar() 
        {
            txtcodigomodvende.Clear();
            txtusuariomodvende.Clear();
            txtcontramodvenede.Clear();
            txtnombremodvende.Clear();
        }
        private void mostrarnombrevendedor() 
        {
            cmbconsulvende.DataSource = oCNvendedores.Buscarnombrevend();
            cmbconsulvende.DisplayMember = "Usuario";
            cmbconsulvende.ValueMember = "Codigo";
            cmbconsulvende.SelectedIndex = -1;
        }

        private void mostrartodosvendedores() 
        {
            OCE_Vendedores.Codigo = Convert.ToInt32(cmbconsulvende.SelectedValue);
            dgvmostrarvende.DataSource = oCNvendedores.BuscarTodosVendedores(OCE_Vendedores);
        }

        private void mosstrartablatodovendedores() 
        {
            dgvmostrarvende.DataSource = oCNvendedores.MostrarTablaVendedores();
            cmbconsulvende.SelectedIndex = -1;
        }

        private void Editarmostrarnombrevendedor() 
        {
            cmbmodificarvende.DataSource = oCNvendedores.Buscarnombrevend();
            cmbmodificarvende.DisplayMember = "Usuario";
            cmbmodificarvende.ValueMember = "Codigo";
            cmbmodificarvende.SelectedIndex = -1;
        }

        private void mostrartodoseditarvendedores() 
        {
            CE_vendedores vendedor = new CE_vendedores();
            vendedor.Codigo = Convert.ToInt32(cmbmodificarvende.SelectedValue);
            dgvmodificarvendedor.DataSource = oCNvendedores.MostrarTablaVendeEditar(vendedor);
            dgvmodificarvendedor.Visible = false;
        }

        private void eliminarmostrarnombrevendedor() 
        {
            cmbeliminarvende.DataSource = oCNvendedores.Buscarnombrevend();
            cmbeliminarvende.DisplayMember = "Usuario";
            cmbeliminarvende.ValueMember = "Codigo";
            
        }

        private void btnguardarinservende_Click(object sender, EventArgs e)
        {
            seguridad encripta = new seguridad();

            if (txtcodigoinservend.Text == string.Empty || 
                txtusuarioinserven.Text == string.Empty ||
                txtContraseñainservende.Text == string.Empty ||
                txtnombreinservend.Text == string.Empty)
            {
                MessageBox.Show("Error ingrese los datos");
            }
            else
            {
                OCE_Vendedores.Codigo = Convert.ToInt32(txtcodigoinservend.Text); ;
                OCE_Vendedores.Usuario = txtusuarioinserven.Text.Trim();
                OCE_Vendedores.Contraseña = encripta.GetSHA256(txtContraseñainservende.Text.ToLower().Trim());
                OCE_Vendedores.Nombre = txtnombreinservend.Text.Trim();
                oCNvendedores.InsertarVendedor(OCE_Vendedores); 
                MessageBox.Show("Se ingresó correctamente el vendedor");
                LimpiarIngresar(); 
                mostrarnombrevendedor();
                mostrartodoseditarvendedores();
                Editarmostrarnombrevendedor();
                eliminarmostrarnombrevendedor();
            }
        }
        private void btnlimpiarinservend_Click(object sender, EventArgs e)
        {
            LimpiarIngresar();
        }
        private void btnConsultarmodvende_Click(object sender, EventArgs e)
        {
            mostrartodoseditarvendedores();
            if (cmbmodificarvende.SelectedIndex >= 0)
            {
                txtcontramodvenede.Enabled= false;
                txtcodigomodvende.Enabled= false;
                txtcodigomodvende.Text = dgvmodificarvendedor.CurrentRow.Cells["Codigo"].Value.ToString();
                txtusuariomodvende.Text = dgvmodificarvendedor.CurrentRow.Cells["Usuario"].Value.ToString();
                txtcontramodvenede.Text = dgvmodificarvendedor.CurrentRow.Cells["Contraseña"].Value.ToString();
                txtnombremodvende.Text = dgvmodificarvendedor.CurrentRow.Cells["Nombre"].Value.ToString();
            }
            mostrartodoseditarvendedores();
        }
        private void btnguardarcammodvende_Click(object sender, EventArgs e)
        {
            mostrartodoseditarvendedores();
            OCE_Vendedores.Codigo = Convert.ToInt32(txtcodigomodvende.Text);
            OCE_Vendedores.Usuario = txtusuariomodvende.Text;
            OCE_Vendedores.Contraseña = txtcontramodvenede.Text;
            OCE_Vendedores.Nombre = txtnombremodvende.Text;
            oCNvendedores.EditarVendedor(OCE_Vendedores);
            MessageBox.Show("Actualizado");
            LimpiarEditar();
            mostrartodoseditarvendedores();
            Editarmostrarnombrevendedor();
            cmbmodificarvende.SelectedIndex = -1;
        }
        private void btnConsultarconvende_Click(object sender, EventArgs e)
        {
            mostrartodosvendedores();
        }
        private void btnmostrarconsulvende_Click(object sender, EventArgs e)
        {
            mosstrartablatodovendedores();
        }

        private void btneliminarvendedor_Enter(object sender, EventArgs e)
        {
            eliminarmostrarnombrevendedor();
        }
        private void btneliminarvendedor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de Eliminar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                eliminarmostrarnombrevendedor();
                OCE_Vendedores.Codigo = (Convert.ToInt32(cmbeliminarvende.SelectedValue));
                oCNvendedores.EliminarVendedor(OCE_Vendedores);
                eliminarmostrarnombrevendedor();
                MessageBox.Show("se elimino");
                mostrarnombrevendedor();
                mostrartodoseditarvendedores();
                Editarmostrarnombrevendedor();
            }
            else
            {
            }
        }







        #endregion

       
    }
}
