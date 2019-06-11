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
    public partial class NewRentalForm : Form
    {
        public NewRentalForm()
        {
            InitializeComponent();
        }

        private void NewRentalForm_Load(object sender, EventArgs e)
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (RentalService rentalService = new RentalService())
            {

                DialogResult dr = MessageBox.Show("Kaydetmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    RentalDTO rental = new RentalDTO
                    {
                        CustomerId = (int)(cmbCustomer.SelectedValue),
                        MovieId = (int)(cmbMovieName.SelectedValue),
                        BeginDate = dtpBegin.Value,
                        EndDate = dtpEnd.Value,
                        TotalPrice =Convert.ToDecimal(txtPrice.Text),
               
                        CreatedBy = 2,
                   

                    };

                    var result = rentalService.Add(rental);

                    if (result != null)
                    {
                        MessageBox.Show("Kayıt başarılı", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Kayıt sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
    }
}
