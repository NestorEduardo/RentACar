using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmEditInspection : Form
    {
        private readonly RentACarEntities rentACarEntities;
        public Inspection Inspection { get; set; }
        private ICollection<Car> cars { get; set; }
        private ICollection<Customer> customers { get; set; }
        private ICollection<FuelQuantity> fuelQuantities { get; set; }
        private ICollection<RubberStatu> rubberStatu { get; set; }
        private ICollection<Employee> employees { get; set; }
        public frmEditInspection()
        {
            rentACarEntities = new RentACarEntities();
            cars = rentACarEntities.Cars.Where(m => m.Status).ToList();
            customers = rentACarEntities.Customers.Where(m => m.Status).ToList();
            fuelQuantities = rentACarEntities.FuelQuantities.Where(m => m.Status).ToList();
            rubberStatu = rentACarEntities.RubberStatus.Where(m => m.Status).ToList();
            employees = rentACarEntities.Employees.Where(m => m.Status).ToList();
            InitializeComponent();
            BindCars();
            BindCustomers();
            BindFuelQuantities();
            BindRubberStatus();
            BindEmployees();
        }

        private void BindCars()
        {
            cars.Add(new Car
            {
                Id = -1,
                Description = "[Seleccione un vehículo]"
            });

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = cars.OrderBy(m => m.Description).ToList();
            cbCar.DataSource = bindingSource.DataSource;
            cbCar.ValueMember = "Id";
            cbCar.DisplayMember = "Description";
        }

        private void BindCustomers()
        {
            customers.Add(new Customer
            {
                Id = -1,
                Name = "[Seleccione un cliente]"
            });

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = customers.OrderBy(m => m.Name).ToList();
            cbCustomer.DataSource = bindingSource.DataSource;
            cbCustomer.ValueMember = "Id";
            cbCustomer.DisplayMember = "Name";
        }

        private void BindFuelQuantities()
        {
            fuelQuantities.Add(new FuelQuantity
            {
                Id = -1,
                Description = "[Seleccione la cantidad de combustible]"
            });

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = fuelQuantities.OrderBy(m => m.Description).ToList();
            cbFuelQuantity.DataSource = bindingSource.DataSource;
            cbFuelQuantity.ValueMember = "Id";
            cbFuelQuantity.DisplayMember = "Description";
        }

        private void BindEmployees()
        {
            employees.Add(new Employee
            {
                Id = -1,
                Name = "[Seleccione un empleado]"
            });

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = employees.OrderBy(m => m.Name).ToList();
            cbEmployee.DataSource = bindingSource.DataSource;
            cbEmployee.ValueMember = "Id";
            cbEmployee.DisplayMember = "Name";
        }

        private void BindRubberStatus()
        {
            rubberStatu.Add(new RubberStatu
            {
                Id = -1,
                Description = "[Seleccione el estado de gomas]"
            });

            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = rubberStatu.OrderBy(m => m.Description).ToList();
            cbRubberStatus1.DataSource = bindingSource1.DataSource;
            cbRubberStatus1.ValueMember = "Id";
            cbRubberStatus1.DisplayMember = "Description";

            BindingSource bindingSource2 = new BindingSource();
            bindingSource2.DataSource = rubberStatu.OrderBy(m => m.Description).ToList();
            cbRubberStatus2.DataSource = bindingSource2.DataSource;
            cbRubberStatus2.ValueMember = "Id";
            cbRubberStatus2.DisplayMember = "Description";

            BindingSource bindingSource3 = new BindingSource();
            bindingSource3.DataSource = rubberStatu.OrderBy(m => m.Description).ToList();
            cbRubberStatus3.DataSource = bindingSource3.DataSource;
            cbRubberStatus3.ValueMember = "Id";
            cbRubberStatus3.DisplayMember = "Description";

            BindingSource bindingSource4 = new BindingSource();
            bindingSource4.DataSource = rubberStatu.OrderBy(m => m.Description).ToList();
            cbRubberStatus4.DataSource = bindingSource4.DataSource;
            cbRubberStatus4.ValueMember = "Id";
            cbRubberStatus4.DisplayMember = "Description";
        }

        private bool IsValid()
        {
            if ((int)cbCar.SelectedValue == -1)
            {
                MessageBox.Show($"El vehículo es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbCustomer.SelectedValue == -1)
            {
                MessageBox.Show($"El cliente es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbFuelQuantity.SelectedValue == -1)
            {
                MessageBox.Show($"La cantidad de combustible es requerida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbRubberStatus1.SelectedValue == -1)
            {
                MessageBox.Show($"El estado de la goma 1 es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbRubberStatus2.SelectedValue == -1)
            {
                MessageBox.Show($"El estado de la goma 2 es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbRubberStatus3.SelectedValue == -1)
            {
                MessageBox.Show($"El estado de la goma 3 es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbRubberStatus4.SelectedValue == -1)
            {
                MessageBox.Show($"El estado de la goma 4 es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbEmployee.SelectedValue == -1)
            {
                MessageBox.Show($"El empleado es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void frmEditInspection_Load(object sender, EventArgs e)
        {
            cbCar.SelectedValue = Inspection.CarId;
            cbCustomer.SelectedValue = Inspection.CustomerId;
            cbScratches.Checked = Inspection.Scratches;
            cbFuelQuantity.SelectedValue = Inspection.FuelQuantityId;
            cbResponseRubber.Checked = Inspection.ResponseRubber;
            cbCat.Checked = Inspection.Cat;
            cbGlassBreak.Checked = Inspection.GlassBreak;
            cbRubberStatus1.SelectedValue = Inspection.RubberStatus1;
            cbRubberStatus2.SelectedValue = Inspection.RubberStatus2;
            cbRubberStatus3.SelectedValue = Inspection.RubberStatus3;
            cbRubberStatus4.SelectedValue = Inspection.RubberStatus4;
            dtpDate.Value = Inspection.Date.Value;
            cbEmployee.SelectedValue = Inspection.EmployeeId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Inspection inspection = rentACarEntities.Inspections.Where(i => i.Id == Inspection.Id).FirstOrDefault();
                inspection.CarId = (int)cbCar.SelectedValue;
                inspection.Cat = cbCat.Checked;
                inspection.CustomerId = (int)cbCustomer.SelectedValue;
                inspection.EmployeeId = (int)cbEmployee.SelectedValue;
                inspection.FuelQuantityId = (int)cbFuelQuantity.SelectedValue;
                inspection.GlassBreak = cbGlassBreak.Checked;
                inspection.ResponseRubber = cbResponseRubber.Checked;
                inspection.RubberStatus1  = (int)cbRubberStatus1.SelectedValue;
                inspection.RubberStatus2 = (int)cbRubberStatus2.SelectedValue;
                inspection.RubberStatus3 = (int)cbRubberStatus3.SelectedValue;
                inspection.RubberStatus4 = (int)cbRubberStatus4.SelectedValue;
                inspection.Scratches = cbScratches.Checked;
                rentACarEntities.Entry(inspection).State = System.Data.Entity.EntityState.Modified;
                rentACarEntities.SaveChanges();
                MessageBox.Show("La inspección fue editada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmInspection frmInspection = new frmInspection();
                frmInspection.Show();
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
