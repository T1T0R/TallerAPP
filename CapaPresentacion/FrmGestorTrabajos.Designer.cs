namespace Gestor_Pedidos_Tecnology.CapaPresentacion
{
    partial class FrmGestorTrabajos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestorTrabajos));
            this.dgvGestorTrabajos = new System.Windows.Forms.DataGridView();
            this.btnBuscarTrabajo = new System.Windows.Forms.Button();
            this.txtBusquedaNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoEquipo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtNuevoValor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.cmbModificar = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tELEVISORESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PendientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EntregadoStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.DevueltosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISTOSPARAENTREGARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEliminarTrabajo = new System.Windows.Forms.Button();
            this.btnListo = new System.Windows.Forms.Button();
            this.BtnDevolucion = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtIDEstado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregarPresupuesto = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDTrabajo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPresupuesto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrecioArreglo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbTablas = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestorTrabajos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGestorTrabajos
            // 
            this.dgvGestorTrabajos.AllowUserToResizeColumns = false;
            this.dgvGestorTrabajos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGestorTrabajos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvGestorTrabajos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGestorTrabajos.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvGestorTrabajos.Location = new System.Drawing.Point(508, 67);
            this.dgvGestorTrabajos.Name = "dgvGestorTrabajos";
            this.dgvGestorTrabajos.ReadOnly = true;
            this.dgvGestorTrabajos.Size = new System.Drawing.Size(821, 549);
            this.dgvGestorTrabajos.TabIndex = 48;
            // 
            // btnBuscarTrabajo
            // 
            this.btnBuscarTrabajo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnBuscarTrabajo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarTrabajo.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarTrabajo.Location = new System.Drawing.Point(6, 150);
            this.btnBuscarTrabajo.Name = "btnBuscarTrabajo";
            this.btnBuscarTrabajo.Size = new System.Drawing.Size(0, 0);
            this.btnBuscarTrabajo.TabIndex = 49;
            this.btnBuscarTrabajo.Text = "BUSCAR🔎";
            this.btnBuscarTrabajo.UseVisualStyleBackColor = false;
            // 
            // txtBusquedaNombre
            // 
            this.txtBusquedaNombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtBusquedaNombre.Location = new System.Drawing.Point(13, 42);
            this.txtBusquedaNombre.Name = "txtBusquedaNombre";
            this.txtBusquedaNombre.Size = new System.Drawing.Size(218, 26);
            this.txtBusquedaNombre.TabIndex = 52;
            this.txtBusquedaNombre.Enter += new System.EventHandler(this.txtBusquedaNombre_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(10, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 17);
            this.label5.TabIndex = 51;
            this.label5.Text = "Ingrese APELLIDO y NOMBRE ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(10, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "Ingrese CATEGORIA del Equipo";
            // 
            // cmbTipoEquipo
            // 
            this.cmbTipoEquipo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cmbTipoEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEquipo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.cmbTipoEquipo.FormattingEnabled = true;
            this.cmbTipoEquipo.Items.AddRange(new object[] {
            "Televisores",
            "Audio",
            "Otros"});
            this.cmbTipoEquipo.Location = new System.Drawing.Point(13, 97);
            this.cmbTipoEquipo.Name = "cmbTipoEquipo";
            this.cmbTipoEquipo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbTipoEquipo.Size = new System.Drawing.Size(219, 27);
            this.cmbTipoEquipo.TabIndex = 54;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.cmbTipoEquipo);
            this.groupBox1.Controls.Add(this.txtBusquedaNombre);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBuscarTrabajo);
            this.groupBox1.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox1.Location = new System.Drawing.Point(9, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 193);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BUSCAR TRABAJO 🔎";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SlateGray;
            this.button3.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(12, 130);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(220, 50);
            this.button3.TabIndex = 70;
            this.button3.Text = "BUSCAR🔎";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.txtNuevoValor);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.btnModificar);
            this.groupBox5.Controls.Add(this.cmbModificar);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox5.Location = new System.Drawing.Point(258, 326);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(244, 290);
            this.groupBox5.TabIndex = 61;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "MODIFICAR COLUMNA ✏️";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label11.Location = new System.Drawing.Point(3, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 19);
            this.label11.TabIndex = 64;
            this.label11.Text = "Ingrese CODIGO ";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 120);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 25);
            this.textBox1.TabIndex = 65;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNuevoValor
            // 
            this.txtNuevoValor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtNuevoValor.Location = new System.Drawing.Point(6, 186);
            this.txtNuevoValor.Name = "txtNuevoValor";
            this.txtNuevoValor.Size = new System.Drawing.Size(231, 26);
            this.txtNuevoValor.TabIndex = 63;
            this.txtNuevoValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label8.Location = new System.Drawing.Point(4, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 19);
            this.label8.TabIndex = 62;
            this.label8.Text = "Ingrese nuevo VALOR";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Yellow;
            this.btnModificar.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.Black;
            this.btnModificar.Location = new System.Drawing.Point(6, 230);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(232, 50);
            this.btnModificar.TabIndex = 50;
            this.btnModificar.Text = "MODIFICAR ✏️";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // cmbModificar
            // 
            this.cmbModificar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cmbModificar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModificar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.cmbModificar.FormattingEnabled = true;
            this.cmbModificar.Items.AddRange(new object[] {
            "DNI",
            "Nombre del Cliente",
            "Telefono",
            "Domicilio",
            "Equipo",
            "Categoria",
            "Falla Declarada",
            "Modelo",
            "Numero de Serie",
            "Detalles",
            "Control",
            "Cable",
            "Base",
            "Presupuesto",
            "Precio del Arreglo"});
            this.cmbModificar.Location = new System.Drawing.Point(6, 52);
            this.cmbModificar.Name = "cmbModificar";
            this.cmbModificar.Size = new System.Drawing.Size(229, 27);
            this.cmbModificar.TabIndex = 61;
            this.cmbModificar.SelectedIndexChanged += new System.EventHandler(this.cmbModificar_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label7.Location = new System.Drawing.Point(0, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 19);
            this.label7.TabIndex = 60;
            this.label7.Text = "Seleccione COLUMNA ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.MenuToolStripMenuItem,
            this.tELEVISORESToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1329, 57);
            this.menuStrip1.TabIndex = 62;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 53);
            this.toolStripMenuItem1.Text = "FORMULARIO";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // MenuToolStripMenuItem
            // 
            this.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem";
            this.MenuToolStripMenuItem.Size = new System.Drawing.Size(186, 53);
            this.MenuToolStripMenuItem.Text = "💸 GANANCIAS";
            this.MenuToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripMenuItem_Click);
            // 
            // tELEVISORESToolStripMenuItem
            // 
            this.tELEVISORESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PendientesToolStripMenuItem1,
            this.EntregadoStripMenuItem6,
            this.DevueltosToolStripMenuItem,
            this.lISTOSPARAENTREGARToolStripMenuItem});
            this.tELEVISORESToolStripMenuItem.Name = "tELEVISORESToolStripMenuItem";
            this.tELEVISORESToolStripMenuItem.Size = new System.Drawing.Size(174, 53);
            this.tELEVISORESToolStripMenuItem.Text = "💼TRABAJOS ";
            // 
            // PendientesToolStripMenuItem1
            // 
            this.PendientesToolStripMenuItem1.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.PendientesToolStripMenuItem1.Name = "PendientesToolStripMenuItem1";
            this.PendientesToolStripMenuItem1.Size = new System.Drawing.Size(276, 24);
            this.PendientesToolStripMenuItem1.Text = "PENDIENTES ❕";
            this.PendientesToolStripMenuItem1.Click += new System.EventHandler(this.PendientesToolStripMenuItem1_Click);
            // 
            // EntregadoStripMenuItem6
            // 
            this.EntregadoStripMenuItem6.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.EntregadoStripMenuItem6.Name = "EntregadoStripMenuItem6";
            this.EntregadoStripMenuItem6.Size = new System.Drawing.Size(276, 24);
            this.EntregadoStripMenuItem6.Text = "ENTREGADOS ✅";
            this.EntregadoStripMenuItem6.Click += new System.EventHandler(this.EntregadoStripMenuItem6_Click);
            // 
            // DevueltosToolStripMenuItem
            // 
            this.DevueltosToolStripMenuItem.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.DevueltosToolStripMenuItem.Name = "DevueltosToolStripMenuItem";
            this.DevueltosToolStripMenuItem.Size = new System.Drawing.Size(276, 24);
            this.DevueltosToolStripMenuItem.Text = "DEVUELTOS ❌";
            this.DevueltosToolStripMenuItem.Click += new System.EventHandler(this.DevueltosToolStripMenuItem_Click);
            // 
            // lISTOSPARAENTREGARToolStripMenuItem
            // 
            this.lISTOSPARAENTREGARToolStripMenuItem.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.lISTOSPARAENTREGARToolStripMenuItem.Name = "lISTOSPARAENTREGARToolStripMenuItem";
            this.lISTOSPARAENTREGARToolStripMenuItem.Size = new System.Drawing.Size(276, 24);
            this.lISTOSPARAENTREGARToolStripMenuItem.Text = "LISTOS PARA ENTREGAR";
            this.lISTOSPARAENTREGARToolStripMenuItem.Click += new System.EventHandler(this.lISTOSPARAENTREGARToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(197, 53);
            this.toolStripMenuItem2.Text = "⚙️ CATEGORIAS";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(214, 24);
            this.toolStripMenuItem3.Text = "TELEVISORES 📺";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click_1);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(214, 24);
            this.toolStripMenuItem4.Text = "AUDIO 🔊";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(214, 24);
            this.toolStripMenuItem5.Text = "OTROS ❔";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(907, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 47);
            this.button1.TabIndex = 63;
            this.button1.Text = "🔄";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SlateGray;
            this.button2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(13, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(220, 50);
            this.button2.TabIndex = 49;
            this.button2.Text = "BUSCAR🔎";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEliminarTrabajo
            // 
            this.btnEliminarTrabajo.BackColor = System.Drawing.Color.Red;
            this.btnEliminarTrabajo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarTrabajo.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarTrabajo.Location = new System.Drawing.Point(12, 300);
            this.btnEliminarTrabajo.Name = "btnEliminarTrabajo";
            this.btnEliminarTrabajo.Size = new System.Drawing.Size(220, 50);
            this.btnEliminarTrabajo.TabIndex = 50;
            this.btnEliminarTrabajo.Text = "ELIMINAR ✖️";
            this.btnEliminarTrabajo.UseVisualStyleBackColor = false;
            this.btnEliminarTrabajo.Click += new System.EventHandler(this.btnEliminarTrabajo_Click);
            // 
            // btnListo
            // 
            this.btnListo.BackColor = System.Drawing.Color.Lime;
            this.btnListo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListo.ForeColor = System.Drawing.Color.Black;
            this.btnListo.Location = new System.Drawing.Point(12, 132);
            this.btnListo.Name = "btnListo";
            this.btnListo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnListo.Size = new System.Drawing.Size(220, 50);
            this.btnListo.TabIndex = 50;
            this.btnListo.Text = "ENTREGADO ✔️";
            this.btnListo.UseVisualStyleBackColor = false;
            this.btnListo.Click += new System.EventHandler(this.btnListo_Click);
            // 
            // BtnDevolucion
            // 
            this.BtnDevolucion.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnDevolucion.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDevolucion.ForeColor = System.Drawing.Color.Black;
            this.BtnDevolucion.Location = new System.Drawing.Point(12, 188);
            this.BtnDevolucion.Name = "BtnDevolucion";
            this.BtnDevolucion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnDevolucion.Size = new System.Drawing.Size(219, 50);
            this.BtnDevolucion.TabIndex = 67;
            this.BtnDevolucion.Text = "DEVOLUCION 📦";
            this.BtnDevolucion.UseVisualStyleBackColor = false;
            this.BtnDevolucion.Click += new System.EventHandler(this.BtnDevolucion_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.button4);
            this.groupBox6.Controls.Add(this.txtIDEstado);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.BtnDevolucion);
            this.groupBox6.Controls.Add(this.btnEliminarTrabajo);
            this.groupBox6.Controls.Add(this.btnListo);
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox6.Location = new System.Drawing.Point(9, 256);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(243, 360);
            this.groupBox6.TabIndex = 64;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "CAMBIAR ESTADO DEL TRABAJO";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Yellow;
            this.button4.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(13, 76);
            this.button4.Name = "button4";
            this.button4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button4.Size = new System.Drawing.Size(220, 50);
            this.button4.TabIndex = 70;
            this.button4.Text = "LISTO PARA ENTREGAR 🚀";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtIDEstado
            // 
            this.txtIDEstado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDEstado.Location = new System.Drawing.Point(12, 44);
            this.txtIDEstado.Multiline = true;
            this.txtIDEstado.Name = "txtIDEstado";
            this.txtIDEstado.Size = new System.Drawing.Size(220, 25);
            this.txtIDEstado.TabIndex = 69;
            this.txtIDEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIDEstado.Enter += new System.EventHandler(this.txtIDEstado_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(13, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 19);
            this.label3.TabIndex = 68;
            this.label3.Text = "Ingrese CODIGO del trabajo";
            // 
            // btnAgregarPresupuesto
            // 
            this.btnAgregarPresupuesto.BackColor = System.Drawing.Color.Lime;
            this.btnAgregarPresupuesto.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPresupuesto.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarPresupuesto.Location = new System.Drawing.Point(6, 210);
            this.btnAgregarPresupuesto.Name = "btnAgregarPresupuesto";
            this.btnAgregarPresupuesto.Size = new System.Drawing.Size(231, 50);
            this.btnAgregarPresupuesto.TabIndex = 50;
            this.btnAgregarPresupuesto.Text = "AGREGAR ✔️";
            this.btnAgregarPresupuesto.UseVisualStyleBackColor = false;
            this.btnAgregarPresupuesto.Click += new System.EventHandler(this.btnAgregarPresupuesto_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(4, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 19);
            this.label4.TabIndex = 51;
            this.label4.Text = "Ingrese CODIGO del trabajo";
            // 
            // txtIDTrabajo
            // 
            this.txtIDTrabajo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDTrabajo.Location = new System.Drawing.Point(7, 42);
            this.txtIDTrabajo.Multiline = true;
            this.txtIDTrabajo.Name = "txtIDTrabajo";
            this.txtIDTrabajo.Size = new System.Drawing.Size(231, 26);
            this.txtIDTrabajo.TabIndex = 60;
            this.txtIDTrabajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIDTrabajo.Enter += new System.EventHandler(this.txtIDTrabajo_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial Black", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label9.Location = new System.Drawing.Point(6, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 24);
            this.label9.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(3, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 19);
            this.label2.TabIndex = 56;
            this.label2.Text = "Ingrese PRESUPUESTO";
            // 
            // txtPresupuesto
            // 
            this.txtPresupuesto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtPresupuesto.Location = new System.Drawing.Point(7, 99);
            this.txtPresupuesto.Multiline = true;
            this.txtPresupuesto.Name = "txtPresupuesto";
            this.txtPresupuesto.Size = new System.Drawing.Size(231, 51);
            this.txtPresupuesto.TabIndex = 57;
            this.txtPresupuesto.Enter += new System.EventHandler(this.txtPresupuesto_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label6.Location = new System.Drawing.Point(2, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 19);
            this.label6.TabIndex = 58;
            this.label6.Text = "Ingrese Precio del arreglo";
            // 
            // txtPrecioArreglo
            // 
            this.txtPrecioArreglo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtPrecioArreglo.Location = new System.Drawing.Point(7, 178);
            this.txtPrecioArreglo.Name = "txtPrecioArreglo";
            this.txtPrecioArreglo.Size = new System.Drawing.Size(230, 26);
            this.txtPrecioArreglo.TabIndex = 59;
            this.txtPrecioArreglo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrecioArreglo.Enter += new System.EventHandler(this.txtPrecioArreglo_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label10.Location = new System.Drawing.Point(4, 509);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 19);
            this.label10.TabIndex = 51;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtPrecioArreglo);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtPresupuesto);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtIDTrabajo);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.btnAgregarPresupuesto);
            this.groupBox4.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox4.Location = new System.Drawing.Point(258, 60);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(244, 265);
            this.groupBox4.TabIndex = 61;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AGREGAR PRESUPUESTO ✔️";
            // 
            // cmbTablas
            // 
            this.cmbTablas.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cmbTablas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTablas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.cmbTablas.FormattingEnabled = true;
            this.cmbTablas.Location = new System.Drawing.Point(997, 12);
            this.cmbTablas.Name = "cmbTablas";
            this.cmbTablas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbTablas.Size = new System.Drawing.Size(320, 27);
            this.cmbTablas.TabIndex = 71;
            this.cmbTablas.SelectedIndexChanged += new System.EventHandler(this.cmbTablas_SelectedIndexChanged_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(832, 7);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(69, 47);
            this.button5.TabIndex = 72;
            this.button5.Text = "📞";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FrmGestorTrabajos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1329, 620);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.cmbTablas);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvGestorTrabajos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGestorTrabajos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GESTOR DE TRABAJOS";
            this.Load += new System.EventHandler(this.FrmGestorTrabajos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestorTrabajos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvGestorTrabajos;
        private System.Windows.Forms.Button btnBuscarTrabajo;
        private System.Windows.Forms.TextBox txtBusquedaNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoEquipo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ComboBox cmbModificar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNuevoValor;
        private System.Windows.Forms.Label label8;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEliminarTrabajo;
        private System.Windows.Forms.Button btnListo;
        private System.Windows.Forms.Button BtnDevolucion;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtIDEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregarPresupuesto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIDTrabajo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPresupuesto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrecioArreglo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbTablas;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tELEVISORESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PendientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DevueltosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem EntregadoStripMenuItem6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem lISTOSPARAENTREGARToolStripMenuItem;
    }
}