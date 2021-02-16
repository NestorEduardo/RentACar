using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmRents : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<Rent> rents;
        public frmRents()
        {
            rentACarEntities = new RentACarEntities();
            rents = rentACarEntities.Rents.Where(r => r.Status).ToList();
            InitializeComponent();
        }

        private void frmRents_Load(object sender, EventArgs e) => BindGridView();

        private void BindGridView()
        {
            rents = rentACarEntities.Rents.Where(c => c.Status).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (Rent rent in rents)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Número de renta"] = rent.Id;
                newRow["Empleado"] = rent.Employee.Name;
                newRow["Vehículo"] = rent.Car.Description;
                newRow["Cliente"] = rent.Customer.Name;
                newRow["Fecha de renta"] = rent.RentalDate;
                newRow["Fecha de devolución"] = rent.ReturnDate;
                newRow["Monto x día"] = rent.AmountPerDay;
                newRow["Cantidad de días"] = rent.Days;
                newRow["Comentarios"] = rent.Comments;
                newRow["Estado"] = rent.RentStatu.Description;

                newTable.Rows.Add(newRow);
            }

            dgvRents.DataSource = newTable;

            if (dgvRents.Rows.Count > 0)
            {
                dgvRents.Rows[0].Selected = true;
            }

            bnCount.Text = $"{rents.Count} registro(s)";
        }

        private DataTable createDataTableTemplate()
        {
            DataTable table = new DataTable("Rentas");

            DataColumn id = new DataColumn("Número de renta");
            id.DataType = Type.GetType("System.Int32");

            DataColumn employee = new DataColumn("Empleado");
            employee.DataType = Type.GetType("System.String");

            DataColumn car = new DataColumn("Vehículo");
            car.DataType = Type.GetType("System.String");

            DataColumn customer = new DataColumn("Cliente");
            customer.DataType = Type.GetType("System.String");

            DataColumn rentDate = new DataColumn("Fecha de renta");
            rentDate.DataType = Type.GetType("System.String");

            DataColumn returnDate = new DataColumn("Fecha de devolución");
            returnDate.DataType = Type.GetType("System.String");

            DataColumn amountPerDay = new DataColumn("Monto x día");
            amountPerDay.DataType = Type.GetType("System.String");

            DataColumn days = new DataColumn("Cantidad de días");
            days.DataType = Type.GetType("System.String");

            DataColumn comments = new DataColumn("Comentarios");
            comments.DataType = Type.GetType("System.String");

            DataColumn status = new DataColumn("Estado");
            status.DataType = Type.GetType("System.String");

            table.Columns.Add(id);
            table.Columns.Add(employee);
            table.Columns.Add(car);
            table.Columns.Add(customer);
            table.Columns.Add(rentDate);
            table.Columns.Add(returnDate);
            table.Columns.Add(amountPerDay);
            table.Columns.Add(days);
            table.Columns.Add(comments);
            table.Columns.Add(status);

            return table;
        }

        private void bnMoveNext_Click(object sender, EventArgs e)
        {
            int currentRow = -1;

            if (dgvRents.SelectedRows.Count > 0)
            {
                currentRow = dgvRents.SelectedRows[0].Index;
            }

            if (currentRow + 1 < dgvRents.RowCount)
            {
                dgvRents.Rows[++currentRow].Selected = true;
            }
        }

        private void bnMoveLast_Click(object sender, EventArgs e) => dgvRents.Rows[rents.Count - 1].Selected = true;

        private void bnMovePrevious_Click(object sender, EventArgs e)
        {
            int currentRow = dgvRents.SelectedRows[0].Index;

            if (currentRow > 0)
            {
                dgvRents.Rows[--currentRow].Selected = true;
            }
        }

        private void bnMoveFirst_Click(object sender, EventArgs e) => dgvRents.Rows[0].Selected = true;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddRent frmAddRent = new frmAddRent();
            frmAddRent.Show();
            Hide();
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de eliminar esta renta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int currentRow = dgvRents.SelectedRows[0].Index;
                int id = (int)dgvRents.Rows[currentRow].Cells[0].Value;

                Rent rent = rentACarEntities.Rents.Where(r => r.Id == id).FirstOrDefault();
                rentACarEntities.Entry(rent).State = EntityState.Modified;
                rent.Status = false;
                rentACarEntities.SaveChanges();
                MessageBox.Show("La renta fue eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            frmEditRent frmEditRent = new frmEditRent();
            int currentRow = dgvRents.SelectedRows[0].Index;
            int id = (int)dgvRents.Rows[currentRow].Cells[0].Value;
            Rent rent = rentACarEntities.Rents.Where(r => r.Id == id).FirstOrDefault();

            frmEditRent.Rent = rent;
            frmEditRent.Show();
            rentACarEntities.Dispose();
            Hide();
        }

        private void txtReturn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de hacer devolución de esta renta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int currentRow = dgvRents.SelectedRows[0].Index;
                int id = (int)dgvRents.Rows[currentRow].Cells[0].Value;

                Rent rent = rentACarEntities.Rents.Where(r => r.Id == id).FirstOrDefault();
                rent.RentStatusId = rentACarEntities.RentStatus.Where(rs => rs.Description == "Devuelto").FirstOrDefault().Id;
                rentACarEntities.Entry(rent).State = EntityState.Modified;

                Car car = rentACarEntities.Cars.Where(m => m.Id == rent.CarId).FirstOrDefault();
                car.Status = true                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;
                rentACarEntities.Entry(car).State = EntityState.Modified;
                rentACarEntities.SaveChanges();
                MessageBox.Show("La devolución fue guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
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
            Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            rents = rentACarEntities.Rents.Where(c => c.Status && c.Car.Description.Contains(txtSearch.Text)).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (Rent rent in rents)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Número de renta"] = rent.Id;
                newRow["Empleado"] = rent.Employee.Name;
                newRow["Vehículo"] = rent.Car.Description;
                newRow["Cliente"] = rent.Customer.Name;
                newRow["Fecha de renta"] = rent.RentalDate;
                newRow["Fecha de devolución"] = rent.ReturnDate;
                newRow["Monto x día"] = rent.AmountPerDay;
                newRow["Cantidad de días"] = rent.Days;
                newRow["Comentarios"] = rent.Comments;
                newRow["Estado"] = rent.RentStatu.Description;

                newTable.Rows.Add(newRow);
            }

            dgvRents.DataSource = newTable;

            if (dgvRents.Rows.Count > 0)
            {
                dgvRents.Rows[0].Selected = true;
            }

            bnCount.Text = $"{rents.Count} registro(s)";
        }
    }
}
