using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace RentACar
{
    public partial class frmCars : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<Car> cars;
        public frmCars()
        {
            rentACarEntities = new RentACarEntities();
            cars = rentACarEntities.Cars.Where(m => m.Status).ToList();
            InitializeComponent();
        }

        private void frmCars_Load(object sender, EventArgs e) => BindGridView();

        private void BindGridView()
        {
            cars = rentACarEntities.Cars.Include(c => c.CarType).Include(c => c.Make).Include(c => c.Model).Include(c => c.FuelType).Include(c => c.CarStatu).Where(c => c.Status).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (Car model in cars)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = model.Id;
                newRow["Descripción"] = model.Description;
                newRow["No. Chasis"] = model.ChasisNumber;
                newRow["No. Motor"] = model.EngineNumber;
                newRow["No. Placa"] = model.LicensePlateNumber;
                newRow["Tipo de vehículo"] = model.CarType.Description;
                newRow["Marca"] = model.Make.Description;
                newRow["Modelo"] = model.Model.Description;
                newRow["Tipo de combustible"] = model.FuelType.Description;
                newRow["Estado"] = model.CarStatu.Description;

                newTable.Rows.Add(newRow);
            }

            dgvCars.DataSource = newTable;

            if (dgvCars.Rows.Count > 0)
            {
                dgvCars.Rows[0].Selected = true;
            }

            bnCount.Text = $"{cars.Count} registro(s)";
        }

        private DataTable createDataTableTemplate()
        {
            DataTable table = new DataTable("Tipos de Vehículos");

            DataColumn id = new DataColumn("Identificador");
            id.DataType = Type.GetType("System.Int32");

            DataColumn description = new DataColumn("Descripción");
            description.DataType = Type.GetType("System.String");

            DataColumn chasisNumber = new DataColumn("No. Chasis");
            description.DataType = Type.GetType("System.String");

            DataColumn engineNumber = new DataColumn("No. Motor");
            description.DataType = Type.GetType("System.String");

            DataColumn licensePlateNumber = new DataColumn("No. Placa");
            description.DataType = Type.GetType("System.String");

            DataColumn carType = new DataColumn("Tipo de vehículo");
            description.DataType = Type.GetType("System.String");

            DataColumn make = new DataColumn("Marca");
            description.DataType = Type.GetType("System.String");

            DataColumn model = new DataColumn("Modelo");
            description.DataType = Type.GetType("System.String");

            DataColumn fuelType = new DataColumn("Tipo de combustible");
            description.DataType = Type.GetType("System.String");

            DataColumn estado = new DataColumn("Estado");
            description.DataType = Type.GetType("System.String");

            table.Columns.Add(id);
            table.Columns.Add(description);
            table.Columns.Add(chasisNumber);
            table.Columns.Add(engineNumber);
            table.Columns.Add(licensePlateNumber);
            table.Columns.Add(carType);
            table.Columns.Add(model);
            table.Columns.Add(make);
            table.Columns.Add(fuelType);
            table.Columns.Add(estado);

            return table;
        }

        private void bnMoveNext_Click(object sender, EventArgs e)
        {
            int currentRow = -1;

            if (dgvCars.SelectedRows.Count > 0)
            {
                currentRow = dgvCars.SelectedRows[0].Index;
            }

            if (currentRow + 1 < dgvCars.RowCount)
            {
                dgvCars.Rows[++currentRow].Selected = true;
            }
        }

        private void bnMoveLast_Click(object sender, EventArgs e) => dgvCars.Rows[cars.Count - 1].Selected = true;

        private void bnMovePrevious_Click(object sender, EventArgs e)
        {
            int currentRow = dgvCars.SelectedRows[0].Index;

            if (currentRow > 0)
            {
                dgvCars.Rows[--currentRow].Selected = true;
            }
        }

        private void bnMoveFirst_Click(object sender, EventArgs e) => dgvCars.Rows[0].Selected = true;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCar frmAddCar = new frmAddCar();
            frmAddCar.Show();
            Hide();
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de eliminar este vehículo", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int currentRow = dgvCars.SelectedRows[0].Index;
                int id = (int)dgvCars.Rows[currentRow].Cells[0].Value;

                Car car = rentACarEntities.Cars.Where(m => m.Id == id).FirstOrDefault();
                rentACarEntities.Entry(car).State = EntityState.Modified;
                car.Status = false;
                rentACarEntities.SaveChanges();
                MessageBox.Show("El vehículo fue eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            frmEditCar frmEditCar = new frmEditCar();
            int currentRow = dgvCars.SelectedRows[0].Index;
            int id = (int)dgvCars.Rows[currentRow].Cells[0].Value;
            Car car = rentACarEntities.Cars.Where(m => m.Id == id).FirstOrDefault();

            frmEditCar.Car = car;
            frmEditCar.Show();
            rentACarEntities.Dispose();
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
            cars = rentACarEntities.Cars.Include(c => c.CarType).Include(c => c.Make).Include(c => c.Model).Include(c => c.FuelType).Include(c => c.CarStatu).Where(c => c.Status).Where(c => c.Description.Contains(txtSearch.Text)).ToList();

            DataTable newTable = createDataTableTemplate();

            foreach (Car model in cars)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = model.Id;
                newRow["Descripción"] = model.Description;
                newRow["No. Chasis"] = model.ChasisNumber;
                newRow["No. Motor"] = model.EngineNumber;
                newRow["No. Placa"] = model.LicensePlateNumber;
                newRow["Tipo de vehículo"] = model.CarType.Description;
                newRow["Marca"] = model.Make.Description;
                newRow["Modelo"] = model.Model.Description;
                newRow["Tipo de combustible"] = model.FuelType.Description;
                newRow["Estado"] = model.CarStatu.Description;

                newTable.Rows.Add(newRow);
            }

            dgvCars.DataSource = newTable;

            if (dgvCars.Rows.Count > 0)
            {
                dgvCars.Rows[0].Selected = true;
            }

            bnCount.Text = $"{cars.Count} registro(s)";
        }
    }
}
