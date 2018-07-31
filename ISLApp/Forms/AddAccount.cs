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
    public partial class AddAccount : Form
    {
        public int SelectedCompany;

        public AddAccount(int selectedCompany)
        {
            SelectedCompany = selectedCompany;
            InitializeComponent();
        }

        private void addAccountFormButton_Click(object sender, EventArgs e)
        {
            string username = userTextBox.Text;
            string password = passTextBox.Text;

            if(String.IsNullOrEmpty(username)) {
                MessageBox.Show("Please, insert a valid username.");
                return;
            } else if(String.IsNullOrEmpty(password)) {
                MessageBox.Show("Please, insert a valid password.");
                return;
            }

            RequestAccounts account = new RequestAccounts(SelectedCompany, username, password);

            bool addOk = false;

            try {
                addOk = Connect.AddAccount(account);
            } catch(Exception err) {
                MessageBox.Show("An error occured when adding the account : {0}", err.ToString());
            }
            
            if(addOk) {
                this.Close();
            } else {
                MessageBox.Show("An error occured when adding the account! Please, try again later.");
            }
        }
    }
}
