using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmEditCustomer : Form
    {
        private readonly RentACarEntities rentACarEntities;
        public Customer Customer { get; set; }
        private ICollection<PersonType> personTypes { get; set; }

        public frmEditCustomer()
        {
            rentACarEntities = new RentACarEntities();
            personTypes = rentACarEntities.PersonTypes.Where(pt => pt.Status).ToList();
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
            bindingSource.DataSource = personTypes.OrderBy(m => m.Description).ToList();
            cbPersonType.DataSource = bindingSource.DataSource;
            cbPersonType.ValueMember = "Id";
            cbPersonType.DisplayMember = "Description";
        }

        private void frmEditCustomer_Load(object sender, System.EventArgs e)
        {
            txtName.Text = Customer.Name;
            txtName.Select(txtName.Text.Length, 0);
            txtDocumentNumber.Text = Customer.DocumentNumber;
            txtDocumentNumber.Select(txtDocumentNumber.Text.Length, 0);
            txtCreditCarNumber.Text = Customer.CreditCarNumber;
            txtCreditCarNumber.Select(txtCreditCarNumber.Text.Length, 0);
            txtCreditLimit.Value = Customer.CreditLimit;
            txtCreditLimit.Select(txtCreditLimit.Text.Length, 0);
            cbPersonType.SelectedValue = Customer.PersonTypeId;
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

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (IsValid())
            {
                Customer customer = rentACarEntities.Customers.Where(c => c.Id == Customer.Id).FirstOrDefault();
                customer.Name = txtName.Text;
                customer.DocumentNumber = txtDocumentNumber.Text;
                customer.CreditCarNumber = txtCreditCarNumber.Text;
                customer.CreditLimit = txtCreditLimit.Value;
                customer.PersonTypeId = (int)cbPersonType.SelectedValue;
                rentACarEntities.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                rentACarEntities.SaveChanges();
                MessageBox.Show("El cliente fue editado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCustomers frmCustomers = new frmCustomers();
                frmCustomers.Show();
                Hide();
            }
        }

        private void inicioToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void tiposDeVehículosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmCarTypes frmCarTypes = new frmCarTypes();
            frmCarTypes.Show();
            Hide();
        }

        private void tiposDeCombustiblesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmFuelTypes frmFuelTypes = new frmFuelTypes();
            frmFuelTypes.Show();
            Hide();
        }

        private void vehículosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmCars frmCars = new frmCars();
            frmCars.Show();
            Hide();
        }

        private void clientesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmCustomers frmCustomers = new frmCustomers();
            frmCustomers.Show();
            Hide();
        }

        private void empleadosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmEmployees frmEmployees = new frmEmployees();
            frmEmployees.Show();
            Hide();
        }

        private void marcasToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmMakes frmMakes = new frmMakes();
            frmMakes.Show();
            Hide();
        }

        private void modelosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmModels frmModels = new frmModels();
            frmModels.Show();
            Hide();
        }

        private void inspecciónToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmInspection frmInspection = new frmInspection();
            frmInspection.Show();
            Hide();
        }

        private void rentasToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmRents frmRents = new frmRents();
            frmRents.Show();
            Hide();
        }

        private void reportesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmReports frmReports = new frmReports();
            frmReports.Show();
            Hide();
        }
    }
}
