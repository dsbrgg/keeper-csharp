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
    public partial class Main : Form
    {
        private List<RequestCompany> Companies;
        public int CompanySelected;

        public Main()
        {
            InitializeComponent();
            LoadCompanyAndBind();
        }

        private void LoadCompanyAndBind()
        {
            RequestCompany req = new RequestCompany(User.Id);
            Companies = Connect.ListCompany(req);

            companyComboBox.ValueMember = "Id";
            companyComboBox.DisplayMember = "Name";
            companyComboBox.DataSource = Companies;
        }

        private void BindDataGrid()
        {
            RequestAccounts companyAccounts = new RequestAccounts(CompanySelected);
            List<RequestAccounts> Accounts = Connect.ListAccounts(companyAccounts);

            accountsGrid.DataSource = Accounts;

            accountsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            accountsGrid.Columns["Id"].Visible = false;
            accountsGrid.Columns["CompanyId"].Visible = false;
        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int selectedIndex = companyComboBox.SelectedIndex;
            // RequestCompany selectedRequestCompany = (RequestCompany)companyComboBox.SelectedItem;

            CompanySelected = (int)companyComboBox.SelectedValue;
            BindDataGrid();
        }

        private void addAccountButton_Click(object sender, EventArgs e)
        {
            AddAccount addAccountForm = new AddAccount(CompanySelected);
            addAccountForm.ShowDialog();
            BindDataGrid();
        }

        private void deleteAccountButton_Click(object sender, EventArgs e)
        {
            int AccountDeleteId;
            if(accountsGrid.SelectedRows.Count > 0) {
                using(var form = new Confirm()) {
                   var confirmDelete = form.ShowDialog();
                   string delete = confirmDelete.ToString();

                   if(delete == "OK") {
                        for(int i = 0; i < accountsGrid.SelectedRows.Count; i++) {
                            DataGridViewRow row = accountsGrid.SelectedRows[i];
                            AccountDeleteId = Convert.ToInt32(row.Cells["Id"].Value);

                            RequestAccounts request = new RequestAccounts(CompanySelected, AccountDeleteId);
                            Connect.DeleteAccount(request);
                            BindDataGrid();

                            break;
                        }
                   }
                }
            } else {
                MessageBox.Show("No row selected. Please, make sure there are rows to be selected.");
            }
        }

        private void addCompanyButton_Click(object sender, EventArgs e)
        {
            AddCompany form = new AddCompany();
            form.ShowDialog();
            LoadCompanyAndBind();
        }

        private void deleteCompanyButton_Click(object sender, EventArgs e)
        {
            using(var form = new Confirm()) {
                var confirmDelete = form.ShowDialog();
                string delete = confirmDelete.ToString();

                if(delete == "OK") {
                    RequestCompany request = new RequestCompany(CompanySelected, User.Id);

                    Connect.DeleteCompanyAccounts(request);
                    Connect.DeleteCompany(request);

                    LoadCompanyAndBind();
                }
            }
        }
    }
}
