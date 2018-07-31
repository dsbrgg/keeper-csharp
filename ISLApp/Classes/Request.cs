using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLApp
{
    public class RequestLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public RequestLogin(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }

    public class RequestCompany
    {
        public int Id { get; private set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        // OBJECT TO LIST COMPANIES
        public RequestCompany(int user_id)
        {
            this.UserId = user_id;
        }

        // OBJECTS THAT HAVE BEEN BROUGHT FROM DB
        public RequestCompany(int id, int user_id, string name)
        {
            this.Id = id;
            this.UserId = user_id;
            this.Name = name;
        }

        // OBJECTS TO BE ADDED TO THE DB
        public RequestCompany(int user_id, string name)
        {
            this.UserId = user_id;
            this.Name = name;
        }

        // OBJECT TO DELETE REGISTER FROM DB
        public RequestCompany(int id, int user_id)
        {
            this.Id = id;
            this.UserId = user_id;
        }
    }

    public class RequestAccounts
    {
        public int Id { get; private set; }
        public int CompanyId { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // OBJECT TO DELETE ACCOUNT
        public RequestAccounts(int company_id, int id)
        {
            this.Id = id;
        }

        // CONSTRUCTOR TO RETRIEVE ACCOUNTS FROM X COMPANY
        public RequestAccounts(int company_id)
        {
            this.CompanyId = company_id;
        }

        // CONSTRUCTOR TO ADD ACCOUNT
        public RequestAccounts(int company_id, string username, string password)
        {
            this.CompanyId = company_id;
            this.Username = username;
            this.Password = password;
        }

        // CONSTRUCTOR TO STORE ACCOUNT LOCALLY
        public RequestAccounts(int id, int company_id, string username, string password)
        {
            this.Id = id;
            this.CompanyId = company_id;
            this.Username = username;
            this.Password = password;
        }
    }
}
