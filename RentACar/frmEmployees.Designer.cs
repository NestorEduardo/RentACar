
namespace RentACar
{
    partial class frmEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployees));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bnMoveFirst = new System.Windows.Forms.ToolStripButton();
            this.bnMovePrevious = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bnCount = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bnMoveNext = new System.Windows.Forms.ToolStripButton();
            this.bnMoveLast = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.bnEdit = new System.Windows.Forms.ToolStripButton();
            this.bnDelete = new System.Windows.Forms.ToolStripButton();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeVehículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeCombustiblesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inspecciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnMoveFirst,
            this.bnMovePrevious,
            this.bindingNavigatorSeparator,
            this.bnCount,
            this.bindingNavigatorSeparator1,
            this.bnMoveNext,
            this.bnMoveLast,
            this.bindingNavigatorSeparator2,
            this.btnAdd,
            this.bnEdit,
            this.bnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(12, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(191, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bnMoveFirst
            // 
            this.bnMoveFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnMoveFirst.Image = ((System.Drawing.Image)(resources.GetObject("bnMoveFirst.Image")));
            this.bnMoveFirst.Name = "bnMoveFirst";
            this.bnMoveFirst.RightToLeftAutoMirrorImage = true;
            this.bnMoveFirst.Size = new System.Drawing.Size(23, 22);
            this.bnMoveFirst.Text = "Primero";
            this.bnMoveFirst.Click += new System.EventHandler(this.bnMoveFirst_Click);
            // 
            // bnMovePrevious
            // 
            this.bnMovePrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnMovePrevious.Image = ((System.Drawing.Image)(resources.GetObject("bnMovePrevious.Image")));
            this.bnMovePrevious.Name = "bnMovePrevious";
            this.bnMovePrevious.RightToLeftAutoMirrorImage = true;
            this.bnMovePrevious.Size = new System.Drawing.Size(23, 22);
            this.bnMovePrevious.Text = "Anterior";
            this.bnMovePrevious.Click += new System.EventHandler(this.bnMovePrevious_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bnCount
            // 
            this.bnCount.Name = "bnCount";
            this.bnCount.Size = new System.Drawing.Size(0, 22);
            this.bnCount.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bnMoveNext
            // 
            this.bnMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnMoveNext.Image = ((System.Drawing.Image)(resources.GetObject("bnMoveNext.Image")));
            this.bnMoveNext.Name = "bnMoveNext";
            this.bnMoveNext.RightToLeftAutoMirrorImage = true;
            this.bnMoveNext.Size = new System.Drawing.Size(23, 22);
            this.bnMoveNext.Text = "Siguiente";
            this.bnMoveNext.Click += new System.EventHandler(this.bnMoveNext_Click);
            // 
            // bnMoveLast
            // 
            this.bnMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnMoveLast.Image = ((System.Drawing.Image)(resources.GetObject("bnMoveLast.Image")));
            this.bnMoveLast.Name = "bnMoveLast";
            this.bnMoveLast.RightToLeftAutoMirrorImage = true;
            this.bnMoveLast.Size = new System.Drawing.Size(23, 22);
            this.bnMoveLast.Text = "Último";
            this.bnMoveLast.Click += new System.EventHandler(this.bnMoveLast_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeftAutoMirrorImage = true;
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "Agregar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // bnEdit
            // 
            this.bnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnEdit.Image = global::RentACar.Properties.Resources.pencil;
            this.bnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnEdit.Name = "bnEdit";
            this.bnEdit.Size = new System.Drawing.Size(23, 22);
            this.bnEdit.Text = "toolStripButton1";
            this.bnEdit.Click += new System.EventHandler(this.bnEdit_Click);
            // 
            // bnDelete
            // 
            this.bnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnDelete.Image = ((System.Drawing.Image)(resources.GetObject("bnDelete.Image")));
            this.bnDelete.Name = "bnDelete";
            this.bnDelete.RightToLeftAutoMirrorImage = true;
            this.bnDelete.Size = new System.Drawing.Size(23, 22);
            this.bnDelete.Text = "Eliminar";
            this.bnDelete.Click += new System.EventHandler(this.bnDelete_Click);
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.AllowUserToOrderColumns = true;
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(12, 53);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.Size = new System.Drawing.Size(984, 709);
            this.dgvEmployees.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.tiposDeVehículosToolStripMenuItem,
            this.tiposDeCombustiblesToolStripMenuItem,
            this.vehículosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.empleadosToolStripMenuItem,
            this.marcasToolStripMenuItem,
            this.modelosToolStripMenuItem,
            this.inspecciónToolStripMenuItem,
            this.rentasToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 71;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // tiposDeVehículosToolStripMenuItem
            // 
            this.tiposDeVehículosToolStripMenuItem.Name = "tiposDeVehículosToolStripMenuItem";
            this.tiposDeVehículosToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.tiposDeVehículosToolStripMenuItem.Text = "Tipos de vehículos";
            this.tiposDeVehículosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeVehículosToolStripMenuItem_Click);
            // 
            // tiposDeCombustiblesToolStripMenuItem
            // 
            this.tiposDeCombustiblesToolStripMenuItem.Name = "tiposDeCombustiblesToolStripMenuItem";
            this.tiposDeCombustiblesToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.tiposDeCombustiblesToolStripMenuItem.Text = "Tipos de combustibles";
            this.tiposDeCombustiblesToolStripMenuItem.Click += new System.EventHandler(this.tiposDeCombustiblesToolStripMenuItem_Click);
            // 
            // vehículosToolStripMenuItem
            // 
            this.vehículosToolStripMenuItem.Name = "vehículosToolStripMenuItem";
            this.vehículosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.vehículosToolStripMenuItem.Text = "Vehículos";
            this.vehículosToolStripMenuItem.Click += new System.EventHandler(this.vehículosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.empleadosToolStripMenuItem.Text = "Empleados";
            this.empleadosToolStripMenuItem.Click += new System.EventHandler(this.empleadosToolStripMenuItem_Click);
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.marcasToolStripMenuItem.Text = "Marcas";
            this.marcasToolStripMenuItem.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // modelosToolStripMenuItem
            // 
            this.modelosToolStripMenuItem.Name = "modelosToolStripMenuItem";
            this.modelosToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.modelosToolStripMenuItem.Text = "Modelos";
            this.modelosToolStripMenuItem.Click += new System.EventHandler(this.modelosToolStripMenuItem_Click);
            // 
            // inspecciónToolStripMenuItem
            // 
            this.inspecciónToolStripMenuItem.Name = "inspecciónToolStripMenuItem";
            this.inspecciónToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.inspecciónToolStripMenuItem.Text = "Inspección";
            this.inspecciónToolStripMenuItem.Click += new System.EventHandler(this.inspecciónToolStripMenuItem_Click);
            // 
            // rentasToolStripMenuItem
            // 
            this.rentasToolStripMenuItem.Name = "rentasToolStripMenuItem";
            this.rentasToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.rentasToolStripMenuItem.Text = "Rentas";
            this.rentasToolStripMenuItem.Click += new System.EventHandler(this.rentasToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // frmEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 749);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmEmployees";
            this.Text = "Empleados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmployees_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bnMoveFirst;
        private System.Windows.Forms.ToolStripButton bnMovePrevious;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripLabel bnCount;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bnMoveNext;
        private System.Windows.Forms.ToolStripButton bnMoveLast;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton bnEdit;
        private System.Windows.Forms.ToolStripButton bnDelete;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeVehículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeCombustiblesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inspecciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
    }
}