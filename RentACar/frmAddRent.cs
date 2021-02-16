using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmAddRent : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<Employee> employees { get; set; }
        private ICollection<Car> cars { get; set; }
        private ICollection<Customer> customers { get; set; }
        public frmAddRent()
        {
            rentACarEntities = new RentACarEntities();
            employees = rentACarEntities.Employees.Where(e => e.Status).ToList();
            cars = rentACarEntities.Cars.Where(c => c.Status).ToList();
            customers = rentACarEntities.Customers.Where(c => c.Status).ToList();
            InitializeComponent();
            BindEmployees();
            BindCars();
            BindCustomers();
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

        private bool IsValid()
        {
            if ((int)cbEmployee.SelectedValue == -1)
            {
                MessageBox.Show($"El empleado es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbCar.SelectedValue == -1)
            {
                MessageBox.Show($"El vehículo es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((int)cbCustomer.SelectedValue == -1)
            {
                MessageBox.Show($"El cliente es requerido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtAmountPerDay.Value < 0)
            {
                MessageBox.Show($"El monto por día debe ser mayor o igual a cero.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtDays.Value < 1)
            {
                MessageBox.Show($"La cantidad de día debe ser mayor o igual a uno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                rentACarEntities.Rents.Add(new Rent()
                {
                    AmountPerDay = txtAmountPerDay.Value,
                    CarId = (int)cbCar.SelectedValue,
                    Comments = txtComments.Text,
                    CustomerId = (int)cbCustomer.SelectedValue,
                    EmployeeId = (int)cbEmployee.SelectedValue,
                    Days = (int)txtDays.Value,
                    RentalDate = DateTime.Now,
                    RentStatusId = rentACarEntities.RentStatus.Where(rs => rs.Description == "Rentado").FirstOrDefault().Id,
                    ReturnDate = dtpReturnDate.Value,
                    Status = true
                });

                Car car = rentACarEntities.Cars.Where(m => m.Id == (int)cbCar.SelectedValue).FirstOrDefault();
                rentACarEntities.Entry(car).State = EntityState.Modified;
                car.Status = false;

                rentACarEntities.SaveChanges();

                MessageBox.Show("La renta fue creada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmRents frm = new frmRents();
                frm.Show();
                Close();
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

        private void frmAddRent_Load(object sender, EventArgs e)
        {
            dtpReturnDate.MinDate = DateTime.Now;
        }
    }
}
