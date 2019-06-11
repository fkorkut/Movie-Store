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

namespace MovieStore.WinUI.Customers
{
    public partial class EditMovieForm : Form
    {
        public EditMovieForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (CustomerService customerService = new CustomerService())
            {
                DialogResult dr = MessageBox.Show("Güncellmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    CustomerDTO customer = new CustomerDTO
                    {
                        
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        TcNumber = txtTC.Text,
                        MobilePhone = txtMobilePhone.Text,

                        RecordStatusId = Convert.ToByte(cbRecordStatus.SelectedValue),
                        CreatedDate = DateTime.Now,
                        CreatedBy = 2
                    };
                    var result = customerService.Update(customer);

                    if (result != null)
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

        private void lbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCustomer = lbCustomer.SelectedItem as CustomerDTO;

            using (CustomerService customerService = new CustomerService())
            {
                var customer = customerService.Get(selectedCustomer.CustomerId);

                txtFirstName.Text = customer.FirstName;
                txtLastName.Text = customer.LastName;
                txtTC.Text = customer.TcNumber;
                txtMobilePhone.Text = customer.MobilePhone;
                cbRecordStatus.SelectedValue = customer.RecordStatusId;
            }
        }

        private void EditMovieForm_Load(object sender, EventArgs e)
        {
            using (DefinitionService definitionService = new DefinitionService())
            {
                cbRecordStatus.DataSource = definitionService.GetRecordStatus();
                cbRecordStatus.DisplayMember = "RecordStatusName";
                cbRecordStatus.ValueMember = "RecordStatusId";
            }

            using (CustomerService customerService = new CustomerService())
            {
                var customers = customerService.List();
                lbCustomer.DataSource = customers;
                lbCustomer.DisplayMember = "DisplayString";
                lbCustomer.ValueMember = "CustomerId";
            }
        }
    }
}
