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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string passwd = passwdBox.Text;

            RequestLogin user = new RequestLogin(username, passwd);

            bool VerfiedUser = Connect.AuthUser(user);
            
            if(VerfiedUser) {
                this.Hide();
                Main form = new Main();
                form.Show();
            } else {
                MessageBox.Show("No user found with the provided credentials.");
            }
        }

        
    }
}
