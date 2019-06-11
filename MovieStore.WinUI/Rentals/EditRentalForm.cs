using MovieStore.DTO;
using MovieStore.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieStore.WinUI.Rentals
{
    public partial class EditRentalForm : Form
    {
        public EditRentalForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void EditRentalForm_Load(object sender, EventArgs e)
        {
            using (CustomerService customerService = new CustomerService())
            {
                cmbCustomer.DataSource = customerService.List();
                cmbCustomer.DisplayMember = "FullName";
                cmbCustomer.ValueMember = "CustomerId";
            }

            using (MovieService movieService = new MovieService())
            {
                cmbMovieName.DataSource = movieService.List();
                cmbMovieName.DisplayMember = "MovieName";
                cmbMovieName.ValueMember = "MovieId";
            }

            using (RentalService movieService = new RentalService())
            {
                lstBoxRental.DataSource = movieService.List();
                lstBoxRental.DisplayMember = "Display";
                lstBoxRental.ValueMember = "RentalId";
            }

            using (DefinitionService definitionService = new DefinitionService())
            {
                cbRecordStatus.DataSource = definitionService.GetRecordStatus();
                cbRecordStatus.DisplayMember = "RecordStatusName";
                cbRecordStatus.ValueMember = "RecordStatusId";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (RentalService rentalService = new RentalService())
            {
                DialogResult dr = MessageBox.Show("Güncellemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    RentalDTO rental = new RentalDTO
                    {
                        RentalId = (int)lstBoxRental.SelectedValue,
                        CustomerId = (int)cmbCustomer.SelectedValue,
                        MovieId = (int)cmbMovieName.SelectedValue,
                        BeginDate = dtpBegin.Value,
                        EndDate = dtpBegin.Value,
                        TotalPrice = Convert.ToDecimal(txtPrice.Text),

                        CreatedBy = 2,
                        RecordStatusId = Convert.ToByte(cbRecordStatus.SelectedValue)

                    };
                    var result = rentalService.Update(rental);
                    lstBoxRental.DataSource = rentalService.List();
                    if (result)
                    {
                        MessageBox.Show("Güncelleme başarılı", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Güncelleme sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void lstBoxRental_DoubleClick(object sender, EventArgs e)
        {
            var selected = lstBoxRental.SelectedItem as RentalDTO;

            using (RentalService rentalService = new RentalService())
            {
                var rental = rentalService.Get(selected.RentalId);

                cmbCustomer.SelectedValue = rental.CustomerId;
                cmbMovieName.SelectedValue = rental.MovieId;
                dtpBegin.Value = rental.BeginDate;
                dtpEnd.Value = rental.EndDate;
                txtPrice.Text = rental.TotalPrice.ToString();
                cbRecordStatus.SelectedValue = rental.RecordStatusId;


            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbMovieName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cbRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
