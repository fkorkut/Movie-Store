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
    public partial class NewCustomerForm : Form
    {
        public NewCustomerForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (CustomerService customerService = new CustomerService())
            {
                DialogResult dr = MessageBox.Show("Kaydetmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    CustomerDTO customer = new CustomerDTO
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        TcNumber=txtTC.Text,
                        MobilePhone=txtMobilePhone.Text,
                        CreatedBy = 2
                    };

                    var result = customerService.Add(customer);

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
