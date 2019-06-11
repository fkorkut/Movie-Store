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

namespace MovieStore.WinUI.Users
{
    public partial class EditUserForm : Form
    {
        public EditUserForm()
        {
            InitializeComponent();
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            using (DefinitionService definitionService = new DefinitionService())
            {
                cbRecordStatus.DataSource = definitionService.GetRecordStatus();
                cbRecordStatus.DisplayMember = "RecordStatusName";
                cbRecordStatus.ValueMember = "RecordStatusId";
            }

            using (UserService userService = new UserService())
            {
                var users = userService.List();
                lbUsers.DataSource = users;
                lbUsers.DisplayMember = "DisplayString";
                lbUsers.ValueMember = "UserId";
            }
        }

        private void lbUsers_DoubleClick(object sender, EventArgs e)
        {
            var selectedUser = lbUsers.SelectedItem as UserDTO;

            using (UserService userService = new UserService())
            {
                var user = userService.Get(selectedUser.UserId);

                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtUserName.Text = user.UserName;
                txtPassword.Text = user.Password;
                cbRecordStatus.SelectedValue = user.RecordStatusId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (UserService userService = new UserService())
            {
                DialogResult dr = MessageBox.Show("Güncellmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    UserDTO user = new UserDTO
                    {
                        UserId = Convert.ToInt32(lbUsers.SelectedValue),
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        UserName = txtUserName.Text,
                        Password = txtPassword.Text,

                        RecordStatusId =Convert.ToByte( cbRecordStatus.SelectedValue),
                        CreatedDate = DateTime.Now,
                        CreatedBy = 2
                    };
                    var result = userService.Update(user);

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
