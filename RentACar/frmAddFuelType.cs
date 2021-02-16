using System;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmAddFuelType : Form
    {
        private readonly RentACarEntities rentACarEntities;

        public frmAddFuelType()
        {
            rentACarEntities = new RentACarEntities();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (IsValid())
            {
                rentACarEntities.FuelTypes.Add(new FuelType()
                {
                    Description = txtDescription.Text,
                    Status = true,
                    Created = DateTime.Now
                });

                rentACarEntities.SaveChanges();

                MessageBox.Show("El tipo de combustible fue agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmFuelTypes frmFuelTypes = new frmFuelTypes();
                frmFuelTypes.Show();
                Close();
            }
        }

        private bool IsValid()
        {
            FuelType fuelType = rentACarEntities.FuelTypes.Where(m => m.Description.Trim() == txtDescription.Text).FirstOrDefault();

            if (fuelType != null && fuelType.Status == true)
            {
                MessageBox.Show($"Ya existe un tipo de combustible con la descripción: {txtDescription.Text}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show($"La descripción del tipo de combustible es requerida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtDescription.Text.Count() < 3 || txtDescription.Text.Count() > 20)
            {
                MessageBox.Show($"La descripción del tipo de combustible debe estar entre 3 y 20 caracteres.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
