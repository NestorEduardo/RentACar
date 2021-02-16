using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmCustomers : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<Customer> customers;
        public frmCustomers()
        {
            rentACarEntities = new RentACarEntities();
            customers = rentACarEntities.Customers.Where(m => m.Status).ToList();
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e) => BindGridView();

        private void BindGridView()
        {
            customers = rentACarEntities.Customers.Where(m => m.Status).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (Customer customer in customers)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = customer.Id;
                newRow["Nombre"] = customer.Name;
                newRow["Número de documento"] = customer.DocumentNumber;
                newRow["Número de tarjeta de crédito"] = customer.CreditCarNumber;
                newRow["Límite de crédito"] = customer.CreditLimit;
                newRow["Tipo de persona"] = customer.PersonType.Description;

                newTable.Rows.Add(newRow);
            }

            dgvCustomers.DataSource = newTable;

            if (dgvCustomers.Rows.Count > 0)
            {
                dgvCustomers.Rows[0].Selected = true;
            }

            bnCount.Text = $"{customers.Count} registro(s)";
        }

        private DataTable createDataTableTemplate()
        {
            DataTable table = new DataTable("Tipos de Vehículos");

            DataColumn id = new DataColumn("Identificador");
            id.DataType = Type.GetType("System.Int32");

            DataColumn description = new DataColumn("Nombre");
            description.DataType = Type.GetType("System.String");

            DataColumn documentNumber = new DataColumn("Número de documento");
            documentNumber.DataType = Type.GetType("System.String");

            DataColumn creditCarNumber = new DataColumn("Número de tarjeta de crédito");
            creditCarNumber.DataType = Type.GetType("System.String");

            DataColumn creditLimit = new DataColumn("Límite de crédito");
            creditLimit.DataType = Type.GetType("System.String");

            DataColumn personType = new DataColumn("Tipo de persona");
            personType.DataType = Type.GetType("System.String");

            table.Columns.Add(id);
            table.Columns.Add(description);
            table.Columns.Add(documentNumber);
            table.Columns.Add(creditCarNumber);
            table.Columns.Add(creditLimit);
            table.Columns.Add(personType);

            return table;
        }

        private void bnMoveNext_Click(object sender, EventArgs e)
        {
            int currentRow = -1;

            if (dgvCustomers.SelectedRows.Count > 0)
            {
                currentRow = dgvCustomers.SelectedRows[0].Index;
            }

            if (currentRow + 1 < dgvCustomers.RowCount)
            {
                dgvCustomers.Rows[++currentRow].Selected = true;
            }
        }

        private void bnMoveLast_Click(object sender, EventArgs e) => dgvCustomers.Rows[customers.Count - 1].Selected = true;

        private void bnMovePrevious_Click(object sender, EventArgs e)
        {
            int currentRow = dgvCustomers.SelectedRows[0].Index;

            if (currentRow > 0)
            {
                dgvCustomers.Rows[--currentRow].Selected = true;
            }
        }

        private void bnMoveFirst_Click(object sender, EventArgs e) => dgvCustomers.Rows[0].Selected = true;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCustomer frmAddCustomer = new frmAddCustomer();
            frmAddCustomer.Show();
            Hide();
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de eliminar este cliente", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int currentRow = dgvCustomers.SelectedRows[0].Index;
                int id = (int)dgvCustomers.Rows[currentRow].Cells[0].Value;

                Customer customer = rentACarEntities.Customers.Where(c => c.Id == id).FirstOrDefault();
                rentACarEntities.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                customer.Status = false;
                rentACarEntities.SaveChanges();
                MessageBox.Show("El cliente fue eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            frmEditCustomer frmEditCustomer = new frmEditCustomer();
            int currentRow = dgvCustomers.SelectedRows[0].Index;
            int id = (int)dgvCustomers.Rows[currentRow].Cells[0].Value;
            Customer customer = rentACarEntities.Customers.Where(c => c.Id == id).FirstOrDefault();

            frmEditCustomer.Customer = customer;
            frmEditCustomer.Show();
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
            customers = rentACarEntities.Customers.Where(m => m.Status && m.Name.Contains(txtSearch.Text)).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (Customer customer in customers)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = customer.Id;
                newRow["Nombre"] = customer.Name;
                newRow["Número de documento"] = customer.DocumentNumber;
                newRow["Número de tarjeta de crédito"] = customer.CreditCarNumber;
                newRow["Límite de crédito"] = customer.CreditLimit;
                newRow["Tipo de persona"] = customer.PersonType.Description;

                newTable.Rows.Add(newRow);
            }

            dgvCustomers.DataSource = newTable;

            if (dgvCustomers.Rows.Count > 0)
            {
                dgvCustomers.Rows[0].Selected = true;
            }

            bnCount.Text = $"{customers.Count} registro(s)";
        }
    }
}
