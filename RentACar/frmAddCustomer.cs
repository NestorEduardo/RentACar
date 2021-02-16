using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmAddCustomer : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<PersonType> personTypes { get; set; }

        public frmAddCustomer()
        {
            rentACarEntities = new RentACarEntities();
            personTypes = rentACarEntities.PersonTypes.Where(m => m.Status).ToList();
            InitializeComponent();
            BindPersonTypes();
        }

        private void BindPersonTypes()
        {
            personTypes.Add(new PersonType
            {
                Id = -1,
                Description = "[Seleccione un tipo de persona]"
            });

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = personTypes.OrderBy(pt => pt.Description).ToList();
            cbPersonType.DataSource = bindingSource.DataSource;
            cbPersonType.ValueMember = "Id";
            cbPersonType.DisplayMember = "Description";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                rentACarEntities.Customers.Add(new Customer()
                {
                    Name = txtName.Text,
                    DocumentNumber = txtDocumentNumber.Text,
                    CreditCarNumber = txtCreditCarNumber.Text,
                    CreditLimit = txtCreditLimit.Value,
                    PersonTypeId = (int)cbPersonType.SelectedValue,
                    Created = DateTime.Now,
                    Status = true
                });

                rentACarEntities.SaveChanges();

                MessageBox.Show("El cliente fue agreagdo correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCustomers frmCustomers = new frmCustomers();
                frmCustomers.Show();
                Close();
            }
        }

        private bool IsValid()
        {

            if (txtName.Text == "")
            {
                MessageBox.Show($"El nombre del cliente es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtDocumentNumber.Text == "")
            {
                MessageBox.Show($"El número de documento es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtCreditCarNumber.Text == "")
            {
                MessageBox.Show($"El número de tarjeta de crédito es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtCreditLimit.Value < 0)
            {
                MessageBox.Show($"El límite de crédito debe ser mayor o igual a 1.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbPersonType.SelectedValue == -1)
            {
                MessageBox.Show($"El tipo de persona es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
