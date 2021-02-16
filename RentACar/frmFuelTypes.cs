using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmFuelTypes : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<FuelType> fuelTypes;
        public frmFuelTypes()
        {
            rentACarEntities = new RentACarEntities();
            fuelTypes = rentACarEntities.FuelTypes.Where(ct => ct.Status).ToList();
            InitializeComponent();
        }

        private void frmFuelTypes_Load(object sender, EventArgs e) => BindGridView();

        private void BindGridView()
        {
            fuelTypes = rentACarEntities.FuelTypes.Where(ct => ct.Status).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (FuelType fuelType in fuelTypes)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = fuelType.Id;
                newRow["Descripción"] = fuelType.Description;
                newTable.Rows.Add(newRow);
            }

            dgvFuelTypes.DataSource = newTable;

            if (dgvFuelTypes.Rows.Count > 0)
            {
                dgvFuelTypes.Rows[0].Selected = true;
            }

            bnCount.Text = $"{fuelTypes.Count} registro(s)";
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

            if (dgvFuelTypes.SelectedRows.Count > 0)
            {
                currentRow = dgvFuelTypes.SelectedRows[0].Index;
            }

            if (currentRow + 1 < dgvFuelTypes.RowCount)
            {
                dgvFuelTypes.Rows[++currentRow].Selected = true;
            }
        }

        private void bnMoveLast_Click(object sender, EventArgs e) => dgvFuelTypes.Rows[fuelTypes.Count - 1].Selected = true;

        private void bnMovePrevious_Click(object sender, EventArgs e)
        {
            int currentRow = dgvFuelTypes.SelectedRows[0].Index;

            if (currentRow > 0)
            {
                dgvFuelTypes.Rows[--currentRow].Selected = true;
            }
        }

        private void bnMoveFirst_Click(object sender, EventArgs e) => dgvFuelTypes.Rows[0].Selected = true;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddFuelType frmAddFuelType = new frmAddFuelType();
            frmAddFuelType.Show();
            Hide();
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de eliminar este tipo de combustible?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int currentRow = dgvFuelTypes.SelectedRows[0].Index;
                int id = (int)dgvFuelTypes.Rows[currentRow].Cells[0].Value;

                FuelType fuelType = rentACarEntities.FuelTypes.Where(ct => ct.Id == id).FirstOrDefault();
                rentACarEntities.Entry(fuelType).State = System.Data.Entity.EntityState.Modified;
                fuelType.Status = false;
                rentACarEntities.SaveChanges();
                MessageBox.Show("El tipo de combustible fue eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            frmEditFuelType frmEditFuelType = new frmEditFuelType();
            int currentRow = dgvFuelTypes.SelectedRows[0].Index;
            int id = (int)dgvFuelTypes.Rows[currentRow].Cells[0].Value;
            FuelType fuelType = rentACarEntities.FuelTypes.Where(ct => ct.Id == id).FirstOrDefault();

            frmEditFuelType.FuelType = fuelType;
            frmEditFuelType.Show();
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
    }
}
