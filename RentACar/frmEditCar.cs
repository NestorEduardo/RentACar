using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmEditCar : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<CarType> carTypes { get; set; }
        private ICollection<Make> makes { get; set; }
        private ICollection<Model> models { get; set; }
        private ICollection<FuelType> fuelTypes { get; set; }
        public Car Car { get; set; }
        public frmEditCar()
        {
            rentACarEntities = new RentACarEntities();
            carTypes = rentACarEntities.CarTypes.Where(m => m.Status).ToList();
            makes = rentACarEntities.Makes.Where(m => m.Status).ToList();
            fuelTypes = rentACarEntities.FuelTypes.Where(m => m.Status).ToList();
            InitializeComponent();
            BindCarTypes();
            BindMakes();
            BindFuelTypes();
        }

        private void frmEditCar_Load(object sender, EventArgs e)
        {
            txtDescription.Text = Car.Description;
            txtDescription.Select(txtDescription.Text.Length, 0);
            txtChasisNumber.Text = Car.ChasisNumber;
            txtChasisNumber.Select(txtChasisNumber.Text.Length, 0);
            txtEngineNumber.Text = Car.EngineNumber;
            txtEngineNumber.Select(txtEngineNumber.Text.Length, 0);
            txtLicensePlateNumber.Text = Car.LicensePlateNumber;
            txtLicensePlateNumber.Select(txtLicensePlateNumber.Text.Length, 0);
            cbCarType.SelectedValue = Car.CarTypeId;
            cbMake.SelectedValue = Car.MakeId;
            BindModels();
            cbModel.SelectedValue = Car.ModelId;
            cbFuelType.SelectedValue = Car.FuelTypeId;
        }

        private void BindCarTypes()
        {
            carTypes.Add(new CarType
            {
                Id = -1,
                Description = "[Seleccione un tipo de vehículo]"
            });

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = carTypes.OrderBy(m => m.Description).ToList();
            cbCarType.DataSource = bindingSource.DataSource;
            cbCarType.ValueMember = "Id";
            cbCarType.DisplayMember = "Description";
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

        private void BindModels()
        {
            models = rentACarEntities.Models.Where(m => m.Status && m.MakeId == (int)cbMake.SelectedValue).ToList();

            models.Add(new Model
            {
                Id = -1,
                Description = "[Seleccione un modelo]"
            });

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = models.OrderBy(m => m.Description).ToList();
            cbModel.DataSource = bindingSource.DataSource;
            cbModel.ValueMember = "Id";
            cbModel.DisplayMember = "Description"; 
        }

        private void BindFuelTypes()
        {
            fuelTypes.Add(new FuelType
            {
                Id = -1,
                Description = "[Seleccione un tipo de combustible]"
            });

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = fuelTypes.OrderBy(m => m.Description).ToList();
            cbFuelType.DataSource = bindingSource.DataSource;
            cbFuelType.ValueMember = "Id";
            cbFuelType.DisplayMember = "Description";
        }

        private bool IsValid()
        {
            Car car = rentACarEntities.Cars.Where(ct => ct.Description.Trim() == txtDescription.Text).FirstOrDefault();

            if (car != null && car.Status == true)
            {
                MessageBox.Show($"Ya existe un vehículo con la descripción: {txtDescription.Text}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show($"La descripción del vehículo es requerida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtDescription.Text.Count() < 3 || txtDescription.Text.Count() > 50)
            {
                MessageBox.Show($"La descripción del vehículo debe estar entre 3 y 50 caracteres.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtChasisNumber.Text.Trim() == "")
            {
                MessageBox.Show($"El número de chasis es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtEngineNumber.Text.Trim() == "")
            {
                MessageBox.Show($"El número de motor es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtLicensePlateNumber.Text.Trim() == "")
            {
                MessageBox.Show($"El número de placa es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbCarType.SelectedValue == -1)
            {
                MessageBox.Show($"El tipo de vehículo es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbMake.SelectedValue == -1)
            {
                MessageBox.Show($"La marca es requerida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbModel.SelectedValue == -1)
            {
                MessageBox.Show($"El modelo es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if ((int)cbFuelType.SelectedValue == -1)
            {
                MessageBox.Show($"El tipo de combustible es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void cbMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((int)cbMake.SelectedValue != -1)
                {
                    BindModels();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Car car = rentACarEntities.Cars.Where(c => c.Id == Car.Id).FirstOrDefault();
                //car.CarType = null;
                //car.FuelType = null;
                //car.Model = null;
                //car.Make = null;
                car.Description = txtDescription.Text;
                car.ChasisNumber = txtChasisNumber.Text;
                car.EngineNumber = txtEngineNumber.Text;
                car.LicensePlateNumber = txtLicensePlateNumber.Text;
                car.CarTypeId = (int)cbCarType.SelectedValue;
                car.MakeId = (int)cbMake.SelectedValue;
                car.ModelId = (int)cbModel.SelectedValue;
                car.FuelTypeId = (int)cbFuelType.SelectedValue;
                rentACarEntities.Entry(car).State = System.Data.Entity.EntityState.Modified;
                rentACarEntities.SaveChanges();
                MessageBox.Show("El vehículo fue editado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCars frmCars = new frmCars();
                frmCars.Show();
                Hide();
            }
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
