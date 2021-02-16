using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmCarTypes : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<CarType> carTypes;
        public frmCarTypes()
        {
            rentACarEntities = new RentACarEntities();
            carTypes = rentACarEntities.CarTypes.Where(ct => ct.Status).ToList();
            InitializeComponent();
        }

        private void frmCarTypes_Load(object sender, EventArgs e) => BindGridView();

        private void BindGridView()
        {
            carTypes = rentACarEntities.CarTypes.Where(ct => ct.Status).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (CarType carType in carTypes)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = carType.Id;
                newRow["Descripción"] = carType.Description;
                newTable.Rows.Add(newRow);
            }

            dgvCarTypes.DataSource = newTable;

            if (dgvCarTypes.Rows.Count > 0)
            {
                dgvCarTypes.Rows[0].Selected = true;
            }

            bnCount.Text = $"{carTypes.Count} registro(s)";
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

            if (dgvCarTypes.SelectedRows.Count > 0)
            {
                currentRow = dgvCarTypes.SelectedRows[0].Index;
            }

            if (currentRow + 1 < dgvCarTypes.RowCount)
            {
                dgvCarTypes.Rows[++currentRow].Selected = true;
            }
        }

        private void bnMoveLast_Click(object sender, EventArgs e) => dgvCarTypes.Rows[carTypes.Count - 1].Selected = true;

        private void bnMovePrevious_Click(object sender, EventArgs e)
        {
            int currentRow = dgvCarTypes.SelectedRows[0].Index;

            if (currentRow > 0)
            {
                dgvCarTypes.Rows[--currentRow].Selected = true;
            }
        }

        private void bnMoveFirst_Click(object sender, EventArgs e) => dgvCarTypes.Rows[0].Selected = true;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCarType frmAddCarType = new frmAddCarType();
            frmAddCarType.Show();
            Hide();
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de eliminar este tipo de vehículo", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int currentRow = dgvCarTypes.SelectedRows[0].Index;
                int id = (int)dgvCarTypes.Rows[currentRow].Cells[0].Value;

                CarType carType = rentACarEntities.CarTypes.Where(ct => ct.Id == id).FirstOrDefault();
                rentACarEntities.Entry(carType).State = System.Data.Entity.EntityState.Modified;
                carType.Status = false;
                rentACarEntities.SaveChanges();
                MessageBox.Show("El tipo de vehiculo fue eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            frmEditCarType frmEditCarType = new frmEditCarType();
            int currentRow = dgvCarTypes.SelectedRows[0].Index;
            int id = (int)dgvCarTypes.Rows[currentRow].Cells[0].Value;
            CarType carType = rentACarEntities.CarTypes.Where(ct => ct.Id == id).FirstOrDefault();

            frmEditCarType.CarType = carType;
            frmEditCarType.Show();
            Hide();
        }

        private void dgvCarTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgvCarTypes.SelectedCells[0].RowIndex;
            dgvCarTypes.Rows[rowIndex].Selected = true;
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
            carTypes = rentACarEntities.CarTypes.Where(ct => ct.Status && ct.Description.Contains(txtSearch.Text)).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (CarType carType in carTypes)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = carType.Id;
                newRow["Descripción"] = carType.Description;
                newTable.Rows.Add(newRow);
            }

            dgvCarTypes.DataSource = newTable;

            if (dgvCarTypes.Rows.Count > 0)
            {
                dgvCarTypes.Rows[0].Selected = true;
            }

            bnCount.Text = $"{carTypes.Count} registro(s)";
        }
    }
}
