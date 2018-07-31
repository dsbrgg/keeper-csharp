using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISLApp
{
    public partial class AddCompany : Form
    {
        public AddCompany()
        {
            InitializeComponent();
        }

        private void addCompanyFormButton_Click(object sender, EventArgs e)
        {
            string companyName = addCompanyFormTextBox.Text;

            if(String.IsNullOrEmpty(companyName)) {
                MessageBox.Show("Please, insert a valid value for the new company name!");
            } else {
                RequestCompany request = new RequestCompany(User.Id, companyName);
                bool companyAdded = Connect.AddCompany(request);

                if(companyAdded) {
                    this.Close();
                } else {
                    MessageBox.Show("There was an error while adding the new company. Check the console for errors.");
                    this.Close();
                }
            }
        }
    }
}
