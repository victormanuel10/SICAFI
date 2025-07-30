using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SICAFI.App.Forms.Shared;
using SICAFI.Datos;

namespace SICAFI.App.Forms.FichaPredial
{
    public class FrmModificarFichaPredial : Form
    {
        // Declaraciones de controles
        private TextBox txtNumeroFicha;
        private TextBox txtDireccion;
        private TextBox txtMunicipio;
        private TextBox txtBarrio;
        private TextBox txtManzana;
        private TextBox txtPredio;
        private TextBox txtArea;
        private TextBox txtValorAvaluo;
        private ComboBox cboSector;
        private ComboBox cboCorregimiento;
        
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnCerrar;

        private int fichaPredialId;
        private DataTable datosFichaPredial;
        private FichaPredialData fichaPredialData;

        public void InitializeWithContext(int fichaPredialId)
        {
            this.fichaPredialId = fichaPredialId;
            LoadData();
        }

        public FrmModificarFichaPredial()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "MODIFICAR FICHA PREDIAL";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Aplicar tema SICAFI con tamaño más grande
            SicafiTheme.ApplyFormTheme(this, FormSize.Large);

            CreateControls();
            SetupLayout();
        }

        private void CreateControls()
        {
            // Crear controles de entrada
            this.txtNumeroFicha = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtNumeroFicha.ReadOnly = true;
            
            this.txtDireccion = SicafiTheme.CreateTextBox(TextBoxSize.Standard);
            this.txtMunicipio = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtBarrio = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtManzana = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtPredio = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtArea = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            this.txtValorAvaluo = SicafiTheme.CreateTextBox(TextBoxSize.Small);
            
            this.cboSector = SicafiTheme.CreateComboBox(ComboBoxSize.Standard);
            this.cboCorregimiento = SicafiTheme.CreateComboBox(ComboBoxSize.Standard);

            // Crear botones
            this.btnGuardar = new Button();
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.Size = new Size(120, 35);
            this.btnGuardar.FlatStyle = FlatStyle.Flat;
            this.btnGuardar.BackColor = Color.FromArgb(0, 200, 83);
            this.btnGuardar.ForeColor = Color.White;
            this.btnGuardar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnGuardar.Cursor = Cursors.Hand;
            this.btnGuardar.Click += BtnGuardar_Click;

            this.btnCancelar = new Button();
            this.btnCancelar.Text = "↺ Cancelar";
            this.btnCancelar.Size = new Size(120, 35);
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.BackColor = Color.FromArgb(255, 149, 0);
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnCancelar.Cursor = Cursors.Hand;
            this.btnCancelar.Click += BtnCancelar_Click;

            this.btnCerrar = new Button();
            this.btnCerrar.Text = "❌ Cerrar";
            this.btnCerrar.Size = new Size(120, 35);
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.BackColor = Color.FromArgb(244, 67, 54);
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnCerrar.Cursor = Cursors.Hand;
            this.btnCerrar.Click += BtnCerrar_Click;
        }

        private void SetupLayout()
        {
            // Panel principal
            var mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = Color.FromArgb(45, 45, 48);
            mainPanel.Padding = new Padding(20);

            // Título principal
            var lblTitulo = new Label();
            lblTitulo.Text = "MODIFICAR FICHA PREDIAL";
            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 153, 255);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(500, 35);
            lblTitulo.BackColor = Color.Transparent;
            mainPanel.Controls.Add(lblTitulo);

            // Panel de información básica
            var panelInfoBasica = new Panel();
            panelInfoBasica.Location = new Point(20, 70);
            panelInfoBasica.Size = new Size(1100, 300);
            panelInfoBasica.BackColor = Color.FromArgb(37, 37, 38);
            panelInfoBasica.Padding = new Padding(20);

            var lblInfoBasica = new Label();
            lblInfoBasica.Text = "INFORMACIÓN BÁSICA";
            lblInfoBasica.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblInfoBasica.ForeColor = Color.FromArgb(0, 153, 255);
            lblInfoBasica.Location = new Point(0, 0);
            lblInfoBasica.Size = new Size(300, 30);
            lblInfoBasica.BackColor = Color.Transparent;
            panelInfoBasica.Controls.Add(lblInfoBasica);

            // Configurar controles de información básica con más espacio
            int yPos = 40;
            int xPos = 0;
            int labelWidth = 180;
            int controlSpacing = 50;

            // Primera fila
            var lblNumeroFicha = CreateLabel("Número de Ficha:", xPos, yPos);
            panelInfoBasica.Controls.Add(lblNumeroFicha);
            this.txtNumeroFicha.Location = new Point(xPos + labelWidth, yPos);
            this.txtNumeroFicha.Size = new Size(150, 30);
            panelInfoBasica.Controls.Add(this.txtNumeroFicha);

            var lblDireccion = CreateLabel("Dirección:", xPos + 400, yPos);
            panelInfoBasica.Controls.Add(lblDireccion);
            this.txtDireccion.Location = new Point(xPos + 580, yPos);
            this.txtDireccion.Size = new Size(250, 30);
            panelInfoBasica.Controls.Add(this.txtDireccion);

            // Segunda fila
            yPos += controlSpacing;
            var lblMunicipio = CreateLabel("Municipio:", xPos, yPos);
            panelInfoBasica.Controls.Add(lblMunicipio);
            this.txtMunicipio.Location = new Point(xPos + labelWidth, yPos);
            this.txtMunicipio.Size = new Size(150, 30);
            panelInfoBasica.Controls.Add(this.txtMunicipio);

            var lblBarrio = CreateLabel("Barrio:", xPos + 400, yPos);
            panelInfoBasica.Controls.Add(lblBarrio);
            this.txtBarrio.Location = new Point(xPos + 580, yPos);
            this.txtBarrio.Size = new Size(250, 30);
            panelInfoBasica.Controls.Add(this.txtBarrio);

            // Tercera fila
            yPos += controlSpacing;
            var lblManzana = CreateLabel("Manzana:", xPos, yPos);
            panelInfoBasica.Controls.Add(lblManzana);
            this.txtManzana.Location = new Point(xPos + labelWidth, yPos);
            this.txtManzana.Size = new Size(150, 30);
            panelInfoBasica.Controls.Add(this.txtManzana);

            var lblPredio = CreateLabel("Predio:", xPos + 400, yPos);
            panelInfoBasica.Controls.Add(lblPredio);
            this.txtPredio.Location = new Point(xPos + 580, yPos);
            this.txtPredio.Size = new Size(250, 30);
            panelInfoBasica.Controls.Add(this.txtPredio);

            // Cuarta fila
            yPos += controlSpacing;
            var lblSector = CreateLabel("Sector:", xPos, yPos);
            panelInfoBasica.Controls.Add(lblSector);
            this.cboSector.Location = new Point(xPos + labelWidth, yPos);
            this.cboSector.Size = new Size(150, 30);
            panelInfoBasica.Controls.Add(this.cboSector);

            var lblCorregimiento = CreateLabel("Corregimiento:", xPos + 400, yPos);
            panelInfoBasica.Controls.Add(lblCorregimiento);
            this.cboCorregimiento.Location = new Point(xPos + 580, yPos);
            this.cboCorregimiento.Size = new Size(250, 30);
            panelInfoBasica.Controls.Add(this.cboCorregimiento);

            // Quinta fila
            yPos += controlSpacing;
            var lblArea = CreateLabel("Área (m²):", xPos, yPos);
            panelInfoBasica.Controls.Add(lblArea);
            this.txtArea.Location = new Point(xPos + labelWidth, yPos);
            this.txtArea.Size = new Size(150, 30);
            panelInfoBasica.Controls.Add(this.txtArea);

            var lblValorAvaluo = CreateLabel("Valor Avalúo:", xPos + 400, yPos);
            panelInfoBasica.Controls.Add(lblValorAvaluo);
            this.txtValorAvaluo.Location = new Point(xPos + 580, yPos);
            this.txtValorAvaluo.Size = new Size(250, 30);
            panelInfoBasica.Controls.Add(this.txtValorAvaluo);

            mainPanel.Controls.Add(panelInfoBasica);

            // Panel de botones con más espacio
            var panelBotones = new Panel();
            panelBotones.Location = new Point(20, 390);
            panelBotones.Size = new Size(1100, 60);
            panelBotones.BackColor = Color.Transparent;

            this.btnGuardar.Location = new Point(450, 10);
            this.btnGuardar.Size = new Size(140, 40);
            panelBotones.Controls.Add(this.btnGuardar);

            this.btnCancelar.Location = new Point(600, 10);
            this.btnCancelar.Size = new Size(140, 40);
            panelBotones.Controls.Add(this.btnCancelar);

            this.btnCerrar.Location = new Point(750, 10);
            this.btnCerrar.Size = new Size(140, 40);
            panelBotones.Controls.Add(this.btnCerrar);

            mainPanel.Controls.Add(panelBotones);

            // Agregar controles al formulario
            this.Controls.Add(mainPanel);
        }

        private Label CreateLabel(string text, int x, int y)
        {
            var label = new Label();
            label.Text = text;
            label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label.ForeColor = Color.White;
            label.Location = new Point(x, y);
            label.Size = new Size(170, 30);
            label.BackColor = Color.Transparent;
            label.TextAlign = ContentAlignment.MiddleLeft;
            return label;
        }

        private void LoadData()
        {
            try
            {
                // Inicializar la clase de datos
                fichaPredialData = new FichaPredialData();
                
                // Obtener datos de la ficha predial desde la base de datos
                var row = fichaPredialData.ObtenerFichaPredialPorId(fichaPredialId);
                
                if (row != null)
                {
                    // Cargar datos en los controles
                    this.txtNumeroFicha.Text = row["FIPRNUFI"].ToString();
                    this.txtDireccion.Text = row["FIPRDIRE"].ToString();
                    this.txtMunicipio.Text = row["FIPRMUNI"].ToString();
                    this.txtBarrio.Text = row["FIPRBARR"].ToString();
                    this.txtManzana.Text = row["FIPRMANZ"].ToString();
                    this.txtPredio.Text = row["FIPRPRED"].ToString();
                    this.txtArea.Text = row["FIPRAREA"].ToString();
                    this.txtValorAvaluo.Text = row["FIPRAVAL"].ToString();
                    
                    // Cargar comboboxes
                    this.cboSector.Items.Clear();
                    this.cboSector.Items.AddRange(new string[] { "URBANO", "RURAL", "MIXTO" });
                    this.cboSector.Text = row["FIPRSECT"].ToString();
                    
                    this.cboCorregimiento.Items.Clear();
                    this.cboCorregimiento.Items.AddRange(new string[] { "CENTRO", "NORTE", "SUR", "ESTE", "OESTE" });
                    this.cboCorregimiento.Text = row["FIPRCORR"].ToString();
                }
                else
                {
                    // Si no se encuentra, cargar datos de ejemplo
                    LoadDatosEjemplo();
                }
            }
            catch (Exception ex)
            {
                // Si hay error, cargar datos de ejemplo
                LoadDatosEjemplo();
            }
        }

        private void LoadDatosEjemplo()
        {
            // Cargar datos de ejemplo
            this.txtNumeroFicha.Text = "1001";
            this.txtDireccion.Text = "Dirección de ejemplo 1";
            this.txtMunicipio.Text = "113";
            this.txtBarrio.Text = "CENTRO";
            this.txtManzana.Text = "MANZ001";
            this.txtPredio.Text = "PRED001";
            this.txtArea.Text = "150.50";
            this.txtValorAvaluo.Text = "15000000";
            
            // Cargar comboboxes
            this.cboSector.Items.Clear();
            this.cboSector.Items.AddRange(new string[] { "URBANO", "RURAL", "MIXTO" });
            this.cboSector.Text = "URBANO";
            
            this.cboCorregimiento.Items.Clear();
            this.cboCorregimiento.Items.AddRange(new string[] { "CENTRO", "NORTE", "SUR", "ESTE", "OESTE" });
            this.cboCorregimiento.Text = "CENTRO";
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrEmpty(this.txtDireccion.Text.Trim()))
                {
                    MessageBox.Show("La dirección es obligatoria", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtDireccion.Focus();
                    return;
                }

                // Obtener valores de los controles
                string direccion = this.txtDireccion.Text.Trim();
                string municipio = this.txtMunicipio.Text.Trim();
                string barrio = this.txtBarrio.Text.Trim();
                string manzana = this.txtManzana.Text.Trim();
                string predio = this.txtPredio.Text.Trim();
                string sector = this.cboSector.Text.Trim();
                string corregimiento = this.cboCorregimiento.Text.Trim();

                // Validar y convertir valores numéricos
                if (!decimal.TryParse(this.txtArea.Text, out decimal area))
                {
                    MessageBox.Show("El área debe ser un valor numérico válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtArea.Focus();
                    return;
                }

                if (!decimal.TryParse(this.txtValorAvaluo.Text, out decimal valorAvaluo))
                {
                    MessageBox.Show("El valor de avalúo debe ser un valor numérico válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtValorAvaluo.Focus();
                    return;
                }

                // Guardar en la base de datos
                bool resultado = fichaPredialData.ActualizarFichaPredial(
                    fichaPredialId, direccion, municipio, barrio, manzana, predio, 
                    area, valorAvaluo, sector, corregimiento);

                if (resultado)
                {
                    MessageBox.Show("Ficha predial actualizada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la ficha predial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de que desea cancelar los cambios?", "Confirmación", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoadData(); // Recargar datos originales
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cancelar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 