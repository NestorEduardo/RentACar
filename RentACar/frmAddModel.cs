using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmAddModel : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<Make> makes { get; set; }

        public frmAddModel()
        {
            rentACarEntities = new RentACarEntities();
            makes = rentACarEntities.Makes.Where(m => m.Status).ToList();
            InitializeComponent();
            BindMakes();
        }

        private void BindMakes()
        {
            makes.Add(new Make
            {
                Id = -1,
                Description = "[Seleccione una marca]"
            });

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = makes.OrderBy(m => m.Description).ToList();
            cbMake.DataSource = bindingSource.DataSource;
            cbMake.ValueMember = "Id";
            cbMake.DisplayMember = "Description";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                rentACarEntities.Models.Add(new Model()
                {
                    Description = txtDescription.Text,
                    MakeId = (int)cbMake.SelectedValue,
                    Status = true,
                    Created = DateTime.Now
                });

                rentACarEntities.SaveChanges();

                MessageBox.Show("El modelo fue agreagdo correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmModels frmModels = new frmModels();
                frmModels.Show();
                Close();
            }
        }

        private bool IsValid()
        {
            Model model = rentACarEntities.Models.Where(ct => ct.Description.Trim() == txtDescription.Text).FirstOrDefault();

            if (model != null && model.Status == true)
            {
                MessageBox.Show($"Ya existe un modelo con la descripción: {txtDescription.Text}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show($"La descripción del modelo es requerida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbMake.SelectedValue == -1)
            {
                MessageBox.Show($"La marca es requerida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
