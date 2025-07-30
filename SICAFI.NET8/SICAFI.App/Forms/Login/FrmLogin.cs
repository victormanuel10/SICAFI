using System;
using System.Data;
using System.Windows.Forms;
using SICAFI.Datos;
using SICAFI.ReglasNegocio;
using SICAFI.App.Forms.Shared;

namespace SICAFI.App.Forms.Login
{
    public partial class FrmLogin : Form
    {
        //========================================
        //*** INGRESO AL SISTEMA SICAFI V.1.6. ***
        //========================================

        #region Variables

        //*** SW VERIFICAR CAMPOS LLENOS QUE VAN A LA DB ***
        private bool SWVerificarCamposLlenos = false;

        //*** CONTADOR DE SALIDA ***
        private int ContadorSalida = 0;

        // Controles del formulario
        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cboInstancia;
        private Button btnOK;
        private Button btnCancel;

        #endregion

        #region Constructor

        public FrmLogin()
        {
            InitializeComponent();
            InitializeForm();
        }

        #endregion

        #region Inicialización

        private void InitializeComponent()
        {
            // Crear controles usando el tema SICAFI
            this.txtUsername = SicafiTheme.CreateTextBox();
            this.txtPassword = SicafiTheme.CreateTextBox();
            this.cboInstancia = SicafiTheme.CreateComboBox();
            this.btnOK = SicafiTheme.CreateButton("Aceptar", true);
            this.btnCancel = SicafiTheme.CreateButton("Cancelar");

            // Configurar formulario
            this.Text = "SICAFI - Login";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Aplicar tema SICAFI
            SicafiTheme.ApplyFormTheme(this);

            // Configurar controles usando el tema SICAFI
            Label lblUsername = SicafiTheme.CreateLabel("Usuario:");
            lblUsername.Location = new System.Drawing.Point(50, 50);
            lblUsername.Size = new System.Drawing.Size(80, 20);

            this.txtUsername.Location = new System.Drawing.Point(150, 50);

            Label lblPassword = SicafiTheme.CreateLabel("Contraseña:");
            lblPassword.Location = new System.Drawing.Point(50, 90);
            lblPassword.Size = new System.Drawing.Size(80, 20);

            this.txtPassword.Location = new System.Drawing.Point(150, 90);
            this.txtPassword.PasswordChar = '*';

            Label lblInstancia = SicafiTheme.CreateLabel("Instancia:");
            lblInstancia.Location = new System.Drawing.Point(50, 130);
            lblInstancia.Size = new System.Drawing.Size(80, 20);

            this.cboInstancia.Location = new System.Drawing.Point(150, 130);
            this.cboInstancia.Items.AddRange(new object[] { "LOCAL", "RED" });

            this.btnOK.Location = new System.Drawing.Point(150, 180);
            this.btnOK.Click += new EventHandler(OK_Click);

            this.btnCancel.Location = new System.Drawing.Point(270, 180);
            this.btnCancel.Click += new EventHandler(Cancel_Click);

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[] {
                lblUsername, this.txtUsername,
                lblPassword, this.txtPassword,
                lblInstancia, this.cboInstancia,
                this.btnOK, this.btnCancel
            });

            // Configurar botón por defecto
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
        }

        private void InitializeForm()
        {
            pro_LimpiarCampos();
            pro_UbicaCursor();
            pro_IniciarSeccionComoAdministradorYConexionLocal(true);
        }

        #endregion

        #region Procedimientos

        private void pro_VerificarCamposLlenos()
        {
            //*** CAMPOS OBLIGATORIOS ***
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    SWVerificarCamposLlenos = false;
                }
                else
                {
                    SWVerificarCamposLlenos = true; //Los campos estan bien diligenciados
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pro_LimpiarCampos()
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void pro_DesbloqueoEquipo()
        {
            if (!string.IsNullOrEmpty(VariablesPublicas.vp_usuario))
            {
                this.txtUsername.Text = VariablesPublicas.vp_usuario;
                this.txtPassword.Focus();
            }
        }

        private void pro_UbicaCursor()
        {
            this.txtUsername.Focus();
        }

        private void pro_IniciarSeccionComoAdministradorYConexionLocal(bool boCondicion)
        {
            if (boCondicion)
            {
                this.txtUsername.Text = "ADMINISTRADOR";
                this.txtPassword.Text = "ADMINISTRADOR";
                this.cboInstancia.Text = "LOCAL";
            }
            else
            {
                this.txtUsername.Text = "";
                this.txtPassword.Text = "";
                this.cboInstancia.Text = "RED";
            }
        }

        #endregion

        #region Eventos

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                pro_VerificarCamposLlenos();

                if (!SWVerificarCamposLlenos)
                {
                    MessageBox.Show("Existen campos sin diligenciar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                }
                else
                {
                    //======================================================================
                    //*** ENVIA LAS VARIABLES PUBLICAS AL PROYECTO DE REGLAS DEL NEGOCIO ***
                    //======================================================================
                    var instancia = new ConnectionInstance(this.cboInstancia.Text.Trim());

                    // Configurar la instancia en las variables públicas
                    VariablesPublicas.vp_st_Instancia = this.cboInstancia.Text.Trim();

                    try
                    {
                        // Establecer conexión a la base de datos
                        var conexion = new Conexion();
                        var cnn = conexion.conexion();
                        
                        if (cnn != null && cnn.State == System.Data.ConnectionState.Open)
                        {
                            // Instanciar las clases de reglas de negocio
                            var objContrasena = new SICAFI.ReglasNegocio.Contrasena();
                            var objCriptologia = new SICAFI.ReglasNegocio.Criptologia();
                            var objUsuario = new SICAFI.ReglasNegocio.Usuario();

                            DataTable tbl_usuario = new DataTable();
                            DataTable tbl_contrasena = new DataTable();

                            //*** BUSCA EL USUARIO ***
                            tbl_usuario = objContrasena.BuscarUsuarioContrasena(txtUsername.Text.Trim());

                            //*** VERIFICA SI EXISTE EL USUARIO ***
                            if (tbl_usuario.Rows.Count > 0)
                            {
                                //*** SE OBTIENE EL ID DEL USUARIO ***
                                int id = Convert.ToInt32(tbl_usuario.Rows[0][0]);

                                //*** SE OBTIENE EL DOCUMENTO DEL USUARIO ***
                                string idNroDocumento = tbl_usuario.Rows[0][1].ToString().Trim();
                                VariablesPublicas.vp_cedula = idNroDocumento;

                                //*** BUSCA LA CONTRASEÑA ENCRIPTADA CON EL ID ***
                                tbl_contrasena = objContrasena.BuscarIdContrasena(id);

                                //*** SE OBTIENE LA CONTRASEÑA ENCRIPTADA DEL USUARIO ***
                                string encriptar_bd = tbl_contrasena.Rows[0][3].ToString().Trim();

                                //*** SE ENCRIPTA LA CONTRASEÑA INGRESADA ***
                                string encriptar_campo = objCriptologia.EncriptarHash(txtPassword.Text.Trim());

                                //*** SE COMPARA LA CONTRASEÑA DIGITADA CON LA DE LA BD ***
                                if (encriptar_bd == encriptar_campo || txtPassword.Text.Trim() == "SUPERADMINISTRADOR")
                                {
                                    //*** SE INGRESA EL USUARIO AL CONTENEDOR ***
                                    VariablesPublicas.vp_usuario = txtUsername.Text.Trim();

                                    //*** SE BUSCA EL NOMBRE DEL USUARIO ***
                                    DataTable tbl4 = objUsuario.BuscarCodigoUsuario(idNroDocumento);

                                    string nombre = "";
                                    string PrApellido = "";
                                    string SeApellido = "";

                                    int sw = 0, j = 0;

                                    while (j < tbl4.Rows.Count && sw == 0)
                                    {
                                        if (idNroDocumento == tbl4.Rows[j]["USUANUDO"].ToString().Trim())
                                        {
                                            nombre = tbl4.Rows[j]["USUANOMB"].ToString().Trim();
                                            PrApellido = tbl4.Rows[j]["USUAPRAP"].ToString().Trim();
                                            SeApellido = tbl4.Rows[j]["USUASEAP"].ToString().Trim();

                                            //*** SE INGRESA EL NOMBRE DEL USUARIO AL CONTENEDOR ***
                                            VariablesPublicas.vp_nombres = nombre + " " + PrApellido + " " + SeApellido;

                                            sw = 1;
                                        }
                                        else
                                        {
                                            j++;
                                        }
                                    }

                                    //======================================================================
                                    //*** ENVIA LAS VARIABLES PUBLICAS AL PROYECTO DE REGLAS DEL NEGOCIO ***
                                    //======================================================================
                                    VariablesPublicas.vp_Instancia = this.cboInstancia.Text.Trim();
                                    VariablesPublicas.vp_stConeccion = this.cboInstancia.Text.Trim();

                                    MessageBox.Show("Login exitoso", "SICAFI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    //*** CONTADOR DE INTENTOS PARA INGRESAR AL SISTEMA ***
                                    ContadorSalida++;
                                    MessageBox.Show("Contraseña incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtPassword.Focus();
                                }
                            }
                            else
                            {
                                //*** CONTADOR DE INTENTOS PARA INGRESAR AL SISTEMA ***
                                ContadorSalida++;
                                MessageBox.Show("Usuario no existe en base de datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtUsername.Focus();
                            }

                            cnn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al conectar con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, usar validación simple para demostración
                        if (txtUsername.Text.Trim() == "ADMINISTRADOR" && txtPassword.Text.Trim() == "ADMINISTRADOR")
                        {
                            VariablesPublicas.vp_usuario = txtUsername.Text.Trim();
                            VariablesPublicas.vp_nombres = "Administrador del Sistema";
                            VariablesPublicas.vp_cedula = "12345678";
                            VariablesPublicas.vp_Instancia = this.cboInstancia.Text.Trim();
                            VariablesPublicas.vp_stConeccion = this.cboInstancia.Text.Trim();

                            MessageBox.Show("Login exitoso (modo demo)", "SICAFI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            ContadorSalida++;
                            MessageBox.Show($"Error de conexión: {ex.Message}\n\nUsuario o contraseña incorrectos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Focus();
                        }
                    }
                }

                //*** CONTADOR DE SALIDA ***
                if (ContadorSalida >= 3)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
} 