using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmAddEmployee : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<Employee> employees { get; set; }
        private ICollection<Batch> batches { get; set; }
        public frmAddEmployee()
        {
            rentACarEntities = new RentACarEntities();
            batches = rentACarEntities.Batches.Where(b => b.Status).ToList();
            employees = rentACarEntities.Employees.Where(em => em.Status).ToList();
            InitializeComponent();
            BindBatchTypes();
        }

        private void BindBatchTypes()
        {
            batches.Add(new Batch
            {
                Id = -1,
                Description = "[Seleccione una tanda labor]"
            });

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = batches.OrderBy(b => b.Description).ToList();
            cbBatch.DataSource = bindingSource.DataSource;
            cbBatch.ValueMember = "Id";
            cbBatch.DisplayMember = "Description";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                DateTime dateTime = new DateTime();
                dateTime.AddDays(dtpDateOfAdmission.Value.Day);
                dateTime.AddMonths(dtpDateOfAdmission.Value.Month);
                dateTime.AddYears(dtpDateOfAdmission.Value.Year);

                rentACarEntities.Employees.Add(new Employee()
                {
                    Name = txtName.Text,
                    DocumentNumber = txtDocumentNumber.Text,
                    BatchId = (int)cbBatch.SelectedValue,
                    Comission = txtComision.Value,
                    DateOfAdmission = dtpDateOfAdmission.Value,
                    Status = true
                });

                rentACarEntities.SaveChanges();

                MessageBox.Show("El empleado fue agreagdo correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmEmployees frmEmployees = new frmEmployees();
                frmEmployees.Show();
                Close();
            }
        }

        private bool IsValid()
        {

            if (txtName.Text == "")
            {
                MessageBox.Show($"El nombre del empleado es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtDocumentNumber.Text == "")
            {
                MessageBox.Show($"La cédula es requerida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbBatch.SelectedValue == -1)
            {
                MessageBox.Show($"La tanda labor es requerida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtComision.Value <= 0)
            {
                MessageBox.Show($"La comisión debe ser igual o mayor a cero.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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
