using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmEmployees : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<Employee> employees;
        public frmEmployees()
        {
            rentACarEntities = new RentACarEntities();
            employees = rentACarEntities.Employees.Where(e => e.Status).ToList();
            InitializeComponent();
        }

        private void frmEmployees_Load(object sender, EventArgs e) => BindGridView();

        private void BindGridView()
        {
            employees = rentACarEntities.Employees.Where(e => e.Status).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (Employee employee in employees)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = employee.Id;
                newRow["Nombre"] = employee.Name;
                newRow["Cédula"] = employee.DocumentNumber;
                newRow["Tanda labor"] = employee.Batch.Description;
                newRow["Porciento comisión"] = employee.Comission;
                newRow["Fecha de ingreso"] = employee.DateOfAdmission;

                newTable.Rows.Add(newRow);
            }

            dgvEmployees.DataSource = newTable;

            if (dgvEmployees.Rows.Count > 0)
            {
                dgvEmployees.Rows[0].Selected = true;
            }

            bnCount.Text = $"{employees.Count} registro(s)";
        }

        private DataTable createDataTableTemplate()
        {
            DataTable table = new DataTable("Tipos de Vehículos");

            DataColumn id = new DataColumn("Identificador");
            id.DataType = Type.GetType("System.Int32");

            DataColumn name = new DataColumn("Nombre");
            name.DataType = Type.GetType("System.String");

            DataColumn documentNumber = new DataColumn("Cédula");
            documentNumber.DataType = Type.GetType("System.String");

            DataColumn batch = new DataColumn("Tanda labor");
            batch.DataType = Type.GetType("System.String");

            DataColumn comission = new DataColumn("Porciento comisión");
            comission.DataType = Type.GetType("System.String");

            DataColumn dateOfAdmission = new DataColumn("Fecha de ingreso");
            dateOfAdmission.DataType = Type.GetType("System.String");

            table.Columns.Add(id);
            table.Columns.Add(name);
            table.Columns.Add(documentNumber);
            table.Columns.Add(batch);
            table.Columns.Add(comission);
            table.Columns.Add(dateOfAdmission);

            return table;
        }

        private void bnMoveNext_Click(object sender, EventArgs e)
        {
            int currentRow = -1;

            if (dgvEmployees.SelectedRows.Count > 0)
            {
                currentRow = dgvEmployees.SelectedRows[0].Index;
            }

            if (currentRow + 1 < dgvEmployees.RowCount)
            {
                dgvEmployees.Rows[++currentRow].Selected = true;
            }
        }

        private void bnMoveLast_Click(object sender, EventArgs e) => dgvEmployees.Rows[employees.Count - 1].Selected = true;

        private void bnMovePrevious_Click(object sender, EventArgs e)
        {
            int currentRow = dgvEmployees.SelectedRows[0].Index;

            if (currentRow > 0)
            {
                dgvEmployees.Rows[--currentRow].Selected = true;
            }
        }

        private void bnMoveFirst_Click(object sender, EventArgs e) => dgvEmployees.Rows[0].Selected = true;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEmployee frmAddEmployee = new frmAddEmployee();
            frmAddEmployee.Show();
            Hide();
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de eliminar este empleado", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int currentRow = dgvEmployees.SelectedRows[0].Index;
                int id = (int)dgvEmployees.Rows[currentRow].Cells[0].Value;

                Employee employee = rentACarEntities.Employees.Where(em => em.Id == id).FirstOrDefault();
                rentACarEntities.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                employee.Status = false;
                rentACarEntities.SaveChanges();
                MessageBox.Show("El empleado fue eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            frmEditEmployee frmEditEmployee = new frmEditEmployee();
            int currentRow = dgvEmployees.SelectedRows[0].Index;
            int id = (int)dgvEmployees.Rows[currentRow].Cells[0].Value;
            Employee employee = rentACarEntities.Employees.Where(em => em.Id == id).FirstOrDefault();

            frmEditEmployee.Employee = employee;
            frmEditEmployee.Show();
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
