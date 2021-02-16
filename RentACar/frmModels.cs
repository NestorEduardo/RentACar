using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace RentACar
{
    public partial class frmModels : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<Model> models;
        public frmModels()
        {
            rentACarEntities = new RentACarEntities();
            models = rentACarEntities.Models.Where(m => m.Status).ToList();
            InitializeComponent();
        }

        private void frmModels_Load(object sender, EventArgs e) => BindGridView();

        private void BindGridView()
        {
            models = rentACarEntities.Models.Include(u => u.Make).Where(m => m.Status).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (Model model in models)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = model.Id;
                newRow["Descripción"] = model.Description;
                newRow["Marca"] = model.Make.Description;

                newTable.Rows.Add(newRow);
            }

            dgvModels.DataSource = newTable;

            if (dgvModels.Rows.Count > 0)
            {
                dgvModels.Rows[0].Selected = true;
            }

            bnCount.Text = $"{models.Count} registro(s)";
        }

        private DataTable createDataTableTemplate()
        {
            DataTable table = new DataTable("Tipos de Vehículos");

            DataColumn id = new DataColumn("Identificador");
            id.DataType = Type.GetType("System.Int32");

            DataColumn description = new DataColumn("Descripción");
            description.DataType = Type.GetType("System.String");

            DataColumn make = new DataColumn("Marca");
            description.DataType = Type.GetType("System.String");

            table.Columns.Add(id);
            table.Columns.Add(description);
            table.Columns.Add(make);

            return table;
        }

        private void bnMoveNext_Click(object sender, EventArgs e)
        {
            int currentRow = -1;

            if (dgvModels.SelectedRows.Count > 0)
            {
                currentRow = dgvModels.SelectedRows[0].Index;
            }

            if (currentRow + 1 < dgvModels.RowCount)
            {
                dgvModels.Rows[++currentRow].Selected = true;
            }
        }

        private void bnMoveLast_Click(object sender, EventArgs e) => dgvModels.Rows[models.Count - 1].Selected = true;

        private void bnMovePrevious_Click(object sender, EventArgs e)
        {
            int currentRow = dgvModels.SelectedRows[0].Index;

            if (currentRow > 0)
            {
                dgvModels.Rows[--currentRow].Selected = true;
            }
        }

        private void bnMoveFirst_Click(object sender, EventArgs e) => dgvModels.Rows[0].Selected = true;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModel frmAddModel = new frmAddModel();
            frmAddModel.Show();
            Hide();
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de eliminar este modelo", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int currentRow = dgvModels.SelectedRows[0].Index;
                int id = (int)dgvModels.Rows[currentRow].Cells[0].Value;

                Model model = rentACarEntities.Models.Where(m => m.Id == id).FirstOrDefault();
                rentACarEntities.Entry(model).State = EntityState.Modified;
                model.Status = false;
                rentACarEntities.SaveChanges();
                MessageBox.Show("El modelo fue eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            frmEditModel frmEditModel = new frmEditModel();
            int currentRow = dgvModels.SelectedRows[0].Index;
            int id = (int)dgvModels.Rows[currentRow].Cells[0].Value;
            Model model = rentACarEntities.Models.Where(m => m.Id == id).FirstOrDefault();

            frmEditModel.Model = model;
            frmEditModel.Show();
            rentACarEntities.Dispose();
            Hide();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void tiposDeVehículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCarTypes frmCarTypes = new frmCarTypes();
            frmCarTypes.Show();
            Hide();
        }

        private void tiposDeCombustiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFuelTypes frmFuelTypes = new frmFuelTypes();
            frmFuelTypes.Show();
            Hide();
        }

        private void vehículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCars frmCars = new frmCars();
            frmCars.Show();
            Hide();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomers frmCustomers = new frmCustomers();
            frmCustomers.Show();
            Hide();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployees frmEmployees = new frmEmployees();
            frmEmployees.Show();
            Hide();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMakes frmMakes = new frmMakes();
            frmMakes.Show();
            Hide();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModels frmModels = new frmModels();
            frmModels.Show();
            Hide();
        }

        private void inspecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInspection frmInspection = new frmInspection();
            frmInspection.Show();
            Hide();
        }

        private void rentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRents frmRents = new frmRents();
            frmRents.Show();
            Hide();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReports frmReports = new frmReports();
            frmReports.Show();
            Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            models = rentACarEntities.Models.Include(u => u.Make).Where(m => m.Status && m.Description.Contains(txtSearch.Text)).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (Model model in models)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = model.Id;
                newRow["Descripción"] = model.Description;
                newRow["Marca"] = model.Make.Description;

                newTable.Rows.Add(newRow);
            }

            dgvModels.DataSource = newTable;

            if (dgvModels.Rows.Count > 0)
            {
                dgvModels.Rows[0].Selected = true;
            }

            bnCount.Text = $"{models.Count} registro(s)";
        }
    }
}
