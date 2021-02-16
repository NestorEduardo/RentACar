using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmInspection : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<Inspection> inspections;
        public frmInspection()
        {
            rentACarEntities = new RentACarEntities();
            inspections = rentACarEntities.Inspections.Where(ct => ct.Status).ToList();
            InitializeComponent();
        }

        private void frmInspection_Load(object sender, EventArgs e) => BindGridView();

        private void BindGridView()
        {
            inspections = rentACarEntities.Inspections.Where(ct => ct.Status).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (Inspection inspection in inspections)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = inspection.Id;
                newRow["Vehículo"] = inspection.Car.Description;
                newRow["Cliente"] = inspection.Customer.Name;

                if (inspection.Scratches)
                {
                    newRow["¿Tiene rayaduras?"] = "Si";
                }
                else
                {
                    newRow["¿Tiene rayaduras?"] = "No";
                }

                newRow["Cantidad de combustible"] = inspection.FuelQuantity.Description;


                if (inspection.ResponseRubber)
                {
                    newRow["¿Tiene goma de respuesta?"] = "Si";
                }
                else
                {
                    newRow["¿Tiene goma de respuesta?"] = "No";
                }

                if (inspection.Cat)
                {
                    newRow["¿Tiene gato?"] = "Si";
                }
                else
                {
                    newRow["¿Tiene gato?"] = "No";
                }

                if (inspection.GlassBreak)
                {
                    newRow["¿Tiene roturas de cristal?"] = "Si";
                }
                else
                {
                    newRow["¿Tiene roturas de cristal?"] = "No";
                }

                newRow["Estado de goma 1"] = inspection.RubberStatu.Description;
                newRow["Estado de goma 2"] = inspection.RubberStatu1.Description;
                newRow["Estado de goma 3"] = inspection.RubberStatu2.Description;
                newRow["Estado de goma 4"] = inspection.RubberStatu3.Description;
                newRow["Fecha"] = inspection.Date;
                newRow["Empleado"] = inspection.Employee.Name;

                newTable.Rows.Add(newRow);
            }

            dgvInspection.DataSource = newTable;

            if (dgvInspection.Rows.Count > 0)
            {
                dgvInspection.Rows[0].Selected = true;
            }

            bnCount.Text = $"{inspections.Count} registro(s)";
        }

        private DataTable createDataTableTemplate()
        {
            DataTable table = new DataTable("Inspecciones");

            DataColumn id = new DataColumn("Identificador");
            id.DataType = Type.GetType("System.Int32");

            DataColumn car = new DataColumn("Vehículo");
            car.DataType = Type.GetType("System.String");

            DataColumn customer = new DataColumn("Cliente");
            customer.DataType = Type.GetType("System.String");

            DataColumn scratches = new DataColumn("¿Tiene rayaduras?");
            scratches.DataType = Type.GetType("System.String");

            DataColumn fuelQuantity = new DataColumn("Cantidad de combustible");
            fuelQuantity.DataType = Type.GetType("System.String");

            DataColumn responseRubber = new DataColumn("¿Tiene goma de respuesta?");
            responseRubber.DataType = Type.GetType("System.String");

            DataColumn cat = new DataColumn("¿Tiene gato?");
            cat.DataType = Type.GetType("System.String");

            DataColumn glassBreak = new DataColumn("¿Tiene roturas de cristal?");
            glassBreak.DataType = Type.GetType("System.String");

            DataColumn rubberStatus1 = new DataColumn("Estado de goma 1");
            rubberStatus1.DataType = Type.GetType("System.String");

            DataColumn rubberStatus2 = new DataColumn("Estado de goma 2");
            rubberStatus2.DataType = Type.GetType("System.String");

            DataColumn rubberStatus3 = new DataColumn("Estado de goma 3");
            rubberStatus3.DataType = Type.GetType("System.String");

            DataColumn rubberStatus4 = new DataColumn("Estado de goma 4");
            rubberStatus4.DataType = Type.GetType("System.String");

            DataColumn date = new DataColumn("Fecha");
            date.DataType = Type.GetType("System.String");

            DataColumn employee = new DataColumn("Empleado");
            employee.DataType = Type.GetType("System.String");

            table.Columns.Add(id);
            table.Columns.Add(car);
            table.Columns.Add(customer);
            table.Columns.Add(scratches);
            table.Columns.Add(fuelQuantity);
            table.Columns.Add(responseRubber);
            table.Columns.Add(cat);
            table.Columns.Add(glassBreak);
            table.Columns.Add(rubberStatus1);
            table.Columns.Add(rubberStatus2);
            table.Columns.Add(rubberStatus3);
            table.Columns.Add(rubberStatus4);
            table.Columns.Add(date);
            table.Columns.Add(employee);

            return table;
        }

        private void bnMoveNext_Click(object sender, EventArgs e)
        {
            int currentRow = -1;

            if (dgvInspection.SelectedRows.Count > 0)
            {
                currentRow = dgvInspection.SelectedRows[0].Index;
            }

            if (currentRow + 1 < dgvInspection.RowCount)
            {
                dgvInspection.Rows[++currentRow].Selected = true;
            }
        }

        private void bnMoveLast_Click(object sender, EventArgs e) => dgvInspection.Rows[inspections.Count - 1].Selected = true;

        private void bnMovePrevious_Click(object sender, EventArgs e)
        {
            int currentRow = dgvInspection.SelectedRows[0].Index;

            if (currentRow > 0)
            {
                dgvInspection.Rows[--currentRow].Selected = true;
            }
        }

        private void bnMoveFirst_Click(object sender, EventArgs e) => dgvInspection.Rows[0].Selected = true;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddInspection frmAddInspection = new frmAddInspection();
            frmAddInspection.Show();
            Hide();
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de eliminar esta inspección?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                int currentRow = dgvInspection.SelectedRows[0].Index;
                int id = (int)dgvInspection.Rows[currentRow].Cells[0].Value;

                Inspection inspection = rentACarEntities.Inspections.Where(i => i.Id == id).FirstOrDefault();
                rentACarEntities.Entry(inspection).State = System.Data.Entity.EntityState.Modified;
                inspection.Status = false;
                rentACarEntities.SaveChanges();
                MessageBox.Show("La inspección fue eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            frmEditInspection frmEditInspection = new frmEditInspection();
            int currentRow = dgvInspection.SelectedRows[0].Index;
            int id = (int)dgvInspection.Rows[currentRow].Cells[0].Value;
            Inspection inspection = rentACarEntities.Inspections.Where(i => i.Id == id).FirstOrDefault();

            frmEditInspection.Inspection = inspection;
            frmEditInspection.Show();
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
            frmCars frmCars = new frmCars();
            frmCars.Show();
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
            inspections = rentACarEntities.Inspections.Where(ct => ct.Status && ct.Car.Description.Contains(txtSearch.Text)).ToList();
            DataTable newTable = createDataTableTemplate();

            foreach (Inspection inspection in inspections)
            {
                DataRow newRow = newTable.NewRow();

                newRow["Identificador"] = inspection.Id;
                newRow["Vehículo"] = inspection.Car.Description;
                newRow["Cliente"] = inspection.Customer.Name;

                if (inspection.Scratches)
                {
                    newRow["¿Tiene rayaduras?"] = "Si";
                }
                else
                {
                    newRow["¿Tiene rayaduras?"] = "No";
                }

                newRow["Cantidad de combustible"] = inspection.FuelQuantity.Description;


                if (inspection.ResponseRubber)
                {
                    newRow["¿Tiene goma de respuesta?"] = "Si";
                }
                else
                {
                    newRow["¿Tiene goma de respuesta?"] = "No";
                }

                if (inspection.Cat)
                {
                    newRow["¿Tiene gato?"] = "Si";
                }
                else
                {
                    newRow["¿Tiene gato?"] = "No";
                }

                if (inspection.GlassBreak)
                {
                    newRow["¿Tiene roturas de cristal?"] = "Si";
                }
                else
                {
                    newRow["¿Tiene roturas de cristal?"] = "No";
                }

                newRow["Estado de goma 1"] = inspection.RubberStatu.Description;
                newRow["Estado de goma 2"] = inspection.RubberStatu1.Description;
                newRow["Estado de goma 3"] = inspection.RubberStatu2.Description;
                newRow["Estado de goma 4"] = inspection.RubberStatu3.Description;
                newRow["Fecha"] = inspection.Date;
                newRow["Empleado"] = inspection.Employee.Name;

                newTable.Rows.Add(newRow);
            }

            dgvInspection.DataSource = newTable;

            if (dgvInspection.Rows.Count > 0)
            {
                dgvInspection.Rows[0].Selected = true;
            }

            bnCount.Text = $"{inspections.Count} registro(s)";
        }
    }
}
