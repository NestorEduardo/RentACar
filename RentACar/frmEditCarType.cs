using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmEditCarType : Form
    {
        private readonly RentACarEntities rentACarEntities;
        public CarType CarType { get; set; }
        public frmEditCarType()
        {
            rentACarEntities = new RentACarEntities();
            InitializeComponent();
        }

        private void frmEditCarType_Load(object sender, System.EventArgs e)
        {
            txtDescription.Text = CarType.Description;
            txtDescription.Select(txtDescription.Text.Length, 0);
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (IsValid())
            {
                CarType carType = rentACarEntities.CarTypes.Where(ct => ct.Id == CarType.Id).FirstOrDefault();
                carType.Description = txtDescription.Text;
                rentACarEntities.Entry(carType).State = System.Data.Entity.EntityState.Modified;
                rentACarEntities.SaveChanges();
                MessageBox.Show("El tipo de vehiculo fue editado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCarTypes frmCarTypes = new frmCarTypes();
                frmCarTypes.Show();
                Hide();
            }
        }

        private bool IsValid()
        {
            CarType carType = rentACarEntities.CarTypes.Where(ct => ct.Description.Trim() == txtDescription.Text && ct.Description != CarType.Description).FirstOrDefault();

            if (carType != null && carType.Status == true)
            {
                MessageBox.Show($"Ya existe un tipo de vehículo con la descripción: {txtDescription.Text}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtDescription.Text.Count() < 3 || txtDescription.Text.Count() > 20)
            {
                MessageBox.Show($"La descripción del tipo de vehículo debe estar entre 3 y 20 caracteres.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show($"La descripción del tipo de vehículo es requerida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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
