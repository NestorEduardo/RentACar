using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frmReports : Form
    {
        private readonly RentACarEntities rentACarEntities;
        private ICollection<CarType> carTypes { get; set; }
        public frmReports()
        {
            rentACarEntities = new RentACarEntities();
            InitializeComponent();
            carTypes = rentACarEntities.CarTypes.Where(ct => ct.Status).ToList();
            BindCarTypes();
        }

        private void BindCarTypes()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = carTypes.OrderBy(m => m.Description).ToList();
            cbCarType.DataSource = bindingSource.DataSource;
            cbCarType.ValueMember = "Id";
            cbCarType.DisplayMember = "Description";
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            this.RentsTableAdapter.Fill(RentACarDataSet.Rents, (int)cbCarType.SelectedValue, dtpFrom.Value.ToString(), dtpUntil.Value.ToString());
            this.reportViewer1.RefreshReport();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.RentsTableAdapter.Fill(RentACarDataSet.Rents, (int)cbCarType.SelectedValue, dtpFrom.Value.ToString(), dtpUntil.Value.ToString());
            this.reportViewer1.RefreshReport();
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

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpUntil.MinDate = dtpFrom.Value;
        }

        private void dtpUntil_ValueChanged(object sender, EventArgs e)
        {
            dtpFrom.MinDate = dtpUntil.Value;
        }
    }
}
