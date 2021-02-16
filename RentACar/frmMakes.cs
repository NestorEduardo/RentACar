using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmMakes : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<Make> makes;
        public frmMakes()
        {
            rentACarEntities = new RentACarEntities();
            makes = rentACarEntities.Makes.Where(m => m.Status).ToList();
            InitializeComponent();
        }

        private void frmMakes_Load(object sender, EventArgs e) => BindGridView();

        private void BindGridView()
        {
            makes = rentACarEntities.Makes.Where(m => m.Status).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (Make make in makes)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = make.Id;
                newRow["Descripción"] = make.Description;
                newTable.Rows.Add(newRow);
            }

            dgvMakes.DataSource = newTable;

            if (dgvMakes.Rows.Count > 0)
            {
                dgvMakes.Rows[0].Selected = true;
            }

            bnCount.Text = $"{makes.Count} registro(s)";
        }

        private DataTable createDataTableTemplate()
        {
            DataTable table = new DataTable("Tipos de Vehículos");

            DataColumn id = new DataColumn("Identificador");
            id.DataType = Type.GetType("System.Int32");

            DataColumn description = new DataColumn("Descripción");
            description.DataType = Type.GetType("System.String");

            table.Columns.Add(id);
            table.Columns.Add(description);

            return table;
        }

        private void bnMoveNext_Click(object sender, EventArgs e)
        {
            int currentRow = -1;

            if (dgvMakes.SelectedRows.Count > 0)
            {
                currentRow = dgvMakes.SelectedRows[0].Index;
            }

            if (currentRow + 1 < dgvMakes.RowCount)
            {
                dgvMakes.Rows[++currentRow].Selected = true;
            }
        }

        private void bnMoveLast_Click(object sender, EventArgs e) => dgvMakes.Rows[makes.Count - 1].Selected = true;

        private void bnMovePrevious_Click(object sender, EventArgs e)
        {
            int currentRow = dgvMakes.SelectedRows[0].Index;

            if (currentRow > 0)
            {
                dgvMakes.Rows[--currentRow].Selected = true;
            }
        }

        private void bnMoveFirst_Click(object sender, EventArgs e) => dgvMakes.Rows[0].Selected = true;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddMake frmAddMake = new frmAddMake();
            frmAddMake.Show();
            Hide();
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de eliminar esta marca", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int currentRow = dgvMakes.SelectedRows[0].Index;
                int id = (int)dgvMakes.Rows[currentRow].Cells[0].Value;

                Make make = rentACarEntities.Makes.Where(m => m.Id == id).FirstOrDefault();
                rentACarEntities.Entry(make).State = System.Data.Entity.EntityState.Modified;
                make.Status = false;
                rentACarEntities.SaveChanges();
                MessageBox.Show("La marca fue eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            frmEditMake frmEditMake = new frmEditMake();
            int currentRow = dgvMakes.SelectedRows[0].Index;
            int id = (int)dgvMakes.Rows[currentRow].Cells[0].Value;
            Make make = rentACarEntities.Makes.Where(m => m.Id == id).FirstOrDefault();

            frmEditMake.Make = make;
            frmEditMake.Show();
            Hide();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMakes frmMakes = new frmMakes();
            frmMakes.Show();
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
            makes = rentACarEntities.Makes.Where(m => m.Status && m.Description.Contains(txtSearch.Text)).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (Make make in makes)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = make.Id;
                newRow["Descripción"] = make.Description;
                newTable.Rows.Add(newRow);
            }

            dgvMakes.DataSource = newTable;

            if (dgvMakes.Rows.Count > 0)
            {
                dgvMakes.Rows[0].Selected = true;
            }

            bnCount.Text = $"{makes.Count} registro(s)";
        }
    }
}
