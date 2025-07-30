using System.Drawing;
using System.Windows.Forms;

namespace SICAFI.App.Forms.Shared
{
    public static class SicafiTheme
    {
        // Paleta de colores moderna y profesional
        public static Color PrimaryColor = Color.FromArgb(0, 122, 204); // Azul moderno
        public static Color PrimaryLightColor = Color.FromArgb(0, 153, 255); // Azul claro
        public static Color SecondaryColor = Color.FromArgb(45, 45, 48); // Gris oscuro moderno
        public static Color AccentColor = Color.FromArgb(255, 185, 0); // Amarillo dorado
        public static Color SuccessColor = Color.FromArgb(0, 200, 83); // Verde éxito
        public static Color WarningColor = Color.FromArgb(255, 149, 0); // Naranja advertencia
        public static Color ErrorColor = Color.FromArgb(244, 67, 54); // Rojo error
        
        // Colores de fondo
        public static Color BackgroundColor = Color.FromArgb(30, 30, 30); // Gris muy oscuro
        public static Color SurfaceColor = Color.FromArgb(37, 37, 38); // Gris superficie
        public static Color CardColor = Color.FromArgb(45, 45, 48); // Gris tarjeta
        
        // Colores de texto
        public static Color TextPrimaryColor = Color.White; // Texto principal
        public static Color TextSecondaryColor = Color.FromArgb(200, 200, 200); // Texto secundario
        public static Color TextDisabledColor = Color.FromArgb(100, 100, 100); // Texto deshabilitado
        
        // Colores de bordes
        public static Color BorderColor = Color.FromArgb(60, 60, 60); // Borde normal
        public static Color BorderFocusColor = Color.FromArgb(0, 122, 204); // Borde con foco
        
        // Fuentes modernas
        public static Font TitleFont = new Font("Segoe UI", 14, FontStyle.Bold);
        public static Font SubtitleFont = new Font("Segoe UI", 12, FontStyle.Bold);
        public static Font NormalFont = new Font("Segoe UI", 9, FontStyle.Regular);
        public static Font SmallFont = new Font("Segoe UI", 8, FontStyle.Regular);
        public static Font CaptionFont = new Font("Segoe UI", 7, FontStyle.Regular);

        // Espaciado y dimensiones estándar - Mejorados basados en el formulario original
        public static int StandardPadding = 8;
        public static int LargePadding = 16;
        public static int StandardMargin = 6;
        public static int LargeMargin = 12;
        
        // Tamaños de botones mejorados
        public static Size StandardButtonSize = new Size(100, 32);
        public static Size LargeButtonSize = new Size(120, 36);
        public static Size SmallButtonSize = new Size(80, 28);
        
        // Tamaños de controles mejorados basados en el formulario original
        public static Size StandardTextBoxSize = new Size(200, 28);
        public static Size LargeTextBoxSize = new Size(300, 28);
        public static Size SmallTextBoxSize = new Size(100, 28);
        public static Size StandardComboBoxSize = new Size(200, 28);
        public static Size LargeComboBoxSize = new Size(300, 28);
        public static Size SmallComboBoxSize = new Size(100, 28);
        
        // Tamaños de formularios estándar
        public static Size StandardFormSize = new Size(1200, 800);
        public static Size LargeFormSize = new Size(1400, 900);
        public static Size SmallFormSize = new Size(1000, 700);
        
        // Tamaño específico para formularios de Ficha Predial (basado en el original 855x653)
        public static Size FichaPredialFormSize = new Size(1100, 800);

        public static void ApplyFormTheme(Form form, FormSize size = FormSize.Standard)
        {
            form.BackColor = BackgroundColor;
            form.Font = NormalFont;
            form.ForeColor = TextPrimaryColor;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Padding = new Padding(LargePadding);
            
            // Aplicar tamaño según el tipo de formulario
            switch (size)
            {
                case FormSize.Large:
                    form.Size = LargeFormSize;
                    break;
                case FormSize.Small:
                    form.Size = SmallFormSize;
                    break;
                case FormSize.FichaPredial:
                    form.Size = FichaPredialFormSize;
                    break;
                default:
                    form.Size = StandardFormSize;
                    break;
            }
        }

        public static void ApplyGroupBoxTheme(GroupBox groupBox)
        {
            groupBox.BackColor = CardColor;
            groupBox.Font = SubtitleFont;
            groupBox.ForeColor = PrimaryColor;
            groupBox.Padding = new Padding(LargePadding);
            groupBox.Margin = new Padding(StandardMargin);
        }

        public static void ApplyLabelTheme(Label label, bool isTitle = false, bool isSubtitle = false)
        {
            if (isTitle)
            {
                label.Font = TitleFont;
                label.ForeColor = PrimaryColor;
            }
            else if (isSubtitle)
            {
                label.Font = SubtitleFont;
                label.ForeColor = TextPrimaryColor;
            }
            else
            {
                label.Font = NormalFont;
                label.ForeColor = TextSecondaryColor;
            }
            label.BackColor = Color.Transparent;
            label.Margin = new Padding(0, 0, 0, StandardMargin);
        }

        public static void ApplyTextBoxTheme(TextBox textBox, TextBoxSize size = TextBoxSize.Standard)
        {
            textBox.Font = NormalFont;
            textBox.BackColor = SurfaceColor;
            textBox.ForeColor = TextPrimaryColor;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Padding = new Padding(StandardPadding);
            textBox.Margin = new Padding(0, 0, 0, StandardMargin);
            
            // Aplicar tamaño según el tipo
            switch (size)
            {
                case TextBoxSize.Large:
                    textBox.Size = LargeTextBoxSize;
                    break;
                case TextBoxSize.Small:
                    textBox.Size = SmallTextBoxSize;
                    break;
                default:
                    textBox.Size = StandardTextBoxSize;
                    break;
            }
            
            // Eventos para mejorar la experiencia visual
            textBox.Enter += (s, e) => {
                textBox.BackColor = Color.FromArgb(45, 45, 48);
                textBox.BorderStyle = BorderStyle.FixedSingle;
            };
            
            textBox.Leave += (s, e) => {
                textBox.BackColor = SurfaceColor;
                textBox.BorderStyle = BorderStyle.FixedSingle;
            };
        }

        public static void ApplyComboBoxTheme(ComboBox comboBox, ComboBoxSize size = ComboBoxSize.Standard)
        {
            comboBox.Font = NormalFont;
            comboBox.BackColor = SurfaceColor;
            comboBox.ForeColor = TextPrimaryColor;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Margin = new Padding(0, 0, 0, StandardMargin);
            
            // Aplicar tamaño según el tipo
            switch (size)
            {
                case ComboBoxSize.Large:
                    comboBox.Size = LargeComboBoxSize;
                    break;
                case ComboBoxSize.Small:
                    comboBox.Size = SmallComboBoxSize;
                    break;
                default:
                    comboBox.Size = StandardComboBoxSize;
                    break;
            }
        }

        public static void ApplyButtonTheme(Button button, bool isPrimary = false, bool isLarge = false)
        {
            button.Font = NormalFont;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Margin = new Padding(0, 0, StandardMargin, 0);
            
            if (isLarge)
            {
                button.Size = LargeButtonSize;
            }
            else
            {
                button.Size = StandardButtonSize;
            }
            
            if (isPrimary)
            {
                button.BackColor = PrimaryColor;
                button.ForeColor = Color.White;
                button.FlatAppearance.MouseOverBackColor = PrimaryLightColor;
            }
            else
            {
                button.BackColor = SecondaryColor;
                button.ForeColor = TextPrimaryColor;
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            }
        }

        public static void ApplyDataGridViewTheme(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = SurfaceColor;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = BorderColor;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            // Estilos de encabezados
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = SubtitleFont;
            dataGridView.ColumnHeadersHeight = 35;
            
            // Estilos de filas
            dataGridView.RowsDefaultCellStyle.BackColor = SurfaceColor;
            dataGridView.RowsDefaultCellStyle.ForeColor = TextPrimaryColor;
            dataGridView.RowsDefaultCellStyle.Font = NormalFont;
            dataGridView.RowsDefaultCellStyle.SelectionBackColor = PrimaryLightColor;
            dataGridView.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            
            // Estilos de encabezados de filas
            dataGridView.RowHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dataGridView.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.RowHeadersDefaultCellStyle.Font = SmallFont;
            
            // Altura de filas
            dataGridView.RowTemplate.Height = 25;
        }

        public static void ApplyStatusStripTheme(StatusStrip statusStrip)
        {
            statusStrip.BackColor = CardColor;
            statusStrip.ForeColor = TextSecondaryColor;
            statusStrip.Font = SmallFont;
        }

        public static void ApplyMenuStripTheme(MenuStrip menuStrip)
        {
            menuStrip.BackColor = CardColor;
            menuStrip.ForeColor = TextPrimaryColor;
            menuStrip.Font = NormalFont;
        }

        public static void ApplyPanelTheme(Panel panel)
        {
            panel.BackColor = BackgroundColor;
            panel.Padding = new Padding(StandardPadding);
        }

        public static void ApplyFlowLayoutPanelTheme(FlowLayoutPanel flowPanel)
        {
            flowPanel.BackColor = Color.Transparent;
            flowPanel.Padding = new Padding(StandardPadding);
            flowPanel.Margin = new Padding(StandardMargin);
        }

        public static void ApplyTableLayoutPanelTheme(TableLayoutPanel tablePanel)
        {
            tablePanel.BackColor = Color.Transparent;
            tablePanel.Padding = new Padding(StandardPadding);
            tablePanel.Margin = new Padding(StandardMargin);
        }

        public static void ApplyTabControlTheme(TabControl tabControl)
        {
            tabControl.BackColor = BackgroundColor;
            tabControl.Font = NormalFont;
            tabControl.ForeColor = TextPrimaryColor;
        }

        public static void ApplyTabPageTheme(TabPage tabPage)
        {
            tabPage.BackColor = BackgroundColor;
            tabPage.Font = NormalFont;
            tabPage.ForeColor = TextPrimaryColor;
            tabPage.Padding = new Padding(LargePadding);
        }

        public static Panel CreateMainPanel()
        {
            var panel = new Panel();
            ApplyPanelTheme(panel);
            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true;
            return panel;
        }

        public static GroupBox CreateGroupBox(string text, int width = 600, int height = 200)
        {
            var groupBox = new GroupBox();
            groupBox.Text = text;
            groupBox.Size = new Size(width, height);
            ApplyGroupBoxTheme(groupBox);
            return groupBox;
        }

        public static Label CreateLabel(string text, bool isTitle = false, bool isSubtitle = false)
        {
            var label = new Label();
            label.Text = text;
            label.AutoSize = true;
            ApplyLabelTheme(label, isTitle, isSubtitle);
            return label;
        }

        public static TextBox CreateTextBox(TextBoxSize size = TextBoxSize.Standard)
        {
            var textBox = new TextBox();
            ApplyTextBoxTheme(textBox, size);
            return textBox;
        }

        public static ComboBox CreateComboBox(ComboBoxSize size = ComboBoxSize.Standard)
        {
            var comboBox = new ComboBox();
            ApplyComboBoxTheme(comboBox, size);
            return comboBox;
        }

        public static Button CreateButton(string text, bool isPrimary = false, bool isLarge = false)
        {
            var button = new Button();
            button.Text = text;
            ApplyButtonTheme(button, isPrimary, isLarge);
            return button;
        }

        public static DataGridView CreateDataGridView()
        {
            var dataGridView = new DataGridView();
            ApplyDataGridViewTheme(dataGridView);
            return dataGridView;
        }

        public static StatusStrip CreateStatusStrip()
        {
            var statusStrip = new StatusStrip();
            ApplyStatusStripTheme(statusStrip);
            return statusStrip;
        }

        public static MenuStrip CreateMenuStrip()
        {
            var menuStrip = new MenuStrip();
            ApplyMenuStripTheme(menuStrip);
            return menuStrip;
        }

        public static FlowLayoutPanel CreateFlowLayoutPanel()
        {
            var flowPanel = new FlowLayoutPanel();
            ApplyFlowLayoutPanelTheme(flowPanel);
            return flowPanel;
        }

        public static TableLayoutPanel CreateTableLayoutPanel()
        {
            var tablePanel = new TableLayoutPanel();
            ApplyTableLayoutPanelTheme(tablePanel);
            return tablePanel;
        }

        public static BindingNavigator CreateBindingNavigator()
        {
            var bindingNavigator = new BindingNavigator();
            bindingNavigator.BackColor = CardColor;
            bindingNavigator.ForeColor = TextPrimaryColor;
            bindingNavigator.Font = NormalFont;
            return bindingNavigator;
        }

        public static void CreateStandardFormLayout(Form form, string title, Control mainContent, Control[] buttons = null)
        {
            form.Text = title;
            
            var mainPanel = CreateMainPanel();
            mainPanel.Controls.Add(mainContent);
            
            if (buttons != null && buttons.Length > 0)
            {
                var buttonPanel = new FlowLayoutPanel();
                buttonPanel.FlowDirection = FlowDirection.RightToLeft;
                buttonPanel.Dock = DockStyle.Bottom;
                buttonPanel.Height = 50;
                buttonPanel.Padding = new Padding(LargePadding);
                
                foreach (var button in buttons)
                {
                    buttonPanel.Controls.Add(button);
                }
                
                form.Controls.Add(buttonPanel);
            }
            
            form.Controls.Add(mainPanel);
        }
    }

    // Enums para especificar tamaños
    public enum FormSize
    {
        Small,
        Standard,
        Large,
        FichaPredial
    }

    public enum TextBoxSize
    {
        Small,
        Standard,
        Large
    }

    public enum ComboBoxSize
    {
        Small,
        Standard,
        Large
    }
} 